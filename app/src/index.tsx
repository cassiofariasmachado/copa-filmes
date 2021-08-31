import React from 'react';
import ReactDOM from 'react-dom';
import {
  BrowserRouter as Router,
  Switch,
  Route
} from 'react-router-dom';

import { routes } from './routes';

import './styles/global.scss';

ReactDOM.render(
  <React.StrictMode>
    <Router>
      <Switch>
        {routes.map(({ name, path, component }) =>
          <Route
            key={name}
            path={path}
            component={component}
          />
        )}
      </Switch>
    </Router>
  </React.StrictMode>,
  document.getElementById('root')
);

