import { UserService } from './../shared/user.service';
import { Component, OnInit } from '@angular/core';
import { NgForm, NgModel, FormControl, Validators, FormGroup, FormGroupDirective, AbstractControl, FormBuilder } from '@angular/forms';
import { User} from '../shared/user.model';

import { ErrorStateMatcher } from '@angular/material/core';
import { PasswordValidation } from '../shared/password_validator.model';

@Component({
  selector: 'sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.scss']
})
export class SignUpComponent implements OnInit {
  signUpForm: FormGroup;
  newSignUpUser: User;
  confirmationMessage: string;

  suscriptionDropDown: SuscriptionDropDown[] = [
    {value: 'basic', display: 'Basic'},
    {value: 'intermediate', display: 'Intermediate'},
    {value: 'professional', display: 'Professional'},
  ];


  constructor(public fb: FormBuilder, public userService: UserService) {
    this.signUpForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName : ['', Validators.required],
     username : ['', Validators.required],
      email : ['', [Validators.required, Validators.email]],
      password : ['', [Validators.required, Validators.minLength(6)]],
      reTypePassword : ['', [Validators.required]],
      suscriptionType : ['']
     },
     {
      validator: PasswordValidation.MatchPassword
     }
     );

  }


  ngOnInit() {
    this.newSignUpUser = new User();
    this.confirmationMessage = '';
    this.resetForm();
  }

  OnSubmit() {
    console.log(this.signUpForm.value);
this.userService.createUser(this.signUpForm.value);
  }

  resetForm(form?: NgForm) {
if (form) {
   form.reset();
}
this.newSignUpUser = null;
  }
}

export interface SuscriptionDropDown {
  value: string;
  display: string;
}

export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}
