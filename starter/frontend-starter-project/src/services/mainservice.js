import Axios from './dataservice.js';

export default {
    get() {
        return Axios.get('/api/get')
            .then(resp => {
                return resp.data;
            })
            .catch(err => {
                return Promise.reject(err.response);
            })
    },
    getByParam(id) {
        return Axios.get(`/api/${id}`)
            .then(resp => {
                return resp.data;
            })
            .catch(err => {
                return Promise.reject(err.response);
            })
    },
    post(data) {
        return Axios.post('/api/post', data)
            .then(resp => {
                return resp.data;
            })
            .catch(err => {
                return Promise.reject(err.response);
            })
    },
}