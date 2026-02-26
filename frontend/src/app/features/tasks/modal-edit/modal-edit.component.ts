import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Task, TaskStatus, TaskStatusLabels } from '../../../core/models/task.model';
import { TaskService } from '../../../core/services/task-service';

@Component({
  selector: 'app-modal-edit',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './modal-edit.component.html',
  styleUrl: './modal-edit.component.css'
})
export class ModalEditComponent {

  @Input() tasks: Task[] = [];
  @Output() close = new EventEmitter<void>();
  @Output() updated = new EventEmitter<void>();

  selectedTask: Task | null = null;
  description = '';
  status: TaskStatus = TaskStatus.Pending;
  loading = false;
  error = '';

  statusOptions = [
    { value: TaskStatus.Pending,    label: TaskStatusLabels[TaskStatus.Pending] },
    { value: TaskStatus.InProgress, label: TaskStatusLabels[TaskStatus.InProgress] },
    { value: TaskStatus.Completed,  label: TaskStatusLabels[TaskStatus.Completed] }
  ];

  constructor(private taskService: TaskService) {}

  onSelectTask(id: string): void {
    this.selectedTask = this.tasks.find(t => t.id === id) || null;
    if (this.selectedTask) {
      this.description = this.selectedTask.description;
      this.status = this.selectedTask.status;
    }
  }

  submit(): void {
    if (!this.selectedTask) return;
    if (!this.description.trim()) {
      this.error = 'Descrição é obrigatória.';
      return;
    }
    this.loading = true;
    this.error = '';
    this.taskService.update(this.selectedTask.id, {
      description: this.description,
      status: Number(this.status)
    }).subscribe({
      next: () => this.updated.emit(),
      error: () => {
        this.error = 'Erro ao atualizar task.';
        this.loading = false;
      }
    });
  }
}
