import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  username: string;
  password: string;
  userType ='';

  constructor(private router: Router) {
    this.username = '', this.password = '', this.userType = ''; }

  ngOnInit(): void {}

  submitLoginInfo(): void {

  }
}
