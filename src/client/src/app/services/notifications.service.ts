import { Injectable, Output } from '@angular/core';
import * as signalR from "@aspnet/signalr";
import { ToastrService } from 'ngx-toastr';
import { environment } from '../../environments/environment';
import { EventEmitter } from 'events';
import { PriceChangedEvent } from '../shared/events/priceChanged.event';

@Injectable({
    providedIn: 'root'
})
export class NotificationsService {
    private hubConnection: signalR.HubConnection;
    private notificationsUrl = environment.notificationsUrl + 'notifications';
    @Output() eventData = new EventEmitter();

    constructor(private toastr: ToastrService, private event: PriceChangedEvent) { }

    public subscribe = () => {
        const options = {
            accessTokenFactory: () => {
                return localStorage.getItem('token');
            }
        };

        this.hubConnection = new signalR.HubConnectionBuilder()
            .withUrl(this.notificationsUrl, options)
            .build();

        this.hubConnection
            .start()
            .then(() => console.log('Connection started'))
            .catch(err => console.log('Error while starting connection: ' + err));

        this.hubConnection.on('ReceiveNotificationBrandAdded', (data) => {
            this.toastr.success(`Brand - ${data.brandName} added!`);
        });

        this.hubConnection.on('ReceiveNotificationPriceChanged', (data) => {
            this.event.priceChanged.emit(data);
        });
    }
}