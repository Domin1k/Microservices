import { Injectable, EventEmitter } from '@angular/core';


@Injectable({
    providedIn: 'root'
})
export class PriceChangedEvent {
    priceChanged = new EventEmitter();
}