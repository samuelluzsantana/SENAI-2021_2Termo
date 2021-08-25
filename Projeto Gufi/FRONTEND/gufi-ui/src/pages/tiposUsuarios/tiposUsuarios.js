import React, { useState, useEffect } from 'react';
import axios from 'axios';

export default function TiposUsuarios(){
    // Define o state listaTiposUsuarios, a função setListaTiposUsuarios que vai atualizar este state
    // e define que o valor inicial deste state é um array vazio, através do useState ( [] )
    const [ listaTiposUsuarios, setListaTiposUsuarios ] = useState( [] );
    const [ titulo, setTitulo ] = useState( '' );
    const [ isLoading, setIsLoading ] = useState( false );

    function buscarTiposUsuarios(){
        setIsLoading( true );
        // Faz a chamada para a API usando axios
        axios('http://localhost:5000/api/tiposusuarios', {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

        // Caso a resposta da requisição retorne um status code 200
        .then(resposta => {
            if (resposta.status === 200) {
                // Chama a função que atualiza o state listaTiposUsuarios
                setListaTiposUsuarios(resposta.data);
                setIsLoading( false );
            };
        })

        // .then(console.log(listaTiposUsuarios))

        // Caso ocorra algum erro, mostra no console do navegador
        .catch(erro => console.log(erro));
    };

    // Neste caso, o efeito só é disparado uma única vez, ou seja, a função buscarTiposUsuarios só é invocada uma vez porque não estamos escutando nada
    useEffect( buscarTiposUsuarios, [] );

    function cadastrarTipoUsuario(event){
        event.preventDefault();

        setIsLoading( true );

        axios.post('http://localhost:5000/api/tiposusuarios', {
            tituloTipoUsuario : titulo
        }, {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

        .then(resposta => {
            if (resposta.status === 201) {
                console.log('Tipo de Usuário cadastrado!');
                buscarTiposUsuarios();
                setIsLoading( false );
            }
        })

        .catch(erro => console.log(erro));
    };

    // Mostra no console do navegador o valor do titulo
    console.log(titulo);

    return(
        <div>
            <main>
                <section>
                    <h2>Lista de Tipos de Usuários</h2>
                    <div>
                        <table style={{ borderCollapse : 'separate', borderSpacing : 30 }}>
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th>Título</th>
                                </tr>
                            </thead>

                            <tbody>
                                {
                                    listaTiposUsuarios.map( (tipoUsuario) => {
                                        return(
                                            <tr key={tipoUsuario.idTipoUsuario}>
                                                <td>{tipoUsuario.idTipoUsuario}</td>
                                                <td>{tipoUsuario.tituloTipoUsuario}</td>
                                            </tr>
                                        );
                                    } )
                                }
                            </tbody>
                        </table>
                    </div>
                </section>

                <section>
                    <h2>Cadastro de Tipos Usuários</h2>
                    <form onSubmit={cadastrarTipoUsuario}>
                        <div>
                            <input 
                                // Título
                                type="text"
                                value={titulo}
                                onChange={(event) => setTitulo(event.target.value)}
                                placeholder="Título do Tipo de Usuários"
                            />

                            {
                                isLoading === false &&
                                <button type="submit">Cadastrar</button>
                            }

                            {
                                isLoading === true &&
                                <button type="submit" disabled>Carregando...</button>
                            }
                        </div>
                    </form>
                </section>
            </main>
        </div>
    )
};