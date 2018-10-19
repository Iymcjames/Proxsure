export class Suscription {
  id: number;
  name: string;
  price: number;
  duration: string;
}

export class SuscriptionDropDown {
  value: number;
  display: string;

  GetDropdownFromSuscription(suscription: Suscription) {
    this.value = suscription.id;
    this.display = suscription.name;
  }
}
