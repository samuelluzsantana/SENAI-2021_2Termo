
import React, { Component } from 'react';
import { FlatList, StyleSheet, Text, View, TextInput, TouchableOpacity} from 'react-native';
import api from '../services/api';
import {Picker} from '@react-native-picker/picker';

export default class Cadastro extends Component{
  constructor(props){
    super(props)
    this.state = {
      listaProjetos: [],
      nomeProjeto: '',
      idTema: 1
    }
  }

  atualizarTema = (itemValue) => {
    this.setState ({idTema : itemValue})
    console.log (this.state.idTema)
  }

  cadastrarProjeto = async () => {
        await api.post('/projeto', {
        nomeProjeto : this.state.nomeProjeto,
        idTema : this.state.idTema
    })

    this.buscar()
  }

  buscar = async () => {
    const resposta = api.get('/projeto')
    const dadosDaApi = (await resposta).data
    this.setState ({listaProjetos: dadosDaApi})
  }

  componentDidMount (){
    this.buscar();
  }

  render (){
  return(
    <View style={styles.main}>

      <Text style={styles.text}>Cadastro de projeto</Text>

      <TextInput 
      placeholder="text" 
      style={styles.textInput} 
      onChangeText={nomeProjeto => this.setState({nomeProjeto})}/>

      <Picker 
      selectedValue={this.state.idTema} 
      onValueChange={(itemValue) =>
      this.atualizarTema(itemValue)
      }>
        <Picker.Item label='HQ' value='1'/>
        <Picker.Item label='Gestão' value='2'/>
      </Picker>

       <TouchableOpacity 
            style={styles.btnCadastro} 
            onPress={this.cadastrarProjeto}
            >
            <Text style={{color: 'white', textAlign: 'center'}}>CADASTRAR</Text>
       </TouchableOpacity>

       <View>
         <FlatList 
            contentContainerStyle={styles.mainBodyContent}
            data={this.state.listaProjetos}
            keyExtractor={item => item.nomeProjeto}
            renderItem={this.renderItem}/>
       </View>
    </View>
  )
}
renderItem = ({ item }) => (
  <View style={styles.flatItemRow}>
    <Text>{item.idProjeto}</Text>
    <Text>{item.nomeProjeto}</Text>
    <Text>{item.idTemaNavigation.nomeTema}</Text>
  </View>
)}

const styles = StyleSheet.create({
  main: {
    flex: 1,
    backgroundColor: 'f2f2f2',
    alignItems: 'center',
    justifyContent: 'center',
    padding: 20
  },
  textInput:{
    width: '50%',
    height: 40,
    backgroundColor: 'white',
    borderRadius: 20,
    paddingLeft: 10,
    marginBottom: 10
  },
  text: {
    height: 100
  },
  btnCadastro: {
    width: '50%',
    height: 40,
    backgroundColor: '#6A73A6',
    borderRadius: 20,
    justifyContent: 'center'
  }
})