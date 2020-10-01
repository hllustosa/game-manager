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
import Backdrop from "@material-ui/core/Backdrop";
import CircularProgress from "@material-ui/core/CircularProgress";
import { Typography } from "@material-ui/core";
import { withStyles } from "@material-ui/core/styles";
import { GetGames } from "../data/UserFriend";
import { handleErrorResponse, Code2Media } from "../data/Utils";
import Title from "../components/Title";
import ConfirmationModal from "../components/ConfirmationModal";

const styles = (theme) => ({
  root: {
    width: "100%",
  },
  backdrop: {
    zIndex: 1001,
    color: "#fff",
  },
});

function Games(props) {
  const { classes } = props;
  const [rows, setRows] = useState([]);
  const [page, setPage] = useState(0);
  const [itensCount, setItensCount] = useState(0);
  const [search, setSearch] = useState("");
  const [loading, setLoading] = useState(true);
  const [showConfirmation, setShowConfirmation] = useState(false);


  const RenderHeader = () => {
    return (
      <TableHead>
        <TableRow>
          <TableHeaderCell>Jogo</TableHeaderCell>
          <TableHeaderCell>Mídia</TableHeaderCell>
          <TableHeaderCell>Plataforma</TableHeaderCell>
          <TableHeaderCell>Status</TableHeaderCell>
        </TableRow>
      </TableHead>
    );
  };

  const RenderRow = (row, index) => {
    return (
      <TableRow hover key={`row-loans-${index}`}>
        <StyledTableCell component="th" scope="row">
          {row.name}
        </StyledTableCell>
        <StyledTableCell>{Code2Media(row.mediaType)}</StyledTableCell>
        <StyledTableCell>{row.plataformName}</StyledTableCell>
        <StyledTableCell style={{ width: 160 }}>
          {row.isLent ? (
            <Typography style={{ color: "blue" }}> Emprestado </Typography>
          ) : (
            <Typography style={{ color: "green" }}> Disponível </Typography>
          )}
        </StyledTableCell>
      </TableRow>
    );
  };

  useEffect(() => {
    setPage(0);
    loadGames();
  }, [search]);

  useEffect(() => {
    loadGames();
  }, [page]);

  const loadGames = () => {
    setLoading(true);
    GetGames(page + 1, search)
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

  const handleChangePage = (newPage) => {
    setPage(newPage);
  };

  return (
    <Grid container className={classes.root} direction="column">
      <Backdrop className={classes.backdrop} open={loading}>
        <CircularProgress color="primary" />
      </Backdrop>
      <Grid container direction="row" justify="flex-start">
        <Title>{"Games"}</Title>
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
            label="Buscar Jogos"
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
    </Grid>
  );
}

export default withBasePage(withStyles(styles)(Games));
