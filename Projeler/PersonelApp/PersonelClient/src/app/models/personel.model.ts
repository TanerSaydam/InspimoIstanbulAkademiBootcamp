export class PersonelModel{
    id: string = "";
    avatar: any | string | null;
    firstName: string = "";
    lastName: string = "";
    startDate: string | null = "";
    salary: number = 0;
    phoneNumber: string = "";
    email: string = "";
    city: string = "";
    district: string = "";
    fullAddress: string = "";
    cv: string = "";
    certificates: string[] = [];
    diploma: string = "";
    healtReport: string = "";  
    avatarFile:any | null = null;  
    cvFile:any | null = null;  
    certificatedFile:any | null = null;  
    diplomaFile:any | null = null;  
    healtReportFile:any | null = null;  
}