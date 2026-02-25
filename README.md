# 🏠 Household Expenses

Sistema para gestão de despesas e receitas familiares.

## 🚀 Sobre o Projeto

O sistema é uma solução simples para o gerenciamento financeiro doméstico. Ele o controle rigoroso de transações, vinculando membros da família a categorias específicas e gerando relatórios consolidados em tempo real.

### Principais Regras de Negócio Implementadas:
* **Validação de Idade:** Menores de 18 anos são impedidos pelo sistema de registrar transações do tipo "Receita".
* **Integridade de Categorias:** O sistema valida se a categoria selecionada é compatível com o tipo de transação (Receita/Despesa).
* **Cálculo Automático:** Saldo líquido e totais por pessoa processados diretamente no Backend via LINQ.
* **Persistência Segura:** Deleção em cascata.

---

## 🛠️ Stack Tecnológica

### **Backend (.NET 10)**
* **C# / ASP.NET Core Web API**
* **Entity Framework Core** (ORM)
* **SQLite** (Banco de dados relacional local)
* **Arquitetura em Camadas** (Domain, Application, Infrastructure, API)
* **Swagger** para documentação e testes de endpoints

### **Frontend (React + TypeScript)**
* **Vite** (Build Tool)
* **Axios** (Consumo de API)
* **Componentes Genéricos** (DataTable e CurrencyInput reutilizáveis)
* **Máscaras Customizadas** (Currency Input para valores em R$)
* **Navegação por Estados** (Tabs para uma experiência SPA fluida)

---

## 📐 Estrutura do Banco de Dados

O banco de dados SQLite é estruturado em três tabelas principais:
1.  **People:** Armazena nome e idade.
2.  **Categories:** Classificações com finalidade (Receita, Despesa ou Ambas).
3.  **Transactions:** Registros financeiros vinculando uma pessoa a uma categoria.

---

## 📦 Como Instalar e Rodar

### **Pré-requisitos**
* [.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
* [Node.js](https://nodejs.org/) (Versão 18 ou superior)

### **1. Configuração do Backend**
```bash
# Entre na pasta do projeto web api
cd HouseholdExpensesAPI

# Instale a ferramenta de migrations se não tiver
dotnet tool install --global dotnet-ef

# Crie o banco de dados e aplique as tabelas
dotnet ef database update

# Rode a aplicação
dotnet run

### **2. Configuração do Frontend**
```bash
# Entre na pasta do front-end
cd HouseholdExpensesFront

# Instale as dependências
npm install

# Inicie o servidor de desenvolvimento
npm run dev
