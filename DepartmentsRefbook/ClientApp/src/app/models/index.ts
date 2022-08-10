export interface Company {
  id: number;
  name: string;
  departments: Department[];
}

export interface Department {
  id: number;
  name: string;
  rowVersion: string;
  branches: Branch[];
  companyId: number;
}

export interface Branch {
  id: number;
  name: string;
  rowVersion: string;
  departmentId: number;
}

export interface MoveDepartmentRequest {
  departmentId: number;
  departmentRowVersion: string;
  companyId: number;
}

export interface MoveBranchRequest {
  branchId: number;
  branchRowVersion: string;
  departmentId: number;
}

export interface CreateDepartmentRequest {
  companyId: number;
  departmentName: string;
}

export interface CreateBranchRequest {
  departmentId: number;
  branchName: string;
}
