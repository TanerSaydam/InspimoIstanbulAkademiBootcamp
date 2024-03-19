import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SwalService } from './swal.service';

@Injectable({
  providedIn: 'root'
})
export class ErrorService {

  constructor(
    private swal: SwalService
  ) { }

  errorHandler(err: HttpErrorResponse){
    console.log(err);    
    let errorMessage: string = "";
    if(err.status == 500){
      for(const index in err.error.errorMessages){
        const error = err.error.errorMessages[index];
        if(index + 1 === err.error.errorMessages.length){
          errorMessage += error;
        }else{
          errorMessage += error + "\n";
        }        
      }      
      this.swal.showToast(errorMessage,"error");
    }

  }
}