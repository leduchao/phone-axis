import { Result } from "../models/result";
import { UserBasicInfo } from "../models/user-model";
import { BaseApi } from "./base-api";

const CONTROLLER = "users";
const BASE_URL = import.meta.env.VITE_API_BASE_URL;

class UserApi extends BaseApi {
  constructor() {
    super(BASE_URL);
  }

  getUserBasicInfo() {
    const url = `${CONTROLLER}/get-user-info`;
    return this.get<Result<UserBasicInfo>>(url);
  }
}

export const userApi = new UserApi();
