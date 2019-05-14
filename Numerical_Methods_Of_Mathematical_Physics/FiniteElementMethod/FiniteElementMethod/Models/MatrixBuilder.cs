using System.Linq;

using FiniteElementMethod.Models.Math;
using FiniteElementMethod.Models.Enums;

using static FiniteElementMethod.Models.Math.Algorithms;

namespace FiniteElementMethod.Models
{
    public class MatrixBuilder
    {
        // CONST
        static readonly double MATRIX_NODE_BORDER_VALUE = 1e50;
        static readonly double VECTOR_NODE_BORDER_VALUE = 0;

        // FIELDS
        Functions f;
        Derivatives d;

        CoordinateSystemConfig systemConfig;
        CylindricalShellConfig shellConfig;

        System.Lazy<Matrix> connectivityMatrix;
        System.Lazy<Matrix> coordinateMatrix;
        System.Lazy<NodeBorderValue[]> borderNodesMatrix;

        System.Lazy<Matrix> matrixOfElasticCharacteristics;
        System.Lazy<Matrix> eMatrix;
        System.Lazy<Matrix> BEMatrix;
        System.Lazy<double[,]> gaussNodes;
        System.Lazy<double[]> gaussWeights;

        System.Lazy<Matrix> capacityVector;

        // CONSTRUCTORS
        public MatrixBuilder(CoordinateSystemConfig systemConfig, CylindricalShellConfig shellConfig)
        {
            this.f = new Functions();
            this.d = new Derivatives();

            this.systemConfig = systemConfig;
            this.shellConfig = shellConfig;

            this.connectivityMatrix = new System.Lazy<Matrix>(BuildConnectivityMatrix);
            this.coordinateMatrix = new System.Lazy<Matrix>(BuildCoordinateMatrix);
            this.borderNodesMatrix = new System.Lazy<NodeBorderValue[]>(BuildBorderNodesMatrix);

            this.matrixOfElasticCharacteristics = new System.Lazy<Matrix>(BuildMatrixOfElasticCharacteristics);
            this.eMatrix = new System.Lazy<Matrix>(BuildEMatrix);
            this.BEMatrix = new System.Lazy<Matrix>(() => B * E);
            this.gaussNodes = new System.Lazy<double[,]>(BuildGaussNodes);
            this.gaussWeights = new System.Lazy<double[]>(BuildGaussWeights);

            this.capacityVector = new System.Lazy<Matrix>(BuildCapacityVector);
        }

        // PROPERTIES
        public Matrix ConnectivityMatrix => connectivityMatrix.Value;
        public Matrix CoordinateMatrix => coordinateMatrix.Value;
        public NodeBorderValue[] BorderNodesMatrix => borderNodesMatrix.Value;

        public Matrix B => matrixOfElasticCharacteristics.Value;
        public Matrix E => eMatrix.Value;
        public Matrix BE => BEMatrix.Value;
        public double[,] GaussNodes => gaussNodes.Value;
        public double[] GaussWeights => gaussWeights.Value;

        public Matrix CapacityVector => capacityVector.Value;

