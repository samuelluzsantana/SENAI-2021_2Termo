import { React, Component } from 'react';
import axios from 'axios';

export default class Eventos extends Component {
    constructor(props){
        super(props);
        this.state = {
            titulo : '',
            descricao : '',
            dataEvento : new Date(),
            acessoLivre : 0,
            idTipoEvento : 0,
            idInstituicao : 0,
            listaTiposEventos : [],
            listaInstituicoes : [],
            listaEventos : [],
            isLoading : false
        }
    };

    // Função responsável por fazer a requisição e trazer a lista de tipos eventos
    buscarTiposEventos = () => {
        // Faz a chamada para a API usando o axios
        axios('http://localhost:5000/api/tiposeventos', {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
        .then(resposta => {
            // Caso a requisição retorne um status code 200
            if (resposta.status === 200) {
                // atualiza o state listaTiposEventos com os dados obtidos
                this.setState({ listaTiposEventos : resposta.data })
                // e mostra no console do navegador a lista de tipos eventos
                console.log(this.state.listaTiposEventos)
            }
        })
        // Caso ocorra algum erro, mostra no console do navegador
        .catch(erro => console.log(erro));
    };

    // Função responsável por fazer a requisição e trazer a lista de instituições
    buscarInstituicoes = () => {
        // Faz a chamada para a API usando o axios
        axios('http://localhost:5000/api/instituicoes', {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
        .then(resposta => {
            // Caso a requisição retorne um status code 200
            if (resposta.status === 200) {
                // atualiza o state listaInstituicoes com os dados obtidos
                this.setState({ listaInstituicoes : resposta.data })
                // e mostra no console do navegador a lista de instituições
                console.log(this.state.listaInstituicoes)
            }
        })
        // Caso ocorra algum erro, mostra no console do navegador
        .catch(erro => console.log(erro));
    };

    // Função responsável por fazer a requisição e trazer a lista de eventos
    buscarEventos = () => {
        // Faz a chamada para a API usando o axios
        axios('http://localhost:5000/api/eventos', {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
        .then(resposta => {
            // Caso a requisição retorne um status code 200
            if (resposta.status === 200) {
                // atualiza o state listaEventos com os dados obtidos
                this.setState({ listaEventos : resposta.data })
                // e mostra no console do navegador a lista de eventos
                console.log(this.state.listaEventos)
            }
        })
        // Caso ocorra algum erro, mostra no console do navegador
        .catch(erro => console.log(erro));
    };

    // Chama as funções assim que a tela é renderizada
    componentDidMount(){
        this.buscarTiposEventos();
        this.buscarInstituicoes();
        this.buscarEventos();
    };

    // Função que faz a chamada para a API para cadastrar um evento
    cadastrarEvento = (event) => {
        // Ignora o comportamento padrão do navegador
        event.preventDefault();
        // Define que a requisição está em andamento
        this.setState({ isLoading : true })

        // Define um evento que recebe os dados do state
        // É necessário converter o acessoLivre para int, para que o back-end consiga converter para bool ao cadastrar
        // Como o navegador envia o dado como string, não é possível converter para bool implicitamente
        let evento = {
            nomeEvento : this.state.titulo,
            descricao : this.state.descricao,
            dataEvento : new Date( this.state.dataEvento ),
            acessoLivre : parseInt( this.state.acessoLivre ),
            idTipoEvento : this.state.idTipoEvento,
            idInstituicao : this.state.idInstituicao
        };

        // Define a URL e o corpo da requisição
        axios.post('http://localhost:5000/api/eventos', evento, {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

        // Verifica o retorno da requisição
        .then(resposta => {
            // Caso retorne status code 200,
            if (resposta.status === 201) {
                // exibe no console do navegador a mensagem abaixo
                console.log('Evento cadastrado!')
                // e define que a requisição terminou
                this.setState({ isLoading : false })
            }
        })

        // Caso haja algum erro, exibe este erro no console do navegador
        .catch(erro => {
            console.log(erro);
            // e define que a requisição terminou
            this.setState({ isLoading : false });
        })

        // Então, atualiza a lista de Eventos
        // sem o usuário precisar executar outra ação
        .then(this.buscarEventos)
    };

    // Função genérica que atualiza o state de acordo com o input
    // pode ser reutilizada em vários inputs diferentes
    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name] : campo.target.value })
    };

    render(){
        return(
            <>
                <main>
                    <section>
                        {/* Lista de Eventos */}
                        <h2>Lista de Eventos</h2>
                        <table style={{ borderCollapse : 'separate', borderSpacing : 30 }}>
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th>Evento</th>
                                    <th>Descrição</th>
                                    <th>Data</th>
                                    <th>Acesso Livre</th>
                                    <th>Tipo de Evento</th>
                                    <th>Localização</th>
                                </tr>
                            </thead>

                            <tbody>
                                {/* Preenche o corpo da tabela usando a função map() */}

                                {
                                    this.state.listaEventos.map( evento => {
                                        return(
                                            <tr key={evento.idEvento}>
                                                <td>{evento.idEvento}</td>
                                                <td>{evento.nomeEvento}</td>
                                                <td>{evento.descricao}</td>
                                                <td>{Intl.DateTimeFormat("pt-BR").format(new Date(evento.dataEvento))}</td>

                                                {/* 
                                                
                                                    ESTRUTURA IF TERNÁRIO
                                                    CONDIÇÃO ? CASO TRUE : CASO FALSE
                                                
                                                */}

                                                <td>{evento.acessoLivre ? 'Livre' : 'Restrito'}</td>
                                                <td>{evento.idTipoEventoNavigation.tituloTipoEvento}</td>
                                                <td>{evento.idInstituicaoNavigation.nomeFantasia}</td>
                                            </tr>
                                        );
                                    } )
                                }
                            </tbody>
                        </table>
                    </section>

                    <section>
                        {/* Cadastro de Eventos */}
                        <h2>Cadastro de Eventos</h2>
                        {/* Faz a chamada para a função de cadastro quando botão é pressionado */}
                        <form onSubmit={this.cadastrarEvento}>
                            <div style={{ display : 'flex', flexDirection : 'column', width : '30vw' }}>

                                <input 
                                    // Título
                                    type="text"
                                    name="titulo"
                                    // Define que o valor do input é o valor do state
                                    value={this.state.titulo}
                                    // Chama a função para atualizar o state cada vez que há alteração no input
                                    onChange={this.atualizaStateCampo}
                                    placeholder="Título do evento"
                                />

                                <input 
                                    required
                                    // Descrição
                                    type="text"
                                    name="descricao"
                                    // Define que o valor do input é o valor do state
                                    value={this.state.descricao}
                                    // Chama a função para atualizar o state cada vez que há alteração no input
                                    onChange={this.atualizaStateCampo}
                                    placeholder="Descrição do evento"
                                />

                                <input 
                                    // Data do evento
                                    type="date"
                                    name="dataEvento"
                                    // Define que o valor do input é o valor do state
                                    value={this.state.dataEvento}
                                    // Chama a função para atualizar o state cada vez que há alteração no input
                                    onChange={this.atualizaStateCampo}
                                />

                                <select
                                    // Acesso Livre
                                    name="acessoLivre"
                                    // Define que o valor do input é o valor do state
                                    value={this.state.acessoLivre}
                                    // Chama a função para atualizar o state cada vez que há alteração no input
                                    onChange={this.atualizaStateCampo}
                                >
                                    <option value="1">Livre</option>
                                    <option value="0">Restrito</option>
                                </select>

                                <select
                                    // Tipo de Evento
                                    name="idTipoEvento"
                                    // Define que o valor do input é o valor do state
                                    value={this.state.idTipoEvento}
                                    // Chama a função para atualizar o state cada vez que há alteração no input
                                    onChange={this.atualizaStateCampo}
                                >
                                    <option value="0">Selecione o tema do evento</option>

                                    {/* Utiliza a função map() para preencher a lista de opções */}

                                    {
                                        // Percorre a lista de Tipos Eentos e retorna uma opção para cada tema
                                        // definindo o valor como o seu próprio ID

                                        this.state.listaTiposEventos.map( tema => {
                                            return(
                                                <option key={tema.idTipoEvento} value={tema.idTipoEvento}>
                                                    {tema.tituloTipoEvento}
                                                </option>
                                            );
                                        } )
                                    }
                                </select>

                                <select
                                    // Instituição
                                    name="idInstituicao"
                                    // Define que o valor do input é o valor do state
                                    value={this.state.idInstituicao}
                                    // Chama a função para atualizar o state cada vez que há alteração no input
                                    onChange={this.atualizaStateCampo}
                                >
                                    <option value="0">Selecione o local do evento</option>

                                    {/* Utiliza a função map() para preencher a lista de opções */}

                                    {
                                        // Percorre a lista de Instituições e retorna uma opção para cada local
                                        // definindo o valor como o seu próprio ID

                                        this.state.listaInstituicoes.map( local => {
                                            return(
                                                <option key={local.idInstituicao} value={local.idInstituicao}>
                                                    {local.nomeFantasia}
                                                </option>
                                            );
                                        } )
                                    }
                                </select>

                                {/* Verifica se alguma requisição está em andamento, através do valor do state isLoading */}

                                {
                                    // Caso seja true, renderiza um botão desabilitado com o texto 'Loading...'
                                    this.state.isLoading === true &&
                                    <button type="submit" disabled>
                                        Loading...
                                    </button>
                                }

                                {
                                    // Caso seja false, renderiza um botão habilitado com o texto 'Cadastrar'
                                    this.state.isLoading === false &&
                                    <button type="submit">
                                        Cadastrar
                                    </button>
                                }

                            </div>
                        </form>
                    </section>
                </main>
            </>
        );
    };
};