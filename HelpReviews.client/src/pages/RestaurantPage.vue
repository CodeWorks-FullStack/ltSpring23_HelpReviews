<template>
  <div class="restaurant-page" v-if="restaurant">
    <div class="container">
      <div class="row my-3">

        <aside class="col-md-3">
          <img class="img-fluid my-2" :src="restaurant.imgUrl" alt="">
          <h1>{{ restaurant.name }}</h1>
          <div>
            {{ restaurant.category }}
            <span title="exposure">
              <i class="mdi mdi-eye"></i>
              {{ restaurant.exposure }}
            </span>

            <span title="report">
              📜
              {{ reports.length }}
            </span>
          </div>
          <article>{{ restaurant.description }}</article>
        </aside>

        <aside class="col-md-8 col-md-offset-1">
          <RestaurantReportCard v-for="r in reports" :key="r.id" :report="r" />
        </aside>

      </div>
    </div>


  </div>
  <div v-else>loading....</div>
</template>

<script>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState.js';
import Pop from '../utils/Pop.js';
import { useRoute, useRouter } from 'vue-router';
import { restaurantsService } from '../services/RestaurantsService.js';
import { logger } from '../utils/Logger.js';


export default {
  setup() {

    const router = useRouter()
    const route = useRoute()

    async function getRestaurant() {
      try {
        restaurantsService.getRestaurant(route.params.id)
        restaurantsService.getReportsByRestaurantId(route.params.id)
      } catch (error) {
        logger.log(error)
        Pop.error('naw dawg that doesnt exist')
        router.push('/')
      }
    }


    onMounted(() => {
      getRestaurant()
    })


    return {
      restaurant: computed(() => AppState.restaurant),
      reports: computed(() => AppState.restaurantReports)
    }
  }
}
</script>
