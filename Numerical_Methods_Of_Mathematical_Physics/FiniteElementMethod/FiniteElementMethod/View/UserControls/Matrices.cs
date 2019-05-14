using System.Windows.Forms;

using FiniteElementMethod.Models;
using FiniteElementMethod.Models.Math;
using FiniteElementMethod.Models.Structs;

namespace FiniteElementMethod.View.UserControls
{
    internal partial class Matrices : UserControl
    {
        // FIELDS
        Reference<CoordinateSystemConfig> systemConfig;
        MatrixBuilder matrixBuilder;
        
        Matrix coordinateMatrix;
        Models.Enums.NodeBorderValue[] boundaryMatrix;
        Matrix connectivityMatrix;

        // CONSTRUCTORS
        public Matrices(Reference<CoordinateSystemConfig> systemConfig)
        {
            InitializeComponent();
            
            // initialize fields
            this.systemConfig = systemConfig;
            if (systemConfig.Value == null)
            {
                this.matrixBuilder = null;

                this.coordinateMatrix = null;
                this.boundaryMatrix = null;
                this.connectivityMatrix = null;
            }
            else
            {
                this.matrixBuilder = new MatrixBuilder(systemConfig.Value, null);

                this.coordinateMatrix = matrixBuilder.CoordinateMatrix;
                this.boundaryMatrix = matrixBuilder.BorderNodesMatrix;
                this.connectivityMatrix = matrixBuilder.ConnectivityMatrix;
            }            
        }
        private void Matrices_Load(object sender, System.EventArgs e)
        {
            // select tab explicitly
            matrixTabs.SelectedIndex = -1;
            matrixTabs.SelectedIndex = 0;
        }

        // METHODS
        // tabs
        private void matrixTabs_TabIndexChanged(object sender, System.EventArgs e)
        {
            switch (matrixTabs.SelectedIndex)
            {
                case 0: connectivityDgv.RowCount = connectivityMatrix != null ? connectivityMatrix.Rows : 0; break;
                case 1: coordinateDgv.RowCount = coordinateMatrix != null ? coordinateMatrix.Rows : 0; break;
                case 2: boundaryValueDgv.RowCount = boundaryMatrix != null ? boundaryMatrix.Length : 0; break;
            }
        }

        // filling DataGrid in virtual mode
        private void coordinateDgv_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (this.coordinateMatrix == null) return;
            
            // fill in Data Grid
            if (e.ColumnIndex == 0) e.Value = e.RowIndex + 1; // node index
            else e.Value = coordinateMatrix[e.RowIndex, e.ColumnIndex - 1]; // x, y
        }            

        private void boundaryValueDgv_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (this.boundaryMatrix == null) return;

            // fill in Data Grid
            if (e.ColumnIndex == 0) e.Value = e.RowIndex + 1; // node index
            else e.Value = boundaryMatrix[e.RowIndex].ToString(); // boundary value
        }

        private void connectivityDgv_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (this.connectivityMatrix == null) return;

            // fill in Data Grid
            if (e.ColumnIndex == 0) e.Value = e.RowIndex + 1; // finite element index
            else e.Value = (connectivityMatrix[e.RowIndex, e.ColumnIndex - 1] + 1); // node local index
        }

    }
}
