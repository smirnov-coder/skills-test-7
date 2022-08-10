import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { HomePage } from './home/home.page';
import { CompanyTreeViewComponent } from './company-tree-view/company-tree-view.component';
import { CompanyItemComponent } from './company-item/company-item.component';
import { DepartmentItemComponent } from './department-item/department-item.component';
import { RefbookService } from './services/refbook.service';
import { StoreModule } from '@ngrx/store';
import { appReducer } from './store/app.reducer';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { EffectsModule } from '@ngrx/effects';
import { RefbookEffects } from './store/refbook/refbook.effects';
import { BranchItemComponent } from './branch-item/branch-item.component';
import { ImportFileComponent } from './import-file/import-file.component';
import { AppHeaderComponent } from './app-header/app-header.component';
import { NotificationsComponent } from './notifications/notifications.component';

@NgModule({
  declarations: [
    AppComponent,
    HomePage,
    ImportFileComponent,
    CompanyTreeViewComponent,
    CompanyItemComponent,
    DepartmentItemComponent,
    BranchItemComponent,
    AppHeaderComponent,
    NotificationsComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    StoreModule.forRoot(appReducer),
    StoreDevtoolsModule.instrument(),
    EffectsModule.forRoot([RefbookEffects]),
  ],
  providers: [
    RefbookService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
