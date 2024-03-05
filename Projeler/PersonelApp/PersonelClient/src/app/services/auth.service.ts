import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { jwtDecode } from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  token: string | null = "";
  roles: string[] = [];

  constructor(private router: Router) { }

  isAuthenticated(){
    if(!localStorage.getItem("token")){
      this.router.navigateByUrl("/login");
      return false;
    }

    this.token = localStorage.getItem("token");
    const decode:any = jwtDecode(this.token ?? "");

    this.roles = decode["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]
    
    console.log(this.roles);

    return true;
  }

  isAuthorized(role:string){
    if(this.roles.includes(role)){
      return true
    }

   // this.router.navigateByUrl("/");
    return false;
  }
}
