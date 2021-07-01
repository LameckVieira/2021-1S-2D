import React, { Component } from 'react';
import axios from 'axios';
import { parseJwt, usuariAutenti } from '../../sevices/auth';

import logo2  from '../../assets/img/logo2.png'

import '../../assets/styles/Login.css'

class Login extends Component {
    constructor(props){
        super(props);
        this.state = {
            email : '',
            senha : '',
            erroMensagem : '',
            isLoading : false
        }
    }

    efetuaLogin = (event) => {
        event.preventDefault();

        this.setState({ erroMensagem : '', isLoading : true })

        axios.post('http://localhost:5000/api/login', {
            email : this.state.email,
            senha : this.state.senha
        })

        .then(resposta => {
            if (resposta.status === 200) {
                localStorage.setItem('usuario-login', resposta.data.token)
                //console.log(resposta.data.token)

                this.setState({ isLoading : false })
                
                if (parseJwt().Role === "1") {
                    usuariAutenti();
                    this.props.history.push('/ConsultasAdm');
                }

                else{
                    this.props.history.push('/home')
                }

            }
        })

        .catch(() => {
            this.setState({ erroMensagem : 'E-mail ou senha invalidos! Tente novamente.', isLoading : false })
        })
    }

    AtualizaState = (campo) => {
        this.setState({ [campo.target.name] : campo.target.value})
    }

    render(){
        return(
            <div>
                <div className="fundo">
                    <section className="login">
                        <div className="imagem">
                            <div className="overlay"></div>
                            <img src={logo2} alt="logo" className="logo"/>
                        </div>

                        <div className="login-controler">
                            <div class="overlay2"></div>

                            <div className="campos">
                                <h2>Login</h2>

                                <p style={{ color : 'red'}} className="error">{this.state.erroMensagem}</p>
                                <div>
                                    <form onSubmit={this.efetuaLogin}>

                                        <div className="campo">
                                            <i className="fas fa-user"></i>
                                            <input
                                                type="text"
                                                name="email"
                                                value={this.state.email}
                                                onChange={this.AtualizaState}
                                                placeholder="email"
                                            />
                                        </div>

                                        <div className="campo">
                                            <i className="fas fa-lock"></i>
                                            <input
                                                type="password"
                                                name="senha"
                                                value={this.state.senha}
                                                onChange={this.AtualizaState}
                                                placeholder="senha"
                                            />
                                        </div>

                                        {
                                            this.state.isLoading === true && 
                                            <button type="submit"  className="botao" disabled>Loading...</button>
                                        }

                                        {   
                                            this.state.isLoading === false &&
                                            <button className="botao"
                                                type="submit"
                                                disabled={ this.state.email === '' || this.state.senha === '' ? 'none' : ''}
                                            >
                                                Login
                                            </button>
                                        }

                            
                                    </form>
                                </div>
                            </div>

                        </div>
                    </section>
                </div>
            </div>
        )
    }
}

export default Login