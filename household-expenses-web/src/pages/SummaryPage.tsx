import { useEffect, useState } from 'react';
import { TransactionService } from '../services/apiService';
import { DataTable } from '../components/DataTable';

/**
 * Componente de página para visualização de Resumo Financeiro.
 * Exibe o balanço individual de cada pessoa e o saldo líquido global do sistema.
 */
const SummaryPage = () => {
    // Estado para armazenar o objeto GeneralSummary vindo da API.
    const [summary, setSummary] = useState<any>(null);

    /**
     * Busca os dados consolidados ao carregar a página.
     */
    useEffect(() => {
        TransactionService.getSummary().then(res => setSummary(res.data));
    }, []);

    // Aparece quando não há resultados ou a requisição ainda está sendo feita.
    if (!summary) return <p>Loading financial data...</p>;

    return (
        <div style={{ padding: '20px' }}>
            <h2>Total Financeiro por Pessoa</h2>
            
            <DataTable 
                headers={['Pessoa', 'Receita', 'Despesa', 'Saldo']}
                data={summary.details}
                renderRow={(d: any) => (
                    <>
                        <td style={{ padding: '10px', border: '1px solid #ddd' }}>{d.name}</td>
                        <td style={{ color: 'green', padding: '10px', border: '1px solid #ddd' }}>+ R$ {d.totalIncome.toFixed(2)}</td>
                        <td style={{ color: 'red', padding: '10px', border: '1px solid #ddd' }}>- R$ {d.totalExpense.toFixed(2)}</td>
                        <td style={{ fontWeight: 'bold', padding: '10px', border: '1px solid #ddd' }}>R$ {d.balance.toFixed(2)}</td>
                    </>
                )}
            />

            <div style={{ marginTop: '30px', padding: '20px', backgroundColor: '#e3f2fd', borderRadius: '8px' }}>
                <h3>Resumo Geral</h3>
                <p>Receita Total: <span style={{ color: 'green' }}>R$ {summary.grandTotalIncome.toFixed(2)}</span></p>
                <p>Despesas Totais: <span style={{ color: 'red' }}>R$ {summary.grandTotalExpense.toFixed(2)}</span></p>
                <hr />
                <h4>Saldo líquido: R$ {summary.netBalance.toFixed(2)}</h4>
            </div>
        </div>
    );
};

export default SummaryPage;