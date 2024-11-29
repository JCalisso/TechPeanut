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
  const inputNome = document.getElementById('nome');
  const inputTipoPessoa = document.getElementById('tipo_pessoa');
  const inputDocumento = document.getElementById('documento');
  const inputDataNasc = document.getElementById('data_nascimento');
  const inputGenero = document.getElementById('genero');

  const inputTelefone = document.getElementById('celular');
  const inputTipoTelefone = document.getElementById('tipo');

  const inputRua = document.getElementById('endereco_rua');
  const inputBairro = document.getElementById('endereco_bairro');
  const inputNumero = document.getElementById('endereco_numero');
  const inputCep = document.getElementById('endereco_cep');

  const pessoa = {
    Id: 0,
    NM_Pessoa: inputNome.value,
    ST_Tipo_Pessoa: inputTipoPessoa.value,
    CD_Documento_Pessoa: removerFormatacao(inputDocumento.value),
    DT_Nascimento: FormataStringData(inputDataNasc.value),
    ST_Genero: inputGenero.value,
    ID_Telefone_Principal: 0,
    ID_Funcao: 0,
    ID_Cargo: 0,
    ID_Dados_Bancarios: 0,
    ID_Endereco: 0,
  };

  pessoa.ID_Cargo = document.getElementById('cargo').value;
  pessoa.ID_Funcao = document.getElementById('funcao').value;


  // URL da API onde os dados serão enviados
  const url = `${baseurl + port}/api/pessoas/v1/`;

  // Configurações da requisição 
  const config = setConfig('POST', pessoa, true)

  try{
    if (pessoa.NM_Pessoa == ''){
      inputNome.focus();
      alert('Nome da pessoa não inserido(a)!');
      throw new Error('Nome da pessoa não inserido(a)!');
    }

    if (pessoa.ST_Tipo_Pessoa == ''){
      inputTipoPessoa.focus();
      alert('Tipo da pessoa não selecionado!');
      throw new Error('Tipo da pessoa não selecionado!');
    }

    if (pessoa.CD_Documento_Pessoa == ''){
      inputDocumento.focus();
      alert('CPF/CNPJ da pessoa não inserido(a)!');
      throw new Error('CPF/CNPJ da pessoa não inserido(a)!');
    }

    if (pessoa.DT_Nascimento == ''){
      inputDataNasc.focus();
      alert('Data de nascimento da pessoa não inserido(a)!');
      throw new Error('Data de nascimento da pessoa não inserido(a)!');
    }

    if (inputGenero.value == ''){
      inputGenero.focus();
      alert('Gênero da pessoa não selecionado(a)!');
      throw new Error('Gênero da pessoa não selecionado(a)!');
    }

    //telefone
    if ((inputTelefone.value == '') || (!validarTelefone(inputTelefone.value))){
      inputTelefone.focus();
      alert('Telefone não inserido(a) ou inválido!');
      throw new Error('Telefone não inserido(a) ou inválido!');
    }
  
    if (inputTipoTelefone.value == ''){
      inputTipoTelefone.focus();
      alert('Tipo de telefone não selecionado!');
      throw new Error('Tipo de telefone não selecionado!');
    }

    // endereco
    if (inputRua.value == ''){
      inputRua.focus();
      alert('Endereço não inserido(a)!');
      throw new Error('Endereço não inserido(a)!');
    }

    if (inputNumero.value == ''){
      inputNumero.focus();
      alert('Número não inserido(a)!');
      throw new Error('Número não inserido(a)!');
    }

    if (inputBairro.value == ''){
      inputBairro.focus();
      throw new Error('Bairro não inserido(a)!');
    }
    
    if ((inputCep.value == '') || (!validarCep(inputCep.value))) {
      inputCep.focus();
      alert('CEP não inserido(a) ou inválido!');
      throw new Error('CEP não inserido(a) ou inválido!');
    }

    const responsePessoa = {}
    await executaRequisicao(url, config)
      .then(data => {
        responsePessoa = data;
      })
      .catch(error => {
        throw new Error('Erro ao fazer a requisição:', error);
      });


    pessoa.Id = responsePessoa.id;

    if(pessoa.Id != 0){    
      //registra o telefone
      pessoa.ID_Telefone_Principal = ID_Telefone = await cadastrarTelefone(pessoa.Id);
      pessoa.ID_Endereco = await cadastrarEndereco();

      await atualizaPessoa(pessoa);
      btnLimparCampos();
    }
  } catch(err){
    throw (err);
  }
}
  
