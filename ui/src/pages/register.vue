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
import { ref, getCurrentInstance } from 'vue';
import axios from 'axios';

const { proxy } = getCurrentInstance();

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
    const response = await axios.post(`${proxy.$config.API_URL}/auth/register`, {
      username: username.value,
      password: password.value,
    });

    console.log('Registration successful', response.data);
  } catch (error) {
    console.error(error);
    const { data } = error.response;

    if (data.ErrorCode === 'UsernameTakenException') {
      errorMessage.value = data.Message;
    } else if (data.ErrorCode === 'InvalidPasswordException') {
      errorMessage.value = data.Errors.join(', ');
    } else {
      errorMessage.value = 'An unknown error occurred.';
    }
  }
};
</script>
