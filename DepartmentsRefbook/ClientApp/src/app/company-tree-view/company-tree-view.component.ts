import { Component, Input } from "@angular/core";
import { Company } from "../models";

@Component({
  selector: "company-tree-view",
  templateUrl: "company-tree-view.component.html",
})
export class CompanyTreeViewComponent {

  @Input() company?: Company;
  @Input() indexNumber: number = 1;
}
