<template>
  <div class="about">

    <div class="container">
      <div class="row">
        <div class="col">

          <h1>Welcome {{ account.name }}</h1>
          <img class="rounded" :src="account.picture" alt="" />
        </div>
      </div>

      <div class="my-reports">
        <AccountReportCard v-for="r in reports" :key="r.id" :report="r" />

      </div>

      <div class="row">
        <div class="col-md-6 m-auto">
          <ReportForm />
        </div>
      </div>
    </div>

  </div>
</template>

<script>
import { computed } from 'vue';
import { AppState } from '../AppState';
export default {
  setup() {




    return {
      account: computed(() => AppState.account),
      reports: computed(() => AppState.myReports)
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