        // METHODS
        /// <summary>
        /// Matrix wich sets to each finite element numbers of nodes
        /// <example>
        /// |1 2 3 5  9  8 7 4|
        /// |3 4 5 6 11 10 9 5|
        /// |.................|
        /// </example>
        /// </summary>
        /// <returns>
        /// Matrix with: <para/>
        /// rows amount = amount of finite elements <para/>
        /// cols amount =  amount of finite elements  * 8 <para/>
        /// matrix index = node index <para/>      
        /// </returns>
        private Matrix BuildConnectivityMatrix()
        {
            // build regular matrix with 0 in the middle of finite element

            // | 1 2 3  4  5 | 
            // | 4 0 5  0  6 |
            // | 7 8 9 10 11 |
            // | ........... |

            Matrix globalNodeOrderMatrix = new Matrix(rows: systemConfig.NodesRows, cols: systemConfig.NodesColsEven);
            int number = 0;
            if (systemConfig.FiniteElementDirection == FiniteElementDirection.Right)
            {
                for (int i = 0; i < globalNodeOrderMatrix.Rows; ++i)
                {
                    for (int j = 0; j < globalNodeOrderMatrix.Cols; ++j)
                    {
                        if (IsOdd(i) && IsOdd(j)) continue; // skip for zero

                        globalNodeOrderMatrix[i, j] = number++;
                    }
                }
            }
            else// if (systemConfig.FiniteElementDirection == FiniteElementDirection.Top)
            {
                for (int j = 0; j < globalNodeOrderMatrix.Cols; ++j)
                {
                    for (int i = 0; i < globalNodeOrderMatrix.Rows; ++i)
                    {
                        if (IsOdd(i) && IsOdd(j)) continue; // skip for zero

                        globalNodeOrderMatrix[i, j] = number++;
                    }
                }
            }

            // build connectivity matrix

            // hops on 0, and gathers numbers around
            // in clockwise order


            // | [1 2 3]  4  5 | 
            // | [4 0 5]  0  6 |
            // | [7 8 9] 10 11 |
            // | ............. |

            // | 1 2 [3  4  5] | 
            // | 4 0 [5  0  6] |
            // | 7 8 [9 10 11] |
            // | ............. |


            int finiteElementNumber = 0;
            Matrix connectivityMatrix = new Matrix(rows: systemConfig.FiniteElementAmount, cols: systemConfig.NodesAmountPerFiniteElement);

            if (systemConfig.FiniteElementDirection == FiniteElementDirection.Right)
            {
                for (int i = 1; i < globalNodeOrderMatrix.Rows; i += 2)
                {
                    for (int j = 1; j < globalNodeOrderMatrix.Cols; j += 2)
                    {
                        connectivityMatrix[finiteElementNumber++] = ClockwiseBlock (globalNodeOrderMatrix, i , j);
                    }
                }
            }
            else// if (systemConfig.FiniteElementDirection == FiniteElementDirection.Top)
            {
                // counter clockwise
                for (int j = 1; j < globalNodeOrderMatrix.Cols; j += 2)
                {
                    for (int i = 1; i < globalNodeOrderMatrix.Rows; i += 2)
                {
                        connectivityMatrix[finiteElementNumber++] = ClockwiseBlock(globalNodeOrderMatrix, i, j);
                    }
                }
            }
            return connectivityMatrix;
        }
        private double[] ClockwiseBlock(Matrix matrix, int centerBlockI, int centerBlockJ)
        {
            var clockwiseShiftArray = new[]
            {
                new { shiftI = -1, shiftJ = -1 },
                new { shiftI = -1, shiftJ = +0 },
                new { shiftI = -1, shiftJ = +1 },

                new { shiftI = +0, shiftJ = +1 },

                new { shiftI = +1, shiftJ = +1 },
                new { shiftI = +1, shiftJ = +0 },
                new { shiftI = +1, shiftJ = -1 },

                new { shiftI = +0, shiftJ = -1 },
            };

            // go clockwise
            int i = 0;
            double[] blockClocwiseNode = new double[systemConfig.NodesAmountPerFiniteElement];
            foreach (var shift in clockwiseShiftArray)
            {
                blockClocwiseNode[i++] = matrix[centerBlockI + shift.shiftI, centerBlockJ + shift.shiftJ];
            }
            return blockClocwiseNode;
        }
        /// <summary>
        /// Matrix with coordinate of each nodes
        /// <example>
        /// |0 0|
        /// |0 1|
        /// |0 2|
        /// |...|
        /// </example>
        /// </summary>
        /// <returns>
        /// Matrix with: <para/>
        /// rows amount = nodes amount <para/>
        /// cols amount = 2. (x, y) of each nodes <para/>
        /// matrix index = node index <para/>
        /// </returns>
        private Matrix BuildCoordinateMatrix()
        {
            Matrix matrix = new Matrix(rows: systemConfig.NodesAmount, cols: 2);

            // build matrix
            int nodeIndex = 0;
            bool isOddAxes = false, isOddElement = false;
            if (systemConfig.FiniteElementDirection == FiniteElementDirection.Top)
            {
                for (double x = systemConfig.A; x <= systemConfig.B; x += systemConfig.H1 / 2)
                {
                    isOddElement = false; // we start from odd element (0)
                    if (nodeIndex == systemConfig.NodesAmount) break;

                    for (double y = systemConfig.C; y <= systemConfig.D; y += systemConfig.H2 / 2)
                    {
                        // skip middle node
                        if (isOddAxes && isOddElement)
                        {
                            isOddElement = !isOddElement;
                            continue;
                        }

                        matrix[nodeIndex++] = new double[2] { x, y };

                        isOddElement = !isOddElement;
                    }

                    isOddAxes = !isOddAxes;
                }
            }
            else //if (systemConfig.FiniteElementDirection == FiniteElementDirection.Right)
            {
                for (double y = systemConfig.C; y <= systemConfig.D; y += systemConfig.H2 / 2)
                {
                    isOddElement = false; // we start from odd element (0)
                    if (nodeIndex == systemConfig.NodesAmount) break;

                    for (double x = systemConfig.A; x <= systemConfig.B; x += systemConfig.H1 / 2)
                    {
                        // skip middle node
                        if (isOddAxes && isOddElement)
                        {
                            isOddElement = !isOddElement;
                            continue;
                        }

                        matrix[nodeIndex++] = new double[2] { x, y };

                        isOddElement = !isOddElement;
                    }
                    
                    isOddAxes = !isOddAxes;
                }
            }

            // get matrix
            return matrix;
        }
        /// <summary>
        /// Matrix which sets to each nodes his border value <para/>
        /// Left, Top, Top Left, Top Right, Bottom, Bottom Left, Bottom Right, Middle <para/>
        /// TL---T---TR
        /// |         |
        /// L   M     R
        /// |         |
        /// BL---B---BR
        /// <example>
        /// | TL |
        /// | M  |
        /// | M  |
        /// |....|
        /// | TR |
        /// | R  |
        /// | BR |
        /// |....|
        /// </example>
        /// </summary>
        /// <returns>
        /// Matrix with: <para/>
        /// rows amount = nodes amount <para/>
        /// cols amount = 1. border value <para/>
        /// matrix index = node index <para/>
        /// </returns>
        private NodeBorderValue[] BuildBorderNodesMatrix()
        {

            // build matrix
            // corner values are the sum of neighbours ribs

            // 3---2---6
            // |       |
            // 1   0   4
            // |       |
            // 8---7---11

            // TL---T---TR
            // |         |
            // L   M     R
            // |         |
            // BL---B---BR

            int nodeIndex = 0;
            bool isOddAxes = false, isOddElement = false;

            int[] nodeBorderValues = new int[systemConfig.NodesAmount];

            if (systemConfig.FiniteElementDirection == FiniteElementDirection.Top)
            {

                for (double x = systemConfig.A; x <= systemConfig.B; x += systemConfig.H1/2)
                {
                    isOddElement = false;

                    for (double y = systemConfig.C; y <= systemConfig.D; y += systemConfig.H2/2)
                    {
                        // skip middle node
                        if (isOddAxes && isOddElement)
                        {
                            isOddElement = !isOddElement;
                            continue;
                        }

                        if (x == systemConfig.A) nodeBorderValues[nodeIndex] += 1; // Left
                        if (x == systemConfig.B) nodeBorderValues[nodeIndex] += 4; // Right
                        if (y == systemConfig.C) nodeBorderValues[nodeIndex] += 7; // Bottom
                        if (y == systemConfig.D) nodeBorderValues[nodeIndex] += 2; // Top

                        ++nodeIndex;
                        isOddElement = !isOddElement;
                    }

                    isOddAxes = !isOddAxes;
                }
            }
            else //if (systemConfig.FiniteElementDirection == FiniteElementDirection.Right)
            {
                for (double y = systemConfig.C; y <= systemConfig.D; y += systemConfig.H2 / 2)
                {
                    isOddElement = false;
                    for (double x = systemConfig.A; x <= systemConfig.B; x += systemConfig.H1 / 2)
                    {
                        // skip middle node
                        if (isOddAxes && isOddElement)
                        {
                            isOddElement = !isOddElement;
                            continue;
                        }

                        if (x == systemConfig.A) nodeBorderValues[nodeIndex] += 1; // Left
                        if (x == systemConfig.B) nodeBorderValues[nodeIndex] += 4; // Right
                        if (y == systemConfig.C) nodeBorderValues[nodeIndex] += 7; // Bottom
                        if (y == systemConfig.D) nodeBorderValues[nodeIndex] += 2; // Top

                        ++nodeIndex;
                        isOddElement = !isOddElement;
                    }
                    isOddAxes = !isOddAxes;
                }
            }

            return nodeBorderValues.Select(intValue => (NodeBorderValue)intValue).ToArray();
        }

