using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;
using xadrez;

namespace JogoXadrez
{
    class Tela
    {


        public static void imprimirPartida(PartidaDeXadrez partida)
        {
            imprimirTabuleiro(partida.tab);
            Console.WriteLine();

            imprimirPecasCapturadas(partida);

            Console.WriteLine("Turno : " + partida.turno);
            Console.WriteLine("Aguardando Jogada : " + partida.jogadorAtual);



        }

        public static void imprimirPecasCapturadas(PartidaDeXadrez partida)
        {

            Console.WriteLine("Peças Capturadas : ");
            Console.WriteLine();
            Console.Write("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));

            ConsoleColor aux = Console.ForegroundColor;

            ConsoleColor amarelo = ConsoleColor.Yellow;

            Console.WriteLine();

            Console.Write("Peças Preta: ");

            Console.ForegroundColor = amarelo;

            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));

            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void imprimirConjunto(HashSet<Peca> conjunto)
        {

            Console.Write("[");
            foreach (Peca x in conjunto)
            {

                Console.Write(x + " ");

            }

            Console.Write("]\n");


        }

        //metodo para imprimir o tabuleiro

        public static void imprimirTabuleiro(Tabuleiro tab)
        {

            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            Console.WriteLine("* A B C D E F G H");
            // numero que fica ao lado que vao de 1 a 8 
            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");


                for (int j = 0; j < tab.colunas; j++)
                {


                    imprimirPeca(tab.peca(i, j));

                }

                Console.WriteLine();
            }
            //letras para se fazer as jogadas
            Console.WriteLine("* A B C D E F G H");
            Console.BackgroundColor = fundoOriginal;


        }

        //sobrecarga   construtor
        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {

            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;


            // numero que fica ao lado que vao de 1 a 8 
            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");


                for (int j = 0; j < tab.colunas; j++)
                {
                    if (posicoesPossiveis[i, j])
                    {
                        //alterando o fundo das posicções das matrizes onde e possivel fazer movimentações
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        //voltando a cor normal o restante das posições que não forem possiveis
                        Console.BackgroundColor = fundoOriginal;

                    }

                    imprimirPeca(tab.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;

                }

                Console.WriteLine();
            }
            //letras para se fazer as jogadas
            Console.WriteLine("* A B C D E F G H");
            Console.BackgroundColor = fundoOriginal;


        }
        //metodo para ler a peca de origim do usuario
        //convertendo a string em char, e int.parse para converter -
        //o numero em letra
        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string posicaoUsuario = Console.ReadLine();

            char coluna = posicaoUsuario[0];
            //converte a letra em numero
            int linha = int.Parse(posicaoUsuario[1] + "");
            return new PosicaoXadrez(coluna, linha);


        }

        public static void imprimirPeca(Peca peca)
        {

            if (peca == null)
            {

                Console.Write("- ");

            }
            else
            {


                if (peca.cor == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    //cor padrao das letras
                    ConsoleColor corPadrao = Console.ForegroundColor;
                    //alterando as cores pra amarelo caso seja outro tipo de peca(peca adversaria)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);

                    //voltando a cor padrao das pecas
                    Console.ForegroundColor = corPadrao;

                }
                Console.Write(" ");

            }
        }



    }
}
