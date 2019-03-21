using GameTOP.Interface;

namespace GameTOP.lib
{
    public class Jogador1 : IJogador
    {
        public readonly string _nome;

        public Jogador1(string nome)
        {
            _nome = nome;
        }

        //Chuta
        public string Chutar()
        {
            return $"{_nome} está Chutando";
        }

        //Corre
        public string Correr()
        {
            return $"{_nome} está Correndo";
        }

        //Passe
        public string Passar()
        {
            return $"{_nome} está Passarndo";
        }
    }
}