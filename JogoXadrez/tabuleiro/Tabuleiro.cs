using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro
{
    class Tabuleiro
    {

        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {

            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }
        //criando sobrecarga para Peca recebendo uma Pos
        public Peca peca(Posicao pos)
        {

            return pecas[pos.linha, pos.coluna];
        }

        //metodo para retornar uma peça
        //Em forma de matriz

        public Peca peca(int linha, int coluna)
        {

            return pecas[linha, coluna];
        }


        //metodo para verificar se exixti uma peça em uma posicao do xadrez
        public bool existePeca(Posicao pos)
        {
            validarPosicao(pos);
            return peca(pos) != null;

        }
        //metodo para colocar  a Peca no xadrez
        public void colocarPeca(Peca p, Posicao pos)
        {
            //Verificando se existe uma peça na posição Determinada
            if(existePeca(pos)){

                throw new TabuleiroException("Ja existe uma peça nessa Posição");
            }


            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;
        }
        //metodo para testar se o Pos(posicão da peça)  é valida
        public bool posicaoValida(Posicao pos)
        {
            if(pos.linha < 0 || pos.linha >= linhas || pos.coluna < 0 || pos.coluna >= colunas)
            {
                return false;

            }
            return true;
        }

        //metodo para verifica se uma posição e valida, caso não e lancado uma exceção
        public void validarPosicao(Posicao pos)
        {
            if (!posicaoValida(pos))
            {
                throw new TabuleiroException("Posição Invalida");
            }

        }
    }
}
