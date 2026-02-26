/**
 * @author Elias Neri
 */

export enum TaskStatus {
  Pending = 0,
  InProgress = 1,
  Completed = 2
}

export const TaskStatusLabels: Record<TaskStatus, string> = {
  [TaskStatus.Pending]: 'Aguardando',
  [TaskStatus.InProgress]: 'Em Progresso',
  [TaskStatus.Completed]: 'Concluída'
};

export interface Task {
  id: string;
  title: string;
  description: string;
  createdAt: string;
  status: TaskStatus;
}

export interface CreateTaskDto {
  title: string;
  description: string;
}

export interface UpdateTaskDto {
  description: string;
  status: TaskStatus;
}

