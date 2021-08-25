import React, { Component } from "react"
import { StyleSheet, View, TouchableOpacity, Text, TextInput } from "react-native"
import AsyncStorage from "@react-native-async-storage/async-storage"


import api from "../services/api"

export default class Login extends Component{
    constructor(props){
        super(props)
        this.state = {
            email : '',
            senha : ''
        }
    }

    fazerLogin = async () => {
        
        console.warn(this.state.email + ' ' + this.state.senha)

        const resposta = await api.post('/login', {
            email : this.state.email,
            senha : this.state.senha
        })

        const token = resposta.data.token

        await AsyncStorage.setItem('romanToken', token)

        this.props.navigation.navigate('Main')
        
    }

    render(){
        return(
            <View style={styles.main}>

                <TextInput style={styles.inputLogin}
                    placeholder="email"
                    placeholderTextColor="#6A73A6"
                    keyboardType="email-address"
                    onChangeText={email => this.setState({email})}
                />
                <TextInput style={styles.inputLogin}
                    placeholder="password"
                    placeholderTextColor="#6A73A6"
                    secureTextEntry={true}
                    onChangeText={senha => this.setState({senha})}
                />

                <TouchableOpacity 
                    style={styles.btnLogin}
                    onPress={this.fazerLogin}
                    >
                    <Text>Login</Text>
                </TouchableOpacity>
            </View>
        )
    }
}

const styles = StyleSheet.create({
    main: {
        flex: 1,
        backgroundColor: 'fff',
        justifyContent: 'center',
        alignItems: 'center'     
    },
    btnLogin: {
        alignItems: 'center',
        justifyContent: 'center',
        height: 38,
        width: 240,
        backgroundColor: '#fff',
        borderColor: '#FFF',
        borderWidth: 1,
        borderRadius: 4,
        shadowOffset: { height: 1, width: 1}
    },
    inputLogin: {
        width: 240,
        marginBottom: 40,
        fontSize: 18,
        borderBottomColor: '#6A73A6',
        borderWidth: 2
    }
})