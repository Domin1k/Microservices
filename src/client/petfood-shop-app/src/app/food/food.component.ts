import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PetFoodModel } from '../shared/model/petFood-food.model';

@Component({
  selector: 'app-food',
  templateUrl: './food.component.html',
  styleUrls: ['./food.component.css']
})
export class FoodComponent implements OnInit {
  foods: Array<PetFoodModel>;
  token: string;
  constructor(private ar: ActivatedRoute) {}


  ngOnInit() {
    this.ar.data.subscribe(res => {
      this.foods = res.resolvedFoods;
    })
    this.getToken();
  }

  getToken() {
    this.token = localStorage.getItem('token')
  }
}
