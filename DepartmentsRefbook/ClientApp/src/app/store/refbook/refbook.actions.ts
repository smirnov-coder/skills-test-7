import { createAction, props } from "@ngrx/store";
import { Company, CreateBranchRequest, CreateDepartmentRequest, MoveBranchRequest, MoveDepartmentRequest } from "../../models";
import { ActionTypes } from "../app.actions";

export const importCompanies = createAction(
  ActionTypes.ImportCompanies,
  props<{ file: File }>()
);

export const loadCompanies = createAction(
  ActionTypes.LoadCompanies
);

export const loadCompaniesSuccess = createAction(
  ActionTypes.LoadCompaniesSuccess,
  props<{ companies: Company[] }>()
);

export const failure = createAction(
  ActionTypes.Error,
  props<{ error: any }>()
);

export const postSuccess = createAction(
  ActionTypes.PostSuccess,
  props<{ success: string }>()
);

export const moveDepartment = createAction(
  ActionTypes.MoveDepartment,
  props<{ request: MoveDepartmentRequest }>()
);

export const deleteDepartment = createAction(
  ActionTypes.DeleteDepartment,
  props<{ id: number }>()
);

export const createDepartment = createAction(
  ActionTypes.CreateDepartment,
  props<{ request: CreateDepartmentRequest }>()
);

export const moveBranch = createAction(
  ActionTypes.MoveBranch,
  props<{ request: MoveBranchRequest }>()
);

export const deleteBranch = createAction(
  ActionTypes.DeleteBranch,
  props<{ id: number }>()
);

export const createBranch = createAction(
  ActionTypes.CreateBranch,
  props<{ request: CreateBranchRequest }>()
);

export const clearSuccess = createAction(
  ActionTypes.ClearSuccess,
);

export const clearError = createAction(
  ActionTypes.ClearError,
);
