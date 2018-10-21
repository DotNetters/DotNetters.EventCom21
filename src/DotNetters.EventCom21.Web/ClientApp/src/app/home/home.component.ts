import { Component, OnInit } from '@angular/core';
import * as signalR from "@aspnet/signalr";
declare var jquery: any;
declare var $: any;

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {
    private _hubConnection: signalR.HubConnection;
    public async: any;
    tuser = '';
    message = '';
    messages: any[] = [];

    constructor() {
    }

    public sendMessage(): void {
        this._hubConnection.invoke('Send', this.tuser, this.message);
        //this.messages.unshift({ 'user': this.tuser, 'message': this.message, 'sentorreceived': 'Sent' });
    }

    ngOnInit() {
        this._hubConnection = new signalR.HubConnectionBuilder().withUrl("/messaging").build();

        this._hubConnection.on('Send', (user: string, message: string, dateStr: string) => {
          this.messages.unshift({ 'user': user, 'message': message, 'sentorreceived': 'Received', 'date': dateStr  });
        });

        this._hubConnection.start()
            .then(() => {
                console.log('Hub connection started')
            })
            .catch(err => {
                console.log('Error while establishing connection')
            });
    }
}
