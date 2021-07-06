import React, { Component } from 'react';
import { TouchableOpacity, TextInput, Image, ImageBackground, StyleSheet, Text, View } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';

import api from '../services/api';

export default class Login extends Component {
    constructor(props){
        super(props);
        this.state = {
            email : '',
            senha : ''
        }
    }

    realizaLogin = async () => {
        const resposta = await api.post('/login', {
            email : this.state.email,
            senha : this.state.senha
        })

        const token = resposta.data.token;
        
        await AsyncStorage.setItem('userToken', token);
        
        this.props.navigation.navigate('Teste');
    };

    render(){
        return(
            <ImageBackground
                source={require("../../assets/img/Fundo.png")}
                style={StyleSheet.absoluteFillObject}
            >
                <View style={styles.teste}>
                <TextInput 
                        style={styles.inputLogin}
                        placeholder='username'
                        placeholderTextColor= '#fff'
                        keyboardType='email-address'
                        onChangeText={email => this.setState({ email })}

                    />

                    <TextInput 
                        style={styles.inputLogin}
                        placeholder='password'
                        placeholderTextColor= '#fff'
                        secureTextEntry={true}
                        onChangeText={senha => this.setState({ senha })}
                        
                    />

                    <TouchableOpacity
                        style={styles.btnLogin}
                        onPress={this.realizaLogin}
                    >

                    <Text style={styles.btnLoginTexto}>Login</Text>
                    </TouchableOpacity>
                </View>
                
            </ImageBackground>
        )
    }
}

const styles = StyleSheet.create({
    teste: {
        width: '100%',
        height: '100%',
        justifyContent: 'center',
        alignItems: 'center'
      },
  
      inputLogin:{
          width: 276,
          color: '#fff',
          borderColor: '#fff',
          borderBottomWidth: 2,
          marginBottom: 50,
  
  
      },
  
      btnLogin: {
          alignItems: 'center',
          justifyContent: 'center',
          width: 276,
          height: 38,
          color: '#fff',
          borderColor: '#fff',
          borderWidth: 2,
          borderRadius: 4,
      },
  
      btnLoginTexto: {
          color: '#fff',
          fontSize: 14,
      }
});