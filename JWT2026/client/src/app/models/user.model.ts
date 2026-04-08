export interface UsersModel {
  idUser: number;
  email: string;
  pwd: string;
  residenza: string;
  regione: string;
}

export interface LoginRequest {
  email: string;
  pwd: string;
}

export interface LoginResponse {
  success: boolean;
  token: string | null;
  message: string;
  user: UsersModel | null;
}

