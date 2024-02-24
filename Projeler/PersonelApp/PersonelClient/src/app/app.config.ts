import { ApplicationConfig, importProvidersFrom } from '@angular/core';
import { provideRouter } from '@angular/router';
import { provideAnimations } from '@angular/platform-browser/animations';

import { routes } from './app.routes';
import { provideToastr } from 'ngx-toastr';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { provideEnvironmentNgxMask } from 'ngx-mask';
import { IConfig } from 'ngx-mask'
import { provideHttpClient } from '@angular/common/http';

const maskConfig: Partial<IConfig> = {
  validation: false,
};

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    provideAnimations(),  
    provideHttpClient(),
    provideEnvironmentNgxMask(maskConfig),
    provideToastr({
      closeButton: true,
      progressBar: true,
      positionClass: "toast-bottom-right"
    }),
    importProvidersFrom(SweetAlert2Module.forRoot())
  ]
};
