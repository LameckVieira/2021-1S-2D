import React, { Component } from 'react';
import { Image, StyleSheet, View } from 'react-native';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';


import Consultas from './consultas';
import Perfil from './perfil';
  
const bottomTab = createBottomTabNavigator();  

export default class teste extends Component {
  
  render(){
    return (
      <View style={styles.teste}>
          <bottomTab.Navigator
              initialRouteName='Projetos'
              tabBarOptions={{
                showLabel: false,
                activeBackgroundColor: '#81DF99',
                inactiveBackgroundColor: '#3582FF',
                activeTintColor: '#38B3E8',
                inactiveTintColor: 'red',
                style: { height: 55 }
              }}
              screenOptions={({ route }) => ({
                tabBarIcon: () => {
                  if (route.name === "Consultas") {
                    return(
                      <Image
                        source={require('../../assets/img/clipboard 1.png')}
                        style={styles.tabBarIcon}
                      />
                    )
                  }

                  if (route.name === "Perfil") {
                    return(
                      <Image
                        source={require('../../assets/img/user 1.png')}
                        style={styles.tabBarIcon}
                      />
                    )
                  }
                }
              })}
              >
              <bottomTab.Screen name="Consultas" component={Consultas}/>
              <bottomTab.Screen name="Perfil" component={Perfil}/>        
            </bottomTab.Navigator>
          
        </View>
  
    )
  }  
}
const styles = StyleSheet.create({
    teste: {
        flex: 1,
        backgroundColor: '#fff',
      },
  
      BarIcon: {
        width: 30,
        height: 30
      }
})