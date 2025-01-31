import { Component } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-cadastro-cliente',
  standalone: true, 
  imports: [FormsModule, HttpClientModule],
  templateUrl: './cadastro-cliente.component.html',
  styleUrls: ['./cadastro-cliente.component.scss']
})
export class CadastroClienteComponent {
  constructor(private http: HttpClient) {}

  onSubmit(form: any) {
    if (form.valid) {
      const cliente = {
        nome: form.value.nome,
        email: form.value.email,
        telefone: form.value.telefone,
        endereco: form.value.endereco
      };
  
      this.http.post('https://localhost:7114/Cliente/Create', cliente)
        .subscribe(response => {
          console.log('Cliente cadastrado com sucesso!', response);
          form.reset();
        }, error => {
          console.error('Erro ao cadastrar cliente', error);
        });
    }
  }
}