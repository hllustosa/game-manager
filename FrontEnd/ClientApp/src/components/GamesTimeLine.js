import React, { useState, useEffect } from "react";
import { withStyles } from "@material-ui/core/styles";
import Modal from "@material-ui/core/Modal";
import Paper from "@material-ui/core/Paper";
import Grid from "@material-ui/core/Grid";
import Divider from "@material-ui/core/Divider";
import Title from "../components/Title";

import Timeline from "@material-ui/lab/Timeline";
import TimelineItem from "@material-ui/lab/TimelineItem";
import TimelineSeparator from "@material-ui/lab/TimelineSeparator";
import TimelineConnector from "@material-ui/lab/TimelineConnector";
import TimelineContent from "@material-ui/lab/TimelineContent";
import TimelineDot from "@material-ui/lab/TimelineDot";

import { CreateEventStream, adjustDate } from "../data/Utils";
import { GetLoansTimeLine } from "../data/GameLoans";

const styles = () => ({
  root: {
    position: "absolute",
    width: "450px",
    maxHeight: "80vh",
    overflowY: "scroll",
    padding: "20px",
    outline: "none",
    top: "50px",
    left: "calc(50vw - (450px / 2))",
  },
});

function GamesTimeLine(props) {
  const { classes } = props;
  const game = props.game;
  const [timeLine, setTimeLine] = useState([]);

  const handleClose = () => {
    if (props.handleClose) props.handleClose();
  };

  useEffect(() => {
    GetLoansTimeLine(null, game.id).then((response) => {
      setTimeLine(CreateEventStream(response.data, false));
    });
  }, []);

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
            <Title>Time Line de {game.name}</Title>
          </Grid>
          <Divider style={{ marginBottom: "20px" }} />
          <Grid item>
            <Timeline align="alternate">
              {timeLine.map((item) => (
                <TimelineItem>
                  <TimelineSeparator>
                    <TimelineDot />
                    <TimelineConnector />
                  </TimelineSeparator>
                  <TimelineContent>{`${item.date.toLocaleDateString()}: ${
                    item.event
                  }`}</TimelineContent>
                </TimelineItem>
              ))}
            </Timeline>
          </Grid>
        </Grid>
      </Paper>
    </Modal>
  );
}

export default withStyles(styles)(GamesTimeLine);
