import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Contact } from '../Models/Contact.model';

@Injectable({
  providedIn: 'root'
})
export class ContactsService {

  Contactsurl = 'https://localhost:7032/api/Contacts'
  Addressurl = 'http://localhost:7032/api/Address'

  constructor(private http: HttpClient) { }

  getAllContacts() :Observable<Contact[]>{
    return this.http.get<Contact[]>(this.Contactsurl);
  }
   addContact(contact:Contact):Observable<Contact> {
    contact.contactId= '00000000-0000-0000-0000-000000000000'
     return this.http.post<Contact>(this.Contactsurl,contact);
   }
  updateContact(contact:Contact):Observable<Contact> {
    return this.http.put<Contact>(this.Contactsurl + '/' + contact.contactId, contact);
  }
  deleteContact(contactId : string) : Observable<Contact> {
    return this.http.delete<Contact>(this.Contactsurl + '/' + contactId)

   }
 }
