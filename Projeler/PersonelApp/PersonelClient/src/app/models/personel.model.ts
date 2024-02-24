export class PersonelModel{
    id: string = "";
    avatar: any | string | null;
    firstName: string = "";
    lastName: string = "";
    startDate: string | null = "";
    salary: number = 17002;
    phoneNumber: string = "";
    email: string = "";
    city: string = "Select...";
    district: string = "Select...";
    fullAddress: string = "";
    cv: string = "";
    certificates: string[] = [];
    diploma: string = "";
    healtReport: string = "";  
    avatarFile:any | null = null;  
    cvFile:any | null = null;  
    certificatesFile:any | null = null;  
    diplomaFile:any | null = null;  
    healthReportFile:any | null = null;  
}