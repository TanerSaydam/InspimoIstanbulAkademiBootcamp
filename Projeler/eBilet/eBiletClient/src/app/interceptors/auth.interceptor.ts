import { HttpInterceptorFn } from '@angular/common/http';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  
  const token: string = localStorage.getItem("token") ?? "";

  const cloneReq = req.clone({
    headers: req.headers.set("Authorization", "Bearer " + token)
  });
  return next(cloneReq);
};
