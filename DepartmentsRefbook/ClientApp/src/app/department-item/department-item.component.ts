import { Component, Input, OnDestroy, OnInit } from "@angular/core";
import { select, Store } from "@ngrx/store";
import { takeWhile } from "rxjs";
import { Company, CreateBranchRequest, Department, MoveDepartmentRequest } from "../models";
import { createBranch, deleteDepartment, moveDepartment } from "../store/refbook/refbook.actions";
import { getCompanies } from "../store/refbook/refbook.selectors";

@Component({
  selector: "department-item",
  templateUrl: "department-item.component.html",
})
export class DepartmentItemComponent implements OnInit, OnDestroy {

  private subscribed: boolean = true;
  branchName?: string;
  @Input() indexNumber: number = 1;
  @Input() department?: Department;
  availableCompanies: Company[] = [];

  constructor(private store: Store) {
  }

  ngOnInit(): void {
    this.store
      .pipe(select(getCompanies), takeWhile(() => this.subscribed))
      .subscribe(companies => {
        // Формируем список допустимых компаний, в которые можно переместить департамент
        this.availableCompanies = companies.filter(c => !c.departments.some(d => d === this.department));
      });
  }

  ngOnDestroy(): void {
    this.subscribed = false;
  }

  selectionChanged(event: any) {
    if (event.target.value) {
      const request: MoveDepartmentRequest = {
        departmentId: this.department?.id!,
        departmentRowVersion: this.department?.rowVersion!,
        companyId: +event.target.value
      }
      this.store.dispatch(moveDepartment({ request }));
    }
  }

  delete() {
    if (confirm(`Вы действительно хотите удалить департамент '${this.department?.name}'? Также будут удалены все его отделы.`)) {
      this.store.dispatch(deleteDepartment({ id: this.department?.id! }));
    }
  }

  create() {
    if (this.branchName) {
      const request: CreateBranchRequest = {
        departmentId: this.department!.id,
        branchName: this.branchName
      }
      this.store.dispatch(createBranch({ request }))
    }
    this.branchName = "";
  }
}
