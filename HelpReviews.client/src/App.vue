<template>
  <header>
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>
  <footer class="bg-dark text-light">
    Made with 💖 by CodeWorks
  </footer>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'
import Pop from './utils/Pop.js'
import { restaurantsService } from './services/RestaurantsService.js'

export default {
  setup() {

    async function getAllRestaurants() {
      try {
        restaurantsService.getAll()
      } catch (error) {
        Pop.error(error, '[GETTING RESTAURANTS]')
      }
    }

    onMounted(() => {
      getAllRestaurants()
    })

    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root {
  --main-height: calc(100vh - 32px - 64px);
}


footer {
  display: grid;
  place-content: center;
  height: 32px;
}
</style>
