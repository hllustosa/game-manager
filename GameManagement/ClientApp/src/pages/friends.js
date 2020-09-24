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
import { Typography } from "@material-ui/core";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faPlus } from "@fortawesome/free-solid-svg-icons";
import { withStyles } from "@material-ui/core/styles";
import { GetLoans, SaveLoan, UpdateLoan, DeleteLoan } from "../data/GameLoans";
import { handleErrorResponse, adjustDate } from "../data/Utils";
import Title from "../components/Title";
import DetailsIcon from "../components/DetailsIcon";
import DeleteIcon from "../components/DeleteIcon";
import ConfirmationModal from "../components/ConfirmationModal";

import GameLoanForm from "../components/GameLoanForm";

const styles = (theme) => ({
  root: {
    width: "100%",
  },
  backdrop: {
    zIndex: 1001,
    color: "#fff",
  },
});

function GameLoans(props) {
  const { classes } = props;
  const [rows, setRows] = useState([]);
  const [page, setPage] = useState(0);
  const [itensCount, setItensCount] = useState(0);
  const [initial, setInitial] = useState("");
  const [final, setFinal] = useState("");
  const [selectedLoan, setSelectedLoan] = useState({});
  const [loading, setLoading] = useState(true);
  const [showConfirmation, setShowConfirmation] = useState(false);
  const [showForm, setShowForm] = useState(false);

  const RenderHeader = () => {
    return (
      <TableHead>
        <TableRow>
          <TableHeaderCell>Jogo</TableHeaderCell>
          <TableHeaderCell>Amigo</TableHeaderCell>
          <TableHeaderCell>Data</TableHeaderCell>
          <TableHeaderCell>Status</TableHeaderCell>
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
          {row.game.name}
        </StyledTableCell>
        <StyledTableCell>{row.friend.name}</StyledTableCell>
        <StyledTableCell style={{ width: 160 }}>
          {adjustDate(row.loanDate)}
        </StyledTableCell>
        <StyledTableCell style={{ width: 160 }}>
          {row.isActive ? (
            <Typography style={{ color: "blue" }}> Emprestado </Typography>
          ) : (
            <Typography style={{ color: "green" }}>
              {" "}
              Devolvido {adjustDate(row.returnDate)}{" "}
            </Typography>
          )}
        </StyledTableCell>
        <StyledTableCell style={{ width: 30 }}>
          <DetailsIcon
            onClick={() => {
              setSelectedLoan(row);
              setShowForm(true);
            }}
          />
        </StyledTableCell>
        <StyledTableCell style={{ width: 30 }}>
          <DeleteIcon
            onClick={() => {
              setSelectedLoan(row);
              setShowConfirmation(true);
            }}
          />
        </StyledTableCell>
      </TableRow>
    );
  };

  useEffect(() => {
    setPage(0);
    loadLoans();
  }, [initial, final]);

  useEffect(() => {
    loadLoans();
  }, [page]);

  const loadLoans = () => {
    setLoading(true);
    GetLoans(page + 1, initial, final)
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

  const deleteLoan = () => {
    setLoading(true);
    DeleteLoan(selectedLoan)
      .then(() => {
        setPage(0);
        loadLoans();
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
    loadLoans();
  };

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
            label="Data Inicial"
            type="date"
            value={initial}
            onChange={(e) => {
              setInitial(e.target.value);
            }}
            className={classes.textField}
            InputLabelProps={{
              shrink: true,
            }}
          />
        </Grid>
        <Grid item>
          <TextField
            id="date"
            label="Data Final"
            type="date"
            value={final}
            onChange={(e) => {
              setFinal(e.target.value);
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
              setSelectedLoan(null);
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
        handleOk={() => deleteLoan()}
        handleClose={() => setShowConfirmation(false)}
      />
      {showForm && (
        <GameLoanForm
          open={showForm}
          handleClose={handleCloseForm}
          loan={selectedLoan}
        />
      )}
    </Grid>
  );
}

export default withBasePage(withStyles(styles)(GameLoans));
