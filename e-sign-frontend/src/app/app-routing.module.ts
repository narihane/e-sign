import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminMainComponent } from './admin-main/admin-main.component';
import { CodeMappingComponent } from './code-mapping/code-mapping.component';
import { HomeComponent } from './home/home.component';
import { InvoiceDetailsComponent } from './invoice-details/invoice-details.component';
import { RegisteredUsersComponent } from './registered-users/registered-users.component';
import { AuthGuard } from './shared/_guards/authGuard';
import { UserMainComponent } from './user-main/user-main.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    // canActivate: [AuthGuard]
  },
  {
    path: 'userMain',
    component: UserMainComponent
  },
  {
    path: 'adminMain',
    component: AdminMainComponent
  },
  {
    path: 'invoiceDetails',
    component: InvoiceDetailsComponent
  },
  {path:'codeMap', component:CodeMappingComponent},
  {path:'registeredUsers', component:RegisteredUsersComponent},
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
