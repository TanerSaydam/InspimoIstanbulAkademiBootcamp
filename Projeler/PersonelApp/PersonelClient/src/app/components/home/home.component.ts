import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { PersonelModel } from '../../models/personel.model';
import { CommonModule, DatePipe } from '@angular/common';
import { TrCurrencyPipe } from 'tr-currency';
import { FormsModule, NgForm } from '@angular/forms';
import { NgxDropzoneModule } from 'ngx-dropzone';
import { OnlyNumbersDirective } from '../../directives/only-numbers.directive';
import { Cities, Districts } from '../../constants';
import { NgSelectModule } from '@ng-select/ng-select';
import { FormValidateDirective } from 'form-validate-angular';
import { SwalService } from '../../services/swal.service';
import { NgxMaskDirective, NgxMaskPipe } from 'ngx-mask';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, TrCurrencyPipe, FormsModule, NgxDropzoneModule, OnlyNumbersDirective, NgSelectModule, FormValidateDirective, NgxMaskDirective, NgxMaskPipe],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
  providers: [DatePipe]
})
export class HomeComponent implements OnInit {
  data: PersonelModel[] = [];

  cities = Cities;
  districts: { id: number, city: string, name: string }[] = [];

  addModel: PersonelModel = new PersonelModel();

  @ViewChild("avatarFile") avatarFile: ElementRef<HTMLInputElement> | undefined;
  @ViewChild("addModalCloseBtn") addModalCloseBtn: ElementRef<HTMLButtonElement> | undefined;

  constructor(
    private date: DatePipe,    
    private swal: SwalService,
    private http: HttpClient) {    
    this.addModel.avatarUrl = "https://cdn3.iconfinder.com/data/icons/file-and-folder-fill-icons-set/144/File_Upload-512.png";
    this.addModel.startDate = this.date.transform(new Date(), "yyyy-MM-dd");    
  }

  ngOnInit(): void {
    this.getAll();
  }

  getAll(){
    this.http.get("https://localhost:7295/api/Personels/GetAll").subscribe({
      next: (res:any)=> {
        this.data = res;
      },
      error: (err: HttpErrorResponse) => {
        console.log(err);        
      }
    })
  }

  getDistrictByCity(event: any) {
    this.districts = Districts.filter(p => p.city === event.name)
  }

  openAvatarFileInput() {
    this.avatarFile?.nativeElement.click();
  }

  setAvatarImage(event: any) {
    this.addModel.avatarFile = event.target.files[0];

    const reader = new FileReader();

    // Arrow function, `this`'in bulunduğu bağlamı korur
    reader.onload = (e) => {
      console.log(e);
      // FileReader'ın okuma işlemi tamamlandığında avatar'ı güncelle
      this.addModel.avatarUrl = e.target?.result;
    };

    reader.readAsDataURL(this.addModel.avatarFile);
  }

  setCVFile(event: any) {
    this.addModel.cvFile = event.addedFiles[0];
  }

  removeCVFile(event: any) {
    this.addModel.cvFile = undefined;
  }

  setCertificatesFile(event: any) {
    this.addModel.certificatesFile = event.addedFiles;    
  }

  removeCertificatesFile(event: any) {
    this.addModel.certificatesFile.splice(this.addModel.certificatesFile.indexOf(event), 1);
  }

  setDiplomaFile(event: any) {
    this.addModel.diplomaFile = event.addedFiles[0];
  }

  removeDiplomaFile(event: any) {
    this.addModel.diplomaFile = undefined;
  }

  setHealthFile(event: any) {
    this.addModel.healthReportFile = event.addedFiles[0];
  }

  removeHealthFile(event: any) {
    this.addModel.healthReportFile = undefined;
  }

  add(form: NgForm) {
    if (!form.valid) {
      //Validation Check
      this.addModel.salary = +this.addModel.salary.toString().replace(",", ".");   

      if (+this.addModel.salary < 17002) {
        this.swal.callToast("Salary must be greater then 17.002,00 ₺","error");        
        return;
      }

      if (this.addModel.city == "Select...") {
        this.swal.callToast("You must select a city","error");        
        return;
      }

      if (this.addModel.district == "Select...") {
        this.swal.callToast("You must select a district","error");       
        return;
      }
      //Validation Check

      //FormData oluşturma
      const formData = new FormData();
      formData.append("firstName",this.addModel.firstName);
      formData.append("lastName",this.addModel.lastName);
      formData.append("identityNumber",this.addModel.identityNumber);
      formData.append("startDate",this.addModel.startDate ?? "");
      formData.append("salary",this.addModel.salary.toString());
      formData.append("phoneNumber",this.addModel.phoneNumber);
      formData.append("email",this.addModel.email);
      formData.append("city",this.addModel.city);
      formData.append("district",this.addModel.district);
      formData.append("fullAddress",this.addModel.fullAddress);

      if(this.addModel.avatarFile !== null){
        formData.append("avatarFile",this.addModel.avatarFile,this.addModel.avatarFile.name);
      }
      
      if(this.addModel.cvFile !== null){
        formData.append("cvFile",this.addModel.cvFile,this.addModel.cvFile.name);
      }
      
      if(this.addModel.diplomaFile !== null){
        formData.append("diplomaFile",this.addModel.diplomaFile,this.addModel.diplomaFile.name);
      }
      
      if(this.addModel.healthReportFile !== null){
        formData.append("healthReportFile",this.addModel.healthReportFile,this.addModel.healthReportFile.name);
      }
      

      if(this.addModel.certificatesFile !== null){
        for(let certificate of this.addModel.certificatesFile){
          formData.append("certificateFiles",certificate,certificate.name);
        }   
      }
      

      this.http.post("https://localhost:7295/api/Personels/Create",formData)
      .subscribe({
        next: (res:any)=> {
          this.addModalCloseBtn?.nativeElement.click();
          this.getAll();
          this.swal.callToast(res.message);
          this.addModel = new PersonelModel();
          this.addModel.startDate = this.date.transform(new Date(), "yyyy-MM-dd");     
          this.addModel.avatarUrl = "https://cdn3.iconfinder.com/data/icons/file-and-folder-fill-icons-set/144/File_Upload-512.png";     
        },
        error: (err: HttpErrorResponse)=> {
          if(err.status === 500){
            this.swal.callToast(err.error.Message,"error");
          }else if(err.status === 400){
            var errorMessage = "";
            for(let index in err.error.errors){
              const errorMessages = err.error.errors[index];
              for(let messageIndex in errorMessages){
                errorMessage += errorMessages[messageIndex] + "\n";                
              }
            }

            this.swal.callToast(errorMessage, "error");
          }
          console.log(err);          
        }
      });
    }
  }
}
