import { Component, HostListener, ComponentRef, OnInit, ViewChild } from '@angular/core';
import { Contact } from './Models/Contact.model';
import { ContactsService } from './Service/contacts.service';
import { PopupHostDirective } from './directives/host.directives';
import { TooltipComponent } from './tooltip/tooltip.component';
import { Address } from './Models/Address.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

// Data Models Represented in TypeScript
export class AppComponent implements OnInit {
  title = 'Assessment_RW';
  contacts: Contact[] = [];
  address: Address = {
    AddressId: '',
    Street: '',
    City: '',
    State: '',
    ZIP: ''
  }
  contact: Contact ={
    contactId: '',
    firstName: '',
    lastName: '',
    phone: '',
    email: '',
    addressID: this.address
  }
  currentAddressElement:any;


  private calloutRef!: ComponentRef<TooltipComponent>;

  @ViewChild(PopupHostDirective)
    private popupHost!: PopupHostDirective;

  constructor(private contactsService: ContactsService ) {

  }
  ngOnInit(): void {
   this.getAllContacts();
  }

  onAddressMouseEnter(event: { target: any; }, address: any) {
    this.currentAddressElement = event.target;
    const currentPosition = this.offset(event.target);
    this.showCallout(address,currentPosition);
  }
  //TypeScript for Attempted Address Box
  @HostListener('mouseover', ['$event'])
  onAddressMouseOver(event: { target: any; }) {
    let hoverComponent = event.target;
    let inside = false;
    do {
      if (this.calloutRef) {
        if (hoverComponent === this.calloutRef.location.nativeElement || hoverComponent === this.currentAddressElement) {
          inside = true;
        }
      }
      hoverComponent = hoverComponent.parentNode;
    } while (hoverComponent);
    if (inside) {
      console.log('inside');
    } else {
      console.log('outside');
      this.hideCallout();
    }
  }

  private createCallout(data: any): ComponentRef<TooltipComponent> {
    const viewContainer = this.popupHost.viewContainerRef;
    viewContainer.clear();

    const calloutComponentRef = viewContainer.createComponent(TooltipComponent);
    calloutComponentRef.instance.data = data;
    return calloutComponentRef;
  }

  showCallout(address: any, currentPosition: { top: any; left: any; }) {
    this.calloutRef = this.createCallout(address);
    this.calloutRef.instance.styleLeft = currentPosition.left + 'px';
    this.calloutRef.instance.styleTop = currentPosition.top + 27 + 'px';
  }

  hideCallout() {
    if (this.calloutRef) {
      this.calloutRef.destroy();
    }
  }

  private offset(el: { getBoundingClientRect: () => any; }) {
    const rect = el.getBoundingClientRect();
    const scrollLeft = window.pageXOffset || document.documentElement.scrollLeft;
    const scrollTop = window.pageYOffset || document.documentElement.scrollTop;
    return { top: rect.top + scrollTop, left: rect.left + scrollLeft };
  }


  // WebAPI TypeScript for Database function Calls

  getAllContacts(){
    this.contactsService.getAllContacts()
      .subscribe(
        response => {
          console.log(response)
          this.contacts = response;
        });
  }

  onSubmit(){
    if (this.contact.contactId === '') {
      this.contactsService.addContact(this.contact)
      .subscribe(
        response => {
          this.getAllContacts();
          this.contact = {
            contactId: '',
            firstName: '',
            lastName: '',
            phone: '',
            email: '',
            addressID: {
              AddressId: '',
              Street: '',
              City: '',
              State: '',
              ZIP: ''
            }
              }

        }
      );
   } else {
    this.updateContact(this.contact);
   }
  }
  deleteContact(contactId:string)
  {
      this.contactsService.deleteContact(contactId)
      .subscribe(
        response => {
          this.getAllContacts();
        }
      )
  }

  updateContact(contact:Contact) {
    this.contactsService.updateContact(contact)
    .subscribe(
      response => {
        this.getAllContacts();
      }
    )
  }

  PopulateForm(contact:Contact)
  {
    this.contact = contact;
  }
}
