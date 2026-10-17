using Microsoft.Extensions.Logging;
using Mathemagician.API.Controllers;
using Xunit;
using Moq;
using Mathemagician.Domain.Interfaces.Infra;

namespace Mathemagician.Tests.Presentation
{
    public class PercentualOperationsControllerTests
    {
        [Fact]
        public void Return_Correct_Calculo_Aumento()
        {
            var loggerMock = new Mock<ILogger<PercentualOperationsController>>();
            var bacenRepositoryMock = new Mock<IBacenRepository>();
            var controller = new PercentualOperationsController(loggerMock.Object, bacenRepositoryMock.Object);

            float resultado = controller.CalculoAumento(100f, 10f);

            Assert.Equal(110f, resultado);
        }

        [Fact]
        public void Return_Correct_Calculo_Reducao()
        {
            var loggerMock = new Mock<ILogger<PercentualOperationsController>>();
            var bacenRepositoryMock = new Mock<IBacenRepository>();
            var controller = new PercentualOperationsController(loggerMock.Object, bacenRepositoryMock.Object);

            float resultado = controller.CalculoReducao(100f, 10f);

            Assert.Equal(90f, resultado);
        }

        [Fact]
        public async void Return_Correct_Calculo_Juros_Compostos()
        {
            var loggerMock = new Mock<ILogger<PercentualOperationsController>>();
            var bacenRepositoryMock = new Mock<IBacenRepository>();
            var controller = new PercentualOperationsController(loggerMock.Object, bacenRepositoryMock.Object);

            double resultado = await controller.CalculoJurosCompostos(1000.00d, 14.00d, 1);

            Assert.Equal(1140d, resultado);
        }
    }
}
