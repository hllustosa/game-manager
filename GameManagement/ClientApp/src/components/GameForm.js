import React, { useState } from "react";
import { withStyles } from "@material-ui/core/styles";
import Modal from "@material-ui/core/Modal";
import Paper from "@material-ui/core/Paper";
import Grid from "@material-ui/core/Grid";
import Button from "@material-ui/core/Button";
import Switch from "@material-ui/core/Switch";
import Divider from "@material-ui/core/Divider";
import Title from "../components/Title";
import FriendAutoComplete from "../components/FriendAutoComplete";
import GameAutoComplete from "../components/GameAutoComplete";
import { TextField, MenuItem } from "@material-ui/core";
import { SaveGame, UpdateGame } from "../data/Game";
import { handleErrorResponse, Code2Media } from "../data/Utils";

const styles = (theme) => ({
  root: {
    position: "absolute",
    width: "450px",
    height: "330px",
    padding: "20px",
    outline: "none",
    top: "calc(50vh - (330px / 2))",
    left: "calc(50vw - (450px / 2))",
  },
});

function GameForm(props) {
  const { classes } = props;
  const newGame = props.game ? false : true;
  const [game, setGame] = useState(
    newGame
      ? { name: "", mediaType: 0, plataformName: "", isLent: false }
      : props.game
  );

  const handleClose = () => {
    if (props.handleClose) props.handleClose();
  };

  const onNameChange = (e) => {
    const newGame = Object.assign({}, game, {});
    newGame.name = e.target.value;
    setGame(newGame);
  };

  const onMediaChange = (e) => {
    const newGame = Object.assign({}, game, {});
    newGame.mediaType = e.target.value;
    setGame(newGame);
  };

  const onPlatformChange = (e) => {
      const newGame = Object.assign({}, game, {});
    newGame.plataformName = e.target.value;
    setGame(newGame);
  };

  const save = () => {
    if (newGame) {
      SaveGame(game)
        .then(() => {
          handleClose();
        })
        .catch((e) => {
          handleErrorResponse(e);
        });
    } else {
      UpdateGame(game)
        .then(() => {
          handleClose();
        })
        .catch((e) => {
          handleErrorResponse(e);
        });
    }
  };

  return (
    <Modal
      open={props.open}
      onClose={handleClose}
      aria-labelledby="simple-modal-title"
      aria-describedby="simple-modal-description"
    >
      <Paper className={classes.root}>
        <Grid container direction="column" spacing={2}>
          <Grid item>
            <Title>Cadastro de Games</Title>
          </Grid>
          <Divider style={{ marginBottom: "20px" }} />
          <Grid item>
            <TextField
              fullWidth
              id="name"
              label="Nome"
              variant="outlined"
              value={game.name}
              onChange={onNameChange}
            />
          </Grid>
          <Grid item>
            <TextField
              fullWidth
              select
              id="media"
              label="Tipo de Mídia"
              variant="outlined"
              value={game.mediaType}
              onChange={onMediaChange}
            >
              <MenuItem key={0} value={0}>
                {Code2Media(0)}
              </MenuItem>
              <MenuItem key={1} value={1}>
                {Code2Media(1)}
              </MenuItem>
              <MenuItem key={2} value={2}>
                {Code2Media(2)}
              </MenuItem>
              <MenuItem key={3} value={3}>
                {Code2Media(3)}
              </MenuItem>
            </TextField>
          </Grid>
          <Grid item>
            <TextField
              fullWidth
              id="platform"
              label="Plataforma"
              variant="outlined"
              value={game.plataformName}
              onChange={onPlatformChange}
            />
          </Grid>
          <Divider style={{ marginBottom: "20px" }} />
          <Grid container direction="row" justify="flex-end">
            <Button color="primary" variant="contained" onClick={save}>
              Salvar
            </Button>
          </Grid>
        </Grid>
      </Paper>
    </Modal>
  );
}

export default withStyles(styles)(GameForm);
