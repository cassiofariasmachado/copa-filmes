import React, { ButtonHTMLAttributes } from 'react';

import styles from './styles.module.scss';

interface ButtonProps extends ButtonHTMLAttributes<HTMLButtonElement> {
  titulo: string;
}

export const Button: React.FC<ButtonProps> = ({ titulo, ...rest }) => {
  return (
    <button className={styles.button} {...rest}>
      {titulo}
    </button>
  );
};
