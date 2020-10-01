import React, { useState, useEffect } from "react";
import withBasePage from "./base-page";
import CompleteTable, {
  TableHeaderCell,
  StyledTableCell,
} from "../components/Table";
import Grid from "@material-ui/core/Grid";
import TextField from "@material-ui/core/TextField";
import TableRow from "@material-ui/core/TableRow";
import TableHead from "@material-ui/core/TableHead";
import Button from "@material-ui/core/Button";
import Backdrop from "@material-ui/core/Backdrop";
import CircularProgress from "@material-ui/core/CircularProgress";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faPlus } from "@fortawesome/free-solid-svg-icons";
import { withStyles } from "@material-ui/core/styles";
import { GetFriends, DeleteFriend } from "../data/Friend";
import { handleErrorResponse } from "../data/Utils";
import Title from "../components/Title";
import DetailsIcon from "../components/DetailsIcon";
import DeleteIcon from "../components/DeleteIcon";
import ConfirmationModal from "../components/ConfirmationModal";

import FriendForm from "../components/FriendForm";
import FriendTimeLine from "../components/FriendTimeLine";

const styles = () => ({
  root: {
    width: "100%",
  },
  backdrop: {
    zIndex: 1001,
    color: "#fff",
  },
  link: {
    textDecoration: "none",
    fontFamily: "sans-serif"
  }
});

function Friends(props) {
  const { classes } = props;
  const [rows, setRows] = useState([]);
  const [page, setPage] = useState(0);
  const [itensCount, setItensCount] = useState(0);
  const [search, setSearch] = useState("");
  const [selectedFriend, setSelectedFriend] = useState({});
  const [loading, setLoading] = useState(true);
  const [showConfirmation, setShowConfirmation] = useState(false);
  const [showForm, setShowForm] = useState(false);
  const [showTimeLine, setShowTimeLine] = useState(false);

  const RenderHeader = () => {
    return (
      <TableHead>
        <TableRow>
          <TableHeaderCell>Amigo</TableHeaderCell>
          <TableHeaderCell></TableHeaderCell>
          <TableHeaderCell></TableHeaderCell>
        </TableRow>
      </TableHead>
    );
  };

  const RenderRow = (row, index) => {
    return (
      <TableRow hover key={`row-loans-${index}`}>
        <StyledTableCell component="th" scope="row">
          <a className={classes.link} href="#" onClick={e => {
             e.preventDefault();
            setSelectedFriend(row);
            setShowTimeLine(true);
          }}>{row.name}</a>
        </StyledTableCell>
        <StyledTableCell style={{ width: 30 }}>
          <DetailsIcon
            onClick={() => {
              setSelectedFriend(row);
              setShowForm(true);
            }}
          />
        </StyledTableCell>
        <StyledTableCell style={{ width: 30 }}>
          <DeleteIcon
            onClick={() => {
              setSelectedFriend(row);
              setShowConfirmation(true);
            }}
          />
        </StyledTableCell>
      </TableRow>
    );
  };

  useEffect(() => {
    setPage(0);
    loadFriends();
  }, [search]);

  useEffect(() => {
    loadFriends();
  }, [page]);

  const loadFriends = () => {
    setLoading(true);
    GetFriends(page + 1, search)
      .then((response) => {
        setRows(response.data.data);
        setItensCount(response.data.totalItensCount);
        setLoading(false);
      })
      .catch((e) => {
        handleErrorResponse(e);
        setLoading(false);
      });
  };

  const deleteFriend = () => {
    setLoading(true);
    DeleteFriend(selectedFriend)
      .then(() => {
        setPage(0);
        loadFriends();
      })
      .catch((e) => {
        handleErrorResponse(e);
        setLoading(false);
      });
  };

  const handleChangePage = (newPage) => {
    setPage(newPage);
  };

  const handleCloseForm = () => {
    setShowForm(false);
    loadFriends();
  };

  const handleCloseTL = () => {
    setShowTimeLine(false);
  }

  return (
    <Grid container className={classes.root} direction="column">
      <Backdrop className={classes.backdrop} open={loading}>
        <CircularProgress color="primary" />
      </Backdrop>
      <Grid container direction="row" justify="flex-start">
        <Title>{"Amigos"}</Title>
      </Grid>
      <Grid
        container
        direction="row"
        justify="flex-end"
        alignItems="flex-end"
        spacing={2}
      >
        <Grid item>
          <TextField
            id="date"
            label="Buscar Amigo"
            type="text"
            value={search}
            onChange={(e) => {
              setSearch(e.target.value);
            }}
            InputLabelProps={{
              shrink: true,
            }}
          />
        </Grid>
        <Grid item>
          <Button
            variant="contained"
            color="primary"
            onClick={() => {
              setSelectedFriend(null);
              setShowForm(true);
            }}
          >
            <FontAwesomeIcon style={{ marginRight: "5px" }} icon={faPlus} />{" "}
            {"Novo"}
          </Button>
        </Grid>
      </Grid>
      <Grid item style={{ paddingTop: "15px" }}>
        <CompleteTable
          rows={rows}
          page={page}
          totalItens={itensCount}
          renderHeader={RenderHeader}
          renderRow={RenderRow}
          handleChangePage={handleChangePage}
        />
      </Grid>
      <ConfirmationModal
        open={showConfirmation}
        handleOk={() => deleteFriend()}
        handleClose={() => setShowConfirmation(false)}
      />
      {showForm && (
        <FriendForm
          open={showForm}
          handleClose={handleCloseForm}
          friend={selectedFriend}
        />
      )}
       {showTimeLine && (
        <FriendTimeLine
          open={showTimeLine}
          handleClose={handleCloseTL}
          friend={selectedFriend}
        />
      )}
    </Grid>
  );
}

export default withBasePage(withStyles(styles)(Friends));
