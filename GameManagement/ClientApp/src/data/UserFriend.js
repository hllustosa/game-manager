import Axios from "axios";
import { getAuthHeader } from "./Utils";

const GAMELOANS_BYDATE_ENDPOINT =
  "/FriendUser/FindGameLoansByDate?Page={0}&PageSize={1}&initialDate={2}&finalDate={3}";

const GAMES_BYNAME_ENDPOINT =
  "/FriendUser/FindGamesByName?Page={0}&PageSize={1}&name={2}";

export function GetLoans(page, initialDate, finalDate) {
  const headers = getAuthHeader();
  const addr = GAMELOANS_BYDATE_ENDPOINT.replace("{0}", page)
    .replace("{1}", "10")
    .replace("{2}", initialDate ? initialDate : "")
    .replace("{3}", finalDate ? finalDate : "");

  return Axios.get(addr, { headers });
}

export function GetGames(page, name) {
  const headers = getAuthHeader();
  const addr = GAMES_BYNAME_ENDPOINT.replace("{0}", page)
    .replace("{1}", "10")
    .replace("{2}", name ? name : "");

  return Axios.get(addr, { headers });
}