        // B
        private Matrix BuildMatrixOfElasticCharacteristics()
        {
            double v = shellConfig.V, E = shellConfig.E, h = shellConfig.H;

            Matrix b = new Matrix(11, 11);

            b[0, 0] = b[1, 1] = b[2, 2] = ((1 - v) * E * h) / ((1 + v) * (1 - 2 * v));
            b[0, 1] = b[0, 2] = b[1, 0] = b[1, 2] = b[2, 1] = b[2, 0] = (v * E * h) / ((1 + v) * (1 - 2 * v));

            b[3, 3] = b[4, 4] = b[5, 5] = E * h / (1 + v);

            b[6, 6] = b[7, 7] = ((1 - v) * E * h * h * h) / (12 * (1 + v) * (1 - 2 * v));
            b[6, 7] = b[7, 6] = (v * E * h * h * h) / (12 * (1 + v) * (1 - 2 * v));

            b[8, 8] = b[9, 9] = b[10, 10] = (E * h * h * h) / (12 * (1 + v));
            
            return b;
        }
        // E
        private Matrix BuildEMatrix()
        {
            Matrix E = new Matrix(11, 11);
            E[0, 0] = E[1, 1] = E[2, 2] = E[6, 6] = E[7, 7] = 1;
            E[3, 3] = E[4, 4] = E[5, 5] = E[8, 8] = E[9, 9] = E[10, 10] = 2;
            return E;
        }

