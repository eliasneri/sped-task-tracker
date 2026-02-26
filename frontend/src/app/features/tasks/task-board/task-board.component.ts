import { Component, EventEmitter, Input, OnChanges, OnInit, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Task, TaskStatus } from '../../../core/models/task.model';
import { TaskCardComponent } from '../task-card/task-card.component';
import {TaskService} from '../../../core/services/task-service';

@Component({
  selector: 'app-task-board',
  standalone: true,
  imports: [CommonModule, TaskCardComponent],
  templateUrl: './task-board.component.html',
  styleUrl: './task-board.component.css'
})
export class TaskBoardComponent implements OnInit, OnChanges {

  @Input() refreshTrigger = 0;
  @Output() tasksLoaded = new EventEmitter<Task[]>();

  pending: Task[] = [];
  inProgress: Task[] = [];
  completed: Task[] = [];

  constructor(private taskService: TaskService) {}

  ngOnInit(): void { this.loadTasks(); }
  ngOnChanges(): void { this.loadTasks(); }

  loadTasks(): void {
    this.taskService.findAll().subscribe({
      next: (tasks) => {
        this.pending    = tasks.filter(t => t.status === TaskStatus.Pending);
        this.inProgress = tasks.filter(t => t.status === TaskStatus.InProgress);
        this.completed  = tasks.filter(t => t.status === TaskStatus.Completed);
        this.tasksLoaded.emit(tasks);
      },
      error: (err) => console.error('Erro ao carregar tasks', err)
    });
  }
}
