import api from '../api/api';
import type { Person, Category, Transaction} from '../types';

/**
 * Serviço responsável pelas operações relacionadas às Pessoas.
 */
export const PersonService = {
    /** Recupera a lista de pessoas do endpoint /person */
    getAll: () => api.get<Person[]>('/person'),
    /** Envia os dados de uma nova pessoa para persistência */
    create: (data: Person) => api.post('/person', data),
    /** Remove uma pessoa através do seu UUID */
    delete: (id: string) => api.delete(`/person/${id}`)
};

/**
 * Serviço responsável pela gestão de Categorias.
 */
export const CategoryService = {
    /** Lista todas as categorias cadastradas (Income/Expense/Both) */
    getAll: () => api.get<Category[]>('/categories'),
    /** Cria uma nova classificação para as transações */
    create: (data: Category) => api.post('/categories', data)
};

/**
 * Serviço financeiro central da aplicação.
 * Orquestra o registro de movimentações e a obtenção de relatórios.
 */
export const TransactionService = {
    /** Obtém o histórico detalhado de todas as movimentações */
    getAll: () => api.get('/transactions'),
    /** Registra um novo evento financeiro. */
    create: (data: Transaction) => api.post('/transactions', data),
    /** Consome o endpoint de resumo consolidado. */
    getSummary: () => api.get('/transactions/summary')
};