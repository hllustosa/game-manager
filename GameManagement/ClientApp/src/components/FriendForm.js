import React, { useState } from "react";
import { withStyles } from "@material-ui/core/styles";
import Modal from "@material-ui/core/Modal";
import Paper from "@material-ui/core/Paper";
import Grid from "@material-ui/core/Grid";
import Button from "@material-ui/core/Button";
import Divider from "@material-ui/core/Divider";
import Title from "../components/Title";
import { TextField, MenuItem } from "@material-ui/core";
import { SaveFriend, UpdateFriend } from "../data/Friend";
import { handleErrorResponse, Code2Media } from "../data/Utils";

const styles = () => ({
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

function FriendForm(props) {
  const { classes } = props;
  const newFriend = props.friend ? false : true;
  const [friend, setFriend] = useState(newFriend ? { name: "" } : props.friend);

  const handleClose = () => {
    if (props.handleClose) props.handleClose();
  };

  const onNameChange = (e) => {
    const newFriend = Object.assign({}, friend, {});
    newFriend.name = e.target.value;
    setFriend(newFriend);
  };

  const save = () => {
    if (newFriend) {
      SaveFriend(friend)
        .then(() => {
          handleClose();
        })
        .catch((e) => {
          handleErrorResponse(e);
        });
    } else {
      UpdateFriend(friend)
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
            <Title>Cadastro de Amigo</Title>
          </Grid>
          <Divider style={{ marginBottom: "20px" }} />
          <Grid item>
            <TextField
              fullWidth
              id="name"
              label="Nome"
              variant="outlined"
              value={friend.name}
              onChange={onNameChange}
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

export default withStyles(styles)(FriendForm);
