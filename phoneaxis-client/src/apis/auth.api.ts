import axios, { AxiosResponse } from "axios";
import { SignInRequest } from "../interfaces/auth.interface";
import { BASE_URL, post } from "./base.api";

const controller = "auth";

const signIn = (request: SignInRequest): Promise<AxiosResponse> => {
  const url = `${BASE_URL}/${controller}/sign-in`;
  console.log(url);
  return axios.post(url, request);
};

export const AuthApi = {
  signIn,
};
