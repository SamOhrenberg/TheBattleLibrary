/**
 * main.js
 *
 * Bootstraps Vuetify and other plugins then mounts the App`
 */
import { createAuth0 } from '@auth0/auth0-vue';

// Plugins
import { registerPlugins } from '@/plugins'

// Components
import App from './App.vue'

// Composables
import { createApp } from 'vue'

const app = createApp(App)

registerPlugins(app)

app.use(
    createAuth0({
      domain: "dev-c1665uno8ob4w4di.us.auth0.com",
      clientId: "2BFSb2JiqkdmNPqUvnABkDM6Mc5aJzQ1",
      authorizationParams: {
        redirect_uri: window.location.origin
      }
    })
  );

  app.config.errorHandler = (err, vm, info) => {
    // `err`: The error object
    // `vm`: The Vue component instance where the error was caught
    // `info`: A Vue-specific error information string (optional)
  
    // Log the error details for debugging
    console.error('Global Error Handler:', err, vm, info);
  
    // Display an alert with the error message (for demonstration purposes)
    alert(`An error occurred: ${err.message}`);
  };
  
  

app.mount('#app')
