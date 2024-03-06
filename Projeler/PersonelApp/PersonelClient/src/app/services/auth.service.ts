import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { jwtDecode } from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  token: string | null = "";
  roles: string[] = [];

  constructor(private router: Router, private http: HttpClient) { }

  isAuthenticated(){
    if(!localStorage.getItem("token")){
      this.router.navigateByUrl("/login");
      return false;
    }

    this.token = localStorage.getItem("token");
    const decode:any = jwtDecode(this.token ?? "");

   // this.roles = decode["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]

    return true;
  }


  getUserRoles(){
    this.http.get("https://localhost:7295/api/UserRoles/GetAllByUserId",{
      headers: {
        "Authorization": `Bearer ${this.token}`
      }
    }).subscribe((res:any)=> {
      this.roles = res;
    });
  }

  
  isAuthorized2(role: string){
    console.log(this.roles);
    
    if(this.roles.includes(role)) return true;

    return false;
  }

  async isAuthorized(role:string){

    var response = await fetch(`https://localhost:7295/api/UserRoles/IsItAuthorized?role=${role}`,{
      "headers": {
        "Authorization": `Bearer ${this.token}`
      }
    }).then(res=> res.json());

    console.log(response);
    return response.isItAuthorized;
    
    // this.http.get(`https://localhost:7295/api/UserRoles/IsItAuthorized?role=${role}`,{
    //   headers: {
    //     "Authorization": `Bearer ${this.token}`
    //   }
    // })
    // .subscribe({
    //   next: (res:any)=> {
    //     if(!res.isItAuthorized){
    //       this.router.navigateByUrl("/");
    //     }else{
    //       callBack();
    //     }
    //   },
    //   error: (err:any) => {
    //     console.log(err);        
    //   }
    // });     
  }
}
