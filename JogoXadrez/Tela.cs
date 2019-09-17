using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace JogoXadrez
{
    class Tela
    {
        //metodo para imprimir o tabuleiro
        public static void imprimirTabuleiro(Tabuleiro tab)
        {     // numero que fica ao lado que vao de 1 a 8 
            for(int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");


                for(int j = 0; j < tab.colunas; j++)
                {
                    if (tab.peca(i, j) == null)
                    {
                        Console.Write("- ");
                    }else
                    {
                        imprimirPeca(tab.peca(i,j));
                        Console.Write(" ");
                    }
                    
                }

                Console.WriteLine();
            }
            //letras para se fazer as jogadas
            Console.WriteLine("  a b c d e f g h");


        }

        public static void imprimirPeca (Peca peca)
        {
            if(peca.cor == Cor.Branca)
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

        }



    }
}
