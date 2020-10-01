import Axios from "axios";
import { getAuthHeader } from "./Utils";

const GAMELOANS_BYDATE_ENDPOINT = "/api/FriendUsers/loans/{1}/{0}/{2}/{3}";

const GAMES_BYNAME_ENDPOINT = "/api/FriendUsers/games/{1}/{0}/{2}";

export function GetLoans(page, initialDate, finalDate) {
  const headers = getAuthHeader();
  const addr = GAMELOANS_BYDATE_ENDPOINT.replace("{0}", page)
    .replace("{1}", "10")
    .replace("{2}", initialDate ? initialDate : "0001-01-01")
    .replace("{3}", finalDate ? finalDate : "9999-12-31");

  return Axios.get(addr, { headers });
}

export function GetGames(page, name) {
  const headers = getAuthHeader();
  const addr = GAMES_BYNAME_ENDPOINT.replace("{0}", page)
    .replace("{1}", "10")
    .replace("{2}", name ? name : "");

  return Axios.get(addr, { headers });
}
