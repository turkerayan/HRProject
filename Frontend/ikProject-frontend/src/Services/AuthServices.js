import axios from 'axios';
import jwt_decode from 'jwt-decode';

const API_URL = 'http://your-api-url.com/auth/';

class AuthService {
  login(username, password) {
    return axios
      .post(API_URL + 'login', {
        username,
        password
      })
      .then(response => {
        if (response.data.accessToken) {
          localStorage.setItem('user', JSON.stringify(response.data));
        }
        return response.data;
      });
  }

  logout() {
    localStorage.removeItem('user');
  }

  register(username, email, password) {
    return axios.post(API_URL + 'register', {
      username,
      email,
      password
    });
  }

  getCurrentUser() {
    return JSON.parse(localStorage.getItem('user'));
  }

  getDecodedToken() {
    const user = this.getCurrentUser();
    if (user && user.accessToken) {
      return jwt_decode(user.accessToken);
    }
    return null;
  }

  isAuthenticated() {
    const decodedToken = this.getDecodedToken();
    if (decodedToken) {
      const currentTime = Date.now() / 1000;
      return decodedToken.exp > currentTime;
    }
    return false;
  }
}

export default new AuthService();