import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Task, TaskStatusLabels } from '../../../core/models/task.model';

@Component({
  selector: 'app-task-card',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './task-card.component.html',
  styleUrl: './task-card.component.css'
})
export class TaskCardComponent {

  @Input() task!: Task;
  isOpen = false;

  get statusLabel(): string {
    return TaskStatusLabels[this.task.status];
  }

  get formattedDate(): string {
    return new Date(this.task.createdAt).toLocaleDateString('pt-BR');
  }

  toggle(): void {
    this.isOpen = !this.isOpen;
  }
}
