import axios from 'axios';

import config from '../../config';
import { Campeonato } from '../../models';

const { apiUrl } = config;

export const gerarCampeonato = async (filmesId: string[]): Promise<Campeonato | undefined> => {
  const request = { filmesId };

  const { data } = await axios.post(`${apiUrl}/campeonatos`, request);

  return data;
}
