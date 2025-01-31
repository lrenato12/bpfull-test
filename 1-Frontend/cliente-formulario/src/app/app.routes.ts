import { Routes } from '@angular/router';
import { CadastroClienteComponent } from './cadastro-cliente/cadastro-cliente.component';

export const routes: Routes = [
    { path: 'cadastro-cliente', component: CadastroClienteComponent },
    { path: '', redirectTo: '/cadastro-cliente', pathMatch: 'full' }, // Rota padrão
];