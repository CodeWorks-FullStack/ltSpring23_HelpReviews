<template>
  <div class="home">

    <!-- LIST ALL RESTAURANTS HERE -->

    <div class="container">
      <div class="row my-3">
        <div class="col-md-4" v-for="r in restaurants" :key="r.id">
          <RestaurantCard :restaurant="r" @beFree="IwillBeFree" />
        </div>
      </div>
    </div>



    <div class="container">
      <div class="row">
        <div class="col-md-6 m-auto">
          <RestaurantForm class="bg-white elevation-2 p-3 rounded" />
        </div>
      </div>
    </div>



  </div>
</template>

<script>
import { computed } from 'vue';
import { AppState } from '../AppState.js';
// import { Modal } from 'bootstrap';


export default {
  setup() {

    return {

      restaurants: computed(() => AppState.restaurants),
      IwillBeFree() {
        // Modal.getOrCreateInstance('#the-modal').hide()

      }


    }
  }
}
</script>

<style scoped lang="scss">
.home {}
</style>
