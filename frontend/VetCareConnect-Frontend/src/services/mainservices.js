import Axios from './dataservice.js';

export default {
    getAllQuestions() {
        return Axios.get('/faq-all')
            .then(resp => {
                return resp.data;
            })
            .catch(err => {
                return Promise.reject(err.response);
            })
    }
}