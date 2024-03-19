import { Component, ElementRef, ViewChild, ViewEncapsulation } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { FormValidateDirective } from 'form-validate-angular';
import { LoginModel } from '../../models/login.model';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { HttpService } from '../../services/http.service';
import { LoginResponseModel } from '../../models/login-response.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, FormValidateDirective],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
  encapsulation: ViewEncapsulation.None
})
export class LoginComponent {
  isShowPassword: boolean = false;
  loginModel: LoginModel = new LoginModel();

  @ViewChild("passwordInput") password: ElementRef<HTMLInputElement> | undefined;

  constructor(
    private http: HttpService,
    private router: Router
  ){}

  showOrHidePassword(){
    this.isShowPassword = !this.isShowPassword;

    if(this.password !== undefined){
      if(this.isShowPassword){
        this.password.nativeElement.type = "text"
      }else{
        this.password.nativeElement.type = "password"
      }
    }
  }

  login(form: NgForm){
    if(form.valid){
      this.http.post<LoginResponseModel>("Auth/Login", this.loginModel, res=> {
        localStorage.setItem("token", res.value.token);
        this.router.navigateByUrl("/");
      });
    }
  }
}
