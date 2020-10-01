import Axios from "axios";
import store from "../redux/store";

export function getAuthHeader() {
  const state = store.getState();
  const token = state.user.token;
  return { Authorization: `Bearer ${token}` };
}

export function handleErrorResponse(error) {
  if (error.response.data) {
    const data = error.response.data;
    if (data.errors) {
      alert(data.errors[0].ErrorMsg);
    }
  } else {
    alert("Ocorreu um erro durante comunicação com o servidor");
  }
}

export function adjustDate(value) {
  if (value) {
    const dateStr = value.split("T")[0];
    const dataComponents = dateStr.split("-");
    return `${dataComponents[2]}/${dataComponents[1]}/${dataComponents[0]}`;
  }
  return "";
}

export function Code2Media(code) {
  if (code === 0) {
    return "Carturcho";
  } else if (code === 1) {
    return "CD";
  } else if (code === 2) {
    return "DVD";
  } else if (code === 3) {
    return "BLURAY";
  }
}

export function CreateEventStream(loans, isFriend) {
  const stream = [];
  for (const loan of loans) {
    if (loan.loanDate) {
      const d = new Date(loan.loanDate);
      const msg = isFriend
        ? `Pegou emprestado ${loan.game.name}`
        : `Foi pego por ${loan.friend.name}`;
      stream.push({ date: d, event: msg });
    }

    if (loan.returnDate) {
      const d = new Date(loan.returnDate);
      const msg = isFriend
        ? `Retornou ${loan.game.name}`
        : `Foi retornado por ${loan.friend.name}`;
      stream.push({ date: d, event: msg });
    }
  }

  return stream.sort((a, b) => b.date - a.date);
}

export function DoPost(addr, obj) {
  const headers = getAuthHeader();
  return Axios.post(addr, obj, { headers });
}

export function DoPut(addr, obj) {
    const headers = getAuthHeader();
    return Axios.put(addr, obj, { headers });
}

export function DoDelete(addr, obj) {
    const headers = getAuthHeader();
    return Axios.delete(addr, { headers });
}
