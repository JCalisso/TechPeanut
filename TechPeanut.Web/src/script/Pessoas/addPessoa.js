const port = '7188';
const baseurl = 'https://localhost:';

async function preencherDropdowns(){
  preencherCargo();
  preencherFuncao();
}

async function preencherCargo(){
  const cargo = {
    Id: 0,
    CD_Cargo: '',
    NM_Cargo: '',
    SN_Ativo: false
  }
  const dropdownCargo = document.getElementById('cargo');
  const url = `${baseurl + port}/api/cargos/v1/`;
  const config = setConfig('GET', cargo, false);

  await executaRequisicao(url,config).then(data => {
    dropdownCargo.innerHTML = '';
                    
    // Cria a opção padrão
    const optionDefault = document.createElement('option');
    optionDefault.value = '';
    optionDefault.textContent = 'Selecione um Cargo';
    dropdownCargo.appendChild(optionDefault);

    // Preenche o dropdown com as opções da API
    data.forEach(item => {
      const option = document.createElement('option');
      if (item.sN_Ativo === true){
        option.value = item.id;  // Supondo que o item tenha um campo 'id'
        option.textContent = item.cD_Cargo + ' - ' + item.nM_Cargo;  // Supondo que o item tenha um campo 'nome'
        dropdownCargo.appendChild(option);        
      }
    });
  });
}

async function preencherFuncao(){
  const funcao = {
    Id: 0,
    CD_Funcao: '',
    NM_Funcao: '',
    SN_Ativo: false
  }
  const dropdownFuncao = document.getElementById('funcao');
  const url = `${baseurl + port}/api/funcao/v1/`;
  const config = setConfig('GET', cargo, false);

  await executaRequisicao(url,config).then(data => {
    dropdownFuncao.innerHTML = '';
                    
    // Cria a opção padrão
    const optionDefault = document.createElement('option');
    optionDefault.value = '';
    optionDefault.textContent = 'Selecione uma Função';
    dropdownFuncao.appendChild(optionDefault);

    // Preenche o dropdown com as opções da API
    data.forEach(item => {
      const option = document.createElement('option');
      if (item.sN_Ativo === true){
        option.value = item.id;  // Supondo que o item tenha um campo 'id'
        option.textContent = item.cD_Funcao + ' - ' + item.nM_Funcao;  // Supondo que o item tenha um campo 'nome'
        dropdownFuncao.appendChild(option);        
      }
    });
  });
}

// Função para cadastrar uma pessoa
async function cadastrarPessoa(event) {
  event.preventDefault();
  // Dados da pessoa a ser cadastrada  
  const pessoa = {
    Id: 0,
    NM_Pessoa: document.getElementById('nome').value,
    ST_Tipo_Pessoa: document.getElementById('tipo_pessoa').value,
    CD_Documento_Pessoa: removerFormatacao(document.getElementById('documento').value),
    DT_Nascimento: FormataStringData(document.getElementById('data_nascimento').value),
    ST_Genero: document.getElementById('genero').value,
    ID_Telefone_Principal: 0,
    ID_Funcao: 0,
    ID_Cargo: 0,
    ID_Dados_Bancarios: 0,
    ID_Endereco: 0,
  };
  // URL da API onde os dados serão enviados
  const url = `${baseurl + port}/api/pessoas/v1/`;

  // Configurações da requisição 
  const config = setConfig('POST', pessoa, true)

  try{
    const responsePessoa = await executaRequisicao(url,config);

    pessoa.Id = responsePessoa.id;

    if(pessoa.Id != 0){    
      //registra o telefone
      pessoa.ID_Telefone_Principal = ID_Telefone = await cadastrarTelefone(pessoa.Id);
      pessoa.ID_Endereco = await cadastrarEndereco();

      await atualizaPessoa(pessoa);
    }
  } catch(err){
    console.error('Erro ao fazer a cadastrar a pessoa', err);
    return null;  // Retorna null em caso de erro
  }
  
}
  
// cadastra telefone
async function cadastrarTelefone(ID_Pessoa){
  const telefone = {
    Id: 0,
    ID_Pessoa: ID_Pessoa,
    telefone: removerFormatacao(document.getElementById('celular').value),
    ST_Tipo_Telefone: document.getElementById('tipo').value,
    SN_Principal: 'S'
  }

  // URL da API onde os dados serão enviados
  const url = `${baseurl + port}/api/telefones/v1/`;
  // Configurações da requisição 
  const config = setConfig('POST', telefone, true);
  const responseTelefone = await executaRequisicao(url,config);

  return responseTelefone.id;
}

// cadastra telefone
async function cadastrarEndereco(){
  const endereco = {
    Id: 0,
    Endereco: document.getElementById('endereco_rua').value,
    Bairro: document.getElementById('endereco_bairro').value,
    NO_Endereco: document.getElementById('endereco_numero').value, 
    CEP: document.getElementById('endereco_cep').value, 
    Observacao: document.getElementById('observacoes').value
  }

  // URL da API onde os dados serão enviados
  const url = `${baseurl + port}/api/enderecos/v1/`;
  // Configurações da requisição 
  const config = setConfig('POST', endereco, true);
  const responseEndereco = await executaRequisicao(url,config);

  return responseEndereco.id;
}

async function atualizaPessoa(pessoa){
  const url = `${baseurl + port}/api/pessoas/v1/`;
  const config = setConfig('PUT', pessoa, true)
  return responseAtualizaPessoa = await executaRequisicao(url,config);
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

function removerFormatacao(valor_formatado) {
  // Remove todos os caracteres que não são números (0-9)
  return valor_formatado.replace(/\D/g, ''); 
}
// formata data 
function FormataStringData(data) {
  var dia  = data.split("/")[0];
  var mes  = data.split("/")[1];
  var ano  = data.split("/")[2];

  return ano + '-' + ("0"+mes).slice(-2) + '-' + ("0"+dia).slice(-2);
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
document.getElementById('btnGravaPessoa').addEventListener('click', cadastrarPessoa);
document.getElementById('btnCancelar').addEventListener('click', btnLimparCampos);