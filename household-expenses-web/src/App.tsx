import { useState } from 'react';
import PersonPage from './pages/PersonPage';
import CategoryPage from './pages/CategoryPage';
import TransactionPage from './pages/TransactionPage';
import SummaryPage from './pages/SummaryPage';

type Tab = 'people' | 'categories' | 'transactions' | 'summary';

/**
 * Componente Raiz da Aplicação.
 * Monta o menu de navegação e a renderização condicional das páginas.
 */
function App() {
  // Estado que controla qual página está visível no momento
  const [activeTab, setActiveTab] = useState<Tab>('people');

  /**
   * Helper function para gerenciar os estilos dinâmicos dos botões.
   * Aplica cores de destaque para a aba que está ativa no momento.
   */
  const tabStyle = (tab: Tab) => ({
    padding: '10px 20px',
    cursor: 'pointer',
    backgroundColor: activeTab === tab ? '#4CAF50' : '#f0f0f0',
    color: activeTab === tab ? 'white' : 'black',
    border: '1px solid #ccc',
    borderRadius: '4px',
    marginRight: '5px',
    fontWeight: 'bold'
  });

  return (
    <div style={{ maxWidth: '1200px', margin: '0 auto', fontFamily: 'Arial, sans-serif' }}>
      <header style={{ textAlign: 'center', padding: '20px 0', borderBottom: '2px solid #eee' }}>
        <h1>🏠 Household Expenses Control</h1>
      </header>

      <nav style={{ padding: '20px 0', display: 'flex', justifyContent: 'center', gap: '10px' }}>
        <button style={tabStyle('people')} onClick={() => setActiveTab('people')}>
          Pessoas
        </button>
        <button style={tabStyle('categories')} onClick={() => setActiveTab('categories')}>
          Categorias
        </button>
        <button style={tabStyle('transactions')} onClick={() => setActiveTab('transactions')}>
          Nova Transação
        </button>
        <button style={tabStyle('summary')} onClick={() => setActiveTab('summary')}>
          Relatório Geral
        </button>
      </nav>

      <hr />

      <main style={{ marginTop: '20px' }}>
        {activeTab === 'people' && <PersonPage />}
        {activeTab === 'categories' && <CategoryPage />}
        {activeTab === 'transactions' && <TransactionPage />}
        {activeTab === 'summary' && <SummaryPage />}
      </main>

      <footer style={{ marginTop: '50px', textAlign: 'center', color: '#888', fontSize: '0.8em' }}>
        <p>HouseholdExpensesChallenge - 2026</p>
      </footer>
    </div>
  );
}

export default App;