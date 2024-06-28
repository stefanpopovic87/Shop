export interface ApiResponse<T> {
    isSuccess: boolean;
    value: T;
    error: string | null;
  }
  

  export interface AsyncThunkConfig {
    rejectValue: string;
}