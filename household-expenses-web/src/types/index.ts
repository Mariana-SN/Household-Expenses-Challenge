/**
 * Representa a entidade Pessoa. 
 * O 'id' é opcional para permitir a criação de novos objetos antes de possuírem um UUID do banco.
 */
export interface Person {
    id?: string;
    name: string;
    age: number;
}

/**
 * Espelha o Enum CategoryPurpose do C#.
 */
export const CategoryPurpose = {
    Income: 1,
    Expense: 2,
    Both: 3
} as const;

/**
 * Mapeamento de rótulos para exibição na Interface (UI).
 * Converte os valores numéricos do banco em strings.
 */
export const CategoryPurposeLabels: Record<number, string> = {
    [CategoryPurpose.Income]: "Receita",
    [CategoryPurpose.Expense]: "Despesa",
    [CategoryPurpose.Both]: "Ambas"
};

/** Extrai o tipo baseado nos valores de CategoryPurpose (1 | 2 | 3) */
export type CategoryPurposeType = typeof CategoryPurpose[keyof typeof CategoryPurpose];

/**
 * Representa a entidade Categoria. 
 * O 'id' é opcional para permitir a criação de novos objetos antes de possuírem um UUID do banco.
 */
export interface Category {
    id?: string;
    description: string;
    purpose: CategoryPurposeType;
}

/**
 * Espelha o Enum TransactionType do C#.
 */
export const TransactionType = {
    Income: 1,
    Expense: 2
} as const;

export type TransactionType = typeof TransactionType[keyof typeof TransactionType];

/**
 * Representa a entidade Transação.
 */
export interface Transaction {
    description: string;
    amount: number;
    type: TransactionType;
    categoryId: string;
    personId: string;
}