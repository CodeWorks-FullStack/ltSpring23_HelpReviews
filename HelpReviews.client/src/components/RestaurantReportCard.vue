<template>
  <div class="restaurant-report-card">
    <div class="bg-white rounded my-1 d-flex flex-row align-items-center justify-content-between p-3 elevation-1">
      <div class="card-body">
        <p>
          <b>
            {{ report.title }}
          </b>
        </p>
        <p>{{ report.body }}</p>
      </div>
      <div class="d-flex align-items-center gap-2">
        <img class="rounded-circle" :src="report.creator.picture" alt="">
        <span>
          {{ report.creator.name }}
        </span>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  props: {
    report: { type: Object, required: true }
  },
  setup() {
    return {}
  }
}
</script>


<style lang="scss" scoped>
img {
  height: 64px;
  aspect-ratio: 1/1;
}
</style>