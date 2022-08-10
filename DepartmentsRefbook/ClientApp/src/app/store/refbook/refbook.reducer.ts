import { createReducer, on } from "@ngrx/store";
import { Company } from "../../models";
import { clearError, clearSuccess, failure, loadCompanies, loadCompaniesSuccess, postSuccess } from "./refbook.actions";

export interface RefbookState {
  companies: Company[];
  error: any;
  success: string | null;
  isLoadingData: boolean;
}

const initialState: RefbookState = {
  companies: [],
  error: null,
  success: null,
  isLoadingData: true,
}

export const refbookReducer = createReducer(
  initialState,
  on(loadCompanies, (state: RefbookState) => ({ ...state, isLoadingData: true })),
  on(loadCompaniesSuccess, (state: RefbookState, { companies }) => ({
    ...state,
    companies: companies,
    isLoadingData: false
  })),
  on(failure, (state: RefbookState, { error }) => ({ ...state, error, isLoadingData: false })),
  on(postSuccess, (state: RefbookState, { success }) => ({ ...state, success, isLoadingData: false })),
  on(clearError, (state: RefbookState, { }) => ({ ...state, error: null })),
  on(clearSuccess, (state: RefbookState, { }) => ({ ...state, success: null })),
);
