import {PetFoodBrandModel} from './petFood-brand.model';

export interface PetFoodCategoryBrand {
    categoryId: number,
    totalFoods: number,
    brands: Array<PetFoodBrandModel>;
}