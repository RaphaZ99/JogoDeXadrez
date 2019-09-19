using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro
{

    //Classe Generica
    abstract class Peca
    {

        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public  int qteMovimentos { get; private set; }
        public Tabuleiro tab { get; set; }


        public Peca (Tabuleiro tab, Cor cor)
        {
            this.posicao = null;
            this.tab = tab;
            this.cor = cor;
            this.qteMovimentos = 0;

        }

        public void incrementarQtdeMovimento()
        {
            qteMovimentos++;

        }

        public abstract bool[,] movimentosPossiveis();

    }
}
