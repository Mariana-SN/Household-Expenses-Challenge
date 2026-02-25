/**
 * Interface para trabalhar com qualquer tipo de objeto (Pessoas, Transações e Categorias).
 */
interface Props<T> {
    headers: string[];
    data: T[];
    renderRow: (item: T) => React.ReactNode;
}

/**
 * Componente de tabela reutilizável.
 * T representa o tipo do objeto que compõe os dados da tabela.
 */
export function DataTable<T>({ headers, data, renderRow }: Props<T>) {
    return (
        <table style={{ width: '100%', borderCollapse: 'collapse', marginTop: '10px' }}>
            <thead>
                <tr style={{ backgroundColor: '#f4f4f4' }}>
                    {headers.map(h => <th key={h} style={{ padding: '12px', border: '1px solid #ddd' }}>{h}</th>)}
                </tr>
            </thead>
            <tbody>
                {data.map((item, index) => (
                    <tr key={index}>{renderRow(item)}</tr>
                ))}
            </tbody>
        </table>
    );
}