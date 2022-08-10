import { Component, Input } from "@angular/core";
import { Store } from "@ngrx/store";
import { Company, CreateDepartmentRequest } from "../models";
import { createDepartment } from "../store/refbook/refbook.actions";

@Component({
  selector: "company-item",
  templateUrl: "company-item.component.html",
  host: { "class": "w-100" }
})
export class CompanyItemComponent {

  departmentName?: string;
  @Input() indexNumber: number = 1;
  @Input() company?: Company;

  constructor(private store: Store) {
  }

  create() {
    if (this.departmentName) {
      const request: CreateDepartmentRequest = {
        companyId: this.company!.id,
        departmentName: this.departmentName
      }
      this.store.dispatch(createDepartment({ request }))
    }
    this.departmentName = "";
  }
}
