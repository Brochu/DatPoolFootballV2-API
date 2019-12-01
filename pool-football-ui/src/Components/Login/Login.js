import React, {Component} from 'react';

import Avatar from '@material-ui/core/Avatar';
import Typography from '@material-ui/core/Typography';
import Container from '@material-ui/core/Container';
import Textfield from '@material-ui/core/TextField';
import Button from '@material-ui/core/Button';
import Paper from '@material-ui/core/Paper';
import LockOutlinedIcon from '@material-ui/icons/LockOutlined';

//Import custom styles
import './Login.css';

class Login extends Component{

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
                        <form className="login-form" noValidate>
                            <Textfield label="Email" variant="outlined" fullWidth margin="normal" required/>
                            <Textfield label="Password" variant="outlined" fullWidth margin="normal" required/>

                            <Button type="submit" color="primary" fullWidth variant="contained">Login</Button>
                        </form>
                    </Paper>
                </Container>
            </main>
        );
    }
}
export default Login;