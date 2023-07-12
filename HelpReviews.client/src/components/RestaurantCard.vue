<template>
  <div class="restaurant-card card bg-dark">
    <div class="card-body">
      <p>
        <b>
          <router-link class="text-light" :to="{ name: 'Restaurant', params: { id: restaurant.id } }">
            {{ restaurant.name }}
          </router-link>
        </b>
      </p>

    </div>


  </div>
</template>


<script>
import { Restaurant } from '../models/Restaurant.js';

export default {
  props: {
    restaurant: { type: Restaurant, required: true }
  },
  setup() {

    return {}
  }
}
</script>


<style lang="scss" scoped></style>