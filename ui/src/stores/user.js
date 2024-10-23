import { defineStore } from 'pinia';
import { ref, computed, getCurrentInstance } from 'vue';
import axios from 'axios';

export const useUserStore = defineStore('user', () => {
  // State
  const user = ref(null);
  const token = ref(null);
  const { proxy } = getCurrentInstance();

  // Getters
  const isLoggedIn = computed(() => token && token.value);

  // Actions
  function setUser(userInfo) {
    user.value = userInfo;
  }

  function setToken(userToken) {
    token.value = userToken;
  }

  async function login(username, password) {
    // Replace this with your actual login logic (e.g., API call)
    const fakeApiResponse = {
      token: 'fake-jwt-token',
      user: { id: 1, name: 'John Doe', email: 'john@example.com' },
    };
    setToken(fakeApiResponse.token);
    setUser(fakeApiResponse.user);
  }

  function logout() {
    setToken(null);
    setUser(null);
  }

  async function register(username, password) {
    // Call the API using the dynamically loaded API URL
    await axios.post(`${proxy.$config.API_URL}/auth/register`, {
      username: username,
      password: password,
    });    
  }

  async function fetchUser() {
    // Replace this with your actual user fetch logic (e.g., API call)
    const fakeApiResponse = { id: 1, name: 'John Doe', email: 'john@example.com' };
    setUser(fakeApiResponse);
  }

  return {
    user,
    token,
    isLoggedIn,
    login,
    logout,
    fetchUser,
    register
  };
});
