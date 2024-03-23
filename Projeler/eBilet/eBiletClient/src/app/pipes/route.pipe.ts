import { Pipe, PipeTransform } from '@angular/core';
import { RouteModel } from '../models/route.model';

@Pipe({
  name: 'route',
  standalone: true
})
export class RoutePipe implements PipeTransform {

  transform(value: RouteModel[], search: string): RouteModel[] {
    if(search === "") return value;

    return value.filter(p=> 
      p.from.toLocaleLowerCase().includes(search.toLocaleLowerCase()) ||
      p.to.toLocaleLowerCase().includes(search.toLocaleLowerCase()) ||
      p.bus.brand.toLocaleLowerCase().includes(search.toLocaleLowerCase()) ||
      p.bus.plate.toLocaleLowerCase().includes(search.toLocaleLowerCase()) ||
      p.date.includes(search));
  }

}
