import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ClienteFormComponent } from './components/cliente-formulario/cliente-formulario.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, ClienteFormComponent],
  template: `<app-cliente-form></app-cliente-form>`,
})
export class AppComponent {}