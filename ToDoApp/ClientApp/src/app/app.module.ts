import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterLink, RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { ToDoGroupComponent } from './to-do-group/to-do-group.component';
import { TodoItemComponent } from './todo-item/todo-item.component';
import { AddItemComponent } from './add-item/add-item.component';
import { AddItemGroupComponent } from './add-item-group/add-item-group.component';
import { EditItemGroupComponent } from './edit-item-group/edit-item-group.component';
import { MyTitleComponent } from './my-title/my-title.component';
import { MatComponentsModule } from './mat-components.module'; 
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from '@angular/material/dialog';
import { ConfirmDialogComponent } from './confirm-dialog/confirm-dialog.component';
import { MatCardModule } from '@angular/material/card';


@NgModule({
  exports: [
    MyTitleComponent,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    MatIconModule,
    BrowserAnimationsModule,
    RouterLink,
    MatDialogModule,
  ],
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    FetchDataComponent,
    ToDoGroupComponent,
    TodoItemComponent,
    AddItemComponent,
    AddItemGroupComponent,
    EditItemGroupComponent,
    MyTitleComponent,
    ConfirmDialogComponent
  ],
  entryComponents: [
    EditItemGroupComponent,
    ConfirmDialogComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    MatIconModule,
    ApiAuthorizationModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    MatComponentsModule,
    MatCardModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      //{ path: 'to-do-group', component: ToDoGroupComponent },
      { path: 'add-item-group', component: AddItemGroupComponent /* canActivate: [AuthorizeGuard]  */ },
      { path: 'add-item', component: AddItemComponent /* canActivate: [AuthorizeGuard]  */ },
      { path: 'editItemGroup/:id', component: EditItemGroupComponent /*, canActivate: [AuthorizeGuard] */ },
      { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthorizeGuard] },
      { path: '**', redirectTo: '' },
    ], { relativeLinkResolution: 'legacy' })
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
