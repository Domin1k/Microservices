import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { FoodComponent } from './food/food.component';
import { FoodDetailComponent } from './food-detail/food-detail.component';
import {HomeComponent} from './home/home.component';
import { CartComponent } from './cart/cart.component';
import { AuthGuardService } from './services/auth-guard.service';
import { FoodResolver } from './services/resolvers/food.resolver';
import { AnonymousGuardService } from './services/anonymous-guard.service';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'auth/login', component: LoginComponent, canActivate: [AnonymousGuardService] },
  { path: 'auth/register', component: RegisterComponent, canActivate: [AnonymousGuardService] },
  { path: 'foods/details/:id', component: FoodDetailComponent },
  { path: 'foods/:id/brands', component: FoodComponent, resolve: {resolvedFoods: FoodResolver } },
  { path: 'cart', component: CartComponent, canActivate: [AuthGuardService] },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }