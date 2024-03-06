import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-professions',
  standalone: true,
  imports: [],
  templateUrl: './professions.component.html',
  styleUrl: './professions.component.css'
})
export class ProfessionsComponent {
constructor(
  private auth: AuthService
){
  //this.auth.isAuthorized("Professions.GetAll");
}
}
