import { Component, EventEmitter, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Task, TaskStatusLabels } from '../../../core/models/task.model';
import { TaskService } from '../../../core/services/task-service';

@Component({
  selector: 'app-modal-search',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './modal-search.component.html',
  styleUrl: './modal-search.component.css'
})
export class ModalSearchComponent {

  @Output() close = new EventEmitter<void>();

  searchId = '';
  result: Task | null = null;
  error = '';
  loading = false;

  constructor(private taskService: TaskService) {}

  getStatusLabel(task: Task): string {
    return TaskStatusLabels[task.status];
  }

  search(): void {
    if (!this.searchId.trim()) { this.error = 'Informe o ID da task.'; return; }
    this.loading = true;
    this.error = '';
    this.result = null;
    this.taskService.findById(this.searchId.trim()).subscribe({
      next: (task) => { this.result = task; this.loading = false; },
      error: () => { this.error = 'Task não encontrada.'; this.loading = false; }
    });
  }
}