// cadastra telefone
async function cadastrarTelefone(ID_Pessoa){
  const inputTelefone = document.getElementById('celular');
  const inputTipoTelefone = document.getElementById('tipo');
  
  const telefone = {
    Id: 0,
    ID_Pessoa: ID_Pessoa,
    telefone: removerFormatacao(inputTelefone.value),
    ST_Tipo_Telefone: inputTipoTelefone.value,
    SN_Principal: 'S'
  }
  try{
    if (telefone.telefone == ''){
      inputTelefone.focus();
      throw new Error('Telefone não inserido(a)!');
    }
  
    if (telefone.ST_Tipo_Telefone == ''){
      inputTipoTelefone.focus();
      throw new Error('Tipo de telefone não selecionado!');
    }

    // URL da API onde os dados serão enviados
    const url = `${baseurl + port}/api/telefones/v1/`;
    // Configurações da requisição 
    const config = setConfig('POST', telefone, true);

    const responseTelefone = await executaRequisicao(url,config);

    telefone.Id = responseTelefone.id;
  } catch(err){
    throw ('Erro ao cadastrar o telefone da pessoa');
  }
  return telefone.Id;
}

// cadastra telefone
async function cadastrarEndereco(){
  const inputRua = document.getElementById('endereco_rua');
  const inputBairro = document.getElementById('endereco_bairro');
  const inputNumero = document.getElementById('endereco_numero');
  const inputCep = document.getElementById('endereco_cep');
  const inputObservacoes = document.getElementById('observacoes');

  const endereco = {
    Id: 0,
    Endereco: inputRua.value,
    Bairro: inputBairro.value,
    NO_Endereco: inputNumero.value, 
    CEP: removerFormatacao(inputCep.value), 
    Observacao: inputObservacoes.value
  }

  try {
    // URL da API onde os dados serão enviados
    const url = `${baseurl + port}/api/enderecos/v1/`;
    // Configurações da requisição 
    const config = setConfig('POST', endereco, true);

    if (endereco.Endereco == ''){
      inputRua.focus();
      throw new Error('Endereço não inserido(a)!');
    }

    if (endereco.Bairro == ''){
      inputRua.focus();
      throw new Error('Bairro não inserido(a)!');
    }

    if (endereco.NO_Endereco == ''){
      inputRua.focus();
      throw new Error('Número não inserido(a)!');
    }
    
    if (endereco.CEP == ''){
      inputRua.focus();
      throw new Error('CEP não inserido(a)!');
    }

    const responseEndereco = await executaRequisicao(url,config);

    endereco.Id = responseEndereco.id;

  } catch(error) {
    throw ('Erro ao cadastrar o endereço da pessoa');
  }
  return endereco.Id;
}

async function atualizaPessoa(pessoa){
  const url = `${baseurl + port}/api/pessoas/v1/`;
  const config = setConfig('PUT', pessoa, true)
  return responseAtualizaPessoa = await executaRequisicao(url,config);
}

async function excluiPessoa(Id){
  const url = `${baseurl + port}/api/pessoas/v1/${Id}`;
  const config = setConfig('DELETE', {}, false)
  return responseExcluiPessoa = await executaRequisicao(url,config);
}

async function excluiTelefone(Id){
  const url = `${baseurl + port}/api/telefones/v1/${Id}`;
  const config = setConfig('DELETE', {}, false)
  return responseExcluiPessoa = await executaRequisicao(url,config);
}

async function excluiEdereco(Id){
  const url = `${baseurl + port}/api/enderecos/v1/${Id}`;
  const config = setConfig('DELETE', {}, false)
  return responseExcluiPessoa = await executaRequisicao(url,config);
}

async function executaRequisicao(url, config) {
  try {
    const response = await fetch(url, config); // Espera a resposta da API

    if (!response.ok) {
      throw new Error('Erro na requisição');
    }
    
    const data = await response.json();
    
    return data;  // Retorna o JSON da API
  } catch (e) {
    console.error('Erro na requisição:', error);
    return { error: error.message };
  }
}

function removerFormatacao(valor_formatado) {
  // Remove todos os caracteres que não são números (0-9)
  return valor_formatado.replace(/\D/g, ''); 
}
// formata data 
function FormataStringData(data) {
  if (data === '') {
    return '';
  }
  var dia  = data.split("/")[0];
  var mes  = data.split("/")[1];
  var ano  = data.split("/")[2];

  return ano + '-' + ("0"+mes).slice(-2) + '-' + ("0"+dia).slice(-2);
}

function validarCep(cep) {
  // Remove espaços em branco e traços
  cep = cep.replace("-", "").trim();

  // Verifica se o CEP tem exatamente 8 dígitos numéricos
  const regex = /^\d{8}$/;

  return regex.test(cep);
}

function validarTelefone(telefone) {
  // Remove espaços em branco, parênteses e traços
  telefone = telefone.replace(/\D/g, "").trim(); // Remove tudo que não for número

  // Verifica se o telefone tem exatamente 10 ou 11 dígitos numéricos
  const regex = /^(?:\d{10}|\d{11})$/;

  return regex.test(telefone);
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