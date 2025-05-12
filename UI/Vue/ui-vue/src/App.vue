<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
</script>

<template>
  <div class="app">
    <router-view />
  </div>

</template>

<style scoped>
.app {
  height: 100vh;
  width: 100vw;
  background-color: aqua;
}
</style>
