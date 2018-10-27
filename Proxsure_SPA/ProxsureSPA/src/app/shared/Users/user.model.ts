import { Suscription } from '../../Admin/Suscription/suscription.model';

export class User {
  firstName: string;
  lastName: string;
  username: string;
  email: string;
  password: string;
  suscriptionId: number;
  profilePicture: File;
  suscriptionStartDate: Date;
  suscriptionExpirydate: Date;
}
