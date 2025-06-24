import { BaseResponse } from "./base-model";

export interface SignInRequest {
  email: string;
  password: string;
  rememberMe: boolean;
}

export interface SignUpRequest {
  firstName?: string;
  email: string;
  password: string;
}

export interface AuthResponse extends BaseResponse {
  accessToken: string;
  authResult: boolean;
}
