import { Review } from './../contracts/review';
import { ItemList } from './../contracts/item-list';
import { ApiEndpoints } from './../api-endpoints';
import { Observable } from 'rxjs';

import { ListItem } from './../../shared/models/list-item';
import { Injectable } from '@angular/core';
import { ApiService } from '../api.service';
import { Restaurant } from "../contracts/restaurant";

@Injectable()
export class ReviewsListService {

  constructor(
    private apiService: ApiService
  ) { }

    getReviewsList(restaurantName?: string, search?: string): Observable<ItemList<Review>> {
    const parameters = {
      'restaurantName': restaurantName,
      'search': search,
    };
    const url = ApiEndpoints.reviews().listUrl(parameters);
    return this.apiService.get<ItemList<Review>>(url);
  }

  getRestaurantsList(): Observable<ItemList<Restaurant>> {
    const url = ApiEndpoints.restaurants().listUrl();
    return this.apiService.get<ItemList<Restaurant>>(url);
  }

  updateReview(review: Review) {
    if (review.id) {
      const url = ApiEndpoints.reviews().itemUrl(review.id);
      return this.apiService.put<Review>(url, review);
    } else {
      const url = ApiEndpoints.reviews().listUrl();
      return this.apiService.post<Review>(url, review);
    }
  }

}
