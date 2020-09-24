import Axios from "axios";
import { getAuthHeader, DoPost } from "./Utils";

const FRIENDS_BYNAME_ENDPOINT =
  "/Friend/FindFriendsByName?Page={0}&PageSize={1}&name={2}";

const SAVE_ENDPOINT = "/Friend/Save";
const UPDATE_ENDPOINT = "/Friend/Update";
const DELETE_ENDPOINT = "/Friend/Delete";

export function GetFriends(page, name) {
  const headers = getAuthHeader();
  const addr = FRIENDS_BYNAME_ENDPOINT
                .replace("{0}", page)
                .replace("{1}", "10")
                .replace("{2}", name ? name : "");

  return Axios.get(addr, { headers });
}

export function SaveFriend(friend) {
  return DoPost(SAVE_ENDPOINT, friend);
}

export function UpdateFriend(friend) {
  return DoPost(UPDATE_ENDPOINT, friend);
}

export function DeleteFriend(friend) {
  return DoPost(DELETE_ENDPOINT, friend);
}