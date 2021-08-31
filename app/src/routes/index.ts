import { ResultadoFinalScreen, SelecaoCompetidoresScreen } from '../screens';

interface Route {
  name: string;
  path: string | string[] | undefined;
  component: React.ComponentType<any> | undefined,
}

export const routes: Route[] = [
  {
    name: 'resultado-final',
    path: '/resultado-final',
    component: ResultadoFinalScreen
  },
  {
    name: 'inicio',
    path: '/',
    component: SelecaoCompetidoresScreen
  }
];
