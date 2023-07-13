<template>
  <div class="component">
    <div class="bg-white rounded my-1 d-flex flex-row align-items-center elevation-1">
      <img class="rounded-start" :src="report.restaurant.imgUrl" alt="">
      <div class="card-body ms-3">
        <p>
          <b>
            {{ report.restaurant.name }} - {{ report.title }}
          </b>
        </p>
        <p>{{ report.body }}</p>
      </div>
    </div>
  </div>
</template>


<script setup>

const props = defineProps({
  report: { type: Object, required: true }
})




</script>


<style lang="scss" scoped>
img {
  max-height: 150px;
  max-width: 30vw;
  aspect-ratio: 1/1;
  object-fit: cover;
}
</style>