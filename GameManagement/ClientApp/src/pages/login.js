import React, { useState } from "react";
import Paper from "@material-ui/core/Paper";
import Grid from "@material-ui/core/Grid";
import Typography from "@material-ui/core/Typography";
import TextField from "@material-ui/core/TextField";
import Button from "@material-ui/core/Button";
import { withStyles } from "@material-ui/core/styles";
import { Login } from "../data/User";
import store from "../redux/store";
import { getLogin } from "../redux/actions";
import paths from "../paths.json";

const styles = (theme) => ({
  root: {
    width: "340px",
    padding: "25px",
    maxWidth: "95%",
    margin: "auto",
    position: "absolute",
    top: "50%",
    left: "50%",
    transform: "translate(-50%, -50%)",
  },
});

function LoginPage(props) {
  const { classes } = props;
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState("");

  function handleLogin(username, password) {
    setError("");
    Login(username, password)
      .then((response) => {
        const action = getLogin(response.data);
        store.dispatch(action);
        props.history.push(paths.gameLoans);
      })
      .catch((e) => {
        setError(e.response.data.errors[0].ErrorMsg)
      });
  }

  return (
    <Paper className={classes.root} elevation={3}>
      <Grid container direction="column" justify="center" spacing={2}>
        <Grid item>
          <Typography align="center">
            {"Games Loan Manager Login"}
          </Typography>
        </Grid>
        <Grid item>
          <TextField
            fullWidth
            id="user-name"
            label="Usuário"
            variant="outlined"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
            error = {error ? true : false}
            helperText = {error}
          />
        </Grid>
        <Grid item>
          <TextField
            fullWidth
            id="user-password"
            label="Senha"
            type="password"
            variant="outlined"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            error = {error ? true : false}
          />
        </Grid>
        <Grid item>
          <Button
            fullWidth
            id="btn-login"
            color="primary"
            variant="contained"
            onClick={() => {
              handleLogin(username, password);
            }}
          >
            Entrar
          </Button>
        </Grid>
      </Grid>
    </Paper>
  );
}

export default withStyles(styles)(LoginPage);
