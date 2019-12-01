import React, {Component} from 'react';

import Avatar from '@material-ui/core/Avatar';
import Typography from '@material-ui/core/Typography';
import Container from '@material-ui/core/Container';
import Textfield from '@material-ui/core/TextField';
import Button from '@material-ui/core/Button';
import Paper from '@material-ui/core/Paper';
import LockOutlinedIcon from '@material-ui/icons/LockOutlined';
import FormHelperText from '@material-ui/core/FormHelperText';

//Import custom styles
import './Login.css';

class Login extends Component{

    constructor(props) {
        super(props);

        this.state = {
            email: "",
            password: "",
            error: "",

        };

        this.handleSubmit = this.handleSubmit.bind(this);
        this.validateForm = this.validateForm.bind(this);
    }

    setEmail(email){
        this.setState({
            email: email
        });
    }

    setPassword(password){
        this.setState({
            password: password
        });
    }

    validateForm(){

        /**
         * @todo Validate valid email address
         */

        return true;
    }

    handleSubmit(e){
        e.preventDefault();

        if(!this.validateForm()){
            this.setState({
                error: <FormHelperText error="true">I am error</FormHelperText>
            })
            return false;
        }

        /**
         * @todo Check if right password for user
         */

        window.location = "/dashboard";

    }

    render() {
        return(
            <main className="login-page">
                <Container id="login-box" className="login-box" maxWidth="xs">
                    <Paper className="login-content">
                        <Avatar className="login-icon">
                            <LockOutlinedIcon />
                        </Avatar>
                        <Typography component="h1" variant="h5">
                        Sign in
                        </Typography>
                        {this.state.error}
                        <form id="login-form" className="login-form" noValidate onSubmit={this.handleSubmit}>
                            <Textfield label="Email" variant="outlined" fullWidth margin="normal" onChange={e => this.setEmail(e.target.value)}/>
                            <Textfield label="Password" variant="outlined" fullWidth margin="normal" onChange={e => this.setPassword(e.target.value)}/>

                            <Button type="submit" color="primary" fullWidth variant="contained">Login</Button>
                        </form>
                    </Paper>
                </Container>
            </main>
        );
    }
}
export default Login;