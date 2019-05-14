using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using FiniteElementMethod.Models;

namespace UnitTests
{
    [TestClass]
    public class CoordinateSystemConfigTest
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [DataSource(
            providerInvariantName: "Microsoft.VisualStudio.TestTools.DataSource.XML",
            connectionString: @"..\..\Resources\NodesAmount.xml",
            tableName: "FiniteElements",
            dataAccessMethod: DataAccessMethod.Random)]
        public void NodesAmountTest()
        {
            // Arrange
            double a = 0;
            double b = 1;
            double c = 0;
            double d = 1;

            int n = Convert.ToInt32(TestContext.DataRow["N"]);
            int m = Convert.ToInt32(TestContext.DataRow["M"]);

            int expectedNodesAmount = Convert.ToInt32(TestContext.DataRow["NodesAmount"]);

            CoordinateSystemConfig systemConfig = new CoordinateSystemConfig(a, b, c, d, n, m);

            // Act
            int actualNodesAmount = systemConfig.NodesAmount;

            // Assert
            Assert.AreEqual(expectedNodesAmount, actualNodesAmount);
        }
    }
}
