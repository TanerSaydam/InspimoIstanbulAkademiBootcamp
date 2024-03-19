import { CommonModule } from '@angular/common';
import { AfterViewInit, Component, ElementRef, Renderer2, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
  encapsulation: ViewEncapsulation.None
})
export class HomeComponent implements AfterViewInit {
  
  routes:any[] = [1,2,3,4,5]

  constructor(
    private renderer: Renderer2, 
    private el: ElementRef
  ){}

  ngAfterViewInit(): void {
    for(let index in this.routes){
      const btnEl = document.getElementById("buyTicketBtn-" + index);
      if(btnEl !== null){
        this.renderer.setAttribute(btnEl, 'data-bs-target', `#detail${index}`);
      }
    }
  }
}
