<template>
  <div class="home">

    <!-- LIST ALL RESTAURANTS HERE -->

    <div class="container">
      <div class="row my-3">
        <div class="col-md-4" v-for="r in restaurants" :key="r.id">
          <RestaurantCard :restaurant="r" />
        </div>
      </div>
    </div>



    <div class="container">
      <div class="row">
        <div class="col-md-6 m-auto">
          <RestaurantForm  class="bg-white elevation-2 p-3 rounded" />
        </div>
      </div>
    </div>



  </div>
</template>

<script>
import { computed, onMounted } from 'vue';
import Pop from '../utils/Pop.js';
import { restaurantsService } from '../services/RestaurantsService.js'
import { AppState } from '../AppState.js';


export default {
  setup() {

    async function getAllRestaurants() {
      try {
        restaurantsService.getAll()
      } catch (error) {
        Pop.error(error, '[GETTING RESTAURANTS]')
      }
    }


    onMounted(() => {
      getAllRestaurants()
    })



    return {

      restaurants: computed(() => AppState.restaurants)


    }
  }
}
</script>

<style scoped lang="scss">
.home {}
</style>
