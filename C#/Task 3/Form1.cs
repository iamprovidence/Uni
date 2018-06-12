using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;

namespace Task3
{
    public partial class MainForm : Form
    {
        private bool isSaved;
        private string OpenedFileName;
        public Option option;
        private enum SaveMode { csv, xml };
        private Lazy<DataValue> es;

        private void MainForm_Load(object sender, EventArgs e)
        {
            option = new Option();
            option.styleChanged += ChangeStyle;
            es = new Lazy<DataValue>();
            OpenedFileName = @"File.csv";
            isSaved = true;

            
            progressBar.Visible = false;
        }
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (backgroundWorker.IsBusy)
            {
                MessageBox.Show("Calculations in progress", "Calculations in progress", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                e.Cancel = true; // не закривати форму
                return;
            }

            if (!isSaved && option.AskBeforeExit)
            {
                if (MessageBox.Show("You have forgot to save. Still exit?", "Warning!",
         MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true; // не закривати форму
                }
            }
        }

        public void ChangeStyle(object o, OptionArg arg)
        {
            this.Opacity = arg.Opacity;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(backgroundWorker.IsBusy)
            {
                MessageBox.Show("Calculations in progress", "Calculations in progress", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // додаткові, необов'язкові, налаштування
                this.Text = openFileDialog.SafeFileName;
                OpenedFileName = openFileDialog.FileName;
                openFileDialog.Title = OpenedFileName;

                // очистити таблицю
                this.dataGridView.DataSource = null;
                this.dataGridView.Rows.Clear();

                // читання файла
                string[] CVS_File_rows = File.ReadAllLines(OpenedFileName);
        
                // створення масиву і занесення даних у таблицю
                Product[] CVS_rows = new Product[CVS_File_rows.Length];
                for (int i = 0; i < CVS_File_rows.Length; ++i)
                {
                    try
                    {
                        CVS_rows[i] = new Product(CVS_File_rows[i].Split(';'));
                    }
                    catch (ArgumentException ex) when(ex.Message.Contains("many"))
                    {
                        DialogResult exOption = MessageBox.Show(ex.Message + $"on line {i + 1}", "Exception", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                        if (exOption == DialogResult.Retry)
                        {
                            string[] cutArr = CVS_File_rows[i].Split(';');
                            CVS_rows[i] = new Product(cutArr[0], cutArr[1], cutArr[2]);
                        }
                        else if(exOption == DialogResult.Ignore)
                        {
                            continue;
                        }
                        else if (exOption == DialogResult.Abort)
                        {
                            break;
                        }
                    }
                    catch (ArgumentException ex) when (ex.Message.Contains("few"))
                    {
                        DialogResult exOption = MessageBox.Show(ex.Message + $"on line {i + 1}", "Exception", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                        if (exOption == DialogResult.Retry)
                        {
                            string[] cutArr = CVS_File_rows[i].Split(';');
                            CVS_rows[i] = new Product(
                                0 < cutArr.Length ? cutArr[0] : String.Empty,
                                1 < cutArr.Length ? cutArr?[1] : String.Empty,
                                2 < cutArr.Length ? cutArr?[2] : "0"); 
                        }
                        else if (exOption == DialogResult.Ignore)
                        {
                            continue;
                        }
                        else if (exOption == DialogResult.Abort)
                        {
                            break;
                        }
                    }
                    catch (FormatException ex)
                    {
                        DialogResult exOption = MessageBox.Show(ex.Message + $"on line {i + 1}", "Exception", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                        if (exOption == DialogResult.Retry)
                        {
                            string[] cutArr = CVS_File_rows[i].Split(';');
                            CVS_rows[i] = new Product(cutArr[0] , cutArr[1] ,  "0");
                        }
                        else if (exOption == DialogResult.Ignore)
                        {
                            continue;
                        }
                        else if (exOption == DialogResult.Abort)
                        {
                            break;
                        }
                    }
                    
                }

                CVS_rows = CVS_rows.Where(x => x != null).ToArray();
                // заповнення таблиці новими даними
                for (int i = 0; i < CVS_rows.Length; ++i)
                {
                    dataGridView.Rows.Add(CVS_rows[i]?.name, CVS_rows[i]?.producer, CVS_rows[i]?.price);
                }
                
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy)
            {
                MessageBox.Show("Calculations in progress", "Calculations in progress", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            SaveToFile(OpenedFileName, SaveMode.csv);

            IsSaved(true);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy)
            {
                MessageBox.Show("Calculations in progress", "Calculations in progress", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string saveHere = saveFileDialog.FileName;
                
                switch(Path.GetExtension(saveHere).ToLower())
                {
                    case ".csv":
                        SaveToFile(saveHere, SaveMode.csv);
                        break;
                    case ".xml":
                        SaveToFile(saveHere, SaveMode.xml);
                        break;
                }
                
            }
            
        }

        private void SaveToFile(string path, SaveMode sm)
        {
            // масив даних, які будуть записані у файл
            Product[] CVS_rows = FormArrayFromData();
            // сформувати дані у потрібний формат
            StringBuilder allData = new StringBuilder();

            if(sm == SaveMode.xml) allData.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n<DataTable>");

            for (int i = 0; i < CVS_rows.Length; ++i)
            {
                if (sm == SaveMode.xml) allData.AppendLine(CVS_rows[i].WriteXML());
                else                    allData.AppendLine(CVS_rows[i].WriteCVS());
            }

            if(sm == SaveMode.xml) allData.Append("</DataTable>");

            // записати дані у файл
            File.WriteAllText(path: path, contents: allData.ToString());
        }

        private void Edit_Selected_butt_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy)
            {
                MessageBox.Show("Calculations in progress", "Calculations in progress", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (dataGridView.CurrentRow == null) return;
            es.Value.Text = "Edit Selected";
            
            
            if (dataGridView.Rows.Count == dataGridView.CurrentRow.Index + 1)
            {
                MessageBox.Show("You can edit default row", "Default row", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            

            es.Value.SetDefaultValue(
            dataGridView.CurrentRow.Cells[0].Value?.ToString(),
            dataGridView.CurrentRow.Cells[1].Value?.ToString(),
            dataGridView.CurrentRow.Cells[2].Value?.ToString());
            

            if (es.Value.ShowDialog() == DialogResult.OK)
            {
                Product newProduct = es.Value.getProduct();
                dataGridView.CurrentRow.Cells[0].Value = newProduct.name;
                dataGridView.CurrentRow.Cells[1].Value = newProduct.producer;
                dataGridView.CurrentRow.Cells[2].Value = Regex.Replace(newProduct.price.ToString(), @"\s+", "");

                IsSaved(false);
            }
        }

        private void Add_New_butt_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy)
            {
                MessageBox.Show("Calculations in progress", "Calculations in progress", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            es.Value.Text = "Add New";
            es.Value.SetDefaultValue();
            
            if(es.Value.ShowDialog() == DialogResult.OK)
            {
                Product newProduct = es.Value.getProduct();
                dataGridView.Rows.Add(newProduct.name, newProduct.producer, newProduct.price);

                IsSaved(false);
            }
        }

        private void Delete_butt_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy)
            {
                MessageBox.Show("Calculations in progress", "Calculations in progress", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (dataGridView.CurrentRow == null) return;

            DialogResult remove = DialogResult.Yes;
            if(option.AskBeforeDel)
            {
                remove = MessageBox.Show("Do you want to delete this row", "Deleting row", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            if(remove == DialogResult.Yes)
            {
                int RowIndex = dataGridView.CurrentRow.Index;
                if (dataGridView.Rows.Count != RowIndex + 1)
                {
                    dataGridView.Rows.RemoveAt(RowIndex);

                    IsSaved(false);
                }
            }
        }

        private void IsSaved(bool isSaved)
        {
            bool hasStar = Text.Contains('*');
            if (isSaved && hasStar) this.Text =  this.Text.Remove(this.Text.Length - 1,1);
            else if (!isSaved && !hasStar) this.Text += '*';

            this.isSaved = isSaved;
        }

        private void Calc_Stat_butt_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy)
            {
                MessageBox.Show("Calculations in progress", "Calculations in progress", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            progressBar.Visible = true;
            backgroundWorker.RunWorkerAsync();
            CancelStat_but.Enabled = true;
        }

        private void Cancel_stat_butt_Click(object sender, EventArgs e)
        {
            if(backgroundWorker.IsBusy)
            {
                backgroundWorker.CancelAsync();
            }
        }

        private Product[] FormArrayFromData()
        {
            // масив даних
            Product[] Arr = new Product[dataGridView.RowCount - 1];
            // зчитати із таблиці
            for (int i = 0; i < dataGridView.RowCount - 1; ++i)
            {
                string[] formAString = new string[dataGridView.ColumnCount];

                for (int j = 0; j < dataGridView.ColumnCount; ++j)
                {
                    formAString[j] = dataGridView.Rows[i].Cells[j].Value.ToString();
                }
                // записати дані у масив
                Arr[i] = new Product(formAString);
            }
            return Arr;
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 100; ++i)
            {
                Thread.Sleep(50);
                backgroundWorker.ReportProgress(i);

                // Чи прийшло повідомлення, щоб завершити
                if (backgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    backgroundWorker.ReportProgress(0);
                    return;
                }
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Visible = false;
            CancelStat_but.Enabled = false;

            if (e.Cancelled) return;

            ulong sum = 0;
            string MaxProduct;
            string MaxProducer;
            int amount;
            Product[] ArrProduct = FormArrayFromData();

            if(ArrProduct.Length != 0)
            {

                Dictionary<string, int> CountNames = new Dictionary<string, int>();
                Dictionary<string, int> CountProducer = new Dictionary<string, int>();

                foreach (Product p in ArrProduct)
                {
                    if (!CountNames.ContainsKey(p.name)) CountNames.Add(p.name, 0);
                    else ++CountNames[p.name];

                    if (!CountProducer.ContainsKey(p.producer)) CountProducer.Add(p.producer, 0);
                    else ++CountProducer[p.producer];

                    sum += (ulong)p.price;
                }
                amount = CountNames.Values.Max();
                MaxProduct = CountNames.FirstOrDefault(x => x.Value == amount).Key;
                amount = CountProducer.Values.Max();
                MaxProducer = CountProducer.FirstOrDefault(x => x.Value == amount).Key;

                MessageBox.Show($"The most popular product is \'{MaxProduct}\'\nThe most popular producer is \'{MaxProducer}\'\nTotal price is \'{sum}\'",
                    "Statistic", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Table is clear", "Clear table", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy)
            {
                MessageBox.Show("Calculations in progress", "Calculations in progress", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            About about = new About();
            about.Opacity = this.Opacity;
            about.Show();
        }

        private void optionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy)
            {
                MessageBox.Show("Calculations in progress", "Calculations in progress", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            option.Show();
        }
    }
    
    [ComVisible(true)]
    public class Product
    {
        public string name { get; }
        public string producer { get; }
        public int price { get; }
        // Exceptions:
        //   T:System.FormatException:
        //     s is not in the correct format.
        //
        //   T:System.ArgumentException:
        //     s arr is too big, or too small
        public Product(params string[] arr)
        {
            if (arr.Length == 3)
            {
                name = arr[0];
                producer = arr[1];
                try
                {
                    price = int.Parse(arr[2]);
                }
                catch (FormatException ex)
                {
                    throw ex;
                }
            }
            else if(arr.Length > 3) throw new ArgumentException("Too many argument");
            else throw new ArgumentException("Too few arguments");
        }
        public string WriteCVS()
        {
            return $"{name};{producer};{price}";
        }
        public string WriteXML()
        {
            return $"<product>\n\t<name>{name}</name>\n\t<producer>{producer}</producer>\n\t<price>{price}</price>\n</product>";
        }
    }
}
