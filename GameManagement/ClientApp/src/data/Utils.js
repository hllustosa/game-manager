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
  }
}

export function calcPageCount(itensCount) {
  return itensCount % 10 === 0 ? itensCount / 10 : itensCount / 10 + 1;
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

export function Media2Code(media) {
  if (media === "Carturcho") {
    return 0;
  } else if (media === "CD") {
    return 1;
  } else if (media === "DVD") {
    return 2;
  } else if (media === "BLURAY") {
    return 3;
  }
}

export function DoPost(addr, obj) {
  const headers = getAuthHeader();
  return Axios.post(addr, obj, { headers });
}
