import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, ElementRef, ViewChild } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { FormValidateDirective } from 'form-validate-angular';
import { ErrorService } from '../../services/error.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormValidateDirective, FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  email: string = "";
  password: string = "asdasdasd";

  showPassword: boolean = false;

  @ViewChild("passwordInput") passwordInput: ElementRef<HTMLInputElement> | undefined;

  constructor(
    private http: HttpClient,
    private error: ErrorService,
    private router: Router
  ){}

login(form: NgForm){
  if(form.valid){
    this.http.post("https://localhost:7295/api/Auth/Login",{email: this.email, password: this.password})
    .subscribe({
      next: (res:any)=> {
        localStorage.setItem("token", res.token);
        this.router.navigateByUrl("/");
      },
      error: (err: HttpErrorResponse)=> {
        this.error.errorHandler(err);
      }
    })
  }
}

showOrHidePassword(){ //
  console.log(this.passwordInput);
  
  const type =  this.passwordInput?.nativeElement.type;

  if(type === "password"){
    if (this.passwordInput && this.passwordInput.nativeElement) {
      this.passwordInput.nativeElement.type = "text";
      this.showPassword = true; 
  }
  }else{
    if (this.passwordInput && this.passwordInput.nativeElement) {
      this.passwordInput.nativeElement.type = "password"; 
      this.showPassword = false;
    }
  }
}
}
