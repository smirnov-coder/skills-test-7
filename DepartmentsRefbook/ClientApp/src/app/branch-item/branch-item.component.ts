import { Component, Input, OnDestroy, OnInit } from "@angular/core";
import { select, Store } from "@ngrx/store";
import { takeWhile } from "rxjs";
import { Branch, Company, Department, MoveBranchRequest } from "../models";
import { deleteBranch, moveBranch } from "../store/refbook/refbook.actions";
import { getCompanies } from "../store/refbook/refbook.selectors";

interface CompanyDepartment {
  company: Company;
  department: Department;
}

@Component({
  selector: "branch-item",
  templateUrl: "branch-item.component.html",
  host: { "class": "w-100" }
})
export class BranchItemComponent implements OnInit, OnDestroy {

  private subscribed: boolean = true;
  @Input() indexNumber: number = 1;
  @Input() branch?: Branch;
  availableDepartments: CompanyDepartment[] = [];

  constructor(private store: Store) {
  }

  ngOnInit(): void {
    this.store
      .pipe(select(getCompanies), takeWhile(() => this.subscribed))
      .subscribe(companies => {
        // Формируем список допустимых департаментов, в которые можно переместить отдел
        var result: CompanyDepartment[] = [];
        for (let company of companies) {
          for (let department of company.departments) {
            result.push({ company, department });
          }
        }
        this.availableDepartments = result.filter(x => !x.department.branches.some(b => b === this.branch));
      });
  }

  selectionChanged(event: any) {
    if (event.target.value) {
      const request: MoveBranchRequest = {
        branchId: this.branch!.id,
        branchRowVersion: this.branch!.rowVersion,
        departmentId: +event.target.value
      }
      this.store.dispatch(moveBranch({ request }));
    }
  }

  delete() {
    if (confirm(`Вы действительно хотите удалить отдел '${this.branch!.name}'?`)) {
      this.store.dispatch(deleteBranch({ id: this.branch!.id }));
    }
  }

  ngOnDestroy(): void {
    this.subscribed = false;
  }
}
