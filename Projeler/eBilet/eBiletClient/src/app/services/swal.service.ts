import { Injectable } from '@angular/core';
import Swal from 'sweetalert2'
@Injectable({
  providedIn: 'root'
})
export class SwalService {

  constructor() { }

  showToast(title: string | null, icon: SweetAlertIcon = "success"){
     const Toast = Swal.mixin({
       toast: true,
       position: 'bottom-end',
       timer: 3000,
       timerProgressBar: true,
       showConfirmButton: false
     })
     Toast.fire(title ?? '', '', icon)
  }

  showSwal(title: string, callBack: ()=> void){
    Swal.fire({
      title: title,
      showConfirmButton: true,
      confirmButtonText: "Delete",
      showCancelButton: true,
      cancelButtonText: "Cancel", 
      icon: "question"     
    }).then(res=> {
      if(res.isConfirmed){
        callBack();
      }
    })
  }
}

export type SweetAlertIcon = 'success' | 'error' | 'warning' | 'info' | 'question'
