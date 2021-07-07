import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { parseJwt } from '../../sevices/auten';

import '../../assets/styles/Admin.css'

import fotoUsuario  from '../../assets/img/user1.png'
import logo  from '../../assets/imgs/logo.sp.jpg'


export default function ConsultaAdm(){
    const [ listaConsultas, setListaConsultas ] =  useState( [] );

    const [listaMedicos, setListaMedicos] = useState( [] );

    const [listaPacientes, setListaPacientes] = useState( [] );

    const [nome, setNome] = useState( [] );

    //Cadastro 

    const [idPaciente, setIdPaciente] = useState(0);

    const [idMedico, setIdMedico] = useState(0);

    const [dataConsulta, setDataConsulta] = useState(new Date());

    const [isLoading, setIsLoading] = useState(false);

    function buscarConsultas(){
        axios('http://localhost:5000/api/consultas', {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

        .then(resposta => {
            if (resposta.status === 200) {
                setListaConsultas(resposta.data)
            };
        })

        .catch(erro => console.log(erro));
    };

    function buscarMedicos(){
        axios('http://localhost:5000/api/medicos', {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

        .then(resposta => {
            if (resposta.status === 200) {
                setListaMedicos(resposta.data)
            };
        })

        .catch(erro => console.log(erro));
    };

    function buscarPacientes(){
        axios('http://localhost:5000/api/pacientes', {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

        .then(resposta => {
            if (resposta.status === 200) {
                setListaPacientes(resposta.data)
            };
        })

        .catch(erro => console.log(erro));
    };

    function cadastrarConsulta(event){
        event.preventDefault();

        setIsLoading(true)
        
        axios.post('http://localhost:5000/api/consultas', {
            idPaciente : idPaciente,
            idMedico : idMedico,
            dataConsulta : dataConsulta
        }, {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

        .then(resposta => {
            if (resposta.status === 201) {
                console.log('Consula cadastrada')
                buscarConsultas();
            }
        })
        
        .catch(erro => {
            console.log(erro)
            setIsLoading(false)
        })
    }

    function buscaNome(){

        let nomeUsuer = parseJwt().name
        setNome(nomeUsuer)
    }


    useEffect( buscarConsultas, []);

    useEffect( buscarMedicos, []);

    useEffect( buscarPacientes, []);

    useEffect( buscaNome, [] )
    

    



    return(
    <div className="body"> 
        
        <header className="cabecalho">
            <div className="container topo">

                <img src={logo} alt="logo"/>

                <div className="info">
                    <nav className="menu">
                        <a href="">Home</a>
                        <a href="">Perfil</a>
                    </nav>

                    <div id="linha"></div>

                    <div className="user">
                        <img src={fotoUsuario} alt="" className="fotoPerfil"/>
                        <p className="usuarioName">
                            {
                                nome
                            }
                        </p>
                    </div>
                </div>
            </div>
        </header>
        <main>
            <section className="pageConsulta">
                <div className="menus">
                    <nav className="menusPage">
                        <a href="">Consultas</a>
                        <a href="">Usuarios</a>
                        <a href="">Médicos</a>
                        <a href="">Pacientes</a>
                        <a href="">Tipos de <br/> Usuarios</a>
                        <a href="">Especialidade</a>
                    </nav>
                </div>

                <div className="lista">
                    {/* Consultas */}
                    <h2>Administrador</h2>
                    <section className="listagem">
                        <div>
                            <div class="linha">
                                <p>Consultas</p>
                            </div>

                            <h2>Lista de Consultas</h2>

                            <table id="tabela">
                                <thead>
                                    <tr>
                                        <th>#</th>
                                        <th>Paciente</th>
                                        <th>Médico</th>
                                        <th>Data</th>
                                        <th>Descrição</th>
                                        <th>Situação</th>
                                    </tr>
                                </thead>

                                <tbody id="consulta">
                                    {
                                        listaConsultas.map( (consulta) => {
                                        return(
                                                <tr key={consulta.idConsulta}>
                                                    <td>{consulta.idConsulta}</td>
                                                    <td>{consulta.idPacienteNavigation.idUsuarioNavigation.nome}</td>
                                                    <td>{consulta.idMedicoNavigation.idUsuarioNavigation.nome}</td>
                                                    <td>{new Date (consulta.dataConsulta).toLocaleDateString()}</td>
                                                    <td>{consulta.descricao}</td>
                                                    <td>{consulta.situacao}</td>
                                                </tr>
                                                )
                                            })
                                    }
                                </tbody>
                            </table>
                        </div>
                    </section>

                    <section className="listagemCadastro">
                            <div>
                                <div className="linha btn">
                                    <p>Consultas</p>
                                </div>

                                <form  onSubmit={cadastrarConsulta} className="formulario">

                                    <div className="linha2">
                                        <h2>Cadastro</h2>
                                    </div>

                                    <div className="cadastro">
                                        <select
                                            name="idMedico"
                                            value={idMedico}
                                            onChange={(event) => setIdMedico(event.target.value)}

                                        >
                                            <option value="0">Médico</option>

                                            {
                                                listaMedicos.map(  m => {
                                                    return(
                                                        
                                                        <option
                                                            key={m.idMedico}
                                                            value={m.idMedico}
                                                        >
                                                            {m.idUsuarioNavigation.nome} - {m.idEspecialidadeNavigation.tituloEspecialidade}
                                                        </option>
                                                    );
                                                })
                                            }

                                        </select>

                                        <select
                                            name="idPaciente"
                                            value={idPaciente}
                                            onChange={(event) => setIdPaciente(event.target.value)}

                                        >
                                            <option value="0">Paciente</option>

                                            {
                                                listaPacientes.map(  p => {
                                                    return(
                                                            
                                                        <option
                                                             key={p.idPaciente}
                                                            value={p.idPaciente}
                                                        >
                                                            {p.idUsuarioNavigation.nome}
                                                        </option>
                                                    );
                                                })
                                            }

                                        </select>

                                        <input 
                                            className="data"
                                            type="date"
                                            value={dataConsulta}
                                            onChange={(event) => setDataConsulta(event.target.value)}
                                            placeholder="Data"
                                        />
                                        {
                                            isLoading === (true) && 
                                            <button className="botao" disabled>Loading...</button>
                                        }

                                        {
                                            isLoading === (false) &&
                                            <button className="botao">Cadastrar</button>
                                        }
                                            
                                        
                                    
                                    </div>
                                </form>
                            </div>
                    </section>
                </div>
        
            </section>
        </main>

        <footer className="rodapePrincipal">
            <section className="rodape">
                <div className="texto">
                    <p>Lameck Vieira Barbosa</p>
                </div>
            </section>
      </footer>
    </div>
    )
}