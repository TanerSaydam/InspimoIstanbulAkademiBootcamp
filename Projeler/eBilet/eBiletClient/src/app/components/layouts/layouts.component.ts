import { Component, ViewEncapsulation } from '@angular/core';
import { Router, RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-layouts',
  standalone: true,
  imports: [RouterOutlet, RouterLink, RouterLinkActive],
  templateUrl: './layouts.component.html',
  styleUrl: './layouts.component.css',
  encapsulation: ViewEncapsulation.None
})
export class LayoutsComponent {

  constructor(
    private router: Router
  ){}

  logout(){
    localStorage.clear();
    this.router.navigateByUrl("/login");
  }
}
