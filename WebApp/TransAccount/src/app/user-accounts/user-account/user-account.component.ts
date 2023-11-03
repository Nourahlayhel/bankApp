import { Component, EventEmitter, Input, Output } from '@angular/core';
import { AccountDto } from '../userAccount';

@Component({
  selector: 'app-user-account',
  templateUrl: './user-account.component.html',
  styleUrls: ['./user-account.component.scss']
})
export class UserAccountComponent {

  @Input() account : AccountDto = new AccountDto();

  showTransactions :boolean = false;

  toggleTransactions(){
  this.showTransactions = !this.showTransactions
  }
}
