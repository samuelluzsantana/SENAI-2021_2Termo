raccon = [

    {
        nome: 'George',
        idade: 13,
        raca: 'raça legal'
    },

    {
        nome: 'Augusto',
        idade: 12,
        raca: 'sapeca'

    },

    {
        nome: 'Julia',
        idade: 13,
        raca: 'dorminhoca'

    },



    {
        nome: 'Ramiel',
        idade: 17,
        raca: 'aluno do senai'
    }




] // array né pae


var nomeRaccons = raccon.map(function (raccon) { return ("\n" + raccon.nome) })
var idadeRaccon = raccon.map(function (raccon) { return (raccon.idade) })
 

//revelar nomes
function nomes() {

    alert("Seus nomes são: " + "\n" + nomeRaccons);

    for (let numer = 0; numer <raccon.length; numer++) {

        document.getElementsByTagName('h2')[numer].innerHTML = nomeRaccons[numer]

    }  
  

}

//revelar idade
function idade() {

     var numero = 0;
    
    for (numero = 0; numero < raccon.length; numero++) {
        alert(nomeRaccons[numero] + ": " + idadeRaccon[numero] + " anos")
    }


    // alert(

    //     "Suas idades são: " + "\n" +

    //     nomeRaccons[0] + ": " + idadeRaccon[0] + " anos" +
    //     nomeRaccons[1] + ": " + idadeRaccon[1] + " anos" +
    //     nomeRaccons[2] + ": " + idadeRaccon[2] + " anos" +
    //     nomeRaccons[3] + ": " + idadeRaccon[3] + " anos"

    // ) <-----da pra fazer desse jeito tbm


    for (let numer = 0; numer <raccon.length; numer++) {

    document.getElementsByTagName('h2')[numer].innerHTML = nomeRaccons[numer] + " " + idadeRaccon[numer] + " anos"

    }  
    
}

//somar todas idades 
function somar(){


    var total = idadeRaccon.reduce(function(total,idadeRaccon){
        return total + idadeRaccon;
    }, 0);


 alert("A Soma da idade de todos são: " + total + " anos.")
 
}


//piorar site
function piorar(){

    alert('Agora ja foi..')

    var img = document.getElementById('julia');
    img.setAttribute('src',"img/julia2.gif")

    alert('oh não vc acordou a julia >:c')

  

    document.body.style.backgroundImage = "url('img/julia2')"             

}







