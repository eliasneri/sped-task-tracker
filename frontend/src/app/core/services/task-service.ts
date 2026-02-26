import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {CreateTaskDto, Task, UpdateTaskDto} from '../models/task.model';

@Injectable({
  providedIn: 'root'
})

export class TaskService {
    private baseUrl: string = 'http://localhost:8080/api/v1/tasks';

    constructor(private http: HttpClient) {}

  // Busca todas as tasks
  findAll(): Observable<Task[]> {
    return this.http.get<Task[]>(`${this.baseUrl}/findall`);
  }

  findById(id: string): Observable<Task> {
    return this.http.get<Task>(`${this.baseUrl}/findby/${id}`);
  }

  create(dto: CreateTaskDto): Observable<Task> {
    return this.http.post<Task>(`${this.baseUrl}/new`, dto);
  }

  update(id: string, dto: UpdateTaskDto): Observable<Task> {
    return this.http.put<Task>(`${this.baseUrl}/update/${id}`, dto);
  }

  delete(id: string): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/delete/${id}`);
  }

  healthCheck(): Observable<string> {
    return this.http.get('http://localhost:8080/hc', { responseType: 'text' });
  }
}
