import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserAccountsComponent } from './user-accounts.component';
import { Routes, RouterModule } from '@angular/router';
import { AuthenticationGuard } from '../authentication.guard';
import { UserAccountComponent } from './user-account/user-account.component';
import { CurrencyDropdownModule } from '../currency-dropdown/currency-dropdown/currency-dropdown.module';
import { FormsModule } from '@angular/forms';

const routes: Routes = [
  {
    path: '',
    component: UserAccountsComponent,
    pathMatch: 'full',
    canActivate: [AuthenticationGuard],
  },
];

@NgModule({
  declarations: [UserAccountsComponent, UserAccountComponent],
  imports: [
    CommonModule, CurrencyDropdownModule, FormsModule, RouterModule.forChild(routes)
  ],
  exports : [UserAccountsComponent]
})
export class UserAccountsModule { }
