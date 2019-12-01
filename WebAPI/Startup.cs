using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			string domain = $"https://{ Configuration["Auth0:Domain"] }/";
			string audience = Configuration["Auth0:ApiIdentifier"];

			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(options =>
			{
				options.Authority = domain;
				options.Audience = audience;
			});

			services.Configure<PoolDatabaseSettings>(
				Configuration.GetSection(nameof(PoolDatabaseSettings))
			);
			services.AddSingleton<IPoolDatabaseSettings>(
				sp => sp.GetRequiredService<IOptions<PoolDatabaseSettings>>().Value
			);

			services.Configure<NflDataSettings>(
				Configuration.GetSection(nameof(NflDataSettings))
			);
			services.AddSingleton<INflDataSettings>(
				sp => sp.GetRequiredService<IOptions<NflDataSettings>>().Value
			);

			services.AddSingleton<TeamService>();

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseAuthentication();
			app.UseMvc();
		}
	}
}
