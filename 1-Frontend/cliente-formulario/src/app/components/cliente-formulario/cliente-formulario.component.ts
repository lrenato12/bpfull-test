import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CepService } from '../../services/cep.service';
import { NgxMaskDirective, NgxMaskPipe, provideNgxMask } from 'ngx-mask';

@Component({
  selector: 'app-cliente-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, HttpClientModule, NgxMaskDirective, NgxMaskPipe],
  providers: [CepService, provideNgxMask()],
  templateUrl: './cliente-formulario.component.html',
  styleUrls: ['./cliente-formulario.component.scss']
})
export class ClienteFormComponent {
  clienteForm: FormGroup;
  tipoDocumento: 'CPF' | 'CNPJ' = 'CPF';

  constructor(private fb: FormBuilder, private cepService: CepService) {
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
      console.log('Cliente cadastrado:', this.clienteForm.value);
    } else {
      console.log('Formulário inválido');
    }
  }
}
