const fs = require('fs');

export function getConfigBaseUrl (){
  fs.readFile('../../webconfig.json', 'utf-8', (err, data) => {
  if (err) {
    console.error('Erro ao ler arquivo de configuração', err);
    return
  }

  const config = JSON.parse(data);

  const port = config.port;
  const baseurl = config.baseurl;

  console.log('Porta:', port);
  console.log('Base URL:', baseurl);
});
}