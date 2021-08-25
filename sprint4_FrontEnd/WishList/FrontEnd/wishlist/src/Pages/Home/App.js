import { Component } from 'react'
import './App.css';
import editar from './img/editar.svg'
import excluir from './img/excluir.svg'
import logo from './img/logo.svg'
import select from './img/select.svg'
import tipografia from './img/tipografia.svg'

class Desejos extends Component {

  constructor(props) {

    super(props)

    this.state = {
      listaDesejos: [],
      email: '',
      descricao: '',
      idDesejoAlterado: 0
    }

  }


  BuscarDesejos = () => {

    console.log('Agora vamos chamar os dados da API')

    fetch('http://localhost:5000/api/desejos')

      .then(resposta => resposta.json())

      .then(dados => this.setState({ listaDesejos: dados }))

      .catch(erro => console.log(erro))

  }




  AtualizaEstadoEmail = async (event) => {

    await this.setState({ email: event.target.value })
    console.log(this.state.email)

  }


  AtualizaEstadoDescricao = async (event) => {

    await this.setState({ descricao: event.target.value })
    console.log(this.state.descricao)

  }




  CadastrarDesejo = (event) => {

    event.preventDefault()

    if (this.state.idDesejoAlterado !== 0) {  //edição

      fetch('http://localhost:5000/api/desejos/' + this.state.idDesejoAlterado,
        {
          method: 'PUT',

          body: JSON.stringify({
            descricao: this.state.descricao,
          }),

          headers: { 'Content-Type': 'application/json' }
        }
      )

        .then(resposta => {

          if (resposta.status === 204) {
            console.log(
              'Desejo ' + this.state.idDesejoAlterado + ' atualizado.',
              'Seu novo desejo agora é: ' + this.state.descricao,
            )
          }

        })

        .then(this.BuscarDesejos)

        .then(this.LimparCampos)

    }

    else { //cadastro

      fetch('http://localhost:5000/api/desejos/',
        {
          method: 'POST',

          body: JSON.stringify({
            descricao: this.state.descricao,
          }),

          headers: { 'Content-Type': 'application/json' }
        })

        .then(console.log('Desejo adicionado com sucesso'))

        .catch(erro => console.log(erro))

        .then(this.BuscarDesejos)

        .then(this.LimparCampos)

    }

  }


  componentDidMount() {
    this.BuscarDesejos()
  }



  BuscarDesejoPorId = (desejo) => {

    this.setState(

      {
        idDesejoAlterado: desejo.idDesejo,
      },

      () => {
        console.log(
          'O Desejo ' + desejo.idDesejo + ' foi selecionado,',
          'agora o valor do state idDesejoAlterado é: ' + this.state.idDesejoAlterado,
        )
      }

    )

  }



  ExcluirDesejo = (desejo) => {

    console.log('O Desejo ' + desejo.idDesejo + ' foi selecionado')

    fetch('http://localhost:5000/api/desejos/' + desejo.idDesejo,
      {
        method: 'DELETE'
      })

      .then(resposta => {
        if (resposta.status === 204) {
          console.log('Desejo ' + desejo.idDesejo + ' foi excluído')
        }
      })

      .catch(erro => console.log(erro))

      .then(this.BuscarDesejos)

  }



  LimparCampos = () => {

    this.setState({
      email: '',
      descricao: '',
      idTipoEventoAlterado: 0
    })

    console.log('Os states foram resetados')
  }



  render() {
    return (

      <div>

        <header>

          <div className="hamburger"><i className="fa fa-bars"></i></div>

          <div className="center-header">

            <div className="header-topo">

              <div className="logo">
                <img src={logo} alt="logo icone" className="icone" />
                <img src={tipografia} alt="wish list tipografia" className="letra" />
              </div>

            </div>

          </div>

        </header>


        <main>

          <div className="center-main">

            <div className="central">

              <div className="meus-desejos">
                <p>Meus desejos</p>
              </div>


              <div className="azul-imputs">

                <h2>ADICIONAR DESEJO</h2>


                <form onSubmit={this.CadastrarDesejo}>

                  <div className="inputs">

                    <p>SEU EMAIL</p>
                    <input
                      type="text"
                      value={this.state.email}
                      onChange={this.AtualizaEstadoEmail}
                      className="inputt"
                      name="fname"
                      placeholder="email@exemplo.com"
                    />

                    <div className="inputs-bottom">

                      <div className="descricao">
                        <p> DESCRIÇÃO</p>
                        <input
                          type="text"
                          value={this.state.descricao}
                          onChange={this.AtualizaEstadoDescricao}
                          className="inputt"
                          name="fname"
                        />
                      </div>

                      <button type="submit" className="btn-cadastrar">
                        <img src={select} alt="ícone para adicionar um desejo" />
                      </button>

                    </div>

                  </div>

                </form>

              </div>


              <div className="desejo">

                <div className="wish-bottom">

                  <div className="descricao2">
                    <h3>DESEJO DE:</h3>
                    <p>email@exemplo.com</p>
                  </div>


                  <div className="other">

                    <div className="desejo1">

                      <h3>DESCRIÇÃO</h3>

                      {
                        this.state.listaDesejos.map((desejo) => {
                          return (
                            <p>
                              {desejo.descricao}

                              <div className="icons">

                                <button id="lapis" className="btn-icon" onClick={() => this.BuscarDesejoPorId(desejo)}>
                                  <img src={editar} alt="lápis para editar desejo" />
                                </button>

                                <button id="lixeira" className="btn-icon" onClick={() => this.ExcluirDesejo(desejo)}>
                                  <img src={excluir} alt="lixeira para excluir desejo" />
                                </button>

                              </div>

                            </p>
                          )
                        })
                      }

                    </div>

                  </div>

                </div>

              </div>


            </div>

          </div>

        </main>

      </div>

    )
  }




}


export default Desejos


