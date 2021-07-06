import React, { Component } from 'react';
import { FlatList, Image, StyleSheet, Text, View } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';
import jwtDecode from 'jwt-decode';

import api from '../services/api'
import axios from 'axios';
import { color } from 'react-native-reanimated';

export default class Perfil  extends Component {
    render(){
        return (
            <View style={styles.container}>
              <Text>Perfil</Text>
            </View>
        );
    }
        
}
const styles = StyleSheet.create({
    container: {
        flex: 1,
        backgroundColor: '#fff',
        alignItems: 'center',
        justifyContent: 'center',
        },
});