import React, { Component } from 'react';
import { StyleSheet, Text, View, FlatList } from 'react-native';
import api from '../services/api'

export default class Projetos extends Component {
  constructor(props){
    super(props)
    this.state = {
      listaProjetos : []
    }
  }

  buscarProjetos = async () => {
    const resposta = await api.get('/projeto')
    const dadosDaApi = resposta.data
    this.setState({listaProjetos : dadosDaApi})
  }

  componentDidMount(){
      this.buscarProjetos()
  }

  render(){
    return(
      <View style={styles.main}>
        <View style={styles.mainHeader}>
          <View style={styles.mainHeaderRow}>
            <Text style={styles.mainHeaderText}>{"Projetos".toUpperCase()}</Text>
          </View>
          <View style={styles.mainHeaderLine}/>
        </View>

        <View style={styles.mainBody}>
          <FlatList 
            contentContainerStyle={styles.mainBodyContent}
            data={this.state.listaProjetos}
            keyExtractor={item => item.nomeProjeto}
            renderItem={this.renderItem}
          />
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
  )
}

const styles = StyleSheet.create({
  main: {
    flex: 1,
    backgroundColor: '#F2F2F2',
  },
  mainHeader: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center'
  },
  mainHeaderRow: {
    flexDirection: 'row'
  },
  mainHeaderText: {
    fontSize: 16,
    letterSpacing: 5,
    color: '#999',
    fontFamily: 'Open Sans'
  },
  mainHeaderLine: {
    width: 220,
    paddingTop: 10,
    borderBottomColor: '#999',
    borderBottomWidth: 1
  },
  mainBody: {
    flex: 4
  },
  mainBodyContent: {
    paddingTop: 30,
    paddingRight: 50,
    paddingLeft: 50
  },
  flatItemRow: {
    borderBottomWidth: 1,
    borderBottomColor: '#ccc',
    marginTop: 30,
  },
})

