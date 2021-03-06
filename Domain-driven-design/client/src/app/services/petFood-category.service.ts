import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { PetFoodCategoryModel} from '../shared/model/petFood-category.model';
import { PetFoodCategoryBrand } from '../shared/model/petFood-categoryBrand.model';

@Injectable({
    providedIn: 'root'
})
export class PetFoodCategoryService {
    private path = environment.gatewayUrl + 'categories';
    constructor(private http: HttpClient) { }

    getAll(): Observable<Array<PetFoodCategoryModel>> {
        return this.http.get<Array<PetFoodCategoryModel>>(`${this.path}/all`);
    }

    getCategoryBrands(categoryId: number): Observable<PetFoodCategoryBrand> {
        return this.http.get<PetFoodCategoryBrand>(`${this.path}/${categoryId}/brands`);
    }
}