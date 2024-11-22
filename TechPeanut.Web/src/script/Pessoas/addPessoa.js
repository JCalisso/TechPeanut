const port = '7188';
const baseurl = 'https://localhost:';

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
  const config = setConfig('POST', pessoa)
  const responsePessoa = await executaRequisicao(url,config);

  pessoa.Id = responsePessoa.id;
  
  if(pessoa.Id != 0){    
    //registra o telefone
    pessoa.ID_Telefone_Principal = ID_Telefone = await cadastrarTelefone(pessoa.Id);

    const responseAtualizaPessoa = await atualizaPessoa(pessoa)
    if (responseAtualizaPessoa){
      alert('Pessoa cadastrada com sucesso!')
    }
  }else{
    alert('Falha ao efetuar o cadastro da pessoa.');
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
  const config = setConfig('POST', telefone);
  const responseTelefone = await executaRequisicao(url,config);

  return responseTelefone.id;
}

async function atualizaPessoa(pessoa){
  const url = `${baseurl + port}/api/pessoas/v1/`;
  const config = setConfig('PUT', pessoa)
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

function setConfig(method, body){
  return config = {
    method: method,
    headers: {
      'Content-Type': 'application/json',  // Especifica que o conteúdo enviado é em JSON
      'accept': 'text/plain'
    },
    body: JSON.stringify(body)  // Converte o objeto 'pessoa' para uma string JSON
  };
}

// Chama a função para realizar o cadastro
document.getElementById('btnGravaPessoa').addEventListener('click', cadastrarPessoa);