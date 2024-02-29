import { ProfessionModel } from "./profession.model";

export class PersonelModel{
    id: string = "";
    firstName: string = "";
    lastName: string = "";
    fullName: string = "";
    identityNumber:string = "";
    startDate: string | null = "";
    salary: number = 17002;
    phoneNumber: string = "";
    email: string = "";
    city: string = "Select...";
    district: string = "Select...";
    fullAddress: string = "";
    avatarUrl: any | string | null;
    cvUrl: string = "";
    certificateFileUrls: string[] = [];    
    diplomaUrl: string = "";
    healthReportUrl: string = "";  
    avatarFile:any | null = null;  
    cvFile:any | null = null;  
    certificatesFile:any | null = null;  
    diplomaFile:any | null = null;  
    healthReportFile:any | null = null;  
    professionId: string = "";
    profession: ProfessionModel = new ProfessionModel();
    professionName: string = "";
}