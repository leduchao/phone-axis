import axios, { AxiosResponse } from "axios";
import {
  AuthResponse,
  SignInRequest,
  SignUpRequest,
} from "../models/auth-model";
import { BASE_URL, post } from "./base-api";

const controller = "auth";

const signUp = (
  request: SignUpRequest
): Promise<AxiosResponse<AuthResponse>> => {
  const url = `${BASE_URL}/${controller}/sign-up`;
  return axios.post(url, request);
};

const signIn = (
  request: SignInRequest
): Promise<AxiosResponse<AuthResponse>> => {
  const url = `${BASE_URL}/${controller}/sign-in`;
  return axios.post(url, request);
};

export const AuthApi = {
  signUp,
  signIn,
};
