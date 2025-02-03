import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClienteService } from '../..//services/cliente.service';

@Component({
  selector: 'app-cliente-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './cliente-list.component.html',
  styleUrls: ['./cliente-list.component.scss']
})
export class ClienteListComponent implements OnInit {
  clientes: any[] = [];
  mensagem: string = '';
  erro: boolean = false;

  constructor(private clienteService: ClienteService) {}

  ngOnInit(): void {
    this.carregarClientes();
  }

  carregarClientes(): void {
    this.clienteService.listarClientes().subscribe({
      next: (dados) => {
        this.clientes = Array.from(dados.apiResultData);
      },
      error: (err) => {
        console.error('Erro ao carregar clientes:', err);
        this.mensagem = 'Erro ao carregar clientes.';
        this.erro = true;
      }
    });
  }

  excluirCliente(id: number): void {
    if (confirm('Tem certeza que deseja excluir este cliente?')) {
      this.clienteService.excluirCliente(id).subscribe({
        next: () => {
          this.mensagem = 'Cliente excluído com sucesso!';
          this.erro = false;
          this.carregarClientes();
        },
        error: (err) => {
          console.error('Erro ao excluir cliente:', err);
          this.mensagem = 'Erro ao excluir cliente.';
          this.erro = true;
        }
      });
    }
  }
}
