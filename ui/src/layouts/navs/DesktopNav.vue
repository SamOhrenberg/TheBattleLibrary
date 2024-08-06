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
            <span>Profile</span>
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
const { isLoggedIn } = useUserStore();

const goToHome = () => {
  router.push('/');
};

const goToProfile = () => {
  router.push('/profile');
};

const goToCombatReport = () => {
  router.push('/combat-report');
};

const goToLogin = () => {
  router.push('/login');
}

const goToRegister = () => {
  router.push('/register');
}

const goToLogout = () => {
  router.push('/logout');
}

</script>