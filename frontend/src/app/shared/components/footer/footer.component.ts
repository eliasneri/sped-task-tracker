import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import {TaskService} from '../../../core/services/task-service';


@Component({
  selector: 'app-footer',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './footer.component.html',
  styleUrl: './footer.component.css'
})
export class FooterComponent implements OnInit {

  apiOnline = false;

  constructor(private taskService: TaskService) {}

  ngOnInit(): void {
    this.taskService.healthCheck().subscribe({
      next: () => this.apiOnline = true,
      error: () => this.apiOnline = false
    });
  }
}
