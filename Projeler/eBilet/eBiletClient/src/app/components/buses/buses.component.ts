import { CommonModule } from '@angular/common';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { FormValidateDirective } from 'form-validate-angular';
import { BusModel } from '../../models/bus.model';
import { HttpService } from '../../services/http.service';
import { SwalService } from '../../services/swal.service';
import { BusPipe } from '../../pipes/bus.pipe';

@Component({
  selector: 'app-buses',
  standalone: true,
  imports: [CommonModule, FormsModule, FormValidateDirective,BusPipe],
  templateUrl: './buses.component.html',
  styleUrl: './buses.component.css'
})
export class BusesComponent implements OnInit {
  buses: BusModel[] = [];
  addModel: BusModel = new BusModel();
  updateModel: BusModel = new BusModel();

  search: string = "";

  brands:string[] = [
    "Mercedes",
    "Renault",
    "BMW",
  ]

  @ViewChild("addModalCloseBtn") addModalCloseBtn: ElementRef<HTMLButtonElement> | undefined;
  @ViewChild("updateModalCloseBtn") updateModalCloseBtn: ElementRef<HTMLButtonElement> | undefined;

  constructor(
    private http: HttpService,
    private swal: SwalService
  ){}

  ngOnInit(): void {
    this.getAll();
  }

  getAll(){
    this.http.post<BusModel[]>("Buses/GetAll", {}, res=> {      
      this.buses = res.value ?? [];
    });
  }

  create(form: NgForm){
    if(form.valid){ 
      this.http.post<string>("Buses/Create", this.addModel,(res)=> {
        this.swal.showToast(res.value);
        this.addModel = new BusModel();
        this.addModalCloseBtn?.nativeElement.click();
        this.getAll();
      });
    }
  }

  deleteById(id:string){
    this.swal.showSwal("You want to delete this bus?",()=> {
      this.http.post<string>("Buses/DeleteById",{id: id}, res=> {
        this.swal.showToast(res.value,"info");
        this.getAll();
      });
    })
  }

  get(model: BusModel){
    this.updateModel = {...model};
  }

  update(form: NgForm){
    if(form.valid){
      this.http.post<string>("Buses/Update", this.updateModel,res=> {
        this.swal.showToast(res.value, "info");
        this.updateModalCloseBtn?.nativeElement.click();
        this.getAll();
      });
    }
  }
}
