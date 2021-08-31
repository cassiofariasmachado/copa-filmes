import React, { useEffect, useState } from 'react';
import { useHistory } from 'react-router';

import { Header, FilmeCard, Button } from '../../components';
import { Filme } from '../../models';
import { gerarCampeonato, listarFilmes } from '../../services/api';

import styles from './styles.module.scss';

export const SelecaoCompetidoresScreen: React.FC = () => {
  const [filmes, definirFilmes] = useState<Filme[]>([])
  const [filmesSelecionados, definirFilmesSelecionados] = useState<Filme[]>([]);
  const history = useHistory();

  const aoSelecionarFilme = (filme: Filme) => {
    const filmeJaSelecionado = filmesSelecionados.find(f => f.id === filme.id);

    if (filmesSelecionados.length >= 8 && !filmeJaSelecionado) {
      alert('Máximo de filmes permitido é 8 filmes.');
      return;
    }

    if (filmeJaSelecionado) {
      definirFilmesSelecionados(filmesSelecionados.filter(f => f.id !== filme.id));
      return;
    }

    definirFilmesSelecionados([...filmesSelecionados, filme]);
  };

  const aoGerarCampeonato = async () => {
    if (filmesSelecionados.length !== 8) {
      alert('Selecione no mínimo 8 filmes para continuar.');
      return;
    }

    try {
      const campeonato = await gerarCampeonato(filmesSelecionados.map(f => f.id));

      history.push('/resultado-final', { campeonato });
    } catch {
      alert('Ocorreu um erro ao gerar o campeonato.')
    }
  };

  useEffect(
    () => {
      async function obterFilmesDisponiveis() {
        const novosFilmes = await listarFilmes();

        if (!novosFilmes) return;

        definirFilmes(novosFilmes);
      }

      obterFilmesDisponiveis();
    },
    []
  );

  const renderFilmes = () => {
    if (!filmes) return undefined;

    return filmes.map(filme => (
      <div className={styles.card} onClick={() => aoSelecionarFilme(filme)}>
        <FilmeCard titulo={filme.titulo} ano={filme.ano} selected={filmesSelecionados.some(f => f.id === filme.id)} />
      </div>
    ))
  }

  return (
    <div className={styles.screenContainer}>
      <Header
        titulo="Fase de seleção"
        subTitulo="Selecione 8 filmes que você deseja que entrem na competição e depois pressione o botão Gerar Meu Campeonato para prosseguir."
      />

      <div className={styles.buttonsContainer}>
        <div>
          <p>
            Selecionados
          </p>
          <p>
            {filmesSelecionados.length} de 8 filmes.
          </p>
        </div>
        <Button onClick={aoGerarCampeonato} titulo="GERAR MEU CAMPEONATO"></Button>
      </div>

      <div className={styles.cardContainer}>
        {renderFilmes()}
      </div>
    </div>
  );
};
