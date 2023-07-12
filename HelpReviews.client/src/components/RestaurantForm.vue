<template>
  <form @submit.prevent="handleSubmit">

    <div class="form-group mb-3">
      <label for="name">Name:</label>
      <input type="text" class="form-control" name="name" v-model="editable.name" minlength="2" maxlength="60" required>
    </div>

    <div class="form-group mb-3">
      <label for="description">Description:</label>
      <input type="text" class="form-control" name="description" v-model="editable.description" minlength="10"
        maxlength="60" required>
    </div>

    <div class="form-group mb-3">
      <label for="category">category:</label>
      <input type="text" class="form-control" name="category" v-model="editable.category" minlength="5" maxlength="15"
        required>
    </div>

    <div class="form-group mb-3">
      <label for="imgUrl">Cover Image:</label>
      <input type="url" class="form-control" name="imgUrl" v-model="editable.imgUrl" required>
    </div>


    <button type="submit" class="btn btn-primary">Create</button>
  </form>
</template>


<script>
import { ref } from 'vue';
import Pop from '../utils/Pop.js';
import { restaurantsService } from '../services/RestaurantsService.js';

export default {
  setup() {

    const editable = ref({})


    return {
      editable,
      async handleSubmit() {
        try {
          await restaurantsService.create(editable.value)
          editable.value = {}
        } catch (error) {
          Pop.error(error, '[CREATING_RESTAURANT]')
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped></style>