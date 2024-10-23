<template>
    <v-container>
      <v-form v-model="valid" @submit.prevent="submitRegistration">
        <v-text-field
          label="Username"
          v-model="username"
          :rules="[usernameRule]"
          required
        ></v-text-field>
  
        <v-text-field
          label="Password"
          v-model="password"
          :rules="[passwordRule]"
          type="password"
          required
        ></v-text-field>
  
        <v-btn type="submit" :disabled="!valid">
          Register
        </v-btn>
  
        <v-alert v-if="errorMessage" type="error" dismissible>
          {{ errorMessage }}
        </v-alert>
      </v-form>
    </v-container>
</template>
  

<script setup>
import { ref } from 'vue';
import { useRouter } from 'vue-router';

import { useUserStore } from '@/stores/user';
const userStore = useUserStore();
const router = useRouter();

// Form fields and validation
const username = ref('');
const password = ref('');
const valid = ref(false);
const errorMessage = ref('');

// Rules for validation
const usernameRule = v => !!v || 'Username is required';
const passwordRule = v => v.length >= 6 || 'Password must be at least 6 characters long';

// Submit registration form
const submitRegistration = async () => {
  errorMessage.value = '';

  try {
    // Call the API using the dynamically loaded API URL
    await userStore.register(username.value, password.value);
    router.push('/login');

    console.log('Registration successful');
  } catch (error) {
    console.error(error);
    const { data } = error.response;

    if (data.code === 'UsernameTakenException') {
      errorMessage.value = data.message;
    } else if (data.code === 'InvalidPasswordException') {
      errorMessage.value = data.errors.join(', ');
    } else {
      errorMessage.value = 'An unknown error occurred.';
    }
  }
};
</script>
