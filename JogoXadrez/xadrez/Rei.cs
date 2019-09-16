using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace xadrez
{

    //classe herda os atributods da classe Peca
    class Rei : Peca
    {
        public Rei (Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }
        public override string ToString()
        {
            return "R";
        }


    }
}
