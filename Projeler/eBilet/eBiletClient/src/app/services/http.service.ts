import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { api } from '../constants';
import { ErrorService } from './error.service';
import { ResultModel } from '../models/result.model';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(
    private http: HttpClient,
    private error:ErrorService
  ) { }

  post<T>(endpoint: string, data:any, callBack: (res:any)=> void){
    this.http.post<ResultModel<T>>(`${api}/${endpoint}`, data).subscribe({
        next: (res: any)=> {
          callBack(res);
        },
        error: (err: HttpErrorResponse)=> {
          this.error.errorHandler(err);
        }
    })
  }
}
