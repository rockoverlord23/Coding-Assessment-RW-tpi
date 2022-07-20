import { Address } from "./Address.model";

export interface Contact {
  contactId: string;
  firstName: string;
  lastName: string;
  phone: string;
  email:string;
  addressID:Address;
}
