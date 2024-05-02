import { Injectable } from '@angular/core';
import { UserModel } from '../models/user.model';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  user: UserModel = new UserModel();

  constructor(private router:Router) { }

  isAuthenticated(){
    if(localStorage.getItem("user")){
      this.user = JSON.parse(localStorage.getItem("user") ?? "")
      return true;
    }

    this.router.navigateByUrl("/login");
    return false;
  }
}
