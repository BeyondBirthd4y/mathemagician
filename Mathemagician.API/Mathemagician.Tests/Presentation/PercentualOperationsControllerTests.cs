using Microsoft.Extensions.Logging;
using Mathemagician.API.Controllers;
using Xunit;
using Moq;
using Mathemagician.Domain.Interfaces.Infra;
using Mathemagician.Domain.Interfaces.Services;
using Mathemagician.Services.Operations;
using Mathemagician.Domain.Entities;

namespace Mathemagician.Tests.Presentation
{
    public class PercentualOperationsControllerTests
    {
        private readonly Mock<ILogger<PercentualOperationsController>> _loggerMock;
        private readonly Mock<IBacenRepository> _bacenRepositoryMock;
        private readonly PercentualOperationsController _controller;
        private readonly Mock<IPercentualServices> _percentualServicesMock;

        public PercentualOperationsControllerTests()
        {
            _loggerMock = new Mock<ILogger<PercentualOperationsController>>();
            _bacenRepositoryMock = new Mock<IBacenRepository>();
            _percentualServicesMock = new Mock<IPercentualServices>();
            _controller = new PercentualOperationsController(_loggerMock.Object, _bacenRepositoryMock.Object, _percentualServicesMock.Object);
        }
        [Fact]
        public void Return_Correct_Calculo_Aumento()
        {
            _percentualServicesMock
                .Setup(s => s.CalculoAumento(100f, 10f))
                .Returns(110f);

            float resultado = _controller.CalculoAumento(100f, 10f);

            Assert.Equal(110f, resultado);
        }

        [Fact]
        public void Return_Correct_Calculo_Reducao()
        {
            _percentualServicesMock
                .Setup(s => s.CalculoReducao(100f, 10f))
                .Returns(90f);
            float resultado = _controller.CalculoReducao(100f, 10f);

            Assert.Equal(90f, resultado);
        }

        [Fact]
        public async void Return_Correct_Calculo_Juros_Compostos()
        {
            var respostaFakeBacen = new TaxaSelic(DateTime.Today, 14.00m);
            _bacenRepositoryMock
                .Setup(r => r.ObterSelicAtualAsync())
                .ReturnsAsync(respostaFakeBacen);

            _percentualServicesMock
                .Setup(s => s.JurosCompostos(1000.00d, 14.00d, 1))
                .Returns(1140d);
            double resultado = await _controller.CalculoJurosCompostos(1000.00d, 14.00d, 1);

            Assert.Equal(1140d, resultado);
        }
    }
}
