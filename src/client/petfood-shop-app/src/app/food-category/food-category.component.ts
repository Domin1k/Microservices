import { Component, OnInit } from '@angular/core';
import { PetFoodCategoryModel } from '../shared/model/petFood-category.model';
import { PetFoodCategoryService } from '../services/petFood-category.service';
import { PetFoodCategoryBrand } from '../shared/model/petFood-categoryBrand.model';

@Component({
  selector: 'app-food-category',
  templateUrl: './food-category.component.html',
  styleUrls: ['./food-category.component.css']
})
export class FoodCategoryComponent implements OnInit {
  foodCategories: Array<PetFoodCategoryModel>;
  foodBrands: Array<PetFoodCategoryBrand>;
  constructor(private foodCategorySvc: PetFoodCategoryService) { }

  ngOnInit() {
    this.foodCategorySvc.getAll().subscribe(categories => {
      this.foodCategories = categories;
    });
  }

  getCategoryBrands(foodCategoryId: number) {
    this.foodCategorySvc.getCategoryBrands(foodCategoryId).subscribe(foodBrands => {
      this.foodBrands = foodBrands;
    });
  }
}