        // Gauss Nodes
        // 3 6 9
        // 2 5 8  
        // 1 4 7
        private double[,] BuildGaussNodes()
        {
            return new double[9, 2]
            { 
                { -0.77459, -0.77459 },
                {        0, -0.77459 },
                { +0.77459, -0.77459 },
                { -0.77459,        0 },
                {        0,        0 },
                { +0.77459,        0 },
                { -0.77459, +0.77459 },
                {        0, +0.77459 },
                { +0.77459, +0.77459 }
            };
        }
        // Gauss Weights
        private double[] BuildGaussWeights()
        {
            return new double[3]
            {
                0.5555555555,
                0.8888888888,
                0.5555555555
            };
        }

        // CL
        public Matrix BuildClMatrix(int finiteElementIndex, int nodeIndex, int gaussNodesIndex)
        {
            double k2 = 1 / shellConfig.R; // TODO: maybe remove this
            double R = shellConfig.R;

            double xi1 = GaussNodes[gaussNodesIndex, 0];
            double xi2 = GaussNodes[gaussNodesIndex, 1];

            Matrix derivativeOnAlpha = DerivativesOfFiOnAlpha(finiteElementIndex, nodeIndex, xi1, xi2);

            double d1 = derivativeOnAlpha[0, 0];
            double d2 = derivativeOnAlpha[1, 0];

            double phi = f.phiBasis(nodeIndex, xi1, xi2);

            return new Matrix(11, 6)
            {
                [0, 0] = d1,
                                        [1, 1] = d2/R,          [1, 2] = phi/R,
                                                                                                                                  [ 2, 5] = phi,
                [3, 0] = d2/(2*R),      [3, 1] = d1/2,
                                                                [4, 2] = d1/2,          [4, 3] = phi/2,
                                        [5, 1] = -phi/(2*R),    [5, 2] = d2/(2*R),                          [5, 4] = phi/2,
                                                                                        [6, 3] = d1,   
                                                                                                            [7, 4] = d2/R,        [ 7, 5] = phi*k2,
                                        [8, 1] = d1/(2*R),                              [8, 3] = d2/(2*R),  [8, 4] = d1/2,
                                                                                                                                  [ 9, 5] = d1/2,
                                                                                                                                  [10, 5] = d2/(2*R),
            };
        }
        
