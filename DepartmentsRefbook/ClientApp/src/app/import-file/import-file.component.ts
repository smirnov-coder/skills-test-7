import { Component } from "@angular/core";
import { Store } from "@ngrx/store";
import { importCompanies } from "../store/refbook/refbook.actions";

@Component({
  selector: "import-file",
  templateUrl: "import-file.component.html"
})
export class ImportFileComponent {

  private file?: File;

  constructor(private store: Store) {
  }

  onFileSelected(event: any) {
    this.file = event.target.files[0];
  }

  onSend() {
    if (this.file) {
      this.store.dispatch(importCompanies({ file: this.file }))
    }
  }
}
