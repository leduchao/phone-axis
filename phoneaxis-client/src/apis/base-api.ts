import axios, { AxiosInstance, AxiosRequestConfig, AxiosResponse } from "axios";

export class BaseApi {
  protected http: AxiosInstance;

  constructor(baseURL: string) {
    this.http = axios.create({
      baseURL,
      headers: {
        "Content-Type": "application/json",
      },
    });

    this.http.interceptors.response.use(
      (response) => response,
      (error) => {
        alert(error.response.data.errors);
        return Promise.reject(error);
      }
    );
  }

  protected async get<T>(url: string, config?: AxiosRequestConfig): Promise<T> {
    const response: AxiosResponse<T> = await this.http.get(url, config);
    return response.data;
  }

  protected async post<TRequest, TResponse = unknown>(
    url: string,
    data?: TRequest,
    config?: AxiosRequestConfig
  ): Promise<TResponse> {
    const response: AxiosResponse<TResponse> = await this.http.post(
      url,
      data,
      config
    );
    return response.data;
  }

  protected async put<TRequest, TResponse = unknown>(
    url: string,
    data?: TRequest,
    config?: AxiosRequestConfig
  ): Promise<TResponse> {
    const response: AxiosResponse<TResponse> = await this.http.put(
      url,
      data,
      config
    );
    return response.data;
  }

  protected async delete<T>(
    url: string,
    config?: AxiosRequestConfig
  ): Promise<T> {
    const response: AxiosResponse<T> = await this.http.delete(url, config);
    return response.data;
  }
}
