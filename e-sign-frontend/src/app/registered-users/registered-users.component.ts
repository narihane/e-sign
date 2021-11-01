import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { User } from '../shared/_models/user.model';
import { NotificationService } from '../shared/_services/notifications.service';
import { UserAddDetailsComponent } from '../user-add-details/user-add-details.component';

@Component({
  selector: 'app-registered-users',
  templateUrl: './registered-users.component.html',
  styleUrls: ['./registered-users.component.css']
})
export class RegisteredUsersComponent implements OnInit {
  registeredUsers:User[]=[];
  modalMessage:string='';
  modalReference: any;

  constructor(private modalService: NgbModal, private notifyService : NotificationService) { }

  ngOnInit(): void {
    //TODO: Get all registered users API + populate registeredUsers
    this.registeredUsers.push({
      password:'jsaknkahnsa',
      email:'sha@gmail.com',
      fullName:'Narihan',
      phone:'010009390293'
    })
  }

  approveUser(){
    //TODO: APPROVE USER API CALL + ERROR HANDLING + update table with new get call of registered users
    //On success display modal approved
    this.notifyService.showSuccess("","User approved");
  }

  rejectUser(){
    this.notifyService.showWarning("","User rejected");
  }

}
