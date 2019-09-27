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
        public void decrementarQtdeMovimento()
        {
           qteMovimentos--;

        }

        public bool existeMovimentosPossiveis()
        {
            bool[,] mat = movimentosPossiveis();

            for(int i = 0; i < tab.linhas; i++)
            {
                for(int j = 0; j < tab.colunas; j++)
                {
                    if (mat[i, j])
                    {

                        return true;
                    }

                }

            }

            return false;

        }

        public bool movimentoPossivel(Posicao pos)
        {

            return movimentosPossiveis()[pos.linha, pos.coluna];
        }

        public abstract bool[,] movimentosPossiveis();

    }
}
