import { createFeatureSelector, createSelector } from "@ngrx/store";
import { RefbookState } from "./refbook.reducer";

const getRefbookState = createFeatureSelector<RefbookState>("refbook");

export const getCompanies = createSelector(
  getRefbookState,
  (state) => state.companies
);

export const getError = createSelector(
  getRefbookState,
  (state) => state.error
);

export const getSuccess = createSelector(
  getRefbookState,
  (state) => state.success
);
