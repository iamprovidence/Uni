using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ClassLibrary1;

namespace Exam_Test
{
    public partial class Form1 : Form
    {
        enum LibraryValue { Book, ScienceBook}
        public Form1()
        {
            InitializeComponent();
        }
        List<Book> libraries;
        private void Form1_Load(object sender, EventArgs e)
        {
            libraries = new List<Book>(10);
            Application.Idle += AppIdle;
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] str = File.ReadAllLines(openFileDialog1.FileName);
                for(int i = 0; i < str.Length;++i)
                {
                    string[] sortedValue = str[i].Split('*');
                    if (sortedValue[0] == "B")
                    {
                        try
                        {
                            libraries.Add(SafeRead(sortedValue[1].Split(), LibraryValue.Book));
                        }
                        catch (Exception ex) when(ex.Message.Contains("break")) 
                        {
                            return;
                        }
                    }
                    else if (sortedValue[0] == "SB")
                    {
                        try
                        {
                            libraries.Add(SafeRead(sortedValue[1].Split(), LibraryValue.ScienceBook));
                        }
                        catch (Exception ex) when (ex.Message.Contains("break"))
                        {
                            return;
                        }
                    }
                    libraries[i].propertyChanged += ShowPropertyChanged;
                }
                libraries.RemoveAll(x => x == null);  

                foreach(Book b in libraries)
                {
                    listBox1.Items.Add(b.ToString());
                }

            }
        }

        private Book SafeRead(string[] data, LibraryValue returnValue)
        {
            try
            {
                if (returnValue == LibraryValue.Book) return new Book(data);
                else return new ScienceBook(data);
            }
            #region FewArgument
            catch (ArgumentException ae) when (ae.Message.Contains("few"))
            {
                DialogResult dr = MessageBox.Show("File contain bad line with too FEW argument", "Warning", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);


                if (dr == DialogResult.Abort)
                {
                    MessageBox.Show("Stop File Reading", "Abort", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    throw new Exception("break");
                }
                else if (dr == DialogResult.Retry)
                {
                    MessageBox.Show("Data will be wrong", "Retry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (returnValue == LibraryValue.Book)
                    {
                        return new Book()
                        {
                            Name = data.Length > 1 ? data[0] : "Name",
                            AmountOfPages = data.Length > 2 ? int.Parse(data[2]) : 100
                        };
                    }
                    else 
                    {
                        return new ScienceBook()
                        {
                            Name = data.Length > 1 ? data[0] : "Name",
                            AmountOfPages = data.Length > 2 ? int.Parse(data[2]) : 100,
                            Author = data.Length > 3 ? data[2] : "Author",
                        };
                    }

                }
                else 
                {
                    MessageBox.Show("Ignore this line", "Ignore", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return null;
                }
            }
            #endregion
            #region Many Argument
            catch (ArgumentException ae) when (ae.Message.Contains("many"))
            {
                DialogResult dr = MessageBox.Show("File contain bad line with too MANY argument", "Warning", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);

                if (dr == DialogResult.Abort)
                {
                    MessageBox.Show("Stop File Reading", "Abort", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    throw new Exception("break");
                }
                else if (dr == DialogResult.Retry)
                {
                    MessageBox.Show("Data will be lost", "Retry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (returnValue == LibraryValue.Book)
                    {
                        return new Book()
                        {
                            Name = data[0],
                            AmountOfPages = int.Parse(data[2])
                        };
                    }
                    else
                    {
                        return new ScienceBook()
                        {
                            Name = data[0],
                            AmountOfPages = int.Parse(data[2]),
                            Author = data[2]
                        };
                    }

                }
                else 
                {
                    MessageBox.Show("Ignore this line", "Ignore", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return null;
                }
            }
            #endregion
            #region Format Exeption
            catch (FormatException fe)
            {
                DialogResult dr = MessageBox.Show("File contain bad line with too BAD NUMBER", "Warning", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);

                if (dr == DialogResult.Abort)
                {
                    MessageBox.Show("Stop File Reading", "Abort", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    throw new Exception("break");
                }
                else if (dr == DialogResult.Retry)
                {
                    MessageBox.Show("Data will be wrong", "Retry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (returnValue == LibraryValue.Book)
                    {
                        return new Book()
                        {
                            Name = data.Length > 1 ? data[0] : "Name",
                            AmountOfPages = 100
                        };
                    }
                    else 
                    {
                        return new ScienceBook()
                        {
                            Name = data.Length > 1 ? data[0] : "Name",
                            AmountOfPages = 100,
                            Author = data.Length > 3 ? data[2] : "Author",
                        };
                    }

                }
                else
                {
                    MessageBox.Show("Ignore this line", "Ignore", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return null;

                }
            } 
            #endregion
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(listBox1.Items.Count > 0)
            {
                backgroundWorker1.RunWorkerAsync();
                lockBTN(false);
            }
        }
        private void AppIdle(object o, EventArgs ea)
        {
            toolStripStatusLabel1.Text = "Collection has "  + libraries.Count.ToString() + " element";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Book b = libraries[listBox1.SelectedIndex];
            ChangeEL c;
            if (b is ScienceBook)
            {
                ScienceBook sb = b as ScienceBook;
                c = new ChangeEL(sb.Name, sb.AmountOfPages.ToString(), sb.Author);
            }
            else
            {
                c = new ChangeEL(b.Name, b.AmountOfPages.ToString());
            }
            if(c.ShowDialog()  == DialogResult.OK)
            {
                b.Name = c.BookName;
                b.AmountOfPages = int.Parse(c.Page);
            }
        }

        private void ShowPropertyChanged(object sender, PropertyChanged pc)
        {
            listBox2.Items.Add(pc.Message);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChangeEL c = new ChangeEL();
            if(c.ShowDialog() == DialogResult.OK)
            {
                ScienceBook sb = new ScienceBook()
                {
                    Name = c.BookName,
                    AmountOfPages = int.Parse(c.Page),
                    Author = c.Author
                };
                libraries.Add(sb);
                listBox1.Items.Add(sb);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] str = new string[libraries.Count];
                for(int i = 0; i < libraries.Count; ++i)
                {
                    str[i] = libraries[i].ToFile();
                }
                File.WriteAllLines(path: saveFileDialog1.FileName, contents: str);
            }
        }
        int maxElemIndex = 0;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
           //  lockBTN(false);

            int progresValue =  100 / libraries.Count;
           // int index = 0;
            int max = int.MinValue;
            for(int i = 0; i < libraries.Count; ++i)
            {
                if(libraries[i].AmountOfPages > max)
                {
                    max = libraries[i].AmountOfPages;
                    maxElemIndex = i;
                }
                if(backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                    backgroundWorker1.ReportProgress(0);
                    return;

                }
                backgroundWorker1.ReportProgress(i * progresValue);
                System.Threading.Thread.Sleep(1250);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripProgressBar1.Value = 0;
            if(!e.Cancelled)
            {
                lockBTN(true);

                textBox1.Text = libraries[maxElemIndex].ToString();

                if ((libraries[maxElemIndex] is ScienceBook)) MessageBox.Show("Is sub class");
                else MessageBox.Show("NOT sub class");

            }
        }

        private void lockBTN(bool locker)
        {
            button1.Enabled = locker;
            button2.Enabled = locker;
            button3.Enabled = locker;
            button4.Enabled = locker;
            button5.Enabled = locker;
        }
    }
}
