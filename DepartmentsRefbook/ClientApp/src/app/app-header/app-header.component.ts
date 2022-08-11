import { Component, OnDestroy, OnInit } from "@angular/core";
import { select, Store } from "@ngrx/store";
import { takeWhile } from "rxjs";
import { getCompanies } from "../store/refbook/refbook.selectors";

@Component({
  selector: "app-header",
  templateUrl: "app-header.component.html"
})
export class AppHeaderComponent implements OnInit, OnDestroy {

  private subscribed: boolean = true;
  canExport: boolean = false;

  constructor(private store: Store) {
  }

  ngOnInit(): void {
    // Скрываем кнопку 'Экспорт', если список компаний пуст, нечего экспортировать
    this.store.pipe(
      select(getCompanies),
      takeWhile(() => this.subscribed)
    ).subscribe(companies => {
      this.canExport = !!companies.length;
    });
  }

  ngOnDestroy(): void {
    this.subscribed = false;
  }
}
