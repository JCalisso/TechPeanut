document.addEventListener('DOMContentLoaded', async function(event) {
  const url = `https://localhost:62635/api/pessoas/v1`;

  try {
      // Fazendo a requisição GET para a API
      const response = await fetch(url, {
          method: 'GET',
          headers: {
              'Content-Type': 'application/json'
          }
      });

      if (!response.ok) {
          // Exibe uma mensagem de erro se a resposta não for OK
          const errorMessage = await response.json();
          document.getElementById('error-message').innerText = errorMessage.message || 'Erro ao buscar dados.';
          document.getElementById('error-message').style.display = 'block';
      } else {  
          // Caso a resposta seja bem-sucedida
          const data = await response.json();

          // Função para criar os cards
          createCards(data);
      }
  } catch (error) {
      // Caso ocorra algum erro na requisição (ex: falha de rede)
      document.getElementById('error-message').innerText = 'Erro ao conectar ao servidor.';
      document.getElementById('error-message').style.display = 'block';
  }
});

// Função para criar os cards
function createCards(data) {
  const container = document.getElementById('cards-container'); 

  // // Limpar o conteúdo atual do container
  // container.innerHTML = '';

  // Verificar se existem dados na resposta
  if (data && data.length > 0) {
      // Para cada pessoa no retorno da API
      data.forEach(person => {
          // Criando um card para cada pessoa
          const card = document.createElement('div');
          card.classList.add('users-card', 'text-center');
          card.style.width = '250px';

          // Criando a imagem (caso tenha uma imagem ou não)
          const img = document.createElement('img');
          img.classList.add('users-photo');
          img.alt = `Foto do usuário ${person.nM_Pessoa}`;

          // Verifica se existe um campo de foto ou se deve usar o ícone padrão
          if (person.foto && person.foto !== "") {
              img.src = person.foto; // Substitua por um campo real se a API retornar uma URL de imagem
          } else {
              img.src = './src/img/defaultUserIcon.jpg'; // img padrão
          }
          card.appendChild(img);

          // Criando o nome da pessoa
          const name = document.createElement('p');
          name.classList.add('users-name');
          name.textContent = person.nM_Pessoa;
          card.appendChild(name);
          
          // Criando o botão "Tarefas"
          const tasksButton = document.createElement('a');
          tasksButton.href = './userView.html';
          const tasksButtonElement = document.createElement('button');
          tasksButtonElement.classList.add('card-button');
          tasksButtonElement.textContent = 'Tarefas';
          tasksButtonElement.style.marginRight = '5px';  // Adicionando margem à direita
          tasksButtonElement.disabled = true;
          tasksButton.appendChild(tasksButtonElement);
          card.appendChild(tasksButton);
                  
          // Criando o botão "Perfil"
          const profileButton = document.createElement('a');
          profileButton.href = './perfilView.html';
          const profileButtonElement = document.createElement('button');
          profileButtonElement.classList.add('card-button');
          profileButtonElement.textContent = 'Perfil';
          profileButton.appendChild(profileButtonElement);
          card.appendChild(profileButton);
                    
          // Adicionando o card ao container
          container.appendChild(card);
      });
  } else {
      // Se não houver dados, exibe uma mensagem
      const noDataMessage = document.createElement('p');
      noDataMessage.textContent = 'Nenhuma pessoa encontrada.';
      container.appendChild(noDataMessage);
  }
}
