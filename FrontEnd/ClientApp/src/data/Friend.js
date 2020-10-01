import Axios from "axios";
import { getAuthHeader, DoPost, DoPut, DoDelete } from "./Utils";

const FRIENDS_BYNAME_ENDPOINT = "/api/Friends/{1}/{0}/{2}";

const SAVE_ENDPOINT = "/api/Friends/";
const UPDATE_ENDPOINT = "/api/Friends/{0}";
const DELETE_ENDPOINT = "/api/Friends/{0}";

export function GetFriends(page, name) {
  const headers = getAuthHeader();
  const addr = FRIENDS_BYNAME_ENDPOINT.replace("{0}", page)
    .replace("{1}", "10")
    .replace("{2}", name ? name : "");

  return Axios.get(addr, { headers });
}

export function SaveFriend(friend) {
  return DoPost(SAVE_ENDPOINT, friend);
}

export function UpdateFriend(friend) {
  return DoPut(UPDATE_ENDPOINT.replace("{0}", friend.id), friend);
}

export function DeleteFriend(friend) {
  return DoDelete(DELETE_ENDPOINT.replace("{0}", friend.id), friend);
}
