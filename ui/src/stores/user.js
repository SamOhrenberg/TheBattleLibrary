import { defineStore } from 'pinia';
import { ref, computed, getCurrentInstance } from 'vue';
import axios from 'axios';

export const useUserStore = defineStore('user', () => {
  // State
  const user = ref(null);
  const token = ref(localStorage.getItem('token') || null); // Load token from localStorage if available
  const { proxy } = getCurrentInstance();

  // Getters
  const isLoggedIn = computed(() => {
    return token && token.value
  });

  // Actions
  function setUser(userInfo) {
    user.value = userInfo;
    if (userInfo) {
      localStorage.setItem('userInfo', userInfo); // Save token to localStorage
    } else {
      localStorage.removeItem('userInfo'); // Remove token from localStorage on logout
    }
  }

  function setToken(userToken) {
    token.value = userToken;
    if (userToken) {
      localStorage.setItem('token', userToken); // Save token to localStorage
    } else {
      localStorage.removeItem('token'); // Remove token from localStorage on logout
    }
  }

  async function login(username, password) {
    try {
      var loginResponse = await axios.post(`${proxy.$config.API_URL}/auth/login`, {
        username: username,
        password: password,
      });  
      setToken(loginResponse.data);
      setUser({
        username: username.toUpperCase()
      });
    } 
    catch ({response}) {
      throw response.code;
    }
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
