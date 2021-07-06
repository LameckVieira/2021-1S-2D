import React, { Component } from 'react';
import { FlatList, Image, StyleSheet, Text, View } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';
import jwtDecode from 'jwt-decode';

import api from '../services/api'
import axios from 'axios';

export default class Consultas extends Component {
    constructor(props) {
        super(props);
        this.state = {
            consultas: [],
            nomeUsuarioLogado: '',
            idUsuarioLogado : '',
        };
    }

    buscaDados = async ()  => {
        try {
            const valorToken = await AsyncStorage.getItem('userToken')

            if (valorToken !== null) {
                this.setState({idUsuarioLogado : jwtDecode(valorToken).jti});
                this.setState({nomeUsuarioLogado : jwtDecode(valorToken).name})
            }
        } catch(error) {

        }
    }

    buscarConsultas = async () => {
        const valorToken = await AsyncStorage.getItem('userToken')
        
        const resposta = await axios
        ('http://localhost:5000/api/Consultas/minhasconsultas', {
                headers: {
                  Authorization: "Bearer " + valorToken
                }
              }
        );

        this.setState({ consultas : resposta.data });
        console.log(this.state.consultas)
        
    };

    componentDidMount() {
      this.buscaDados();  
      this.buscarConsultas();

    };
    

    render(){
        return(

            <View style={styles.teste}>

                           
            </View>
        );
    }
    renderItem = ({ item }) => (
        <View style={styles.campoConsultas}>
            
        </View>
    )
    
    }

    const styles = StyleSheet.create({});