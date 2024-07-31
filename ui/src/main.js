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
  

app.mount('#app')
