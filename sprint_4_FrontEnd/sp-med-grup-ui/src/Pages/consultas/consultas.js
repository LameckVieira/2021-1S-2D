import { Component }from 'react';
import axios from 'axios';

class Consultas extends Component{
    constructor(props){
        super(props);
        this.state = {
            listaDeConsultas : [],
            medico  : 0,
            paciente : 0,
            data : new Date(),
            listaDeMedicos :  [],
            listaDePacientes : [],
            listaDeUsuarios : [],
            isLoading : false


        }
    }

    buscarConsultas = () => {
        axios.get('http://localhost:5000/api/consultas', {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

        .then(resposta => {
            if (resposta.status === 200) {
                this.setState({ listaDeConsultas : resposta.data })
            };

        })

        .catch(erro => console.log(erro))
    };

    buscaMedicos = () => {
        axios.get('http://localhost:5000/api/medicos', {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

        .then(resposta => {
            if (resposta.status === 200) {
                this.setState({ listaDeMedicos : resposta.data })
            };

        })

        .catch(erro => console.log(erro))
    };

    buscaPaciente =() => {
        axios.get('http://localhost:5000/api/Pacientes', {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

        .then(resposta => {
            if (resposta.status === 200) {
                this.setState({ listaDePacientes : resposta.data })
            };

        })

        .catch(erro => console.log(erro))
    }

    buscaUsuario =() => {
        axios.get('http://localhost:5000/api/usuarios', {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

        .then(resposta => {
            if (resposta.status === 200) {
                this.setState({ listaDeUsuarios : resposta.data })
            };

        })

        .catch(erro => console.log(erro))
    }

    atualizaCampo = (event) =>{
        this.setState({ paciente : event })
    };

    cadastrarConsulta = (event) => {
        event.preventDefault();

        this.setState({ isLoading : true });

        fetch('http://localhost:5000/api/consultas', {

            method : 'POST',

           
        })
    }

    componentDidMount(){
        this.buscarConsultas();
        this.buscaMedicos();
        this.buscaPaciente();
        this.buscaUsuario();
    }


    render(){
        return(
            <div>
                <main>
                    <section>
                        {/* Consultas */}
                        <h2>Consultas Lista</h2>
                        <table>
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th>Paciente</th>
                                    <th>Medico</th>
                                    <th>DataConsulta</th>
                                    <th>Descricao</th>
                                    <th>Situacao</th>
                                </tr>
                            </thead>

                            <tbody>
                                {
                                    this.state.listaDeConsultas.map( (Consultas) => {
                                        return(
                                            <tr key={Consultas.idConsulta}>
                                                <td>{Consultas.idConsulta}</td>
                                                <td>{Consultas.idPaciente}</td>
                                                <td>{Consultas}</td>
                                                <td>{new Date (Consultas.dataConsulta).toLocaleDateString()}</td>
                                                <td>{Consultas.descricao}</td>
                                                <td>{Consultas.situacao}</td>
                                            </tr>     
                                        )
                                    })
                                }
                            </tbody>
                        </table>
                    </section>

                    <section>
                        {/* Cadastro de consultas */}
                        <h2>Cadastro de Consultas</h2>
                        
                        <form onSubmit={this.cadastrarConsulta}>
                            <div>
                                <input 
                                    type="text"
                                    value={this.state.medico}
                                    onChange={this.atualizaCampo}
                                    placeholder="Medico"
                                />

                                <input 
                                    type="text"
                                    value={this.state.paciente}
                                    onChange={this.atualizaCampo}
                                    placeholder="Paciente"
                                />

                                <input 
                                    type="date"
                                    value={this.state.data}
                                    onChange={this.atualizaCampo}
                                    placeholder="Data"
                                />

                                <button type="submit">Cadastrar</button>
                            </div>
                        </form>
                    </section>
                </main>
            </div>
        );
    }

}

export default Consultas;