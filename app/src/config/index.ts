interface Config {
  apiUrl: string;
}

const config: Config = {
  apiUrl: process.env.REACT_APP_API_URL || 'https://localhost:5001'
}

export default config;
