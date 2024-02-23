import { Component, ElementRef, ViewChild } from '@angular/core';
import { PersonelModel } from '../../models/personel.model';
import { CommonModule, DatePipe } from '@angular/common';
import { TrCurrencyPipe } from 'tr-currency';
import { FormsModule, NgForm } from '@angular/forms';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, TrCurrencyPipe, FormsModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
  providers: [DatePipe]
})
export class HomeComponent {
    data:PersonelModel[] = [
      {
        firstName: "Taner",
        lastName: "Saydam",
        avatar: "https://img.freepik.com/free-vector/businessman-character-avatar-isolated_24877-60111.jpg?size=338&ext=jpg&ga=GA1.1.1700460183.1708646400&semt=ais",
        certificates: [
          "https://tanersaydam.net/assets/cv.pdf",
          "https://tanersaydam.net/assets/cv.pdf",
          "https://tanersaydam.net/assets/cv.pdf"],
        city: "Kayseri",
        cv: "https://tanersaydam.net/assets/cv.pdf",
        diploma: "https://tanersaydam.net/assets/cv.pdf",
        district: "Kocasinan",
        email: "tanersaydam@gmail.com",
        fullAddress: "Kayseri",
        healtReport: "https://tanersaydam.net/assets/cv.pdf",
        id: "id",
        phoneNumber: "+90(554) 654 8006",
        salary: 50000,
        startDate: "02.23.2024",
        avatarFile: null,
        certificatedFile: null,
        cvFile: null,
        diplomaFile: null,
        healtReportFile: null
      }
    ];

    addModel: PersonelModel = new PersonelModel();

    @ViewChild("avatarFile") avatarFile: ElementRef<HTMLInputElement> | undefined;
    @ViewChild("cvFile") cvFile: ElementRef<HTMLInputElement> |undefined;

    constructor(private date: DatePipe){
      this.addModel.avatar = "/assets/upload.jpeg";
      this.addModel.startDate = this.date.transform(new Date(), "yyyy-MM-dd");
    }

    openAvatarFileInput(){
      this.avatarFile?.nativeElement.click();
    }

    setAvatarImage(event:any) {
      this.addModel.avatarFile = event.target.files[0];
      
      const reader = new FileReader();
    
      // Arrow function, `this`'in bulunduğu bağlamı korur
      reader.onload = (e) => {
        console.log(e);
        // FileReader'ın okuma işlemi tamamlandığında avatar'ı güncelle
        this.addModel.avatar = e.target?.result;
      };
    
      reader.readAsDataURL(this.addModel.avatarFile);
    }

    openCVFile(){
      this.cvFile?.nativeElement.click();
    }

    setCVFile(event:any){
      this.addModel.cvFile = event.target.files[0];
    }

    add(form: NgForm){
      console.log(form);      
    }
}
