import { Component, OnInit, Input } from '@angular/core';
import {ShippmentModel} from '../shared/model/shippment.model';

@Component({
  selector: 'app-thankyou',
  templateUrl: './thankyou.component.html',
  styleUrls: ['./thankyou.component.css']
})
export class ThankyouComponent implements OnInit {
  model: ShippmentModel
  constructor() { }

  ngOnInit() {
    this.model = <ShippmentModel>history.state.data;
  }
}
