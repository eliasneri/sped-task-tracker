import { Component, EventEmitter, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { TaskService } from '../../../core/services/task-service';

@Component({
  selector: 'app-modal-create',
  standalone: true,
  imports: [CommonModule, FormsModule],  // ← FormsModule para o [(ngModel)]
  templateUrl: './modal-create.component.html',
  styleUrl: './modal-create.component.css'
})
export class ModalCreateComponent {

  @Output() close = new EventEmitter<void>();
  @Output() created = new EventEmitter<void>();

  title = '';
  description = '';
  loading = false;
  error = '';

  constructor(private taskService: TaskService) {}

  submit(): void {
    if (!this.title.trim() || !this.description.trim()) {
      this.error = 'Título e Descrição são obrigatórios.';
      return;
    }
    this.loading = true;
    this.error = '';
    this.taskService.create({ title: this.title, description: this.description }).subscribe({
      next: () => this.created.emit(),
      error: () => {
        this.error = 'Erro ao criar task. Verifique a API.';
        this.loading = false;
      }
    });
  }
}
