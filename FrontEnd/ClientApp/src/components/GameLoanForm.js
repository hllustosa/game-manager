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
import { Typography } from "@material-ui/core";
import { SaveLoan, UpdateLoan } from "../data/GameLoans";
import { handleErrorResponse } from "../data/Utils";

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

function GameLoanForm(props) {
  const { classes } = props;
  const newLoan = props.loan ? false : true;
  const [loaned, setLoaned] = useState(newLoan ? true : props.loan.isActive);
  const [game, setGame] = useState(newLoan ? "" : props.loan.game);
  const [friend, setFriend] = useState(newLoan ? "" : props.loan.friend);

  const handleClose = () => {
    if (props.handleClose) props.handleClose();
  };

  const onGameChange = (newGame) => {
    setGame(newGame);
  };

  const onFriendChange = (newFriend) => {
    setFriend(newFriend);
  };

  const save = () => {
    if (newLoan) {
      if (!game || !friend) {
        return;
      }
    }

    const loanData = {
      gameId: game.id,
      friendId: friend.id,
    };

    if (newLoan) {
      loanData["isActive"] = true;
      SaveLoan(loanData)
        .then(() => {
          handleClose();
        })
        .catch((e) => {
          handleErrorResponse(e);
        });
    } else {
      loanData["isActive"] = loaned;
      loanData["id"] = props.loan.id;
      UpdateLoan(loanData)
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
            <Title>Cadastro de Empréstimo</Title>
          </Grid>
          <Divider style={{ marginBottom: "20px" }} />
          <Grid item>
            <GameAutoComplete
              defaultValue={newLoan ? "" : props.loan.game}
              handleOnChange={onGameChange}
            />
          </Grid>
          <Grid item>
            <FriendAutoComplete
              defaultValue={newLoan ? "" : props.loan.friend}
              handleOnChange={onFriendChange}
            />
          </Grid>
          <Grid item>
            <Typography>{loaned ? "Emprestado" : "Devolvido"}</Typography>
            <Switch
              checked={loaned}
              onChange={(e) => setLoaned(e.target.checked)}
              color="primary"
              disabled={newLoan}
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

export default withStyles(styles)(GameLoanForm);
