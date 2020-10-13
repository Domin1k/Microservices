import { PetFoodModel } from "./petFood-food.model";

export interface CartModel {
    items: Array<PetFoodModel>;
    totalPrice: number;
}