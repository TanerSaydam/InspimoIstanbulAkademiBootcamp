import { Component } from '@angular/core';
import { Router, RouterLink, RouterOutlet } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-layouts',
  standalone: true,
  imports: [CommonModule,RouterOutlet, RouterLink],
  templateUrl: './layouts.component.html',
  styleUrl: './layouts.component.css'
})
export class LayoutsComponent {

  isProfessionMenuAllowed: boolean = false;

  constructor(
    private router: Router,
    public auth: AuthService
  ){

    this.auth.isAuthorized("Menu.Professions").then(res=> {
      this.isProfessionMenuAllowed = res
    });

    this.auth.getUserRoles();
  }

  logout(){
    localStorage.clear();
    this.router.navigateByUrl("/login");
  }
}
