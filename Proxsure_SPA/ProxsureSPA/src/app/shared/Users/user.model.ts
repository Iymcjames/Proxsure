import { Suscription } from '../../Admin/Suscription/suscription.model';

// export class SignUpUser implements User {
//   firstName: string;
//   lastName: string;
//   username: string;
//   email: string;
//   suscriptionId: number;
//   profilePictureUrl: string;
//   suscriptionStartDate: Date;
//   suscriptionExpirydate: Date;
// }

export interface UserData {
  firstName: string;
  lastName: string;
  username: string;
  email: string;
  suscriptionId: number;
  profilePictureUrl: string;
}

export class UserViewModel {
  user: UserData;
  password: string;
}


