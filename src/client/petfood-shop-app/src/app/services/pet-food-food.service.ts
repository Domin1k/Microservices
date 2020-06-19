import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import {PetFoodModel} from '../shared/model/petFood-food.model';

@Injectable({
  providedIn: 'root'
})
export class PetFoodFoodService {
  private path = environment.apiUrl + 'foods';
  constructor(private http: HttpClient) { }

  getFoodPerBrand(brandId: number): Observable<Array<PetFoodModel>> {
      return this.http.get<Array<PetFoodModel>>(`${this.path}/${brandId}/brands`);
  }

  getFoodDetails(foodId: number) : Observable<PetFoodModel> {
    return this.http.get<PetFoodModel>(`${this.path}/${foodId}`);
  }
}
