import React from 'react';
import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';

import Teste from './src/screens/teste';
import Login from './src/screens/login';
import Perfil from './src/screens/perfil';
import Consultas from './src/screens/consultas';

const AuthStack = createStackNavigator();

export default function Stack(){
  return(
    <NavigationContainer>
      <AuthStack.Navigator>

        <AuthStack.Screen name = 'Login' component={Login}/>
        <AuthStack.Screen name = 'teste' component={Teste}/>
        <AuthStack.Screen name = 'perfil' component={Perfil}/>
        <AuthStack.Screen name = 'consultas' component={Consultas}/>

      </AuthStack.Navigator>
    </NavigationContainer>
  )
}