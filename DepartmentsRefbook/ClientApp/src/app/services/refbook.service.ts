import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Company, CreateBranchRequest, CreateDepartmentRequest, MoveBranchRequest, MoveDepartmentRequest } from "../models";

@Injectable()
export class RefbookService {

  private options = {
    headers: {
      "Content-Type": "application/json"
    }
  }

  constructor(private httpClient: HttpClient) {
  }

  getCompanies(): Observable<Company[]> {
    return this.httpClient.get<Company[]>("/api/companies");
  }

  importCompanies(file: File): Observable<any> {
    const formData = new FormData();
    formData.append("file", file, file.name);
    return this.httpClient.post("/api/companies/import", formData);
  }

  moveDepartment(request: MoveDepartmentRequest): Observable<any> {
    return this.httpClient.post("/api/departments/move", JSON.stringify(request), this.options);
  }

  deleteDepartment(id: number): Observable<any> {
    return this.httpClient.delete(`/api/departments/${id}`);
  }

  createDepartment(request: CreateDepartmentRequest): Observable<any> {
    return this.httpClient.post("/api/departments", JSON.stringify(request), this.options)
  }

  moveBranch(request: MoveBranchRequest): Observable<any> {
    return this.httpClient.post("/api/branches/move", JSON.stringify(request), this.options);
  }

  deleteBranch(id: number): Observable<any> {
    return this.httpClient.delete(`/api/branches/${id}`);
  }

  createBranch(request: CreateBranchRequest): Observable<any> {
    return this.httpClient.post("/api/branches", JSON.stringify(request), this.options);
  }
}
