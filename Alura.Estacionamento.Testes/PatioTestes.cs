using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class PatioTestes: IDisposable
    {
        private Veiculo veiculo;
        private Patio estacionamento;
        private Operador operador;
        public ITestOutputHelper _SaidaConsoleTeste;

        public PatioTestes(ITestOutputHelper saidaConsoleTeste)
        {
            _SaidaConsoleTeste = saidaConsoleTeste;
            _SaidaConsoleTeste.WriteLine("Construtor is running.");
            veiculo = new Veiculo();
            operador = new Operador() { Nome = "Nilson"};
            estacionamento = new Patio();

            estacionamento.OperadorPatio = operador;
        }

        [Fact]
        public void ValidaFaturamentoDoEstacionamentoComVeiculo()
        {
            //Arrange
            //var estacionamento = new Patio();
            //var veiculo = new Veiculo();

            veiculo.Proprietario = "Daut Pavan";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Branco";
            veiculo.Modelo = "Ford Fiesta";
            veiculo.Placa = "asd-9999";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);


            //Act
            double faturamento = estacionamento.TotalFaturado();


            //Assert
            Assert.Equal(2, faturamento);

        }


        [Theory]
        [InlineData("Janaina Silva", "ASD-6543", "Cinza", "Fusion")]
        [InlineData("Silvio Pavan", "POL-6784", "Preto", "S10")]
        [InlineData("Daut Pavan", "GDR-7891", "Preto", "Opala")]
        public void ValidaFaturamentoDoEstacionamentoComVariosVeiculos(
            string proprietario,
            string placa,
            string cor,
            string modelo
        )
        {
            //Arrange
            //var estacionamento = new Patio();
            //var veiculo = new Veiculo();

            veiculo.Proprietario = proprietario;
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();


            //Assert
            Assert.Equal(2, faturamento);
        }


        [Theory]
        [InlineData("Janaina Silva", "ASD-6543", "Cinza", "Fusion")]
        [InlineData("Daut Pavan", "GDR-7891", "Preto", "Opala")]
        public void LocalizaVeiculoNoPatioComBaseNoIdTicket(
            string proprietario,
            string placa,
            string cor,
            string modelo
        )
        {
            //Arrange
            // estacionamento = new Patio();
            //var veiculo = new Veiculo();

            veiculo.Proprietario = proprietario;
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act
            var consulta = estacionamento.PesquisaVeiculo(veiculo.IdTicket);

            //Assert
            Assert.Contains("### Ticket Estacionamento Alura ###", consulta.Ticket);

        }

        [Fact]
        public void AlterarDadosDoProprioVeiculo()
        {
            //Arrange
            //var estacionamento = new Patio();
            //var veiculo = new Veiculo();

            veiculo.Proprietario = "Daut Pavan";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Branco";
            veiculo.Modelo = "Ford Fiesta";
            veiculo.Placa = "asd-9999";

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var AlteradoVeiculo = new Veiculo();

            AlteradoVeiculo.Proprietario = "Daut Pavan";
            AlteradoVeiculo.Tipo = TipoVeiculo.Automovel;
            AlteradoVeiculo.Cor = "Preto";
            AlteradoVeiculo.Modelo = "Ford Fiesta";
            AlteradoVeiculo.Placa = "asd-9999";

            //Act
            Veiculo alterado = estacionamento.AlterarDadosVeiculo(AlteradoVeiculo);

            //Assert
            Assert.Equal(alterado.Cor, AlteradoVeiculo.Cor);

        }

        public void Dispose()
        {
            _SaidaConsoleTeste.WriteLine("Dispose is running.");
        }
    }
}
