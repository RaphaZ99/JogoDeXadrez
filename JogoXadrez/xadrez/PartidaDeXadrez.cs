using tabuleiro;
using System.Collections.Generic;

namespace xadrez
{
    class PartidaDeXadrez
    {

        public Tabuleiro tab { get; private set; }
        public int turno { get; set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;



        //construtor criando o tabuleiro 8x8, iniciando o turno e definindo o jogador incial
        public PartidaDeXadrez()
        {

            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();

            colocarPeca();



        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            executaMovimento(origem, destino);

            turno++;

            mudaJogador();

        }

        public void validarPosicaoDeOrigem(Posicao pos)
        {

            if(tab.peca(pos) == null)
            {

                throw new TabuleiroException("Não eixste peça nna psoicao de origem");


            }
            if(jogadorAtual != tab.peca(pos).cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não e sua");
            }
            if (!tab.peca(pos).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Não ha movimentos possiveis na peça de origem");
            }
            
        }

        public void validarPosicaoDeDeestino(Posicao origem, Posicao destino)
        {

            if (!tab.peca(origem).podeMoverPara(destino))
            {
                throw new TabuleiroException("Posicao de destino invalida");

            }

        }

        private void mudaJogador()
        {
            if(jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;

            } else
            {
                jogadorAtual = Cor.Branca;
            }

        }


        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);

        }


        //metodo para executar um movimento(fazer uma jogada) dentro do tabuleiro de xadrez
        public void executaMovimento(Posicao origem,Posicao destino)
        {
            
            Peca p = tab.retirarPeca(origem);
            p.incrementarQtdeMovimento();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
            if(pecaCapturada != null)
            {

                capturadas.Add(pecaCapturada);
            }

        }

        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach(Peca x in capturadas)
            {
                if(x.cor == cor)
                {
                    aux.Add(x);

                }
               
            }
            return aux;
        }



        public HashSet<Peca> pecasEmJogo(Cor cor)
        {

            HashSet<Peca> aux = new HashSet<Peca>();

            foreach (Peca x in capturadas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);

                }

            }

           aux.ExceptWith(pecasCapturadas(cor));

            return aux;
        }

        //metodo para colocar as peças no xadrez
        private void colocarPeca()
        {

            colocarNovaPeca('c', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('c', 2, new Torre(tab, Cor.Branca));
            colocarNovaPeca('d', 2, new Torre(tab, Cor.Branca));
            colocarNovaPeca('d', 1, new Rei(tab, Cor.Branca));
            colocarNovaPeca('e', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('e', 2, new Torre(tab, Cor.Branca));


            colocarNovaPeca('c', 8, new Torre(tab, Cor.Preta));
            colocarNovaPeca('c', 7, new Torre(tab, Cor.Preta));
            colocarNovaPeca('d', 7, new Torre(tab, Cor.Preta));
            colocarNovaPeca('d', 8, new Rei(tab, Cor.Preta));
            colocarNovaPeca('e', 8, new Torre(tab, Cor.Preta));
            colocarNovaPeca('e', 7, new Torre(tab, Cor.Preta));

        


        }

    }
}
