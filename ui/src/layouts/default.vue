<template>

  <v-app>
    <v-main>
      <!-- Render this component only on tablet screens -->
      <div v-if="smAndUp">
        <DesktopNav 
          :is-logged-in="isLoggedIn" 
          :login="login" 
          :go-to-search="goToSearch" 
          :go-to-combat-report="goToCombatReport" 
          :go-to-profile="goToProfile" />
      </div>

      <!-- Render this component only on desktop screens -->
      <!-- <div v-if="mdAndUp">
        <DesktopNav 
          :is-logged-in="isLoggedIn" 
          :login="login" 
          :go-to-search="goToSearch" 
          :go-to-combat-report="goToCombatReport" 
          :go-to-profile="goToProfile" />
      </div> -->



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
import TabletNav from './navs/TabletNav.vue';

import { useRouter } from 'vue-router';
import { useAuth } from '@/utils/auth';


// Destructure only the keys you want to use
const { xs, smAndUp, mdAndUp } = useDisplay()

const router = useRouter();
const { isLoggedIn, login } = useAuth();

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
