import { CommonModule, DatePipe } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterOutlet } from '@angular/router';
import * as signalR from '@microsoft/signalr';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, FormsModule, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  chat = new ChatModel();
  chats: ChatModel[] = [];
  hub: signalR.HubConnection | undefined;

  constructor(
    private http: HttpClient,
  ){
    this.getAll();
    this.hub = new signalR.HubConnectionBuilder().withUrl("https://localhost:7248/chat-hub").build();

    this.hub.start().then(()=> {
      console.log("Connection is started...");
      this.hub?.on("Message", (res:ChatModel)=> {
        this.chats.push(res);
      })
    })
    
  }

  getAll(){
    this.http.get<ChatModel[]>("https://localhost:7248/api/Chats/GetAll").subscribe(res=> {
      this.chats = res;
    });
  }

  send(){
    this.http.post("https://localhost:7248/api/Chats/Send", this.chat).subscribe(()=> {
      this.chat = new ChatModel();
    });
  }
}

export class ChatModel{
  userName: string = "";
  message: string = "";
  date: string = "";
}
