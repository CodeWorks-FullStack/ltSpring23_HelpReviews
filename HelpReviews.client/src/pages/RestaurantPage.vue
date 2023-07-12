<template>
  <div class="restaurant-page" v-if="restaurant">
    <h1>{{ restaurant.name }}</h1>
    <div>
      {{ restaurant.category }}
    </div>
    <article>{{ restaurant.description }}</article>
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
      restaurant: computed(() => AppState.restaurant)
    }
  }
}
</script>
