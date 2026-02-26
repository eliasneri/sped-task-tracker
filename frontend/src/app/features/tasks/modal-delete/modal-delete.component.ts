import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Task, TaskStatusLabels } from '../../../core/models/task.model';
import { TaskService } from '../../../core/services/task-service';

@Component({
  selector: 'app-modal-delete',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './modal-delete.component.html',
  styleUrl: './modal-delete.component.css'
})
export class ModalDeleteComponent {

  @Input() tasks: Task[] = [];
  @Output() close = new EventEmitter<void>();
  @Output() deleted = new EventEmitter<void>();

  selectedTask: Task | null = null;
  confirming = false;
  loading = false;

  constructor(private taskService: TaskService) {}

  getStatusLabel(task: Task): string {
    return TaskStatusLabels[task.status];
  }

  onSelectTask(id: string): void {
    this.selectedTask = this.tasks.find(t => t.id === id) || null;
    this.confirming = false;
  }

  requestConfirm(): void {
    this.confirming = true;
  }

  confirmDelete(): void {
    if (!this.selectedTask) return;
    this.loading = true;
    this.taskService.delete(this.selectedTask.id).subscribe({
      next: () => this.deleted.emit(),
      error: () => { this.loading = false; }
    });
  }

  protected readonly HTMLSelectElement = HTMLSelectElement;
}
