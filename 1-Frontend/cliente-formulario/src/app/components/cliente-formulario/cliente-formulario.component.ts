import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CepService } from '../../services/cep.service';
import { ClienteService } from '../../services/cliente.service';
import { NgxMaskDirective, NgxMaskPipe, provideNgxMask } from 'ngx-mask';

@Component({
  selector: 'app-cliente-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, HttpClientModule, NgxMaskDirective, NgxMaskPipe],
  providers: [CepService, ClienteService, provideNgxMask()],
  templateUrl: './cliente-formulario.component.html',
  styleUrls: ['./cliente-formulario.component.scss']
})
export class ClienteFormComponent {
  clienteForm: FormGroup;
  tipoDocumento: 'CPF' | 'CNPJ' = 'CPF';
  mensagem: string = '';
  erro: boolean = false;

  constructor(private fb: FormBuilder, private cepService: CepService, private clienteService: ClienteService) {
    this.clienteForm = this.fb.group({
      nome: ['', [Validators.required, Validators.minLength(3)]],
      email: ['', [Validators.required, Validators.email]],
      telefone: ['', [Validators.required]],
      tipoDocumento: ['CPF', [Validators.required]],
      cpf: [''],
      cnpj: [''],
      cep: ['', [Validators.required]],
      endereco: ['', [Validators.required]],
      bairro: ['', [Validators.required]],
      cidade: ['', [Validators.required]],
      estado: ['', [Validators.required]],
    });

    this.atualizarValidacoes();
  }

  atualizarValidacoes(): void {
    if (this.tipoDocumento === 'CPF') {
      this.clienteForm.get('cpf')?.setValidators([Validators.required]);
      this.clienteForm.get('cnpj')?.clearValidators();
    } else {
      this.clienteForm.get('cnpj')?.setValidators([Validators.required]);
      this.clienteForm.get('cpf')?.clearValidators();
    }
    this.clienteForm.get('cpf')?.updateValueAndValidity();
    this.clienteForm.get('cnpj')?.updateValueAndValidity();
  }

  buscarCep(): void {
    const cep = this.clienteForm.get('cep')?.value;
    if (cep && cep.length === 8) {
      this.cepService.buscarCep(cep).subscribe((dados) => {
        if (!dados.erro) {
          this.clienteForm.patchValue({
            endereco: dados.logradouro,
            bairro: dados.bairro,
            cidade: dados.localidade,
            estado: dados.uf,
          });
        }
      });
    }
  }

  onSubmit(): void {
    if (this.clienteForm.valid) {
      const cliente = this.clienteForm.value;

      this.clienteService.cadastrarCliente(cliente).subscribe({
        next: () => {
          this.mensagem = 'Cliente cadastrado com sucesso!';
          this.erro = false;
          this.clienteForm.reset();
        },
        error: (err) => {
          console.error('Erro ao cadastrar:', err);
          this.mensagem = 'Erro ao cadastrar cliente. Tente novamente.';
          this.erro = true;
        }
      });
    } else {
      this.mensagem = 'Preencha todos os campos corretamente.';
      this.erro = true;
    }
  }
}
