using System;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using FiniteElementMethod.Models;
using FiniteElementMethod.Models.Math;
using FiniteElementMethod.Models.Enums;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class MatrixBuilderTest
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [DataSource(
            providerInvariantName: "Microsoft.VisualStudio.TestTools.DataSource.XML",
            connectionString: @"..\..\Resources\BorderNodesMatrix.xml",
            tableName: "BorderMatrix",
            dataAccessMethod: DataAccessMethod.Random)]
        public void BorderNodesMatrixTest()
        {
            // Arrange
            double a = 0;
            double b = 1;

            double c = 0;
            double d = 1;

            int n = Convert.ToInt32(TestContext.DataRow["N"]);
            int m = Convert.ToInt32(TestContext.DataRow["M"]);            

            CoordinateSystemConfig systemConfig = new CoordinateSystemConfig(a, b, c, d, n, m);
            MatrixBuilder matrixBuilder = new MatrixBuilder(systemConfig, null);

            NodeBorderValue[] expectedNodeBorderValues = Convert.ToString(TestContext.DataRow["BorderValue"])
                                                                .Split()
                                                                .Select(str => (NodeBorderValue)Enum.Parse(typeof(NodeBorderValue), str))
                                                                .ToArray();

            // Act
            NodeBorderValue[] actualNodeBorderValues = matrixBuilder.BorderNodesMatrix;

            // Assert
            CollectionAssert.AreEqual(expectedNodeBorderValues, actualNodeBorderValues);
        }

        [TestMethod]
        [DataSource(
            providerInvariantName: "Microsoft.VisualStudio.TestTools.DataSource.XML",
            connectionString: @"..\..\Resources\ConnectivityMatrix.xml",
            tableName: "Matrix",
            dataAccessMethod: DataAccessMethod.Random)]
        public void ConnectivityMatrixTest()
        {
            // Arrange
            double a = 0;
            double b = 1;

            double c = 0;
            double d = 1;

            int n = Convert.ToInt32(TestContext.DataRow["N"]);
            int m = Convert.ToInt32(TestContext.DataRow["M"]);

            CoordinateSystemConfig systemConfig = new CoordinateSystemConfig(a, b, c, d, n, m);
            MatrixBuilder matrixBuilder = new MatrixBuilder(systemConfig, null);
            
            int rows = Convert.ToInt32(TestContext.DataRow["Rows"]);
            int cols = Convert.ToInt32(TestContext.DataRow["Cols"]);

            Matrix expectedConnectivityMatrix = new Matrix(rows, cols);
            IEnumerable<double> values = Convert.ToString(TestContext.DataRow["Values"])
                                                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                                                .Select(double.Parse);
            for (int i = 0; i < rows; ++i)
            {
                expectedConnectivityMatrix[i] = values.Skip(i * cols).Take(cols).ToArray();
            }

            // Act
            Matrix actualConnectivityMatrix = matrixBuilder.ConnectivityMatrix;

            // Assert
            for (int i = 0; i < rows; ++i)
            {
                CollectionAssert.AreEqual(expectedConnectivityMatrix.Data[i], actualConnectivityMatrix.Data[i]);
            }
        }
        [TestMethod]
        [DataSource(
            providerInvariantName: "Microsoft.VisualStudio.TestTools.DataSource.XML",
            connectionString: @"..\..\Resources\CoordinateMatrix.xml",
            tableName: "Matrix",
            dataAccessMethod: DataAccessMethod.Random)]
        public void CoordinateMatrixTest()
        {
            // Arrange
            double a = Convert.ToInt32(TestContext.DataRow["A"]);
            double b = Convert.ToInt32(TestContext.DataRow["B"]);

            double c = Convert.ToInt32(TestContext.DataRow["C"]);
            double d = Convert.ToInt32(TestContext.DataRow["D"]);

            int n = Convert.ToInt32(TestContext.DataRow["N"]);
            int m = Convert.ToInt32(TestContext.DataRow["M"]);

            CoordinateSystemConfig systemConfig = new CoordinateSystemConfig(a, b, c, d, n, m);
            MatrixBuilder matrixBuilder = new MatrixBuilder(systemConfig, null);

            int rows = Convert.ToInt32(TestContext.DataRow["Rows"]);
            
            double[][] expectedCoordinateMatrix = new double[rows][];


            IEnumerable<double> values = Convert.ToString(TestContext.DataRow["Values"])
                                                .Split(new char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries)
                                                .Select(double.Parse);
 
            for (int i = 0; i < rows; ++i)
            {
                expectedCoordinateMatrix[i] = values.Skip(i * 2).Take(2).ToArray();
            }

            // Act
            Matrix actualCoordinateMatrix = matrixBuilder.CoordinateMatrix;

            // Assert
            for (int i = 0; i < rows; ++i)
            {
                CollectionAssert.AreEqual(expectedCoordinateMatrix[i], actualCoordinateMatrix.Data[i]);
            }
        }
        [TestMethod]
        public void JacobianTest()
        {
            // Arrange
            MatrixBuilder matrixBuilder = new MatrixBuilder(
                new CoordinateSystemConfig(a: 0, b: 0.4, c: 0, d: Math.PI/25, n: 4, m: 1),
                new CylindricalShellConfig(e: 80.1e10, v: 0.3, h: 0.005, r: 0.1));

            double[,] gaussNodeMatrix = matrixBuilder.GaussNodes;

            int finiteElementNumber = 0;
            int gaussNodeNumber = 0;

            double expectedJacobian = 0.00314159;

            // Act
            double actualJacobian = matrixBuilder.GetJacobian(finiteElementNumber, gaussNodeMatrix[gaussNodeNumber, 0], gaussNodeMatrix[gaussNodeNumber, 1]);

            // Assert
            Assert.AreEqual(expectedJacobian, actualJacobian, delta: 8);
        }
        [TestMethod]
        public void ClMatrixTest()
        {
            // Arrange
            int finiteElementIndex = 0;
            int nodeIndex = 1;
            int gaussNodeIndex = 0;

            MatrixBuilder matrixBuilder = new MatrixBuilder(
                new CoordinateSystemConfig(a: 0, b: 0.4, c: 0, d: Math.PI / 25, n: 4, m: 1),
                new CylindricalShellConfig(e: 80.1e10, v: 0.3, h: 0.005, r: 0.1));

            Matrix expectedClMatrix; Matrix.Read(out expectedClMatrix, @"..\..\Resources\CLMatrixOnFirstFiniteElementOnSecondNodeOnFirstPhi.txt");

            // Act
            Matrix actualClMatrix = matrixBuilder.BuildClMatrix(finiteElementIndex, nodeIndex, gaussNodeIndex);

            // Assert
            Assert.AreEqual(expectedClMatrix, actualClMatrix);
        }
        [TestMethod]
        public void GlobalMatrixOnFirstGaussNodeTest()
        {
            // Arrange
            int finiteElementIndex = 0;
            int gaussNodeIndex = 0;
            double R = 0.1;

            MatrixBuilder matrixBuilder = new MatrixBuilder(
                new CoordinateSystemConfig(a: 0, b: 0.4, c: 0, d: Math.PI / 25, n: 4, m: 1),
                new CylindricalShellConfig(e: 80.1e10, v: 0.3, h: 0.005, r: R));

            double[,] gaussNodes = matrixBuilder.GaussNodes;
            double[] gaussWeights = matrixBuilder.GaussWeights;

            double detJ = matrixBuilder.GetJacobian(finiteElementIndex, gaussNodes[gaussNodeIndex, 0], gaussNodes[gaussNodeIndex, 1]);
            
            double M = gaussWeights[gaussNodeIndex / 3] * gaussWeights[gaussNodeIndex % 3] * detJ * R;

            Matrix expectedGlobalMatrixOnFirstNode; Matrix.Read(out expectedGlobalMatrixOnFirstNode, @"..\..\Resources\GlobalMatrixOnFirstFiniteElementOnFirstGausseNode.txt");

            // Act
            Matrix actualGlobalMatrixOnFirstNode = matrixBuilder.BuildGlobalMatrixForGaussNodeIndex(finiteElementIndex, gaussNodeIndex) * M;

            // Assert
            Assert.AreEqual(expectedGlobalMatrixOnFirstNode, actualGlobalMatrixOnFirstNode);
        }

        [TestMethod]
        public void GlobalMatrixOnFirstFiniteElementTest()
        {
            // Arrange
            int finiteElementIndex = 0;

            MatrixBuilder matrixBuilder = new MatrixBuilder(
                new CoordinateSystemConfig(a: 0, b: 0.4, c: 0, d: Math.PI / 25, n: 4, m: 1),
                new CylindricalShellConfig(e: 80.1e10, v: 0.3, h: 0.005, r: 0.1));

            Matrix expectedGlobalMatrix; Matrix.Read(out expectedGlobalMatrix, @"..\..\Resources\GlobalMatrixOnFirstFiniteElement.txt");

            // Act
            Matrix actualGlobalMatrix = matrixBuilder.BuildGlobalMatrixForFiniteElement(finiteElementIndex);

            // Assert
            Assert.AreEqual(expectedGlobalMatrix, actualGlobalMatrix);
        }
    }
}
