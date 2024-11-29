document.addEventListener('DOMContentLoaded', async function(event) {
  const url = `https://localhost:7188/api/pessoas/v1`;

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

            //=====================================================================
            // Criando o botão "Edit" com o id_pessoa
            const EditButton = document.createElement('a');
            EditButton.href = `./editPessoa.html?id_pessoa=${person.id}`; // URL com o id_pessoa dinâmico
            EditButton.classList.add('btn', 'btn-primary',  'me-1'); // Adicionando classes ao elemento "a"
            
            // Criando o ícone dentro do botão
            const EditButtonElement = document.createElement('span');
            EditButtonElement.classList.add('fa', 'fa-pen'); // Adicionando classes ao elemento "span"
            
            // Anexando o ícone ao botão
            EditButton.appendChild(EditButtonElement);
            
            // Adicionando o botão ao card
            card.appendChild(EditButton);
            
            // Adicionando o card ao container
            container.appendChild(card);
            //=====================================================================

            //=====================================================================
            // Criando o botão "View" com o id_pessoa
            const profileButton = document.createElement('a');
            profileButton.href = `./viewPessoa.html?id_pessoa=${person.id}`; // URL com o id_pessoa dinâmico
            profileButton.classList.add('btn', 'btn-warning', 'me-1'); // Adicionando classes ao elemento "a"
            
            // Criando o ícone dentro do botão
            const profileButtonElement = document.createElement('span');
            profileButtonElement.classList.add('fa', 'fa-eye'); // Adicionando classes ao elemento "span"
            
            // Anexando o ícone ao botão
            profileButton.appendChild(profileButtonElement);
            
            // Adicionando o botão ao card
            card.appendChild(profileButton);
            
            // Adicionando o card ao container
            container.appendChild(card);
            //=====================================================================

            //=====================================================================
            // Criando o botão "Delete" com o id_pessoa
            const deleteButton = document.createElement('a');
            deleteButton.classList.add('btn', 'btn-danger'); // Adicionando classes ao elemento "a"
            deleteButton.onclick = () => deletarPessoa(person); // Chamando a função com o id_pessoa dinâmico
            

            // Criando o ícone dentro do botão
            const deleteButtonElement = document.createElement('span');
            deleteButtonElement.classList.add('fa', 'fa-trash'); // Adicionando classes ao elemento "span"
                    
            // Anexando o ícone ao botão
            deleteButton.appendChild(deleteButtonElement);
                    
            // Adicionando o botão ao card
            card.appendChild(deleteButton);
                    
            // Adicionando o card ao container
            container.appendChild(card);
                        //=====================================================================

            // window.reload()
        });
    } else {    
        // Se não houver dados, exibe uma mensagem
        const noDataMessage = document.createElement('p');
        noDataMessage.textContent = 'Nenhuma pessoa encontrada.';
        container.appendChild(noDataMessage);
    }
}
