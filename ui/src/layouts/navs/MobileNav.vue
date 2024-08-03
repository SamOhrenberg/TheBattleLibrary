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
        <span>Profile</span>
      </v-btn>
      
      <v-btn class="fill-height" v-if="!isLoggedIn" @click="login">
        <v-icon>mdi-login</v-icon>
        <span>Login</span>
      </v-btn>
    </v-bottom-navigation>

</template>

<script setup>
import { defineProps } from 'vue';

// Define props for the component
const props = defineProps({
  isLoggedIn: Boolean,
  login: Function,
  goToSearch: Function,
  goToProfile: Function,
  goToCombatReport: Function
});
</script>