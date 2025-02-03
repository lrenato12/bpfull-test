// src/app/models/cliente.model.ts
export interface ClienteResponseModel {
    id: string;
    nome: string;
    email: string;
    telefone: string;
    documento: string;
    cep: string;
    endereco: string;
    bairro: string;
    cidade: string;
    estado: string;
    pais: string;
  }
  
  export interface ApiResponseModel {
    success: boolean;
    error: string | null;
    errors: any[];
    apiResultData: ClienteResponseModel[];
    hasErrors: boolean;
  }