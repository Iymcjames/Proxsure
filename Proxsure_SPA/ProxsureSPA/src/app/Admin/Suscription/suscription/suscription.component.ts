import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { Suscription } from '../suscription.model';

@Component({
  selector: 'suscription',
  templateUrl: './suscription.component.html',
  styleUrls: ['./suscription.component.scss']
})
export class SuscriptionComponent implements OnInit {
suscriptionForm: FormGroup;
theSuscription: Suscription;

  constructor(public fb: FormBuilder) {
    this.suscriptionForm = this.fb.group({
      name: ['', Validators.required],
      price : ['', Validators.required],
      duration : ['', Validators.required]
    });
  }

  ngOnInit() {
    this.theSuscription = new Suscription();
  }

}
