import { Component, OnInit } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs/internal/Observable';
import { Company } from '../models';
import { loadCompanies } from '../store/refbook/refbook.actions';
import { getCompanies } from '../store/refbook/refbook.selectors';

@Component({
  selector: "home-page",
  templateUrl: "./home.page.html",
  host: { "class": "d-block h-100" }
})
export class HomePage implements OnInit {

  companies$?: Observable<Company[]>;

  constructor(private store: Store) {
  }

  ngOnInit(): void {
    this.companies$ = this.store.pipe(select(getCompanies));
    this.store.dispatch(loadCompanies());
  }
}
