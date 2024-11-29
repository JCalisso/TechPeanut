document.addEventListener('DOMContentLoaded', async function () {
  // Obtém o parâmetro `id_pessoa` da URL
  const params = new URLSearchParams(window.location.search);
  const idPessoa = params.get('id_pessoa');

  if (!idPessoa) {
      document.getElementById('error-message').innerText = 'ID de pessoa não encontrado na URL.';
      document.getElementById('error-message').style.display = 'block';
      return;
  }

  const url = `https://localhost:62635/api/pessoas/v1/${idPessoa}`;

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

            const dataFormatada = formatarData(data.dT_Nascimento);
          // Preenchendo os campos do formulário
            document.getElementById('nome').value = data.nM_Pessoa || '';
            document.getElementById('tipo_pessoa').value = data.sT_Tipo_Pessoa || '';
            document.getElementById('documento').value = data.cD_Documento_Pessoa || '';
            document.getElementById('genero').value = data.sT_Genero || '';
            document.getElementById('data_nascimento').value = dataFormatada || '';
    }
    } catch (error) {
      // Caso ocorra algum erro na requisição (ex: falha de rede)
        document.getElementById('error-message').innerText = 'Erro ao conectar ao servidor.(Pessoa)';
        document.getElementById('error-message').style.display = 'block';
    }

  //============================ENDEREÇO========================================
    const EnderecoUrl = `https://localhost:62635/api/enderecos/v1/${idPessoa}`;

    try {
      // Fazendo a requisição GET para a API
        const response = await fetch(EnderecoUrl, {
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

          // Preenchendo os campos do formulário
            document.getElementById('endereco_rua').value = data.endereco || '';
            document.getElementById('endereco_numero').value = data.nO_Endereco || '';
            document.getElementById('endereco_bairro').value = data.bairro || '';
            document.getElementById('endereco_cep').value = data.cep || '';
            document.getElementById('observacoes').value = data.observacao || '';
        }
    } catch (error) {
      // Caso ocorra algum erro na requisição (ex: falha de rede)
        document.getElementById('error-message').innerText = 'Erro ao conectar ao servidor. Endereço';
        document.getElementById('error-message').style.display = 'block';
    }

    //============================TELEFONE========================================
      const urlPessoa = `https://localhost:62635/api/pessoas/v1/${idPessoa}`
      // Fazendo a requisição GET para a API
      const responsePessoa = await fetch(urlPessoa, {
          method: 'GET',
          headers: {
              'Content-Type': 'application/json'
          }
      });
  
      const dataPessoa = await responsePessoa.json();
      // console.log(dataPessoa);
      
      const idTelefonePessoa = dataPessoa.iD_Telefone_Principal;
    
      const TelefoneUrl = `https://localhost:62635/api/telefones/v1/${idTelefonePessoa}`;

    try {
      // Fazendo a requisição GET para a API
        const response = await fetch(TelefoneUrl, {
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
          console.log(data)
          // Preenchendo os campos do formulário
            document.getElementById('celular').value = data.telefone || '';
            document.getElementById('tipo').value = data.sT_Tipo_Telefone || '';
        }
    } catch (error) {
      // Caso ocorra algum erro na requisição (ex: falha de rede)
        document.getElementById('error-message').innerText = 'Erro ao conectar ao servidor.(Telefone)';
        document.getElementById('error-message').style.display = 'block';
    }
    //============================CARGO========================================
    const CargoUrl = `https://localhost:62635/api/cargos/v1/${idPessoa}`;

    try {
      // Fazendo a requisição GET para a API
        const response = await fetch(CargoUrl, {
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
            // console.log(data);
            

          // Preenchendo os campos do formulário
            document.getElementById('cargo').value = data.nM_Cargo || '';

        }
    } catch (error) {
      // Caso ocorra algum erro na requisição (ex: falha de rede)
        document.getElementById('error-message').innerText = 'Erro ao conectar ao servidor. Endereço';
        document.getElementById('error-message').style.display = 'block';
    }
    //============================FUNÇÃO========================================
    const FuncaoUrl = `https://localhost:62635/api/funcao/v1/${idPessoa}`
    try {
      // Fazendo a requisição GET para a API
        const response = await fetch(FuncaoUrl, {
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
            console.log(data);
            

          // Preenchendo os campos do formulário
            document.getElementById('funcao').value = data.nM_Funcao || '';

        }
    } catch (error) {
      // Caso ocorra algum erro na requisição (ex: falha de rede)
        document.getElementById('error-message').innerText = 'Erro ao conectar ao servidor. Endereço';
        document.getElementById('error-message').style.display = 'block';
    }
});

function formatarData(dataISO) {
    if (!dataISO) return '';
  // Remove a parte do horário, se existir
    const dataSemHora = dataISO.split('T')[0]; 
  // Divide a data em partes
    const [ano, mes, dia] = dataSemHora.split('-');
    return `${dia}/${mes}/${ano}`;
}