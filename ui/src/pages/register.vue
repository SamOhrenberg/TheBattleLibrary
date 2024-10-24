<template>
    <v-container class="login-page">
      <div class="login-card">
        <h2>Register</h2>
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
          
    
          <p class="text-body-2">
            The only password requirement is that the password is at least
            six characters in length. 
          </p>

          <p class="text-body-2">
            Please consider using a more complex password to protect
            your account.
          </p>
    
          <v-btn type="submit" class="btn" :disabled="!valid">
            Register
          </v-btn>
    
          <v-alert v-if="errorMessage" type="error" dismissible>
            {{ errorMessage }}
          </v-alert>
        </v-form>
      </div>
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


<style scoped>
.login-page {
  display: flex;
  justify-content: center;
  align-items: center;
  height: auto; /* Removed min-height: 100vh */
  padding: 20px;
  margin-bottom: 60px; /* Adjust this based on your bottom nav height */
}

.login-card {
  background-color: #fafafa;
  padding: 20px;
  border-radius: 8px;
  box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
  max-width: 400px;
  width: 100%;
  box-sizing: border-box;
}

h2 {
  margin-bottom: 20px;
  text-align: center;
}

.form-group {
  margin-bottom: 15px;
}

label {
  display: block;
  margin-bottom: 5px;
}

input {
  width: 100%;
  padding: 10px;
  border-radius: 4px;
  border: 1px solid #ddd;
  box-sizing: border-box;
}

.btn {
  width: 100%;
  padding: 10px;
  border: none;
  border-radius: 4px;
  background-color: #007bff;
  color: white;
  cursor: pointer;
  font-size: 16px;
}

.btn:hover {
  background-color: #0056b3;
}

.links {
  margin-top: 15px;
  display: flex;
  justify-content: space-between;
  font-size: 14px;
}

.links a {
  color: #007bff;
  text-decoration: none;
}

.links a:hover {
  text-decoration: underline;
}

@media (max-width: 600px) {
  .login-card {
    padding: 15px;
  }
}

.text-body-2 {
  margin-bottom: 20px;
  padding-left: 10px;
  padding-right: 10px;
}
</style>
  