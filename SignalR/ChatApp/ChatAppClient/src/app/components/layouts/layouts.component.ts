import { Component } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-layouts',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './layouts.component.html',
  styleUrl: './layouts.component.css'
})
export class LayoutsComponent {

  constructor(
    private router:Router
  ){}

  logout(){
    localStorage.clear();
    this.router.navigateByUrl("/login");
  }
}
