import { Pipe, PipeTransform } from '@angular/core';
import { BusModel } from '../models/bus.model';

@Pipe({
  name: 'bus',
  standalone: true
})
export class BusPipe implements PipeTransform {

  transform(value: BusModel[], search: string): BusModel[] {
    if(search === "") return value;

    return value.filter(x => 
      x.brand.toLocaleLowerCase().includes(search.toLocaleLowerCase()) ||
      x.plate.toLocaleLowerCase().includes(search.toLocaleLowerCase()) ||
      x.model.toString().includes(search));
  }
}
