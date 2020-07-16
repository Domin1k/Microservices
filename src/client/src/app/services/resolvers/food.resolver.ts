import { PetFoodModel } from "../../shared/model/petFood-food.model";

import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PetFoodFoodService } from "../pet-food-food.service";


@Injectable({ providedIn: 'root' })
export class FoodResolver implements Resolve<PetFoodModel> {
  constructor(private service: PetFoodFoodService) {}

  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<any>|Promise<any>|any {
    return this.service.getFoodPerBrand(route.params['id']);
  }
}