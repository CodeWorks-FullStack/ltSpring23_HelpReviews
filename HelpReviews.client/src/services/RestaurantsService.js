import { AppState } from "../AppState.js"
import { Restaurant } from "../models/Restaurant.js"
import { api } from "./AxiosService.js"

const URI = 'api/restaurants/'

class RestaurantsService {

  async getAll() {
    const res = await api.get(URI)

    AppState.restaurants = res.data.map(r => new Restaurant(r))
  }

  async getRestaurant(id) {
    AppState.restaurant = null
    const res = await api.get(URI + id)
    AppState.restaurant = new Restaurant(res.data)
  }

  async create(restaurantData) {
    const res = await api.post(URI, restaurantData)
    AppState.restaurants.push(new Restaurant(res.data))
  }


  async createReport(reportData) {
    const res = await api.post('/api/reports', reportData)
    AppState.myReports.push(res.data)

    // just to fix reactivity
    AppState.restaurants.find(r => r.id == reportData.restaurantId).reportCount++

  }

  async getReportsByRestaurantId(id) {
    AppState.restaurantReports = []
    const res = await api.get(URI + id + '/reports')
    AppState.restaurantReports = res.data
  }

}


export const restaurantsService = new RestaurantsService()