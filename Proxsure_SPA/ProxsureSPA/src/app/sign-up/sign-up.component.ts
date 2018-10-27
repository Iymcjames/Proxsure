import { SuscriptionService } from './../Admin/Suscription/suscription.service';
import { Suscription } from './../Admin/Suscription/suscription.model';
import { UserService } from './../shared/Users/user.service';
import { Component, OnInit } from '@angular/core';
import {
  NgForm,
  NgModel,
  FormControl,
  Validators,
  FormGroup,
  FormGroupDirective,
  AbstractControl,
  FormBuilder
} from '@angular/forms';
import { User } from '../shared/Users/user.model';

import { ErrorStateMatcher } from '@angular/material/core';
import { PasswordValidation } from '../shared/password_validator.model';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.scss']
})
export class SignUpComponent implements OnInit {
  signUpForm: FormGroup;
  newSignUpUser: User;
  confirmationMessage: string;
  suscriptions: Suscription[];


  constructor(
    public fb: FormBuilder,
    public userService: UserService,
    public suscriptionService: SuscriptionService
  ) {
    this.newSignUpUser = new User();
    this.signUpForm = this.fb.group(
      {
        firstName: ['', Validators.required],
        lastName: ['', Validators.required],
        username: ['', Validators.required],
        email: ['', [Validators.required, Validators.email]],
        password: ['', [Validators.required, Validators.minLength(6)]],
        reTypePassword: ['', [Validators.required]],
        suscriptionId: ['', [Validators.required]]
      },
      {
        validator: PasswordValidation.MatchPassword
      }
    );
  }

  ngOnInit() {
    this.resetForm();
    this.GetSuscriptions();
  }

  GetSuscriptions() {
    this.suscriptionService
      .getAllSuscriptions()
      .subscribe((response: Suscription[]) => {
        this.suscriptions = response;
      });
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

export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(
    control: FormControl | null,
    form: FormGroupDirective | NgForm | null
  ): boolean {
    const isSubmitted = form && form.submitted;
    return !!(
      control &&
      control.invalid &&
      (control.dirty || control.touched || isSubmitted)
    );
  }
}
