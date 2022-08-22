using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class TipoVeiculoTestes
    {
        [Fact]
        public void TestaTipoVeiculo() 
        {
            //Arrange
            var veiculo = new Veiculo();
            //Act

            //Assert
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);

        }

    }
}
