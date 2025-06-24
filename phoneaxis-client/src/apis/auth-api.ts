import {
  AuthResponse,
  SignInRequest,
  SignUpRequest,
} from "../models/auth-model";
import { BaseApi } from "./base-api";

const CONTROLLER = "auth";
const BASE_URL = import.meta.env.VITE_API_BASE_URL;

class AuthApi extends BaseApi {
  constructor() {
    super(BASE_URL);
  }

  signUp(request: SignUpRequest) {
    return this.post<SignUpRequest, AuthResponse>(
      `${CONTROLLER}/sign-up`,
      request
    );
  }

  signIn(request: SignInRequest) {
    return this.post<SignInRequest, AuthResponse>(
      `${CONTROLLER}/sign-in`,
      request
    );
  }
}

export const authApi = new AuthApi();
