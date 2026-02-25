import { useEffect, useState } from 'react';
import { PersonService } from '../services/apiService';
import { DataTable } from '../components/DataTable';
import type { Person } from '../types';

/**
 * Componente de página para visualização, cadastro e remoção de Pessoas.
 * Implementa o fluxo de Create, Read e Delete.
 */
const PersonPage = () => {
    // Lista de pessoas carregadas da API
    const [people, setPeople] = useState<Person[]>([]);

    // Estados do formulário
    const [name, setName] = useState('');
    const [age, setAge] = useState<number>(0);

    /**
     * Sincroniza o estado local com o banco de dados.
     */
    const loadData = async () => {
        const res = await PersonService.getAll();
        setPeople(res.data);
    };

    /**
     * Envia os dados para o backend e limpa o formulário em caso de sucesso.
     */
    const handleAdd = async (e: React.FormEvent) => {
        e.preventDefault();
        await PersonService.create({ name, age });
        setName(''); setAge(0);
        loadData();
    };

    useEffect(() => { loadData(); }, []);

    return (
        <div className="container">
            <h2>👥 Gerenciar Pessoas</h2>
            
            <form onSubmit={handleAdd} className="form-container">
                <input placeholder="Nome" value={name} onChange={e => setName(e.target.value)} required />
                <input type="number" placeholder="Idade" value={age} onChange={e => setAge(Number(e.target.value))} required />
                <button type="submit" className="primary">Adicionar Pessoa</button>
            </form>

            <DataTable 
                headers={['Nome', 'Idade', 'Ações']}
                data={people}
                renderRow={(p) => (
                    <>
                        <td>{p.name}</td>
                        <td>{p.age} anos</td>
                        <td>
                            <button className="danger" onClick={() => p.id && PersonService.delete(p.id).then(loadData)}>
                                Excluir
                            </button>
                        </td>
                    </>
                )}
            />
        </div>
    );
};

export default PersonPage;