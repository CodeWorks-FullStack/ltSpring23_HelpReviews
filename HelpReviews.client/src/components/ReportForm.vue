<template>
  <form class="report-form" @submit.prevent="handleSubmit">

    <div class="form-group mb-3">
      <label for="restaurant">Select Restaurant</label>
      <select name="restaurant" class="form-control" v-model="editable.restaurantId">
        <option disabled selected value="">Please Select a Restaurant</option>
        <option v-for="r in restaurants" :key="r.id" :value="r.id">{{ r.name }}</option>
      </select>
    </div>

    <div class="form-group mb-3">
      <label for="title">Title</label>
      <input type="text" required v-model="editable.title" class="form-control" name="title">
    </div>

    <div class="form-group mb-3">
      <label for="body">What do you say?</label>
      <textarea required v-model="editable.body" class="form-control" rows="8" name="body"></textarea>
    </div>

    <div class="button-group">
      <button class="btn me-4" type="reset">Cancel</button>
      <button class="btn btn-primary" type="submit">Create Report!</button>
    </div>


  </form>
</template>


<script setup>
import { computed, ref } from 'vue';
import Pop from '../utils/Pop.js';
import { AppState } from '../AppState.js';
import { restaurantsService } from '../services/RestaurantsService.js';

const editable = ref({ restaurantId: '' })

const restaurants = computed(() => AppState.restaurants)



async function handleSubmit() {

  try {
    await restaurantsService.createReport(editable.value)
    editable.value = { restaurantId: '' }
  } catch (error) {
    Pop.error(error, '[CREATING_REPORT]')
  }

}





</script>


<style lang="scss" scoped></style>