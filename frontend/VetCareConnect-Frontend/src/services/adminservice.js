import Axios from './dataservice.js';

export default {
    adminLogin(data) {
        return Axios.post('/admin-login', data)
            .then(resp => {
                return resp;
            })
            .catch(err => {
                return Promise.reject(err.response);
            })
    },
    getAllOwner(token) {
        return Axios.get('/owner-all', { headers: { "Authorization": "Bearer " + token } })
            .then(resp => {
                return resp.data;
            })
            .catch(err => {
                return Promise.reject(err.response);
            })
    },
    getAllVet(token) {
        return Axios.get('/vet-all', { headers: { "Authorization": "Bearer " + token } })
            .then(resp => {
                return resp.data;
            })
            .catch(err => {
                return Promise.reject(err.response);
            })
    },
    deleteVet(id, token) {
        return Axios.delete(`/delete-vet/${id}`, { headers: { "Authorization": "Bearer " + token } })
            .then(resp => {
                return resp.data;
            })
            .catch(err => {
                return Promise.reject(err.response);
            })
    },
    deleteOwner(id, token) {
        return Axios.delete(`/delete-owner/${id}`, { headers: { "Authorization": "Bearer " + token } })
            .then(resp => {
                return resp.data;
            })
            .catch(err => {
                return Promise.reject(err.response);
            })
    },
    modifyEmail(data, token){
        return Axios.post(`/modify-user-email`, data, {headers: {"Authorization" : "Bearer "+ token}})
        .then(resp => {
            return resp.data;
        })
        .catch(err => {
            return Promise.reject(err.response);
        })
    }
}