        // Jacobi's matrix 
        public Matrix BuildJacobiInverseMatrix(int finiteElementIndex, double xi1, double xi2)
        {
            Matrix result = new Matrix(2, 2);

            // sum of matrix
            for (int i = 0; i < systemConfig.NodesAmountPerFiniteElement; ++i)
            {
                double derivativeOfFiOnXi1 = d.DerivativeOfPhiOnXi1(i, xi1, xi2);
                double derivativeOfFiOnXi2 = d.DerivativeOfPhiOnXi2(i, xi1, xi2);

                Structs.Coordinate2D nodeCoordinate = CoordinateMatrix[(int)ConnectivityMatrix[finiteElementIndex, i]];

                result += new Matrix(2, 2)
                {
                    [0, 0] = +derivativeOfFiOnXi2 * nodeCoordinate.Y,   [0, 1] = -derivativeOfFiOnXi1 * nodeCoordinate.Y,
                    [1, 0] = -derivativeOfFiOnXi2 * nodeCoordinate.X,   [1, 1] = +derivativeOfFiOnXi1 * nodeCoordinate.X,
                }; 
            }

            return result / GetJacobian(finiteElementIndex, xi1, xi2);
        }
        public double GetJacobian(int finiteElementIndex, double xi1, double xi2)
        {      
            // Jacobian - Jacobi matrix determinant
            double sum = 0;
            for (int i = 0; i < systemConfig.NodesAmountPerFiniteElement; ++i)
            {
                for (int j = 0; j < systemConfig.NodesAmountPerFiniteElement; ++j)
                {
                    if (i != j)
                    {
                        Structs.Coordinate2D coordinateI = CoordinateMatrix[(int)ConnectivityMatrix[finiteElementIndex, i]];
                        Structs.Coordinate2D coordinateJ = CoordinateMatrix[(int)ConnectivityMatrix[finiteElementIndex, j]];

                        sum += d.DerivativeOfPhiOnXi1(i, xi1, xi2) * d.DerivativeOfPhiOnXi2(j, xi1, xi2) * (coordinateI.X * coordinateJ.Y - coordinateJ.X * coordinateI.Y);
                    }
                }
            }
            return sum;
        }

        // [a1]
        // [a2]
        private Matrix DerivativesOfFiOnAlpha(int finiteElementIndex, int nodeIndex, double xi1, double xi2)
        {
            return BuildJacobiInverseMatrix(finiteElementIndex, xi1, xi2) * DerivativesOfFiOnXi(nodeIndex, xi1, xi2);
        }
        private Matrix DerivativesOfFiOnXi(int nodeIndex, double xi1, double xi2)
        {
            return new Matrix(2, 1)
            {
                [0, 0] = d.DerivativeOfPhiOnXi1(nodeIndex, xi1, xi2),
                [1, 0] = d.DerivativeOfPhiOnXi2(nodeIndex, xi1, xi2),
            };
        }



