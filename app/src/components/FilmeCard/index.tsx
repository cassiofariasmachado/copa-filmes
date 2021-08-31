import styles from './styles.module.scss';

interface FilmeCardProps {
  titulo: string;
  ano: number;
  selected?: boolean;
}

export const FilmeCard: React.FC<FilmeCardProps> = ({ titulo, ano, selected = false }) => {
  return (
    <div className={styles.cardContainer}>
      <div className={styles.cardCheckbox}>
        <input type="checkbox" checked={selected} readOnly />
      </div>
      <div className={styles.cardContent}>
        <strong>{titulo}</strong>
        <span>{ano}</span>
      </div>
    </div>
  );
};
