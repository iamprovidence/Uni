using System;
using System.Windows.Forms;

namespace Bonus.Controls
{
    public partial class PolygonPanel : UserControl
    {
        // PROPERTIES
        public Classes.Polygon Polygon { get; private set; }
        public new string Text
        {
            get
            {
                return textLbl.Text;
            }
            set
            {
                textLbl.Text = value;
            }
        }
        // CONSTRUCTORS
        public PolygonPanel()
        {
            InitializeComponent();
            Polygon = null;
        }
        // EVENT
        public event EventHandler Commited;
        // METHODS
        public void Commit()
        {
            commitBtn.PerformClick();
            OnCommited(EventArgs.Empty);
        }
        public void Add(float x, float y)
        {
            pointDgv.Rows.Add(x, y);
        }       
        public void SetDefaultColorPicker(System.Drawing.Color color)
        {
            colorPnl.BackColor = color;
        }
        public void SetDefaultStartPosition(float x, float y)
        {
            sxTb.Text = x.ToString();
            syTb.Text = y.ToString();
        }
        public void SetDefaultEndPosition(float x, float y)
        {
            exTb.Text = x.ToString();
            eyTb.Text = y.ToString();
        }
        public void SetDefaultStepsAmount(int amount)
        {
            stepsTb.Text = amount.ToString();
        }
        // EVENT
        private void insertBtn_Click(object sender, EventArgs e)
        {
            try
            {
                double x = double.Parse(xTb.Text);
                double y = double.Parse(yTb.Text);

                int index = pointDgv.CurrentCell.RowIndex;

                if (index != -1) pointDgv.Rows.Insert(index, x, y);
                else pointDgv.Rows.Add(x, y);
            }
            catch (Exception ex)
            {
                ExceptionMessage(ex.Message);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int index = pointDgv.CurrentCell.RowIndex;
                if (index != -1) pointDgv.Rows.RemoveAt(index);
            }
            catch (Exception ex)
            {
                ExceptionMessage(ex.Message);
            }
        }

        private void commitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (pointDgv.RowCount < 3)
                {
                    ExceptionMessage("Should be more points");
                    return;
                }

                // start point
                System.Drawing.PointF startPoint = new System.Drawing.PointF
                {
                    X = float.Parse(sxTb.Text),
                    Y = float.Parse(syTb.Text),
                };
                // end point
                System.Drawing.PointF endPoint = new System.Drawing.PointF
                {
                    X = float.Parse(exTb.Text),
                    Y = float.Parse(eyTb.Text),
                };
                // steps amount
                int stepsAmount = int.Parse(stepsTb.Text);
                // color
                System.Drawing.Color color = colorPnl.BackColor;
                // points
                int index = 0;
                System.Drawing.PointF[] points = new System.Drawing.PointF[pointDgv.RowCount];
                foreach(DataGridViewRow row in pointDgv.Rows)
                {
                    points[index++] = new System.Drawing.PointF
                    {
                        X = float.Parse(row.Cells[0].Value.ToString()),
                        Y = float.Parse(row.Cells[1].Value.ToString())
                    };
                }
                Polygon = new Classes.Polygon
                    (
                        points: points,
                        color: color,
                        endPosition: endPoint,
                        startPosition: startPoint,
                        stepsAmount: stepsAmount
                    );
                OnCommited(EventArgs.Empty);
            }
            catch (Exception ex)
            {
                ExceptionMessage(ex.Message);
            }
        }
        private void colorPnl_Click(object sender, EventArgs e)
        {
            using (ColorDialog cd = new ColorDialog())
            {
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    colorPnl.BackColor = cd.Color;
                }
            }
        }
        private void ExceptionMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }
        protected void OnCommited(EventArgs e)
        {
            Commited?.Invoke(this, e);
        }
    }
}
