import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-profile-picture',
  templateUrl: './profile-picture.component.html',
  styleUrls: ['./profile-picture.component.scss']
})
export class ProfilePictureComponent implements OnInit {
  imageUrl: string;
  fileToUpload: File = null;
  constructor() {}

  ngOnInit() {
    this.imageUrl = '../../../../assets/Vendors/img/ben-sweet-456320-unsplash.jpg';
  }

  handleProfilePicture(files: FileList) {
    this.fileToUpload = files.item(0);

    const reader = new FileReader();
    reader.onload = (event: any) => {
      this.imageUrl = event.target.result;
    };
    reader.readAsDataURL(this.fileToUpload);
  }
}
