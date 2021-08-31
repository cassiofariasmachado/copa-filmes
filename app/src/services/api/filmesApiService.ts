import axios from 'axios';

import config from '../../config';
import { Filme } from '../../models/filme';

const { apiUrl } = config;

export const listarFilmes = async (): Promise<Filme[] | undefined> => {
  const { data } = await axios.get(`${apiUrl}/filmes`);

  return data;
}
