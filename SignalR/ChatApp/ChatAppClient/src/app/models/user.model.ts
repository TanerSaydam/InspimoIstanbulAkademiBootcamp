export class UserModel{
    id: number = 0;
    fullName: string  ="";
    userName: string = "";
    avatarUrl: string = "";
    file:any;
    status: {name: string, value: number} = {
        name: "offline",
        value: 1
    }
}