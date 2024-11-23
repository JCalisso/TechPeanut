const port = '7188';
const baseurl = 'https://localhost:';

// Função para cadastrar uma pessoa
async function addCargo(event) {
  event.preventDefault();
  const cargo = {
    Id: 0,
    CD_Cargo: document.getElementById('codigo_cargo').value,
    NM_Cargo: document.getElementById('nome_cargo').value,
    SN_Ativo: document.getElementById('sn_ativo').value = 'S' ? true : false,
  }

  // URL da API onde os dados serão enviados
  const url = `${baseurl + port}/api/cargos/v1/`;

  // Configurações da requisição 
  const config = setConfig('POST', cargo, true)
  
  try{
    const response = await executaRequisicao(url,config);
    console.log(response.id)

    alert('Cargo adicionado com sucesso!',response.nM_Cargo)
    console.log(cargo);
    
  } catch(err){
    alert('Erro ao cadastrar o cargo!', err);
    return;
  }
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

function setConfig(method, body, usaBody){
  if (usaBody === false){
    return config = {
      method: method,
      headers: {
        'Content-Type': 'application/json'
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

function btnLimparCampos(){
  // Pessoa
  limparCamposInput('#PessoaForm input');
  document.getElementById('tipo_pessoa').value = "";
  document.getElementById('documento').disabled = true;
  document.getElementById('genero').value = "";
  document.getElementById('cargo').value = "";
  document.getElementById('funcao').value = "";

  // Telefone
  limparCamposInput('#TelefoneForm input');

  // Endereco
  limparCamposInput('#EnderecoForm input');
  document.getElementById('observacoes').value = '';  
} 

function limparCamposInput(selector) {
  // Seleciona todos os elementos de input dentro do formulário
  var inputs = document.querySelectorAll(selector);

  // Loop para limpar todos os campos de entrada
  inputs.forEach(function(input) {
      input.value = ''; // Limpa o valor de cada input
  });
}


// Chama a função para realizar o cadastro
document.getElementById('btnGrava').addEventListener('click', addCargo);