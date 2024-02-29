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
    if(err.status === 0){
      this.swal.callToast("We cannot be reached API","error");
    }else if(err.status === 500){
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
}
