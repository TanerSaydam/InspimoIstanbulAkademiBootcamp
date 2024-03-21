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
  selectedSeat: number = 0;

  routes:any[] = [1,2,3,4,5]
  rows:any[] = []  
  constructor(
    private renderer: Renderer2, 
    private el: ElementRef
  ){
    let seatNumberCount = 0;
    for (let i = 1; i <= 12; i++) { 
      let seats = [];        
      for (let z = 5; z >= 1; z--) {
        if(z === 2 || z === 3){
          const emptyData = {
            num: -1,
            isNoSeat:true
          };
          seats.push(emptyData);
        }else{
          seatNumberCount++;
          const data = {
            num: seatNumberCount,
            isNoSeat:false,
            isAvailable: seatNumberCount % 3 ? true : false,
            isFemale: seatNumberCount % 2 ? true : false,
            isSelected: false
          }
          seats.push(data);
        }        
      }   

      seats = seats.sort((a,b)=> {
        if(a.num === -1) return -1;
        if ( a.num < b.num ){
          return 1;
        }
        if ( a.num > b.num ){
          return -1;
        }
        return 0;
      })

      this.rows.push({seats: seats});
    }  
    
    console.log(this.rows);
    
  }

  ngAfterViewInit(): void {
    for(let index in this.routes){
      const btnEl = document.getElementById("buyTicketBtn-" + index);
      if(btnEl !== null){
        this.renderer.setAttribute(btnEl, 'data-bs-target', `#detail${index}`);
      }
    }
  }
    
  selectSeat(seat:any){
    for(let row of this.rows){
      for(let data of row.seats){
        data.isSelected = false;
      }
    }

    seat.isSelected = true;    
  }

  paintFullSeatByGender(seat:any){
    if(seat.isFemale) {
      return "full-female"
    }

    return "full-male";
  }
}
