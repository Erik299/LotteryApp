<template>
  <ion-app id="app">
    <home-page />
  </ion-app>
</template>

<script lang="ts">
import { IonApp } from '@ionic/vue';
import { defineComponent } from 'vue';
import HomePage from './views/HomePage.vue'

export default defineComponent({
  name: 'App',
  components: {
    IonApp,
    HomePage
  }
});
</script>

<style>
ion-content {
  --overflow: hidden;
  --ion-background-color: rgb(253, 183, 53);
}

</style>