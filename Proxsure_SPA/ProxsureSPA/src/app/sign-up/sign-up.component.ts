import { SuscriptionService } from './../Admin/Suscription/suscription.service';
import { Suscription } from './../Admin/Suscription/suscription.model';
import { UserService } from './../shared/Users/user.service';
import { ToastrService } from 'ngx-toastr';
import { Component, OnInit, ViewChild } from '@angular/core';
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
import { PasswordValidation } from '../shared/Auth/password_validator.model';

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
  @ViewChild(FormGroupDirective)
  myForm;

  constructor(
    public fb: FormBuilder,
    public toastr: ToastrService,
    public userService: UserService,
    public suscriptionService: SuscriptionService
  ) {
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
    this.signUpForm.reset();
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
    this.userService.createUser(this.signUpForm.value).subscribe(result => {
      if (result.succeeded) {
        this.toastr.success(
          'Thanks for signing up, kindly confirm email before logging in.',
          'User Registered'
        );
        if (this.myForm) {
          this.myForm.resetForm();
        }
      } else {
        this.toastr.error(result.errors[0].description, 'Sign up Error');
      }
    });
  }

  // resetForm(form?: NgForm) {
  //   if (form) {
  //     form.reset();
  //   }
  // }
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
