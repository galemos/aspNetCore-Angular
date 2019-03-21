using System;
using GameTOP.lib;

namespace GameTOP
{
    class Program
    {
        static void Main(string[] args)
        {
            var jogo = new JogoFODA(
                new Jogador1("Roberto Carlos"),
                new Jogador2(),
                new Jogador3());
            jogo.IniciarJogo();
        }
    }
    
}
