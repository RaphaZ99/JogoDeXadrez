using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace xadrez
{

    //classe herda os atributos da classe Peca
    class Torre : Peca
    {
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }
        public override string ToString()
        {
            return "T";
        }


    }
}
