import Axios from "axios";
import { getAuthHeader, DoPost, DoPut, DoDelete } from "./Utils";

const GAMES_BYNAME_ENDPOINT =
  "/api/Games/{1}/{0}/{2}";

const SAVE_ENDPOINT = "/api/Games/";
const UPDATE_ENDPOINT = "/api/Games/{0}";
const DELETE_ENDPOINT = "/api/Games/{0}";

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
  return DoPut(UPDATE_ENDPOINT.replace("{0}", game.id), game);
}

export function DeleteGame(game) {
  return DoDelete(DELETE_ENDPOINT.replace("{0}", game.id), game);
}