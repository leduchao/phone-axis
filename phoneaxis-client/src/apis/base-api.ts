import axios from "axios";
import { LocalStorageKey } from "../constants/local-storage";

export const BASE_URL =
  import.meta.env.VITE_API_BASE_URL || "http://localhost:3000";

const axiosInstance = () => {
  const instance = axios.create({
    baseURL: BASE_URL,
    headers: {
      "Content-Type": "application/json",
    },
  });

  setAuthToken(localStorage.getItem(LocalStorageKey.ACCESS_TOKEN) || "");

  return instance;
};

export const get = async (endpoint: string, params = {}) => {
  try {
    const response = await axiosInstance().get(endpoint, { params });
    return response.data;
  } catch (error) {
    if (axios.isAxiosError(error)) {
      throw new Error(error.response?.data?.message || "GET request failed");
    }
    throw new Error("GET request failed");
  }
};

export const post = async (endpoint: string, data = {}) => {
  try {
    const response = await axiosInstance().post(endpoint, data);
    return response.data;
  } catch (error) {
    if (axios.isAxiosError(error)) {
      throw new Error(error.response?.data?.message || "POST request failed");
    }
    throw new Error("POST request failed");
  }
};

// Hàm PUT tổng quát
export const put = async (endpoint: string, data = {}) => {
  try {
    const response = await axiosInstance().put(endpoint, data);
    return response.data;
  } catch (error) {
    if (axios.isAxiosError(error)) {
      throw new Error(error.response?.data?.message || "PUT request failed");
    }
    throw new Error("PUT request failed");
  }
};

export const del = async (endpoint: string) => {
  try {
    const response = await axiosInstance().delete(endpoint);
    return response.data;
  } catch (error) {
    if (axios.isAxiosError(error)) {
      throw new Error(error.response?.data?.message || "DELETE request failed");
    }
    throw new Error("DELETE request failed");
  }
};

export const setAuthToken = (token: string) => {
  if (token) {
    axiosInstance().defaults.headers.common[
      "Authorization"
    ] = `Bearer ${token}`;
  } else {
    delete axiosInstance().defaults.headers.common["Authorization"];
  }
};
