import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../shared/_models/user.model';
import { UserService } from '../shared/_services/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  username: string;
  password: string;
  userType ='';
  // currentUser: User;
  users: User[] = [];

  constructor(
    // private userService: UserService,
     private router: Router) {
      // this.currentUser = JSON.parse(localStorage.getItem('currentUser')!);
      this.username = '', this.password = '', this.userType = '';
  }

  ngOnInit() {
      // this.loadAllUsers();
  }

 /* deleteUser(id: number) {
      this.userService.delete(id).subscribe(() => { this.loadAllUsers() });
  }

  private loadAllUsers() {
      this.userService.getAll().subscribe(users => { this.users = users; });
  }*/

  submitLoginInfo(): void {

  }
}
