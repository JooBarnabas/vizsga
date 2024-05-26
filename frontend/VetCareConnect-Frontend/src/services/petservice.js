import Axios from './dataservice.js';

export default {
    postNewPet(data, token) {
        return Axios.post('/new-pet', data, {headers: {"Authorization" : "Bearer "+ token}})
            .then(resp => {
                return resp.data;
            })
            .catch(err => {
                return Promise.reject(err.response);
            })
    },
    getOwnersPets(token) {
        return Axios.get('/pets', {headers: {"Authorization" : "Bearer "+ token}})
            .then(resp => {
                return resp.data;
            })
            .catch(err => {
                return Promise.reject(err.response);
            })
    },
    deletePet(id, token) {
        return Axios.delete(`/delete-pet/${id}`, {headers: {"Authorization" : "Bearer "+ token}})
        .then(resp => {
            return resp.data;
        })
        .catch(err => {
            return Promise.reject(err.response);
        })
    },
    modifyPet(data, token) {
        return Axios.put(`/modify-pet`, data, {headers: {"Authorization" : "Bearer "+ token}})
        .then(resp => {
            return resp.data;
        })
        .catch(err => {
            return Promise.reject(err.response);
        })
    },
}