﻿using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.Services;
using WeatherApp.ViewModels;
using Xunit;

namespace WeatherStationTests
{
    public class WindDataViewModelTests : IDisposable
    {
        // System Under Test
        // Utilisez ce membre dans les tests
        WindDataViewModel _sut = new WindDataViewModel();

        /// <summary>
        /// Test la fonctionnalité de conversion de mps vers kph
        /// </summary>
        /// <param name="mps">Mètres par seconde</param>
        /// <param name="expected">Résultat attendu</param>
        /// <remarks>T01</remarks>
        [Theory]
        [InlineData(0, 0)]
        [InlineData(5, 18)]
        [InlineData(51, 183.6)]
        [InlineData(-10, -36)]
        [InlineData(65, 234)]
        public void MPStoKPH_AlwaysReturnGoodValue(double mps, double expected)
        {
            // Arrange
            // Act       
            var actual = _sut.MPStoKPH(mps);

            // Assert
            Assert.Equal(expected, actual);
            /// TODO : git commit -a -m "T01 MPStoKPH_AlwaysReturnGoodValue : Done"
        }

        /// <summary>
        /// Test la fonctionnalité de conversion de kph à mps
        /// </summary>
        /// <param name="kph">km par heure</param>
        /// <param name="expected">Résultat attendu</param>
        /// <remarks>T02</remarks>
        [Theory]
        [InlineData(0, 0)]
        [InlineData(10, 2.78)]
        [InlineData(50, 13.89)]
        [InlineData(100, 27.78)]
        [InlineData(126, 35)]
        [InlineData(200, 55.56)]
        public void KPHtoMPS_AlwaysReturnGoodValue(double kph, double expected)
        {
            // Arrange
            // Act       
            var actual = _sut.KPHtoMPS(kph);

            // Assert
            Assert.Equal(expected, actual);
            /// TODO : git commit -a -m "T02 KPHtoMPS_AlwaysReturnGoodValue : Done"
        }

        /// <summary>
        /// Lorsqu'exécuté GetDataCommand devrait lancer une NullException
        /// </summary>
        /// <remarks>T03</remarks>
        [Fact]
        public void GetDataCommand_ExecuteIfNullService_ShouldThrowNullException()
        {
            // Arrange
            // Act       

            // Assert
            Assert.Throws<NullReferenceException>( () => _sut.GetDataCommand.Execute(_sut.WindDataService));
            /// TODO : git commit -a -m "T03 GetDataCommand_ExecuteIfNullService_ShouldThrowNullException : Done"
        }

        /// <summary>
        /// La méthode CanGetData devrait retourner faux si le service est null
        /// </summary>
        /// <remarks>T04</remarks>
        [Fact]
        public void CanGetData_WhenServiceIsNull_ReturnsFalse()
        {
            // Arrange

            // Act       

            // Assert

            Assert.False(_sut.CanGetData());

            /// TODO : git commit -a -m "T04 CanGetData_WhenServiceIsNull_ReturnsFalse : Done"
        }

        /// <summary>
        /// La méthode CanGetData devrait retourner vrai si le service est instancié
        /// </summary>
        /// <remarks>T05</remarks>
        [Fact]
        public void CanGetData_WhenServiceIsSet_ReturnsTrue()
        {
            // Arrange
            var expected = true;
            Mock<IWindDataService> MockWindDataService = new Mock<IWindDataService>();
            _sut.SetWindDataService(MockWindDataService.Object);

            // Act       
            var actual = _sut.CanGetData();

            // Assert 

            Assert.Equal(actual, expected);

            /// TODO : git commit -a -m "T05 CanGetData_WhenServiceIsSet_ReturnsTrue : Done"
        }

        /// <summary>
        /// WindDataService ne devrait plus être null lorsque SetWindDataService reçoit un paramètre
        /// </summary>
        /// <remarks>T06</remarks>
        [Fact]
        public void SetWindDataService_WhenExecuted_WindDataServiceIsNotNull()
        {
            // Arrange
            Mock<IWindDataService> MockWindDataService = new Mock<IWindDataService>();

            _sut.SetWindDataService(MockWindDataService.Object);

            // Act       
            var actual = _sut.WindDataService;
            // Assert
            Assert.NotNull(actual);

            /// TODO : git commit -a -m "T06 SetWindDataService_WhenExecuted_WindDataServiceIsNotNull : Done"
        }

        /// <summary>
        /// CurrentData devrait avoir une valeur lorsque GetDataCommand est exécutée
        /// </summary>
        /// <remarks>T07</remarks>
        [Fact]
        public void GetDataCommand_HaveCurrentDataWhenExecuted_ShouldPass()
        {
            // Arrange


            Mock<IWindDataService> MockWindDataService = new Mock<IWindDataService>();
            WindDataModel wdm = new WindDataModel();
            wdm.DateTime = DateTime.Now;
            wdm.MetrePerSec = 33.55;
            wdm.Direction = 22.77;
            Mock<WindDataModel> MockWindDataModel = new Mock<WindDataModel>();

            MockWindDataService.Setup(w => w.GetDataAsync()).Returns(Task.FromResult(wdm));
            _sut.SetWindDataService(MockWindDataService.Object);

            // Act       

            _sut.GetData("");
            var actual = _sut.CurrentData;

            // Assert

            Assert.NotNull(actual);

            /// TODO : git commit -a -m "T07 GetDataCommand_HaveCurrentDataWhenExecuted_ShouldPass : Done"
        }

        /// <summary>
        /// Ne touchez pas à ça, c'est seulement pour respecter les standards
        /// de test qui veulent que la classe de tests implémente IDisposable
        /// Mais ça peut être utilisé, par exemple, si on a une connexion ouverte, il
        /// faut s'assurer qu'elle sera fermée lorsque l'objet sera détruit
        /// </summary>
        public void Dispose()
        {
            // Nothing to here, just for Testing standards
        }
    }
}
