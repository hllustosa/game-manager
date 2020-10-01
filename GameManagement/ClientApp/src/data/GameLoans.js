import Axios from "axios";
import { getAuthHeader, DoPost, DoPut, DoDelete } from "./Utils";

const GAMELOANS_BYDATE_ENDPOINT =
  "/api/GameLoans/{1}/{0}/{2}/{3}";

const GAMELOANS_FRIENDS_TL_ENDPOINT =
    "/api/GameLoans/friends/{0}";

const GAMELOANS_GAMES_TL_ENDPOINT =
    "/api/GameLoans/games/{0}";

const SAVE_ENDPOINT = "/api/GameLoans/";
const UPDATE_ENDPOINT = "/api/GameLoans/{0}";
const DELETE_ENDPOINT = "/api/GameLoans/{0}";

export function GetLoans(page, initialDate, finalDate) {
  const headers = getAuthHeader();
  const addr = GAMELOANS_BYDATE_ENDPOINT
                .replace("{0}", page)
                .replace("{1}", "10")
      .replace("{2}", initialDate ? initialDate : "0001-01-01")
      .replace("{3}", finalDate ? finalDate : "9999-12-31");

  return Axios.get(addr, { headers });
}

export function GetLoansTimeLine(friendId, gameId) {
  const headers = getAuthHeader();

    if (friendId) {
        const addr = GAMELOANS_FRIENDS_TL_ENDPOINT
            .replace("{0}", friendId);
        return Axios.get(addr, { headers });
    }

    if (gameId) {
        const addr = GAMELOANS_GAMES_TL_ENDPOINT
            .replace("{0}", gameId);
        return Axios.get(addr, { headers });
    }
  
}

export function SaveLoan(loan) {
  return DoPost(SAVE_ENDPOINT, loan);
}

export function UpdateLoan(loan) {
  return DoPut(UPDATE_ENDPOINT.replace("{0}", loan.id), loan);
}

export function DeleteLoan(loan) {
    return DoDelete(DELETE_ENDPOINT.replace("{0}", loan.id), loan);
}