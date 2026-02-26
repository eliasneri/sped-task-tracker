import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Task } from '../../core/models/task.model';
import { HeaderComponent } from '../../shared/components/header/header.component';
import { FooterComponent } from '../../shared/components/footer/footer.component';
import { TaskBoardComponent } from '../../features/tasks/task-board/task-board.component';
import { ModalCreateComponent } from '../../features/tasks/modal-create/modal-create.component';
import { ModalEditComponent } from '../../features/tasks/modal-edit/modal-edit.component';
import { ModalDeleteComponent } from '../../features/tasks/modal-delete/modal-delete.component';
import { ModalSearchComponent } from '../../features/tasks/modal-search/modal-search.component';

@Component({
  selector: 'app-main-layout',
  standalone: true,
  imports: [
    CommonModule,
    HeaderComponent,
    FooterComponent,
    TaskBoardComponent,
    ModalCreateComponent,
    ModalEditComponent,
    ModalDeleteComponent,
    ModalSearchComponent
  ],
  templateUrl: './main-layout.component.html',
  styleUrl: './main-layout.component.css'
})
export class MainLayoutComponent {

  activeModal: string | null = null;
  allTasks: Task[] = [];
  refreshTrigger = 0;

  openModal(modal: string): void { this.activeModal = modal; }
  closeModal(): void { this.activeModal = null; }

  onRefresh(): void {
    this.closeModal();
    this.refreshTrigger++;
  }

  onTasksLoaded(tasks: Task[]): void {
    this.allTasks = tasks;
  }
}
