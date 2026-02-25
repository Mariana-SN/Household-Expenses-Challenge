import { useEffect, useState } from 'react';
import { CategoryService } from '../services/apiService';
import { DataTable } from '../components/DataTable';
import { CategoryPurpose, CategoryPurposeLabels } from '../types';
import type { Category, CategoryPurposeType } from '../types';

/**
 * Componente de página para visualização e cadastro de categorias.
 * Implementa o fluxo de Create e Read.
 */
const CategoryPage = () => {
    // Lista de categorias carregadas da API
    const [categories, setCategories] = useState<Category[]>([]);

    // Estados do formulário
    const [description, setDescription] = useState('');
    const [purpose, setPurpose] = useState<CategoryPurposeType>(CategoryPurpose.Both);

    /**
     * Busca as categorias da API e atualiza o estado local.
     */
    const loadData = async () => {
        try {
            const res = await CategoryService.getAll();
            setCategories(res.data);
        } catch (err) { console.error("Erro ao carregar categorias", err); }
    };

    /**
     * Processa a submissão do formulário.
     * Evita o reload da página, envia os dados para a API e limpa os campos.
     */
    const handleAdd = async (e: React.FormEvent) => {
        e.preventDefault();
        await CategoryService.create({ description, purpose });
        setDescription('');
        loadData();
    };

    useEffect(() => { loadData(); }, []);

    return (
        <div className="container">
            <h2>🏷️ Cadastro de Categorias</h2>
            
            <form onSubmit={handleAdd} className="form-container">
                <input 
                    placeholder="Descrição da Categoria" 
                    value={description} 
                    onChange={e => setDescription(e.target.value)} 
                    required 
                />
                <select value={purpose} onChange={e => setPurpose(Number(e.target.value) as CategoryPurposeType)}>
                    <option value={CategoryPurpose.Income}>Receita</option>
                    <option value={CategoryPurpose.Expense}>Despesa</option>
                    <option value={CategoryPurpose.Both}>Ambas</option>
                </select>
                <button type="submit" className="primary">Salvar Categoria</button>
            </form>

            <DataTable 
                headers={['Descrição', 'Finalidade']}
                data={categories}
                renderRow={(c) => (
                    <>
                        <td>{c.description}</td>
                        <td>{CategoryPurposeLabels[c.purpose]}</td>
                    </>
                )}
            />
        </div>
    );
};

export default CategoryPage;