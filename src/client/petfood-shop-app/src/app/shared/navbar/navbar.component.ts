import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PetFoodCategoryModel } from '../model/petFood-category.model';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  token: string;
  categories: Array<PetFoodCategoryModel>;
  constructor(private router: Router) { }

  ngOnInit(): void {
    this.getToken()
  }

  getToken() {
    this.token = localStorage.getItem('token')
  }

  route(param) {
    console.log(param)
    this.router.navigate([param])
  }

  logout() {
    localStorage.removeItem('token')
    this.getToken()
    this.router.navigate(['auth/login'])
  }
}
