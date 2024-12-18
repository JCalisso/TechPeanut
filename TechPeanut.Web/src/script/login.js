const baseurl = 'https://localhost:';
const port = '7188';

document.getElementById('loginForm').addEventListener('submit', async function(event) {
  event.preventDefault(); // Impede o envio normal do formulário
  
  const login = {
    email: document.getElementById('email').value,
    senha: document.getElementById('senha').value
  }
  
  // Validação simples no lado do cliente (se necessário)
  if (!login.email || !login.senha) {
      alert("Por favor, preencha ambos os campos.");
      return;
  }

  const url = `${baseurl + port}/api/login/v1/valida-login?E_Mail=${login.email}&Senha=${login.senha}`;
  const configHeaders = setConfig('GET', {}, false)

  try {
    const response = await executaRequisicao(url, configHeaders)
    console.log(response[0].iD_Pessoa)
    if (response[0]) {
        // Aqui, você pode armazenar o token em um local apropriado, como localStorage
        window.location.href = './listaUsers.html';  // Redireciona para a página inicial
    }
  } catch (error) {
      // Caso ocorra algum erro na requisição (ex: falha de rede)
      document.getElementById('error-message').innerText = 'Erro ao conectar ao servidor.';
      document.getElementById('error-message').style.display = 'block';
  }
});


function setConfig(method, body, usaBody){
    if (usaBody === false){
      return config = {
        method: method,
        headers: {
          'Content-Type': 'application/json',
          'accept': 'text/plain'
        }
      };
    }
  
    return config = {
      method: method,
      headers: {
        'Content-Type': 'application/json',  // Especifica que o conteúdo enviado é em JSON
        'accept': 'text/plain'
      },
      body: JSON.stringify(body)  // Converte o objeto 'pessoa' para uma string JSON
    };
  }

  async function executaRequisicao(url, config){
    try {
      const response = await fetch(url, config); // Espera a resposta da API
      if (!response.ok) {
        throw new Error('Erro na requisição');
      }
      const data = await response.json(); // Converte a resposta para JSON
      return data;  // Retorna o JSON da API
    } catch (error) {
      console.error('Erro ao fazer a requisição:', error);
      return null;  // Retorna null em caso de erro
    }
  }