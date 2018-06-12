using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Person;
using System.Threading;
using System.IO;

namespace Second_Exam
{
    public partial class Form1 : Form
    {
        private List<IPersonality> band;

        public Form1()
        {
            InitializeComponent();
            Application.Idle += ToolTipForUser;


            cancelFind_btn.Enabled = false;
        }

        private void ToolTipForUser(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = $"Band has {band.Count} people";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            band = new List<IPersonality>(15);
        }
        private void EnabledButton(bool en)
        {
            readFromFile_btn.Enabled = en;
            find_btn.Enabled = en;
            cancelFind_btn.Enabled = !en;
            Change_btn.Enabled = en;
            create_btn.Enabled = en;
            remove_btn.Enabled = en;
            clear_btn.Enabled = en;
        }
        private void readFromFile_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] FileLines = File.ReadAllLines(openFileDialog1.FileName);

                for(int i = 0; i < FileLines.Length; ++i)
                {
                    string[] data = FileLines[i].Split('*');

                    if (data[0] == "P") band.Add(new Person.Person(data[1].Split()));
                    else if(data[0] == "S") band.Add(new Person.Student(data[1].Split()));

                    band[i].propertyChanged += ShowProperty;
                    listBox1.Items.Add(band[i].ToString());
                    
                }
            }
        }

        private void ShowProperty(object sender, NorifyPropertyChanged e)
        {
            listBox2.Items.Add(e.Message);
            int i = listBox1.SelectedIndex;
            listBox1.Items[i] = band[i].ToString();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            readFromFile_btn.PerformClick();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            readFromFile_btn.PerformClick();
        }

        private void find_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            EnabledButton(false);
        }
        int maxIndex = int.MinValue;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if(band.Count > 0)
            {
                int BarValue = 100 / band.Count;
                int maxValue = int.MinValue;
                for (int i = 0; i < band.Count; ++i)
                {
                    if (backgroundWorker1.CancellationPending)
                    {
                        e.Cancel = true;
                        backgroundWorker1.ReportProgress(0);
                        return;
                    }
                    if (band[i].Age > maxValue)
                    {
                        maxValue = band[i].Age;
                        maxIndex = i;
                    }

                    Thread.Sleep(1250);
                    backgroundWorker1.ReportProgress(i * BarValue);
                }
            }
            
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(!e.Cancelled)
            {
                textBox1.Text = band[maxIndex].ToString();
                textBox2.Text = band[maxIndex].GetType().Name;
            }
            toolStripProgressBar1.Value = 0;
            EnabledButton(true);
        }

        private void Change_btn_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex != -1)
            {
                int index = listBox1.SelectedIndex;

                Element el = null;
                bool isStrudent = band[index] is Student;
                if (isStrudent)
                {
                    Student s = band[index] as Student;
                    el = new Element(s.Name, s.Age.ToString(), s.TotalMark.ToString());
                }
                else
                {
                    el = new Element(band[index].Name, band[index].Age.ToString());
                }

                if(el.ShowDialog() == DialogResult.OK)
                {

                    band[index].Name = el.PersonName;
                    band[index].Age = int.Parse(el.Age);
                    if (isStrudent)
                    {
                        (band[index] as Student).TotalMark = int.Parse(el.TotalMark);
                    }
                }
            }
        }

        private void create_btn_Click(object sender, EventArgs e)
        {
            Element el = new Element();
            if (el.ShowDialog() == DialogResult.OK)
            {
                IPersonality ip;
                if (el.isStudent)
                {
                    ip = new Person.Student()
                    {
                        Name = el.PersonName,
                        Age = int.Parse(el.Age),
                        TotalMark = int.Parse(el.TotalMark)
                    };
                }
                else
                {
                    ip = new Person.Person()
                    {
                        Name = el.PersonName,
                        Age = int.Parse(el.Age)
                    };
                }
                ip.propertyChanged += ShowProperty;
                band.Add(ip);
                listBox1.Items.Add(ip.ToString());
            }
        }

        private void remove_btn_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex != -1)
            {
                int index = listBox1.SelectedIndex;
                listBox1.Items.RemoveAt(index);
                band.RemoveAt(index);
            }
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            textBox1.Clear();
            textBox2.Clear();
            band.Clear();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_btn.PerformClick();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            clear_btn.PerformClick();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] data = new string[band.Count];
                for(int i = 0; i < band.Count; ++i)
                {
                    data[i] = band[i].ToFile();
                }
                File.WriteAllLines(saveFileDialog1.FileName, data);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox1().ShowDialog();
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            aboutToolStripMenuItem.PerformClick();
        }

        private void cancelFind_btn_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
            EnabledButton(true);
        }
    }
}
