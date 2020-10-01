import Axios from "axios";

const LOGIN_ENDPOINT = "/User/Login";

export function Login(UserName, Password) {
  const addr = LOGIN_ENDPOINT;
  return Axios.post(addr, { UserName, Password });
}
