import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-admin-settings',
  templateUrl: './admin-settings.component.html',
  styleUrls: ['./admin-settings.component.css']
})
export class AdminSettingsComponent implements OnInit {

  settingsForm: FormGroup;
  oneBranchForm = new FormGroup({
    branchCode: new FormControl('', [
      Validators.required
    ]),
    branchAddress: new FormControl('', [
      Validators.required
    ])
  });
  constructor(private fb: FormBuilder) {
    this.settingsForm = this.fb.group({
      branches: this.fb.array([this.oneBranchForm]),
      reg_num: new FormControl('', [
        Validators.required
      ])
    })
  }

  ngOnInit(): void {
  }

  settingsSubmit(){
    //TODO: Settings submit
  }

  branches(): FormArray {
    return this.settingsForm.get("branches") as FormArray
  }

  newCode(): FormGroup {
    return new FormGroup({
      branchCode: new FormControl('', [
        Validators.required
      ]),
      branchAddress: new FormControl('', [
        Validators.required
      ])
    });
  }

  addItem() {
    this.branches().push(this.newCode());
  }
}
