import Axios from './dataservice.js';

export default {
  registerUser(data) {
    return Axios.post('/register', data)
      .then(resp => {
        // console.log(resp);
        return resp;
      })
      .catch(err => {
        // console.log(err.response);
        return Promise.reject(err.response);
      })
  },
  login(data) {
    return Axios.post('/login', data)
      .then(resp => {
        return resp;
      })
      .catch(err => {
        return Promise.reject(err.response);
      })
  },
  adminLogin(data) {
    return Axios.post('/admin-login', data)
      .then(resp => {
        return resp;
      })
      .catch(err => {
        return Promise.reject(err.response);
      })
  },
  logout(token) {
    return Axios.post('/logout', '', { headers: { "Authorization": "Bearer " + token } })
      .then(resp => {
        return resp;
      })
      .catch(err => {
        return Promise.reject(err.response);
      })
  },
  logOutAllDevice(token) {
    return Axios.post('/logout-all-device', '', { headers: { "Authorization": "Bearer " + token } })
      .then(resp => {
        return resp;
      })
      .catch(err => {
        return Promise.reject(err.response);
      })
  },
  getUserData(token) {
    return Axios.get('/user-data', { headers: { "Authorization": "Bearer " + token } })
      .then(resp => {
        return resp;
      })
      .catch(err => {
        return Promise.reject(err.response);
      })
  },
  modifyUserData(data, token){
    return Axios.put('/modify-user-data', data, { headers: { "Authorization": "Bearer " + token } })
      .then(resp => {
        return resp;
      })
      .catch(err => {
        return Promise.reject(err.response);
      })
  },
  sendPasswordResetEmail(data) {
    return Axios.post('/forgot-password', data)
      .then(resp => {
        return resp;
      })
      .catch(err => {
        return Promise.reject(err.response);
      })
  },
  resendVerificationEmail(data) {
    return Axios.get(`/email/resend/${data}`)
      .then(resp => {
        return resp;
      })
      .catch(err => {
        return Promise.reject(err.response);
      })
  },
  modifyPassword(data, token) {
    return Axios.patch('/reset-password', data, { headers: { "Authorization": "Bearer " + token } })
      .then(resp => {
        return resp;
      })
      .catch(err => {
        return Promise.reject(err.response);
      })
  }
}