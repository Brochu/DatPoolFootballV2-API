using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Utils
{
	public static class ErrorUtils
	{
		public static ValidationProblemDetails CreateErrorDetails(int code, string title, string message, string type = "")
		{
			ValidationProblemDetails details = new ValidationProblemDetails();
			details.Status = code;
			details.Type = type;
			details.Title = title;
			details.Detail = message;

			return details;
		}
	}
}
