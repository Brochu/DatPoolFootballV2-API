import React from 'react';
import './App.css';
import Login from './Components/Login/Login';

// React router
import {BrowserRouter as Router, Switch, Route} from 'react-router-dom';

function App() {
  return (

    <div className="App">
    <Router>
        <Switch>
            <Route path="/dashboard">
                <h1>Dashboard</h1>
            </Route>
            <Route path="/">
                <Login />
            </Route>
        </Switch>
    </Router>
    </div>
  );
}

export default App;
