import React from "react";
import ReactDOM from "react-dom";
import { BrowserRouter, Switch, Route, Redirect } from "react-router-dom";
import { Provider, connect } from "react-redux";
import store from "./redux/store";
import Paths from "./paths.json";
import Login from "./pages/login";
import GameLoans from "./pages/game-loans";
import Games from "./pages/games";
import Friends from "./pages/friends";

const baseUrl = document.getElementsByTagName("base")[0].getAttribute("href");
const rootElement = document.getElementById("root");

function App(props) {
  return (
    <BrowserRouter basename={baseUrl}>
      {props.user === null ? (
        <Switch>
          <Route component={Login} />
        </Switch>
      ) : (
        <Switch>
          <Route path={Paths.games} exact component={Games} />
          <Route path={Paths.friends} exact component={Friends} />
          <Route component={GameLoans} />
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
