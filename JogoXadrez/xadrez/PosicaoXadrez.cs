using tabuleiro;
namespace xadrez
    
{
    class PosicaoXadrez
    {
        
        public char coluna { get; set; }
        
            public int linha { get; set; }

        //construtor da classe
        public PosicaoXadrez(char coluna, int linha)
        {
            this.coluna = coluna;
            this.linha = linha;

        }


        //metodo para trasnforma a posicao do string dado pelo usuario
        //Em uma posição na matriz
        //A e um numero inteiro coluna - a = 0, se for B
        //B - A = 1, e assim por diante
        public  Posicao toPosicao()
        {
            return new Posicao(8 - linha, coluna - 'a');

        }

        //retornando os valores dados pelo usuario
        //transforma o objeto em string
        public override string ToString()
        {
            return "" + coluna + linha;
        }
    }

  

}