        /// <summary>
        /// In U = (u1, u2, u3, v1, v2, v3) determines which components are unknown depending on node border value
        /// </summary>
        /// <param name="nodeBorderValue">
        /// Node's border value
        /// </param>
        /// <returns>
        /// A bool array with indices of vector's component which should be raised to higher number <para/>
        /// Or sets to zero in right vector
        /// </returns>
        public bool[] GetNumbersOfUnknownVectorComponent(NodeBorderValue nodeBorderValue)
        {
            //    u2 v2
            //    ______
            // u1|      |u3
            // v1|______|v3
            //    u2  v2

            // TODO: add lazy loading

            switch (nodeBorderValue)
            {
                case NodeBorderValue.Middle: return new bool[6] { false, false, false, false, false, false };
                case NodeBorderValue.Left: return new bool[6] { true, false, false, true, false, false };
                case NodeBorderValue.TopLeft: return new bool[6] { true, true, false, true, true, false };
                case NodeBorderValue.Top: return new bool[6] { false, true, false, false, true, false };
                case NodeBorderValue.TopRight: return new bool[6] { false, true, true, false, true, true };
                case NodeBorderValue.Right: return new bool[6] { false, false, true, false, false, true };
                case NodeBorderValue.BottomRight: return new bool[6] { false, true, true, false, true, true };
                case NodeBorderValue.Bottom: return new bool[6] { false, true, false, false, true, false };
                case NodeBorderValue.BottomLeft: return new bool[6] { true, true, false, true, true, false };

                default: throw new System.ArgumentException("Wrong node border value");
            }
        }










        // Global Matrix
        public Matrix[,] BuildGlobalMatrixForGaussNodeIndex(int finiteElementIndex, int gaussNodeIndex)
        {
            int nodeAmount = systemConfig.NodesAmountPerFiniteElement;
            Matrix[] clLocal = new Matrix[nodeAmount];

            for (int nodeIndex = 0; nodeIndex < nodeAmount; ++nodeIndex) // 8
            {
                clLocal[nodeIndex] = BuildClMatrix(finiteElementIndex, nodeIndex, gaussNodeIndex);
            }

            // Matrix 8*8 of 6*6 matrices
            Matrix[,] globalMatrixForGaussNode = new Matrix[nodeAmount, nodeAmount];
            for (int i = 0; i < globalMatrixForGaussNode.GetLength(0); ++i)
            {
                for (int j = 0; j < globalMatrixForGaussNode.GetLength(1); ++j)
                {
                    // 6*6
                    globalMatrixForGaussNode[i, j] = clLocal[i].Transpose * BE * clLocal[j]; // Cl(T)[i] * B * E * CL[j]
                }
            }

            return globalMatrixForGaussNode;
        }
        public Matrix[,] BuildGlobalMatrixForFiniteElement(int finiteElementIndex)
        {
            double R = shellConfig.R;

            double[] gaussWeights = GaussWeights;
            double[,] gaussNodes = GaussNodes;

            Matrix[,] globalMatrix = new Matrix[8, 8];
            for (int i = 0; i < globalMatrix.GetLength(0); ++i)
            {
                for (int j = 0; j < globalMatrix.GetLength(1); ++j)
                {
                    globalMatrix[i, j] = new Matrix(6, 6);
                }
            }

            // sum up for each gauss' node
            for (int gaussNodeIndex = 0; gaussNodeIndex < gaussNodes.GetLength(0); ++gaussNodeIndex) // 9
            {
                // TODO: extract this to separate function
                double detJ = GetJacobian(finiteElementIndex, gaussNodes[gaussNodeIndex, 0], gaussNodes[gaussNodeIndex, 1]);
                double M = gaussWeights[gaussNodeIndex / 3] * gaussWeights[gaussNodeIndex % 3] * detJ * R;

                Matrix[,] matrixOnGaussNode = BuildGlobalMatrixForGaussNodeIndex(finiteElementIndex, gaussNodeIndex);

                // sum up with previous gauss' nodes
                for (int i = 0; i < globalMatrix.GetLength(0); ++i)
                {
                    for (int j = 0; j < globalMatrix.GetLength(1); ++j)
                    {
                        globalMatrix[i, j] += matrixOnGaussNode[i, j] * M;
                    }
                }
            }
            return globalMatrix;
        }

