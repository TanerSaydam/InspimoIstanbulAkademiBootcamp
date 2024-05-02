import { Component } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { AuthService } from '../../guards/auth.service';

@Component({
  selector: 'app-layouts',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './layouts.component.html',
  styleUrl: './layouts.component.css'
})
export class LayoutsComponent {

  constructor(
    private router:Router,
    public auth: AuthService
  ){}

  logout(){
    localStorage.clear();
    this.router.navigateByUrl("/login");
  }
}
