using GameTOP.Interface;

namespace GameTOP.lib
{
    public class Jogador3 : IJogador
    {
        public string Chutar()
        {
            return "Teste Chutar";
        }

        public string Correr()
        {
            return "Teste Correr";
        }

        public string Passar()
        {
            return "Teste Passar";
        }
    }
}