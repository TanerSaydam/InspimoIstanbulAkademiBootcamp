import { Component, ElementRef, ViewChild } from '@angular/core';
import { RoutePipe } from '../../pipes/route.pipe';
import { CommonModule, DatePipe } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';
import { FormValidateDirective } from 'form-validate-angular';
import { RouteModel } from '../../models/route.model';
import { BusModel } from '../../models/bus.model';
import { HttpService } from '../../services/http.service';
import { SwalService } from '../../services/swal.service';

@Component({
  selector: 'app-routes',
  standalone: true,
  imports: [CommonModule, FormsModule, FormValidateDirective,RoutePipe],
  templateUrl: './routes.component.html',
  styleUrl: './routes.component.css',
  providers: [DatePipe]
})
export class RoutesComponent {
  routes: RouteModel[] = [];
  buses: BusModel[] = [];

  addModel: RouteModel = new RouteModel();
  updateModel: RouteModel = new RouteModel();

  search: string = "";

  @ViewChild("addModalCloseBtn") addModalCloseBtn: ElementRef<HTMLButtonElement> | undefined;
  @ViewChild("updateModalCloseBtn") updateModalCloseBtn: ElementRef<HTMLButtonElement> | undefined;

  constructor(
    private http: HttpService,
    private swal: SwalService,
    private date: DatePipe
  ){
    this.addModel.date = date.transform(new Date(), "yyyy-MM-dd HH:mm") ?? ""
  }

  ngOnInit(): void {
    this.getAll();
    this.getAllBus();
  }

  getAll(){
    this.http.post<RouteModel[]>("Routes/GetAll", {}, res=> {      
      this.routes = res.value ?? [];
    });
  }

  getAllBus(){
    this.http.post<BusModel[]>("Buses/GetAll", {}, res=> {      
      this.buses = res.value ?? [];
    });
  }

  create(form: NgForm){
    if(form.valid){ 
      this.http.post<string>("Routes/Create", this.addModel,(res)=> {
        this.swal.showToast(res.value);
        this.addModel = new RouteModel();
        this.addModel.date = this.date.transform(new Date(), "yyyy-MM-dd HH:mm") ?? ""

        this.addModalCloseBtn?.nativeElement.click();
        this.getAll();
      });
    }
  }

  deleteById(id:string){
    this.swal.showSwal("You want to delete this route?",()=> {
      this.http.post<string>("Routes/DeleteById",{id: id}, res=> {
        this.swal.showToast(res.value,"info");
        this.getAll();
      });
    })
  }

  get(model: RouteModel){
    this.updateModel = {...model};
    this.updateModel.date = this.date.transform(this.updateModel.date, "yyyy-MM-dd HH:mm") ?? ""
  }

  update(form: NgForm){
    if(form.valid){
      this.http.post<string>("Routes/Update", this.updateModel,res=> {
        this.swal.showToast(res.value, "info");
        this.updateModalCloseBtn?.nativeElement.click();
        this.getAll();
      });
    }
  }
}
