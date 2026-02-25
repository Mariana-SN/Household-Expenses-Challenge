import { useEffect, useState } from 'react';
import { PersonService, CategoryService, TransactionService } from '../services/apiService';
import { TransactionType } from '../types';
import { CurrencyInput } from '../components/CurrencyInput';
import type { Person, Category, Transaction, TransactionType as TType } from '../types';

/**
 * Componente de página responsável pelo registro de novas movimentações financeiras.
 */
const TransactionPage = () => {
    /** Listas para preencher os campos de seleção (Selects) */
    const [people, setPeople] = useState<Person[]>([]);
    const [categories, setCategories] = useState<Category[]>([]);
    
    /** Objeto de estado inicial para facilitar o reset do formulário */
    const initialFormState: Transaction = {
        description: '', 
        amount: 0, 
        type: TransactionType.Expense, 
        categoryId: '', 
        personId: ''
    };

    /** Estado do formulário e mensagem de sucesso */
    const [form, setForm] = useState<Transaction>(initialFormState);
    const [successMessage, setSuccessMessage] = useState<string | null>(null);

     /**
     * Carrega as dependências necessárias para o formulário.
     * Como a transação exige um ID de pessoa e de categoria, buscam-se ambos ao montar o componente.
     */
    useEffect(() => {
        PersonService.getAll().then(res => setPeople(res.data));
        CategoryService.getAll().then(res => setCategories(res.data));
    }, []);

    /**
     * Envia os dados para a API e trata a resposta.
     */
    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();

        if (!form.personId || !form.categoryId || form.amount <= 0) {
            alert("Por favor, preencha todos os campos corretamente. O valor deve ser maior que zero.");
            return;
        }

        try {
            await TransactionService.create(form);
            setSuccessMessage("Transação realizada com sucesso!");
            setForm(initialFormState);
            setTimeout(() => setSuccessMessage(null), 3000);
        } catch (err: any) { 
            console.error(err);
            const msg = err.response?.data?.message || "Erro ao salvar transação";
            alert(msg); 
        }
    };

    return (
        <div className="container">
            <h2>💸 Nova Transação</h2>

            {successMessage && (
                <div style={{ backgroundColor: '#d4edda', color: '#155724', padding: '10px', borderRadius: '5px', marginBottom: '15px', textAlign: 'center' }}>
                    {successMessage}
                </div>
            )}
            
            <form onSubmit={handleSubmit} className="form-container" style={{ flexDirection: 'column' }}>
                <div style={{ display: 'flex', gap: '10px', width: '100%', justifyContent: 'center' }}>
                    <input 
                        placeholder="Descrição" 
                        value={form.description} 
                        onChange={e => setForm({...form, description: e.target.value})} 
                        required 
                    />

                    <CurrencyInput 
                        placeholder="Valor"
                        value={form.amount}
                        onChange={(val) => setForm({ ...form, amount: val })}
                    />

                    <select value={form.type} onChange={e => setForm({...form, type: Number(e.target.value) as TType})}>
                        <option value={TransactionType.Income}>Receita</option>
                        <option value={TransactionType.Expense}>Despesa</option>
                    </select>
                </div>
                
                <div style={{ display: 'flex', gap: '10px', width: '100%', justifyContent: 'center' }}>
                    <select value={form.personId} onChange={e => setForm({...form, personId: e.target.value})} required>
                        <option value="">Selecione a Pessoa</option>
                        {people.map(p => <option key={p.id} value={p.id}>{p.name}</option>)}
                    </select>
                    <select value={form.categoryId} onChange={e => setForm({...form, categoryId: e.target.value})} required>
                        <option value="">Selecione a Categoria</option>
                        {categories.map(c => <option key={c.id} value={c.id}>{c.description}</option>)}
                    </select>
                    <button type="submit" className="primary">Registrar</button>
                </div>
            </form>
        </div>
    );
};

export default TransactionPage;