import { Injectable } from '@angular/core';
import { PetFoodModel } from '../shared/model/petFood-food.model';
import { CartModel } from '../shared/model/cart.model';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { CheckoutModel } from '../shared/model/checkout.model';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  private path = environment.apiUrl + 'cart';
  cartKey: string;
  
  constructor(private http: HttpClient) {
    this.cartKey = 'cart';
  }

  checkout(data: CheckoutModel) {
    return this.http.post<CartModel>(`${this.path}/checkout`, data);
  }

  addToCart(data: PetFoodModel) {
    let food = data;
    if (!food) {
      return;
    }

    let cart: CartModel = JSON.parse(localStorage.getItem(this.cartKey));
    if (cart) {
      if (!cart.items.some(p => p.id == food.id)) {
        cart = this.addNew(cart, food);
      }
    } else {
      cart = this.addNew(cart, food);
    }
    cart.totalPrice += food.price;

    localStorage.setItem(this.cartKey, JSON.stringify(cart))
  }

  removeFromCart(food: PetFoodModel) {
    let cart: CartModel = JSON.parse(localStorage.getItem(this.cartKey));
    cart.items = cart.items.filter(x => x.id !== food.id);
    cart.totalPrice = cart.totalPrice - food.price;
    localStorage.setItem(this.cartKey, JSON.stringify(cart));
  }

  getCartItems(): CartModel {
    return JSON.parse(localStorage.getItem(this.cartKey)) || {
      items: [],
      totalPrice: 0
    };
  }

  clearCart() {
    localStorage.removeItem(this.cartKey);
  }

  addNew(cart, food) {
    if (!cart) {
      cart = {
        items: [],
        totalPrice: 0
      };;
    }
    cart.items.push(food);
    return cart;
  }
}
