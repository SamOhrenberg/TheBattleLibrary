/**
 * main.js
 *
 * Bootstraps Vuetify and other plugins then mounts the App`
 */
// Plugins
import { registerPlugins } from '@/plugins'

// Components
import App from './App.vue'

// Composables
import { createApp } from 'vue'

// Global configuration object to store the config
const config = {
    API_URL: ''
  };
  
  // Fetch the configuration at runtime
  fetch('/config.json')
    .then(response => response.json())
    .then((data) => {
      config.API_URL = data.API_URL;  // Set the API URL from the configuration file
  
      const app = createApp(App);


      registerPlugins(app)
  
      // Make the config available globally
      app.config.globalProperties.$config = config;
  
      app.mount('#app');
    })
    .catch((error) => {
      console.error('Error loading configuration:', error);
    });
