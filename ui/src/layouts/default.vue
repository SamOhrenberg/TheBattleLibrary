<template>

  <v-app>
    <v-main>
      <!-- Render this component only on tablet screens and up -->
      <div v-if="smAndUp">
        <DesktopNav  />
      </div>

      <div class="pa-2">
        <router-view />
      </div>

      <!-- Render this component only on small screens (phones) -->
      <div v-if="xs">
        <MobileNav />
      </div>
    </v-main>
  </v-app>
</template>

<script setup>
  import { useDisplay } from 'vuetify'
  import DesktopNav from './navs/DesktopNav.vue' // Correct import
  import MobileNav from './navs/MobileNav.vue';

  const { xs, smAndUp } = useDisplay()

</script>
