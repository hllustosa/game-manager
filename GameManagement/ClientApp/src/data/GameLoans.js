import Axios from "axios";
import { getAuthHeader, DoPost } from "./Utils";

const GAMELOANS_BYDATE_ENDPOINT =
  "/GameLoan/FindGameLoansByDate?Page={0}&PageSize={1}&initialDate={2}&finalDate={3}";

  const GAMELOANS_TL_ENDPOINT =
  "/GameLoan/FindGameLoansTimeline?friendId={0}&gameId={1}";

const SAVE_ENDPOINT = "/GameLoan/Save";
const UPDATE_ENDPOINT = "/GameLoan/Update";
const DELETE_ENDPOINT = "/GameLoan/Delete";

export function GetLoans(page, initialDate, finalDate) {
  const headers = getAuthHeader();
  const addr = GAMELOANS_BYDATE_ENDPOINT
                .replace("{0}", page)
                .replace("{1}", "10")
                .replace("{2}", initialDate ? initialDate : "")
                .replace("{3}", finalDate ? finalDate : "");

  return Axios.get(addr, { headers });
}

export function GetLoansTimeLine(friendId, gameId) {
  const headers = getAuthHeader();
  const addr = GAMELOANS_TL_ENDPOINT
                .replace("{0}", friendId ? friendId : "")
                .replace("{1}", gameId ? gameId : "");

  return Axios.get(addr, { headers });
}

export function SaveLoan(loan) {
  return DoPost(SAVE_ENDPOINT, loan);
}

export function UpdateLoan(loan) {
  return DoPost(UPDATE_ENDPOINT, loan);
}

export function DeleteLoan(loan) {
  return DoPost(DELETE_ENDPOINT, loan);
}