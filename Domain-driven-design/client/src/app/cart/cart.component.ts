import { Component, OnInit } from '@angular/core';
import { CartModel } from '../shared/model/cart.model';
import { CartService } from '../services/cart.service';
import { PetFoodModel } from '../shared/model/petFood-food.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CheckoutModel } from '../shared/model/checkout.model';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { PriceChangedEvent } from '../shared/events/priceChanged.event';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  cart: CartModel;
  cartForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private cartService: CartService,
    private router: Router,
    private toastr: ToastrService,
    private event: PriceChangedEvent) {
      this.cartForm = this.fb.group({
        'deliveryAddress': ['', Validators.required]
      })
  }

  ngOnInit() {
    this.updateComponent();
    this.event.priceChanged.subscribe((eventData) => {
      const food = this.cartService.getProductFromCart(eventData.foodId);
      if (food) {
        this.cartService.recalculateCart(food, eventData);
        this.updateComponent();
        this.toastr.warning('Price of some of the products in your cart was updated!', 'Cart');
      }
    });
  }

  removeFromCart(item: PetFoodModel) {
    this.cartService.removeFromCart(item);
    this.updateComponent();
  }

  checkout() {
    const cartItems = this.cartService.getCartItems();

    const model: CheckoutModel = {
      cart: cartItems.items.map((c) => ({
        productId: c.id,
        productName: c.name,
        productQuantity: c.quantity,
        price: c.price
      })),
      deliveryAddress: this.cartForm.controls['deliveryAddress'].value
    }

    this.cartService.checkout(model).subscribe((res) => {
      this.cartService.clearCart();
      this.router.navigate(['/thank-you'], { state: { data: res } });
      this.toastr.success('Thank you for your purchase', 'Cart');
    });
  }

  updateComponent() {
    this.cart = this.cartService.getCartItems();
  }

  clearCart() {
    this.cartService.clearCart();
    this.updateComponent();
  }
}
