
document.getElementById('loginForm').addEventListener('submit', async function(event) {
  event.preventDefault(); // Impede o envio normal do formulário
  
  // Obtém os dados de usuário e senha
  const username = document.getElementById('email').value;
  const password = document.getElementById('senha').value;
  
  // Validação simples no lado do cliente (se necessário)
  if (!username || !password) {
      alert("Por favor, preencha ambos os campos.");
      return;
  }



  // https://localhost:62635/api/login/v1/valida-login?E_Mail=sysadmin%40sysadmin.com&Senha=Admin123
  const url = `https://localhost:7188/api/login/v1/valida-login?E_Mail=${encodeURIComponent(username)}&Senha=${encodeURIComponent(password)}`;

  try {
    
      // Fazendo a requisição POST para a API
      const response = await fetch(url, {
          method: 'GET',
          headers: {
              'Content-Type': 'application/json'
          }
      });

      if (!response.ok) {
          // Exibe uma mensagem de erro se a resposta não for OK
          const errorMessage = await response.json();
          document.getElementById('error-message').innerText = errorMessage.message || 'Erro ao tentar fazer login.';
          document.getElementById('error-message').style.display = 'block';
      } else {  
          // Caso o login seja bem-sucedido, redireciona para a página inicial
          const data = await response.json();
          if (data) {
              // Aqui, você pode armazenar o token em um local apropriado, como localStorage
              window.location.href = './listaUsers.html';  // Redireciona para a página inicial
          }
      }
  } catch (error) {
      // Caso ocorra algum erro na requisição (ex: falha de rede)
      document.getElementById('error-message').innerText = 'Erro ao conectar ao servidor.';
      document.getElementById('error-message').style.display = 'block';
  }
});
