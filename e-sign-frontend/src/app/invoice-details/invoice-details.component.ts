import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { InvoiceStatus } from '../shared/_models/app.model';

@Component({
  selector: 'app-invoice-details',
  templateUrl: './invoice-details.component.html',
  styleUrls: ['./invoice-details.component.css']
})
export class InvoiceDetailsComponent implements OnInit {
  status=InvoiceStatus.Approved;
  tableHead=['#','Invoice Number','Total Amount','Actions'];
  tableRows=['839283','839201'];

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.status = this.route.snapshot.queryParams['status'];
  }

}
