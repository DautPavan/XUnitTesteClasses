using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes: IDisposable
    {

        private Veiculo veiculo;
        public ITestOutputHelper _SaidaConsoleTeste;

        public VeiculoTestes(ITestOutputHelper saidaConsoleTeste)
        {
            _SaidaConsoleTeste = saidaConsoleTeste;
            _SaidaConsoleTeste.WriteLine("Construtor is running.");
            veiculo = new Veiculo();
        }


        //Padrão AAA
        //Arrange
        //Act
        //Assert

        [Fact]
        public void TestaVeiculoAcelerarComParametro10()
        {
            //Arrange
            //var veiculo = new Veiculo();

            //Act
            veiculo.Acelerar(10);

            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }


        [Fact]
        public void TestaVeiculoFrearComParametro10() 
        {
            //Arrange
            //var veiculo = new Veiculo();

            //Act
            veiculo.Frear(10);

            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }


        [Fact(DisplayName = "Teste nº 3", Skip = "Teste Ainda não implementado.")]
        public void ValidaNomeProprietario() 
        {

        }


        [Theory]
        [Trait("Passando Instancia", "Testa Passando um classe como parametro")]
        [ClassData(typeof(Veiculo))]
        [ClassData(typeof(Veiculo))]
        public void TestaVeiculoClass(Veiculo modelo)
        {
            //Arrange
            //var veiculo = new Veiculo();

            //Act
            veiculo.Acelerar(10);
            modelo.Acelerar(10);

            //Assert
            Assert.Equal(modelo.VelocidadeAtual, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void FichaInformacaoDoVeiculo()
        {
            //Arrange
            //var veiculo = new Veiculo();
            veiculo.Proprietario = "Jose silva";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "ZAP-6789";

            //Act
            string dados = veiculo.ToString();


            //Assert
            Assert.Contains("Tipo do Veiculo:", dados);
        }

        [Fact]
        public void TestaNomeProprietarioVeiculoComMenosDeTresCaracteres() 
        {
            //Arrange
            string nomeProprietario = "ab";

            //Assert
            Assert.Throws<FormatException>(
                //Act
                () => new Veiculo(proprietario: nomeProprietario)
            );

        }

        [Fact]
        public void TestaMensagemDeExcecaoDoQuartoCaractereDaPlaca()
        {
            //Arrange
            string placa = "ffff8978";
            
            //Act
            var mensagem = Assert.Throws<FormatException>(
                () => new Veiculo().Placa = placa
            );

            //Assert
            Assert.Equal("O 4° caractere deve ser um hífen", mensagem.Message);

        }


        public void Dispose()
        {
            _SaidaConsoleTeste.WriteLine("Dispose is running.");
        }
    }
}
