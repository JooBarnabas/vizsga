import Axios from './dataservice.js';

export default {
    getAllVet(token) {
        return Axios.get('/vet-all', { headers: { "Authorization": "Bearer " + token } })
            .then(resp => {
                return resp.data;
            })
            .catch(err => {
                return Promise.reject(err.response);
            })
    },
    getAllCureTypes() {
        return Axios.get('/cure-types-all')
            .then(resp => {
                return resp.data;
            })
            .catch(err => {
                return Promise.reject(err.response);
            })
    },
    getUsersPets(token) {
        return Axios.get(`/pets`, { headers: { "Authorization": "Bearer " + token } })
            .then(resp => {
                return resp.data;
            })
            .catch(err => {
                return Promise.reject(err.response);
            })
    },
    getVetsByParams(data) {
        return Axios.post(`/search-vets`, data)
            .then(resp => {
                return resp.data;
            })
            .catch(err => {
                return Promise.reject(err.response);
            })
    },
    getFreeAppointments(id, date, token) {
        return Axios.get(`/free-appointments/${id}/${date}`, { headers: { "Authorization": "Bearer " + token } })
            .then(resp => {
                return resp.data;
            })
            .catch(err => {
                return Promise.reject(err.response);
            })
    },
    getVetsAppointmentToDays(token, date) {
        return Axios.get(`/vet-appointments/${date}`, { headers: { "Authorization": "Bearer " + token } })
            .then(resp => {
                return resp.data;
            })
            .catch(err => {
                return Promise.reject(err.response);
            })
    },
    addOpeningTime(token, data){
        return Axios.post(`/new-openings`, data, { headers: { "Authorization": "Bearer " + token } })
            .then(resp => {
                return resp.data;
            })
            .catch(err => {
                return Promise.reject(err.response);
            })
    },
    deleteOpening(token, day){
        return Axios.delete(`/delete-opening/${day}`, { headers: { "Authorization": "Bearer " + token } })
            .then(resp => {
                return resp.data;
            })
            .catch(err => {
                return Promise.reject(err.response);
            })
    },
    getOpenings(token) {
        return Axios.get(`/openings`, { headers: { "Authorization": "Bearer " + token } })
            .then(resp => {
                return resp.data;
            })
            .catch(err => {
                return Promise.reject(err.response);
            })
    },
    getSpecialOpenings(token) {
        return Axios.get(`/special-openings`, { headers: { "Authorization": "Bearer " + token } })
            .then(resp => {
                return resp.data;
            })
            .catch(err => {
                return Promise.reject(err.response);
            })
    },
    addSpecialOpeningTime(token, data){
        return Axios.post(`/new-special-openings`, data, { headers: { "Authorization": "Bearer " + token } })
            .then(resp => {
                return resp.data;
            })
            .catch(err => {
                return Promise.reject(err.response);
            })
    },
    deleteSpecialOpening(token, id){
        return Axios.delete(`/delete-special-opening/${id}`, { headers: { "Authorization": "Bearer " + token } })
            .then(resp => {
                return resp.data;
            })
            .catch(err => {
                return Promise.reject(err.response);
            })
    },
}