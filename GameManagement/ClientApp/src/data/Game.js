import Axios from "axios";
import { getAuthHeader, DoPost } from "./Utils";

const GAMES_BYNAME_ENDPOINT =
  "/Game/FindGamesByName?Page={0}&PageSize={1}&name={2}";

const SAVE_ENDPOINT = "/Game/Save";
const UPDATE_ENDPOINT = "/Game/Update";
const DELETE_ENDPOINT = "/Game/Delete";

export function GetGames(page, name) {
  const headers = getAuthHeader();
  const addr = GAMES_BYNAME_ENDPOINT
                .replace("{0}", page)
                .replace("{1}", "10")
                .replace("{2}", name ? name : "");

  return Axios.get(addr, { headers });
}

export function SaveGame(game) {
  return DoPost(SAVE_ENDPOINT, game);
}

export function UpdateGame(game) {
  return DoPost(UPDATE_ENDPOINT, game);
}

export function DeleteGame(game) {
  return DoPost(DELETE_ENDPOINT, game);
}