        public void SetMatrixUV(Matrix nodeMatrix, NodeBorderValue nodeBorderValue)
        {
            bool[] indicesOfNodeBorderValue = GetNumbersOfUnknownVectorComponent(nodeBorderValue);

            // diagonal moving
            for (int k = 0; k < nodeMatrix.Cols; ++k)// 6*6
            {
                if (indicesOfNodeBorderValue[k])
                {
                    nodeMatrix[k, k] = MATRIX_NODE_BORDER_VALUE;
                }
            }
        }


        public Matrix[,] BuildUVGlobalMatrixForFiniteElement(int finiteElementIndex)
        {
            int nodeAmount = systemConfig.NodesAmountPerFiniteElement;
            Matrix[,] globalMatrixForFiniteElement = BuildGlobalMatrixForFiniteElement(finiteElementIndex);

            // diagonal moving
            for (int nodeMatrixIndex = 0; nodeMatrixIndex < nodeAmount; ++nodeMatrixIndex)
            {
                NodeBorderValue nodeBorderValue = BorderNodesMatrix[(int)ConnectivityMatrix[finiteElementIndex, nodeMatrixIndex]];

                SetMatrixUV(globalMatrixForFiniteElement[nodeMatrixIndex, nodeMatrixIndex], nodeBorderValue);
            }
            return globalMatrixForFiniteElement;
        }
        public Matrix[][,] BuildGlobalMatricesForFiniteElements()
        {
            int finiteElementAmount = systemConfig.FiniteElementAmount;

            Matrix[][,] globalMatricesForFiniteElement = new Matrix[finiteElementAmount][,];
            for (int finiteElementIndex = 0; finiteElementIndex < finiteElementAmount; ++finiteElementIndex)
            {
                globalMatricesForFiniteElement[finiteElementIndex] = BuildUVGlobalMatrixForFiniteElement(finiteElementIndex);
            }
            return globalMatricesForFiniteElement;
        }

        public Matrix[,] BuildGlobalMatrix()
        {
            int finiteElementAmount = systemConfig.FiniteElementAmount;
            int nodesAmount = systemConfig.NodesAmount;

            Matrix connectivityMatrix = ConnectivityMatrix;

            // SUPER GLOBAL
            Matrix[,] globalMatrix = new Matrix[nodesAmount, nodesAmount];
            for (int i = 0; i < nodesAmount; ++i)
            {
                for (int j = 0; j < nodesAmount; ++j)
                {
                    globalMatrix[i, j] = new Matrix(6, 6);
                }
            }

            Matrix[][,] globalMatricecForFiniteElement = BuildGlobalMatricesForFiniteElements();

            // building
            for (int finiteElementIndex = 0; finiteElementIndex < systemConfig.FiniteElementAmount; ++finiteElementIndex)
            {
                for (int iNodeIndex = 0; iNodeIndex < systemConfig.NodesAmountPerFiniteElement; ++iNodeIndex)
                {
                    for (int jNodeIndex= 0; jNodeIndex < systemConfig.NodesAmountPerFiniteElement; ++jNodeIndex)
                    {
                        int shiftI = (int)connectivityMatrix[finiteElementIndex, iNodeIndex];
                        int shiftJ = (int)connectivityMatrix[finiteElementIndex, jNodeIndex];

                        globalMatrix[shiftI, shiftJ] += globalMatricecForFiniteElement[finiteElementIndex][iNodeIndex, jNodeIndex];
                    }
                }
            }

            return globalMatrix;
        }











        // Global Vector
        public Matrix BuildCapacityVector()
        {
            return new int[] { 0, 0, -1, 0, 0, 0 };
        }
        

