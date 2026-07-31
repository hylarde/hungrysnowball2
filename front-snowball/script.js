

const telaInicial = document.getElementById("telaInicial");
const telaJogo = document.getElementById("telaJogo");
const iframe = document.getElementById("iframe");
const telaFim = document.getElementById("telaFim");
const imgResult = document.getElementById("imagemResult");
const rodape = document.getElementById("rodape");
const linkWebGl = ""; //colocar o link do arquivo webGl

//funções de controle de tela

function iniciarJogo(){
        telaInicial.classList.add("escondido"); //adicionando uma class à tag html div telaInicial
        telaFim.classList.add("escondido");//adicionando uma class à tag html div telaInicial
        telaJogo.classList.remove("escondido");//removendo a class à tag html div telaJogo
        rodape.classList.add("escondido"); //adicionando uma class à tag html div telaInicial

        iframe.src = linkWebGl; //jogando o link dentro do src do iframe na tag html  
        console.log("Jogo inicializado");
}

function finalizarJogo(resultado){  
        telaJogo.classList.add("escondido");//esconde o mapa da tela
        telaFim.classList.remove("escondido");
        rodape.classList.remove("escondido");
        iframe.src = ""; //tirando o link do jogo do src da tag html iframe

        if(resultado === "Vitória"){ //caso o resultado do jogo seja vitória
                imgResult.src = "./imagens/imgVitoria2.png";//imagem de vitoria é rendelizada junto com botao reniciar
                imgResult.alt = " imagem de vitória";//nomeando foto
                console.log("Imagem de vitória renderizada");
        }else if(resultado === "Game Over"){
                imgResult.src = "./imagens/imgGameOver2.png";
                imgResult.alt = "imagem de game over";
                console.log("Imagem de Game Over renderizada")
        }

}

function reiniciarJogo(){
        document.getElementById("telaFim").classList.remove("escondido"); //só para teste, apagar depois
        console.log("Reiniciando Jogo.");
        //iniciarJogo();//chama a função que roda o jogo

}

window.addEventListener("message", (event)=>{
        const msgFinalJogo = event.data;

        if(msgFinalJogo === "Vitória" || msgFinalJogo === "Game Over"){
                finalizarJogo(msgFinalJogo);

        }

});


