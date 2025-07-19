export interface SignInRequest {
  email: string;
  password: string;
  rememberMe: boolean;
}

export interface SignUpRequest {
  firstName?: string;
  email: string;
  password: string;
  terms: boolean;
  receiveMail: boolean;
}

export interface SignInResponse {
  accessToken: string;
}
