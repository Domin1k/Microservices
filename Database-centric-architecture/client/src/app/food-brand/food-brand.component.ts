import { Component, OnInit, Input } from '@angular/core';
import { PetFoodCategoryBrand } from '../shared/model/petFood-categoryBrand.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-food-brand',
  templateUrl: './food-brand.component.html',
  styleUrls: ['./food-brand.component.css']
})
export class FoodBrandComponent implements OnInit {
  @Input() foodBrands: Array<PetFoodCategoryBrand>;
  constructor(private router: Router) { }

  ngOnInit() {
  }

  goToBrandFoods(brandId: number) {
    this.router.navigate([`foods/${brandId}/brands`])
  }
}
