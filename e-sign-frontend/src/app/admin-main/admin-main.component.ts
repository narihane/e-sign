import { Component, OnInit } from '@angular/core';
import { InvoiceStatus } from '../shared/_models/app.model';

@Component({
  selector: 'app-admin-main',
  templateUrl: './admin-main.component.html',
  styleUrls: ['./admin-main.component.css']
})
export class AdminMainComponent implements OnInit {
  //Types of invoice status
  pending=InvoiceStatus.Pending;
  submitted=InvoiceStatus.Submitted;
  approved=InvoiceStatus.Approved;
  rejected=InvoiceStatus.Rejected;

  constructor() { }

  ngOnInit(): void {
  }

}
