import { Routes } from '@angular/router';
import { ClienteFormComponent } from './components/cliente-formulario/cliente-formulario.component';
import { ClienteListComponent } from './components/cliente-list/cliente-list.component';

export const routes: Routes = [
  { path: 'cadastro', component: ClienteFormComponent },
  { path: 'clientes', component: ClienteListComponent },
  { path: '', redirectTo: '/cadastro', pathMatch: 'full' }
];