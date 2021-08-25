import React, { Component } from 'react'
import { View, StyleSheet } from 'react-native'
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs'

import Cadastro from './cadastro'
import Projetos from './Projeto'
// import Login from './login'

const bottomTab = createBottomTabNavigator()

export default class Main extends Component{
  render(){
    return(
      <View style={styles.main}>
          <bottomTab.Navigator
            // initialRouteName= 'Login'
            tabBarOptions={{
              activeBackgroundColor : '#252759',
              inactiveBackgroundColor : '#6A73A6',
              activeTintColor : 'white',
              inactiveTintColor : 'white'
            }}
          >
            <bottomTab.Screen name="Projetos" component={Projetos}/>
            <bottomTab.Screen name="Cadastro" component={Cadastro}/>
          </bottomTab.Navigator>
      </View>
    )
  }
}

const styles = StyleSheet.create({
  main: {
    flex: 1,
    backgroundColor: '#F1F1F1'
  }
})