import { HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { of } from "rxjs/internal/observable/of";
import { catchError } from "rxjs/internal/operators/catchError";
import { map } from "rxjs/internal/operators/map";
import { mergeMap } from "rxjs/internal/operators/mergeMap";
import { switchMap } from "rxjs/internal/operators/switchMap";
import { RefbookService } from "../../services/refbook.service";
import { ActionTypes } from "../app.actions";
import { failure, loadCompanies, loadCompaniesSuccess, postSuccess } from "./refbook.actions";

@Injectable()
export class RefbookEffects {

  constructor(private actions$: Actions, private refbookService: RefbookService, private store: Store) {
  }

  importCompanies$ = createEffect(() => this.actions$.pipe(
    ofType(ActionTypes.ImportCompanies),
    mergeMap((action: any) => this.refbookService.importCompanies(action.file)
      .pipe(
        map(result => {
          this.store.dispatch(loadCompanies())
          return postSuccess({ success: result.success });
        }),
        catchError((response: HttpErrorResponse) => of(failure({ error: response.error.error })))
      )
    )
  ));

  loadCompanies$ = createEffect(() => this.actions$.pipe(
    ofType(ActionTypes.LoadCompanies),
    switchMap((action: any) => this.refbookService.getCompanies()
      .pipe(
        map(companies => loadCompaniesSuccess({ companies })),
        catchError((response: HttpErrorResponse) => of(failure({ error: response.error })))
      )
    )
  ));

  moveDepartment$ = createEffect(() => this.actions$.pipe(
    ofType(ActionTypes.MoveDepartment),
    mergeMap((action: any) => this.refbookService.moveDepartment(action.request)
      .pipe(
        map(result => {
          this.store.dispatch(loadCompanies())
          return postSuccess({ success: result.success });
        }),
        catchError((response: HttpErrorResponse) => of(failure({ error: response.error.error })))
      )
    )
  ));

  deleteDepartment$ = createEffect(() => this.actions$.pipe(
    ofType(ActionTypes.DeleteDepartment),
    mergeMap((action: any) => this.refbookService.deleteDepartment(action.id)
      .pipe(
        map(result => {
          this.store.dispatch(loadCompanies())
          return postSuccess({ success: result.success });
        }),
        catchError((response: HttpErrorResponse) => of(failure({ error: response.error.error })))
      )
    )
  ));

  createDepartment$ = createEffect(() => this.actions$.pipe(
    ofType(ActionTypes.CreateDepartment),
    mergeMap((action: any) => this.refbookService.createDepartment(action.request)
      .pipe(
        map(result => {
          this.store.dispatch(loadCompanies())
          return postSuccess({ success: result.success });
        }),
        catchError((response: HttpErrorResponse) => of(failure({ error: response.error.error })))
      )
    )
  ));

  moveBranch$ = createEffect(() => this.actions$.pipe(
    ofType(ActionTypes.MoveBranch),
    mergeMap((action: any) => this.refbookService.moveBranch(action.request)
      .pipe(
        map(result => {
          this.store.dispatch(loadCompanies())
          return postSuccess({ success: result.success });
        }),
        catchError((response: HttpErrorResponse) => of(failure({ error: response.error.error })))
      )
    )
  ));

  deleteBranch$ = createEffect(() => this.actions$.pipe(
    ofType(ActionTypes.DeleteBranch),
    mergeMap((action: any) => this.refbookService.deleteBranch(action.id)
      .pipe(
        map(result => {
          this.store.dispatch(loadCompanies())
          return postSuccess({ success: result.success });
        }),
        catchError((response: HttpErrorResponse) => of(failure({ error: response.error.error })))
      )
    )
  ));

  createBranch$ = createEffect(() => this.actions$.pipe(
    ofType(ActionTypes.CreateBranch),
    mergeMap((action: any) => this.refbookService.createBranch(action.request)
      .pipe(
        map(result => {
          this.store.dispatch(loadCompanies())
          return postSuccess({ success: result.success });
        }),
        catchError((response: HttpErrorResponse) => of(failure({ error: response.error.error })))
      )
    )
  ));
}
