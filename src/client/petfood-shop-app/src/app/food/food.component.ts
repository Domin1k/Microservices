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
  
  constructor(private ar: ActivatedRoute) {}


  ngOnInit() {
    this.ar.data.subscribe(res => {
      this.foods = res.resolvedFoods;
    })
  }
}
