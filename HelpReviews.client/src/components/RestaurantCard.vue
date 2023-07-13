<template>
  <div class="restaurant-card card bg-dark">
    <div class="card-body">
      <p>
        <b>
          <router-link class="text-light" :to="{ name: 'Restaurant', params: { id: restaurant.id } }">
            {{ restaurant.name }} - 📜 {{ restaurant.reportCount }}
          </router-link>
        </b>
      </p>
      <p><button @click="doTheEmit">emit example</button></p>
    </div>


  </div>
</template>


<script>
import { Restaurant } from '../models/Restaurant.js';

export default {
  props: {
    restaurant: { type: Restaurant, required: true }
  },
  setup(props, { emit }) {



    return {

      doTheEmit() {
        console.log('lets emit', props.restaurant)
        emit('beFree')
      }


    }
  }
}
</script>


<style lang="scss" scoped></style>