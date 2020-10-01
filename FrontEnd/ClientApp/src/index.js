import React from "react";
import ReactDOM from "react-dom";
import Axios from "axios";
import { BrowserRouter, Switch, Route, Redirect } from "react-router-dom";
import { Provider, connect } from "react-redux";
import store from "./redux/store";
import Paths from "./paths.json";
import Login from "./pages/login";
import GameLoans from "./pages/game-loans";
import UserGameLoans from "./pages/user-game-loans";
import Games from "./pages/games";
import UserGames from "./pages/user-games";
import Friends from "./pages/friends";

const baseUrl = document.getElementsByTagName("base")[0].getAttribute("href");
const rootElement = document.getElementById("root");
Axios.defaults.baseURL = "http://localhost:5000";

function App(props) {
  return (
    <BrowserRouter basename={baseUrl}>
      {props.user === null ? (
        <Switch>
          <Route component={Login} />
        </Switch>
      ) : props.user.roles[0] === "admin" ? (
        <Switch>
          <Route path={Paths.games} exact component={Games} />
          <Route path={Paths.friends} exact component={Friends} />
          <Route component={GameLoans} />
        </Switch>
      ) : (
        <Switch>
          <Route path={Paths.games} exact component={UserGames} />
          <Route component={UserGameLoans} />
        </Switch>
      )}
    </BrowserRouter>
  );
}

const stateToProps = (state) => {
  return { user: state["user"] };
};

const ConnectedApp = connect(stateToProps)(App);

ReactDOM.render(
  <Provider store={store}>
    <ConnectedApp />
  </Provider>,
  rootElement
);
