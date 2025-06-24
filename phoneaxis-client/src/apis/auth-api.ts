import { LocalStorageKey } from "../constants/local-storage";
import {
  SignInResponse,
  SignInRequest,
  SignUpRequest,
} from "../models/auth-model";
import { Result } from "../models/result";
import { BaseApi } from "./base-api";

const CONTROLLER = "auth";
const BASE_URL = import.meta.env.VITE_API_BASE_URL;

class AuthApi extends BaseApi {
  constructor() {
    super(BASE_URL);
  }

  signUp(request: SignUpRequest) {
    return this.post<SignUpRequest, Result<SignInResponse>>(
      `${CONTROLLER}/sign-up`,
      request
    );
  }

  signIn(request: SignInRequest) {
    return this.post<SignInRequest, Result<SignInResponse>>(
      `${CONTROLLER}/sign-in`,
      request
    );
  }

  signOut() {
    localStorage.removeItem(LocalStorageKey.ACCESS_TOKEN);
    localStorage.removeItem(LocalStorageKey.REFRESH_TOKEN);
  }
}

export const authApi = new AuthApi();
