export interface Result<T> {
  isSuccess: boolean;
  statusCode: number;
  message?: string;
  errors: string[];
  data?: T;
}
