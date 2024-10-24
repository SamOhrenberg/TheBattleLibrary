<template>
    <div class="login-page">
      <div class="login-card">
        <h2>Login</h2>
        <form @submit.prevent="handleLogin">
          <div class="form-group">
            <label for="username">Username</label>
            <input
              v-model="username"
              id="username"
              type="text"
              placeholder="Enter your username"
              required
            />
          </div>
          <div class="form-group">
            <label for="password">Password</label>
            <input
              v-model="password"
              id="password"
              type="password"
              placeholder="Enter your password"
              required
            />
          </div>
          <button type="submit" class="btn">Login</button>
          <v-alert v-if="errorMessage" type="error" dismissible>
              {{ errorMessage }}
          </v-alert>

        </form>
        <div class="links">
          <router-link to="/register">Register</router-link>
          <router-link to="/forgot-password">Forgot your password?</router-link>
        </div>
      </div>
    </div>
  </template>
  
  <script>
  import { ref } from 'vue';
  import { useUserStore } from '@/stores/user';
  import { useRouter } from 'vue-router';

  export default {
    setup() {
      const username = ref('');
      const password = ref('');
      const userStore = useUserStore();
      const errorMessage = ref('');
      const router = useRouter();

      const handleLogin = async () => {
        try {
          await userStore.login(username.value, password.value);        
          router.push('/');
        }
        catch (errorCode) {
          console.log(errorCode);
          if (errorCode === 'FailedLoginException') {
            errorMessage.value = 'The provided username or password is incorrect. Please try again or reset your password';
          }
          else {
            errorMessage.value = 'There was an unexpected error logging in. Please contact support.';
          }
        }
      };
  
      return {
        username,
        password,
        errorMessage,
        handleLogin,
      };
    },
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
  </style>
    