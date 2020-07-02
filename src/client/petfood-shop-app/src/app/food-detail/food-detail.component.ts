import { Component, OnInit } from '@angular/core';
import { PetFoodFoodService } from '../services/pet-food-food.service';
import { ActivatedRoute, Route, Router, NavigationStart } from '@angular/router';
import { PetFoodModel } from '../shared/model/petFood-food.model';
import { CartService } from '../services/cart.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-food-detail',
  templateUrl: './food-detail.component.html',
  styleUrls: ['./food-detail.component.css']
})
export class FoodDetailComponent implements OnInit {
  food: PetFoodModel;

  constructor(
    private foodService: PetFoodFoodService,
    private cartService: CartService, 
    private route: ActivatedRoute,
    private toastr: ToastrService) { }

  ngOnInit() {
    this.foodService.getFoodDetails(this.route.snapshot.params['id']).subscribe(food => {
      this.food = food;
    })
  }

  addToCart(food: PetFoodModel) {
    this.cartService.addToCart(food);
    this.toastr.success('Successfully added food to cart', 'Food');
  }
}
