import router from '@/router/index.js';
import Axios from './dataservice.js';

export default {
    getMountains() {
        return Axios.get('/api/locations')
            .then(resp => {
                // console.log(resp);
                return resp.data;
            })
            .catch(err => {
                return Promise.reject(err.response);
            })
    },
    getByName(locationName) {
        return Axios.get(`/api/locations/${locationName}/viewpoints`)
        .then(resp => {
                // console.log(resp);
                return resp.data;
            })
            .catch(err => {
                return Promise.reject(err.response);
            })
    },
    getViewpoints() {
        return Axios.get('/api/viewpoints')
            .then(resp => {
                return resp.data;
            })
            .catch(err => {
                return Promise.reject(err.response);
            })
    },
    post(data) {
        return Axios.post('/api/rate', data)
            .then(resp => {
                return resp.data;
            })
            .catch(err => {
                return Promise.reject(err.response);
            })
    },
}