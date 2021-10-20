import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { UserMainComponent } from './user-main/user-main.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'userMain',
    component: UserMainComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
