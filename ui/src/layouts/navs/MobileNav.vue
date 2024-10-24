<template>
    <v-bottom-navigation app height="64" grow mode="shift">
      <!-- Button 1: Takes up 1/4 of the space -->
      <v-btn class="fill-height" @click="goToSearch">
            <v-icon>mdi-book-search</v-icon>

            <span>Search</span>
        </v-btn>

      <!-- Spacer -->
      <v-spacer />

      <!-- Button 2: Takes up 1/2 of the space with dropdown options -->
      <v-btn class="fill-height" @click="goToCombatReport">
        <v-icon>mdi-file-document-edit</v-icon>
        <span>Combat Report</span>
      </v-btn>

      <!-- Spacer -->
      <v-spacer />

      <!-- Profile Button: Takes up 1/4 of the space -->
      <v-btn class="fill-height" v-if="isLoggedIn" @click="goToProfile">
        <v-icon>mdi-account</v-icon>
        <span>{{ username }}</span>
      </v-btn>
      
      <v-btn class="fill-height" v-if="isLoggedIn" @click="logout">
        <v-icon>mdi-logout</v-icon>
        <span>Logout</span>
      </v-btn>
        
      <v-btn class="fill-height" v-if="!isLoggedIn" @click="goToLogin">
        <v-icon>mdi-login</v-icon>
        <span>Login</span>
      </v-btn>

    </v-bottom-navigation>

</template>

<script setup>

import { useRouter } from 'vue-router';
import { useUserStore } from '@/stores/user';


const router = useRouter();
const userStore = useUserStore();

const isLoggedIn = computed(() => userStore.isLoggedIn);
const username = computed(() => userStore?.user?.username ?? "");

const goToProfile = () => {
  router.push('/profile');
};

const goToSearch = () => {
  router.push('/search');
};

const goToCombatReport = () => {
  router.push('/combat-report');
};

const goToLogin = () => {
  router.push('/login');
}

const logout = () => {
  userStore.logout();
}

</script>