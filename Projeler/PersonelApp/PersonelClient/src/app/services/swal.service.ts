import { Injectable } from '@angular/core';
import Swal from 'sweetalert2';

@Injectable({
  providedIn: 'root'
})
export class SwalService {

  constructor() { }

  callToast(message: string, type: SweetAlertIcon = "success"){
    const Toast = Swal.mixin({
      toast: true,
      position: 'bottom-end',
      timer: 3000,
      timerProgressBar: true,
      showConfirmButton: false,
    })
    Toast.fire(message, '', type)
  }
}

export type SweetAlertIcon = 'success' | 'error' | 'warning' | 'info' | 'question'