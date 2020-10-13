export interface CheckoutModel {
    cart: Array<CartDetailModel>;
    deliveryAddress: string;
}

export interface CartDetailModel {
    productId: number;
    productName: string;
    productQuantity: number;
    price: number;
} 