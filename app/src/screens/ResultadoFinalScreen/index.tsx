import React, { useEffect, useState } from 'react';
import { useHistory, useLocation } from 'react-router';

import { Header, ResultadoCard } from '../../components';
import { Campeonato } from '../../models';

import styles from './styles.module.scss';

export const ResultadoFinalScreen: React.FC = () => {
  const [campeonato, definirCampeonato] = useState<Campeonato>();
  const history = useHistory();
  const location = useLocation<{ campeonato?: Campeonato }>();

  useEffect(
    () => {
      if (!location.state.campeonato) {
        history.push('/');
        return;
      }

      definirCampeonato(location.state.campeonato);
    },
    [history, location.state]
  );

  const renderResultado = () => {
    if (!campeonato) return undefined;

    return <>
      <ResultadoCard titulo={campeonato?.campeao.titulo} posicao={1} />
      <ResultadoCard titulo={campeonato?.viceCampeao.titulo} posicao={2} />
    </>
  }

  return (
    <div className={styles.screenContainer}>
      <Header
        titulo="Resultado final"
        subTitulo="Veja o resultado final do Campeonato de Filmes de forma simples e rápida."
      />

      <div className={styles.resultadosContainer}>
        {renderResultado()}
      </div>
    </div>
  );
};
