<template>
  <div>
    <h1>Test</h1>
    <button @click="login">Log in</button>
  </div>
  <div>
    <button @click="doSomethingWithToken">Do omsething</button> </div>
</template>
<script>
import { useAuth0 } from '@auth0/auth0-vue';

export default {
  setup() {
    const { loginWithRedirect, getAccessTokenSilently } = useAuth0();

    return {
      login: () => {
        loginWithRedirect();
      },
      doSomethingWithToken: async () => {
        try {
          const token = await getAccessTokenSilently();
          console.log(token);
        }
        catch ({error}) {
          if (error === "login_required") {
            alert ("You must log in");
          }
        }
      }

    };
  }
};
</script>
