<template>

  <v-app>
    <v-main>
      <!-- Render this component only on tablet screens and up -->
      <div v-if="smAndUp">
        <DesktopNav 
          :is-logged-in="isLoggedIn" 
          :login="login" 
          :go-to-search="goToSearch" 
          :go-to-combat-report="goToCombatReport" 
          :go-to-profile="goToProfile" />
      </div>

      <router-view />

      <!-- Render this component only on small screens (phones) -->
      <div v-if="xs">
        <MobileNav 
          :is-logged-in="isLoggedIn" 
          :login="login" 
          :go-to-search="goToSearch" 
          :go-to-combat-report="goToCombatReport" 
          :go-to-profile="goToProfile" />
      </div>
    </v-main>
  </v-app>
</template>

<script setup>
  import { useDisplay } from 'vuetify'
  import DesktopNav from './navs/DesktopNav.vue' // Correct import
  import MobileNav from './navs/MobileNav.vue';

  import { useRouter } from 'vue-router';
  import { useUserStore } from '@/stores/user';

  // Destructure only the keys you want to use
  const { xs, smAndUp } = useDisplay()

  const router = useRouter();
  const { isLoggedIn, login } = useUserStore();

  const goToSearch = () => {
    router.push('/search');
  };

  const goToProfile = () => {
    router.push('/profile');
  };

  const goToCombatReport = () => {
    router.push('/combat-report');
  };

</script>