        public Matrix[] BuildGlobalVectorForGaussNodeIndex(int finiteElementIndex, int gaussNodeIndex)
        {
            int nodeAmount = systemConfig.NodesAmountPerFiniteElement;

            // Vector 1*8 of 6*6 phi matrices
            Matrix[] vectorForGaussNode = new Matrix[nodeAmount];
            for (int nodeIndex = 0; nodeIndex < nodeAmount; ++nodeIndex)
            {
                vectorForGaussNode[nodeIndex] = new Matrix(6, 6);

                // diagonal moving on phi
                double phi = f.phiBasis(nodeIndex, GaussNodes[gaussNodeIndex, 0], GaussNodes[gaussNodeIndex, 1]);
                for (int d = 0; d < 6; ++d)
                {
                    vectorForGaussNode[nodeIndex][d, d] = phi;
                }
            }

            return vectorForGaussNode;
        }
        public Matrix[] BuildGlobalVectorForFiniteElement(int finiteElementIndex)
        {
            double R = shellConfig.R;
            int nodeAmount = systemConfig.NodesAmountPerFiniteElement;

            Matrix[] vectorR = new Matrix[nodeAmount];
            for (int  i = 0; i < vectorR.Length; ++i)
            {
                vectorR[i] = new Matrix(6, 1);
            }

            // sum up for each gauss' node
            for (int gaussNodeIndex = 0; gaussNodeIndex < GaussNodes.GetLength(0); ++gaussNodeIndex) // 9
            {
                double detJ = GetJacobian(finiteElementIndex, GaussNodes[gaussNodeIndex, 0], GaussNodes[gaussNodeIndex, 1]);
                double M = GaussWeights[gaussNodeIndex / 3] * GaussWeights[gaussNodeIndex % 3] * detJ * R;

                Matrix[] N = BuildGlobalVectorForGaussNodeIndex(finiteElementIndex, gaussNodeIndex);

                for (int nodeIndex = 0; nodeIndex < nodeAmount; ++nodeIndex)
                {
                    vectorR[nodeIndex] += N[nodeIndex] * CapacityVector * M;
                }
                
            }
            return vectorR;
        }

        public void SetVectorUV(Matrix nodeVector, NodeBorderValue nodeBorderValue)
        {
            bool[] indicesOfNodeBorderValue = GetNumbersOfUnknownVectorComponent(nodeBorderValue);
            
            for (int k = 0; k < nodeVector.Rows; ++k)// 6*1
            {
                if (indicesOfNodeBorderValue[k])
                {
                    nodeVector[k, 0] = VECTOR_NODE_BORDER_VALUE;
                }
            }
        }
        public Matrix[] BuildUVGlobalVectorForFiniteElement(int finiteElementIndex)
        {
            int nodeAmount = systemConfig.NodesAmountPerFiniteElement;
            Matrix[] globalVectorForfiniteElement = BuildGlobalVectorForFiniteElement(finiteElementIndex);
            
            for (int nodeIndex = 0; nodeIndex < nodeAmount; ++nodeIndex)
            {
                NodeBorderValue nodeBorderValue = BorderNodesMatrix[(int)ConnectivityMatrix[finiteElementIndex, nodeIndex]];

                SetVectorUV(globalVectorForfiniteElement[nodeIndex], nodeBorderValue);
            }
            return globalVectorForfiniteElement;
        }
        public Matrix[] BuildGlobalVector()
        {
            int finiteElementAmount = systemConfig.FiniteElementAmount;
            int nodesAmount = systemConfig.NodesAmount;

            Matrix connectivityMatrix = ConnectivityMatrix;

            // SUPER GLOBAL
            Matrix[] globalVector = new Matrix[nodesAmount];
            for (int i = 0; i < nodesAmount; ++i)
            {
                globalVector[i] = new Matrix(6, 1);
            }

            // building
            for (int finiteElementIndex = 0; finiteElementIndex < systemConfig.FiniteElementAmount; ++finiteElementIndex)
            {
                Matrix[] vectorR = BuildUVGlobalVectorForFiniteElement(finiteElementIndex);
                for (int nodeIndex = 0; nodeIndex < systemConfig.NodesAmountPerFiniteElement; ++nodeIndex)
                {
                    int shift = (int)connectivityMatrix[finiteElementIndex, nodeIndex];

                    globalVector[shift] += vectorR[nodeIndex];                    
                }
            }

            return globalVector;
        }
    }
}
