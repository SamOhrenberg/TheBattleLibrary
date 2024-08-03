import { useAuth0 } from '@auth0/auth0-vue';

export function useAuth() {
  const { isAuthenticated, user, loginWithRedirect, logout } = useAuth0();

  return {
    isLoggedIn: isAuthenticated,
    currentUser: user,
    login: loginWithRedirect,
    logout,
  };
}
