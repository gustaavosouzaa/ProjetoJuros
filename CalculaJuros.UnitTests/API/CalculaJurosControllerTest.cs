using CalculaJuros.API.Controllers;
using CalculaJuros.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CalculaJuros.UnitTests.API
{
    public class CalculaJurosControllerTest
    {
        //----------------- GET --------------------------
        [Fact]
        public async Task EntradaDeDadosOk_GetJuros_Status200Ok()
        {

            #region Arrange

            decimal valorInicial = 100M;
            int meses = 5;

            Mock<ICalculoJurosService> _calculoJurosServiceMock = new Mock<ICalculoJurosService>();

            var controller = new CalculaJurosController(_calculoJurosServiceMock.Object);


            _calculoJurosServiceMock.Setup(s => s.GetJuros(It.IsAny<decimal>(), It.IsAny<int>()));

            #endregion

            #region Act

            var viewModel = await controller.Get(valorInicial, meses);
            var statusCodeResult = (IStatusCodeActionResult) viewModel;

            #endregion

            #region Assert

            Assert.Equal(StatusCodes.Status200OK, statusCodeResult.StatusCode);
            _calculoJurosServiceMock.Verify(j => j.GetJuros(It.IsAny<decimal>(), It.IsAny<int>()), Times.Once);

            #endregion
        }

        [Theory]
        [InlineData(0, 5)]
        [InlineData(10, 0)]
        [InlineData(0, 0)]
        public async Task ValoresZerados_GetJuros_Status404(decimal valorInicial, int meses)
        {

            #region Arrange

            Mock<ICalculoJurosService> _calculoJurosServiceMock = new Mock<ICalculoJurosService>();

            var controller = new CalculaJurosController(_calculoJurosServiceMock.Object);


            _calculoJurosServiceMock.Setup(s => s.GetJuros(It.IsAny<decimal>(), It.IsAny<int>()));

            #endregion

            #region Act

            var viewModel = await controller.Get(valorInicial, meses);
            var statusCodeResult = (IStatusCodeActionResult)viewModel;

            #endregion

            #region Assert

            Assert.Equal(StatusCodes.Status404NotFound, statusCodeResult.StatusCode);
            _calculoJurosServiceMock.Verify(j => j.GetJuros(It.IsAny<decimal>(), It.IsAny<int>()), Times.Never);

            #endregion
        }      
    }
}


