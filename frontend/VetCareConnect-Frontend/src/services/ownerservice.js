import Axios from './dataservice.js';

export default {
    bookAppointment(appointment, token){
        return Axios.post('/new-appointment', appointment, {headers: {"Authorization" : "Bearer "+ token}})
        .then(resp => {
            return resp.data;
        })
        .catch(err => {
            return Promise.reject(err.response);
        })
    },
    getAppointments(token){
        return Axios.get('/owner-appointments', {headers: {"Authorization" : "Bearer "+ token}})
            .then(resp => {
                return resp.data;
            })
            .catch(err => {
                return Promise.reject(err.response);
            })
    },
    deleteAppointment(appointmentId, token){
        return Axios.delete(`/delete-appointment/${appointmentId}`, {headers: {"Authorization" : "Bearer "+ token}})
        .then(resp => {
            return resp.data;
        })
        .catch(err => {
            return Promise.reject(err.response);
        })
},
}