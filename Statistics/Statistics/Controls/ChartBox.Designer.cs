namespace Statistics.Controls
{
    partial class ChartBox
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.scaleTbl = new System.Windows.Forms.TableLayoutPanel();
            this.polygonChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.diagramaChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.functionChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.diagramLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.sectorChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            this.scaleTbl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.polygonChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagramaChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.functionChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectorChart)).BeginInit();
            this.SuspendLayout();
            // 
            // scaleTbl
            // 
            this.scaleTbl.ColumnCount = 2;
            this.scaleTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.scaleTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.scaleTbl.Controls.Add(this.polygonChart, 0, 1);
            this.scaleTbl.Controls.Add(this.diagramaChart, 1, 1);
            this.scaleTbl.Controls.Add(this.label1, 0, 0);
            this.scaleTbl.Controls.Add(this.diagramLbl, 1, 0);
            this.scaleTbl.Controls.Add(this.label3, 0, 2);
            this.scaleTbl.Controls.Add(this.functionChart, 0, 3);
            this.scaleTbl.Controls.Add(this.sectorChart, 1, 3);
            this.scaleTbl.Controls.Add(this.label2, 1, 2);
            this.scaleTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scaleTbl.Location = new System.Drawing.Point(0, 0);
            this.scaleTbl.Name = "scaleTbl";
            this.scaleTbl.RowCount = 4;
            this.scaleTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.scaleTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.scaleTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.scaleTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.scaleTbl.Size = new System.Drawing.Size(431, 379);
            this.scaleTbl.TabIndex = 0;
            // 
            // polygonChart
            // 
            chartArea1.Name = "ChartArea1";
            this.polygonChart.ChartAreas.Add(chartArea1);
            this.polygonChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.polygonChart.Location = new System.Drawing.Point(3, 38);
            this.polygonChart.Name = "polygonChart";
            this.polygonChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series1.Name = "Series1";
            this.polygonChart.Series.Add(series1);
            this.polygonChart.Size = new System.Drawing.Size(209, 148);
            this.polygonChart.TabIndex = 0;
            // 
            // diagramaChart
            // 
            chartArea2.Name = "ChartArea1";
            this.diagramaChart.ChartAreas.Add(chartArea2);
            this.diagramaChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.diagramaChart.Location = new System.Drawing.Point(218, 38);
            this.diagramaChart.Name = "diagramaChart";
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.ForestGreen;
            series2.Name = "Series1";
            this.diagramaChart.Series.Add(series2);
            this.diagramaChart.Size = new System.Drawing.Size(210, 148);
            this.diagramaChart.TabIndex = 1;
            // 
            // functionChart
            // 
            chartArea3.Name = "ChartArea1";
            this.functionChart.ChartAreas.Add(chartArea3);
            this.functionChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.functionChart.Location = new System.Drawing.Point(3, 227);
            this.functionChart.Name = "functionChart";
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series3.Color = System.Drawing.SystemColors.HotTrack;
            series3.Name = "Series1";
            series3.YValuesPerPoint = 4;
            this.functionChart.Series.Add(series3);
            this.functionChart.Size = new System.Drawing.Size(209, 149);
            this.functionChart.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 35);
            this.label1.TabIndex = 3;
            this.label1.Text = "Полігон";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // diagramLbl
            // 
            this.diagramLbl.AutoSize = true;
            this.diagramLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.diagramLbl.Location = new System.Drawing.Point(218, 0);
            this.diagramLbl.Name = "diagramLbl";
            this.diagramLbl.Size = new System.Drawing.Size(210, 35);
            this.diagramLbl.TabIndex = 4;
            this.diagramLbl.Text = "Діа-/Гісто- грама";
            this.diagramLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(209, 35);
            this.label3.TabIndex = 5;
            this.label3.Text = "Функція розподілу";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sectorChart
            // 
            chartArea4.Name = "ChartArea1";
            this.sectorChart.ChartAreas.Add(chartArea4);
            this.sectorChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.sectorChart.Legends.Add(legend1);
            this.sectorChart.Location = new System.Drawing.Point(218, 227);
            this.sectorChart.Name = "sectorChart";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series4.IsValueShownAsLabel = true;
            series4.LabelFormat = "P2";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.sectorChart.Series.Add(series4);
            this.sectorChart.Size = new System.Drawing.Size(210, 149);
            this.sectorChart.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(218, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 35);
            this.label2.TabIndex = 7;
            this.label2.Text = "Cекторна діаграма";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChartBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.scaleTbl);
            this.Name = "ChartBox";
            this.Size = new System.Drawing.Size(431, 379);
            this.scaleTbl.ResumeLayout(false);
            this.scaleTbl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.polygonChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagramaChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.functionChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectorChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel scaleTbl;
        private System.Windows.Forms.DataVisualization.Charting.Chart polygonChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart diagramaChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart functionChart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label diagramLbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart sectorChart;
        private System.Windows.Forms.Label label2;
    }
}
