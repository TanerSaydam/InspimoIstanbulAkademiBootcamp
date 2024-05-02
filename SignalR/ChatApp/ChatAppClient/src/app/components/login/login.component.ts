import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { UserModel } from '../../models/user.model';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  data:{userName: string, password: string} = {
    userName: "",
    password: ""
  };

  constructor(
    private http: HttpClient,
    private router: Router
  ){}

  login(){
    this.http.get<UserModel>(`https://localhost:7132/api/Auth/Login?userName=${this.data.userName}&password=${this.data.password}`)
    .subscribe({
      next: (res)=> {
        localStorage.setItem("user", JSON.stringify(res));
        this.router.navigateByUrl("/");
      },
      error: (err:HttpErrorResponse)=> {
        console.log(err.error);        
        alert("Bir hatayla karşılaştık!")
      }
    })
  }
}
