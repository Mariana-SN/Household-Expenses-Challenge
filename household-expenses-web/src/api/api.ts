import axios from 'axios';

/**
 * Configuração global do Axios para consumo da HouseholdExpenses API.
 */
const api = axios.create({
    baseURL: 'http://localhost:5105/api', 
});

export default api;