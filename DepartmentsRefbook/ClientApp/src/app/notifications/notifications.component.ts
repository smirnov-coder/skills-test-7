import { Component, OnInit } from "@angular/core";
import { select, Store } from "@ngrx/store";
import { Observable } from "rxjs";
import { clearError, clearSuccess } from "../store/refbook/refbook.actions";
import { getError, getSuccess } from "../store/refbook/refbook.selectors";

@Component({
  selector: "notifications",
  templateUrl: "notifications.component.html"
})
export class NotificationsComponent implements OnInit {

  error$?: Observable<any>;
  success$?: Observable<string | null>;

  constructor(private store: Store) {
  }

  ngOnInit(): void {
    this.error$ = this.store.pipe(select(getError));
    this.success$ = this.store.pipe(select(getSuccess));
  }

  clearError() {
    this.store.dispatch(clearError());
  }

  clearSuccess() {
    this.store.dispatch(clearSuccess());
  }
}
