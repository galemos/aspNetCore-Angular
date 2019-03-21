using GameTOP.Interface;

namespace GameTOP
{
    public class JogoFODA
    {
        private readonly IJogador _jogador1;
        private readonly IJogador _jogador2;
        private readonly IJogador _jogador3;

        public JogoFODA(IJogador jogador1, IJogador jogador2, IJogador jogador3)
        {
            _jogador1 = jogador1;
            _jogador2 = jogador2;
            _jogador3 = jogador3;
        }
        public void IniciarJogo(){
            System.Console.WriteLine(_jogador1.Correr());
            System.Console.WriteLine(_jogador1.Passar());
            System.Console.WriteLine(_jogador1.Chutar());

            System.Console.WriteLine(_jogador2.Correr());
            System.Console.WriteLine(_jogador2.Passar());
            System.Console.WriteLine(_jogador2.Chutar());

            System.Console.WriteLine(_jogador3.Correr());
            System.Console.WriteLine(_jogador3.Passar());
            System.Console.WriteLine(_jogador3.Chutar());
        }
        
    }
}