import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, FormGroupDirective, NgForm, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { Router } from '@angular/router';
import { NgbModal, ModalDismissReasons }
  from '@ng-bootstrap/ng-bootstrap';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  matcher = new MyErrorStateMatcher();
  closeResult = '';
  modalReference: any;
  loginForm = new FormGroup({
    email: new FormControl('', [
      Validators.required
    ]),
    password: new FormControl('', [
      Validators.required
    ])
  });

  checkPasswords: ValidatorFn = (group: AbstractControl): ValidationErrors | null => {
    let pass = group.get('password')?.value;
    let confirmPass = group.get('confirmPassword')?.value
    return pass === confirmPass ? null : { notSame: true }
  }

  registerForm = new FormGroup({
    name: new FormControl('', [
      Validators.required
    ]),
    email: new FormControl('', [
      Validators.required
    ]),
    password: new FormControl('', [
      Validators.required
    ]),
    confirmPassword: new FormControl('', [
      Validators.required
    ]),
  }, { validators: this.checkPasswords });

  constructor(private modalService: NgbModal, private router: Router, private formBuilder: FormBuilder) { }

  ngOnInit(): void { }

  //Login
  get email() { return this.loginForm.get('email'); }
  get password() { return this.loginForm.get('password'); }

  //Register
  get name() { return this.registerForm.get('name'); }
  get emailReg() { return this.registerForm.get('email'); }
  get passReg() { return this.registerForm.get('password'); }
  get confirmPass() { return this.registerForm.get('confirmPassword'); }


  onUserLogin(): void {
    // Process checkout data here
    console.log('Login', this.loginForm.value);
    // API for login access token
    this.router.navigate(['userMain'], {
      queryParams:
        { email: this.email, password: this.password }, skipLocationChange: true
    });
    this.loginForm.reset();
  }

  onAdminLogin():void{
    this.router.navigate(['adminMain'], {
      queryParams:
        { email: this.email, password: this.password }, skipLocationChange: true
    });
    this.loginForm.reset();
  }

  onRegSubmit(): void {
    // Process checkout data here
    console.log('Register', this.registerForm.value);
    // API post for registering users
    this.modalReference.close();
    this.registerForm.reset();
  }

  open(content: any) {
    this.modalReference = this.modalService.open(content);
    this.modalReference.result.then(() => {
      this.closeResult = `Closed with`;
    }, () => {
      this.closeResult = `Dismissed `;
    });
  }
}

export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const invalidCtrl = !!(control?.invalid && control?.parent?.dirty);
    const invalidParent = !!(control?.parent?.invalid && control?.parent?.dirty);

    return invalidCtrl || invalidParent;
  }
}
