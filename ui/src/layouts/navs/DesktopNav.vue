<template>
    
        <v-app-bar
          color="teal-darken-4"
        >
          <template v-slot:image>
            <v-img
              gradient="to top right, rgba(19,84,122,.8), rgba(128,208,199,.8)"
            ></v-img>
          </template>
  
          <v-app-bar-title >
            <v-btn @click="goToHome">
                The Battle Library
            </v-btn>
          </v-app-bar-title>
  
            <v-text-field
            class="mt-5"
            density="compact"
                clearable
                prepend-inner-icon="mdi-magnify"
                variant="solo-filled"
            ></v-text-field>

          
  
          <v-btn icon>
            <v-icon></v-icon>
          </v-btn>

          <v-spacer></v-spacer>

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
        </v-app-bar>
  </template>

<script setup>
import { useRouter } from 'vue-router';
import { useUserStore } from '@/stores/user';


const router = useRouter();
const userStore = useUserStore();

const isLoggedIn = computed(() => userStore.isLoggedIn);
const username = computed(() => userStore?.user?.username ?? "");

const goToHome = () => {
  router.push('/');
};

const goToProfile = () => {
  router.push('/profile');
};

const goToLogin = () => {
  router.push('/login');
}

const logout = () => {
  userStore.logout();
}

</script>