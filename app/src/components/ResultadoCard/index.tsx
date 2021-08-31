import styles from './styles.module.scss';

interface ResultadoCardProps {
  titulo: string;
  posicao: number;
}

export const ResultadoCard: React.FC<ResultadoCardProps> = ({ titulo, posicao }) => {
  return (
    <div className={styles.cardContainer}>
      <div className={styles.posicaoContainer}>
        {posicao}°
      </div>
      <div>
        <h3>{titulo}</h3>
      </div>
    </div>
  );
};
