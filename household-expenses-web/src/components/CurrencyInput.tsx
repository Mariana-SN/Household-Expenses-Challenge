import React from 'react';

interface CurrencyInputProps {
  value: number;
  onChange: (numericValue: number) => void;
  placeholder?: string;
}

export const CurrencyInput = ({ value, onChange, placeholder }: CurrencyInputProps) => {
  
  /** Transforma o número em string formatada: 15.5 -> "R$ 15,50" */
  const formatCurrency = (val: number) => {
    return new Intl.NumberFormat('pt-BR', {
      style: 'currency',
      currency: 'BRL',
    }).format(val);
  };

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const rawValue = e.target.value.replace(/\D/g, ''); 
    const numericValue = Number(rawValue) / 100;
    onChange(numericValue);
  };

  return (
    <input
      type="text"
      placeholder={placeholder}
      value={value === 0 ? '' : formatCurrency(value)}
      onChange={handleChange}
      required
      style={{ textAlign: 'right' }}
    />
  );
};