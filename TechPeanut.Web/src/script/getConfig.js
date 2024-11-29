// const fs = require('fs');  // Substitui o 'import'

// function getConfigBaseUrl() {
//   fs.readFile('../../webconfig.json', 'utf-8', (err, data) => {
//     if (err) {
//       console.error('Erro ao ler arquivo de configuração', err);
//       return;
//     }

//     const config = JSON.parse(data);
//     const { port, baseurl } = config;  // Acesso correto às propriedades do config

//     console.log('Porta:', port);
//     console.log('Base URL:', baseurl);

//     return config;
//   });
// }

// module.exports = getConfigBaseUrl;  // Exporta a função no formato CommonJS
