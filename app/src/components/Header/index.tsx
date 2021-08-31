import React from 'react';

import styles from './styles.module.scss';

interface HeaderProps {
  titulo: string;
  subTitulo: string;
}

export const Header: React.FC<HeaderProps> = ({ titulo, subTitulo }) => {
  return (
    <header className={styles.headerContainer}>
      <p className={styles.tituloPrincipal}>CAMPEONATO DE FILMES</p>

      <h1>{titulo}</h1>

      <hr />

      <h3>{subTitulo}</h3>
    </header>
  );
};
