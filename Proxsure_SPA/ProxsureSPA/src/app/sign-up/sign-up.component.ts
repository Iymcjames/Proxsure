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


  constructor(public fb: FormBuilder) {
    this.signUpForm = this.fb.group({
      firstNameFormControl: ['', Validators.required],
      lastNameFormControl : ['', Validators.required],
     usernameFormControl : ['', Validators.required],
      emailFormControl : ['', [Validators.required, Validators.email]],
      passwordFormControl : ['', [Validators.required, Validators.minLength(6)]],
      reTypePasswordFormControl : ['', [Validators.required]]
     },
     {
      validator: PasswordValidation.MatchPassword
     }
     );

  }

  checkPasswords(group: AbstractControl) { // here we have the 'passwords' group
  const pass = group.get('passwordFormControl').value;
  const confirmPass = group.get('reTypePasswordFormControl').value;

  return pass === confirmPass ? null : group.get('reTypePasswordFormControl').setErrors( {MatchPassword: true} );
}

  ngOnInit() {
    this.newSignUpUser = new User();
    this.confirmationMessage = '';
    this.resetForm();
  }

  OnSubmit() {
    console.warn(this.signUpForm.value);
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
