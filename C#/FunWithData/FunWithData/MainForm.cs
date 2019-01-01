using System;
using System.Windows.Forms;

using FunWithData.Model;
using FunWithData.UserControls;

namespace FunWithData
{
    public partial class MainForm : Form
    {
        // FIELDS
        Random random;
        People people;
        PeopleView peopleView;
        UserControl filterControl;
        
        // CONSTRUCTORS
        public MainForm()
        {
            InitializeComponent();
            
            random = new Random();
            people = new People();
            filterControl = null;

            string[] names = { "Bob", "John", "Sam", "David", "Adam" };
            string[] surnames = { "Ross", "Snow", "Davis", "Bowie", "Gontier" };

            for (int i = 0; i < 50000; ++i)
            {
                people.Add(new Person()
                {
                    Id = i,
                    Name = names[random.Next(names.Length)] + i,
                    Surname = surnames[random.Next(surnames.Length)] + i,
                    Age = random.Next(1, 90)
                });
            }

            peopleView = new PeopleView(people);

            UpdateInterface();
        }
        // METHODS
        void UpdateInterface()
        {
            // update data grid
            dataDgv.RowCount = peopleView.Count;
            dataDgv.Invalidate();

            countLbl.Text = peopleView.Count.ToString();
        }
        private void sortBtn_Click(object sender, EventArgs e)
        {
            if (sortOptionCb.SelectedIndex != -1)
            {
                peopleView.SortBy((SortMode)sortOptionCb.SelectedIndex);
                UpdateInterface();
            }
        }

        private void filterBtn_Click(object sender, EventArgs e)
        {
            int index = filterOptionCb.SelectedIndex;
            if (index == -1) return;


            if (index == 0 || index == 3)
            {
                int minValue = ((NumberControl)filterControl).MinValue;
                int maxValue = ((NumberControl)filterControl).MaxValue;

                peopleView.FilterBy((FilterModeInt)index, minValue, maxValue);
            }
            else if (index == 1 || index == 2)
            {
                string stringValue = ((StringControl)filterControl).StringValue;

                peopleView.FilterBy((FilterModeString)index, stringValue);
            }

            UpdateInterface();
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            peopleView.Reset();
            UpdateInterface();
        }

        private void filterOptionCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = filterOptionCb.SelectedIndex;
            filterPnl.Controls.Clear();
            filterControl = null;

            if (index == 0 || index == 3)
            {
                filterControl = new NumberControl()
                {
                    Parent = filterPnl,
                    Dock = DockStyle.Fill
                };
            }
            else if (index == 1 || index == 2)
            {
                filterControl = new StringControl()
                {
                    Parent = filterPnl,
                    Dock = DockStyle.Fill
                };
            }
        }
        private void findFirstBtn_Click(object sender, EventArgs e)
        {
            if (filterOptionCb.SelectedIndex == 1) // name selected
            {
                // get name
                string name = ((StringControl)filterControl).StringValue;

                // get first index
                int personIndex = peopleView.IndexOf(name);
                if (personIndex == -1) return; // bad index

                // scroll to that value and select it
                dataDgv.FirstDisplayedScrollingRowIndex = personIndex;
                dataDgv.Rows[personIndex].Selected = true;
            }
        }
        // data grid view virtual mode
        private void dataDgv_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            try
            {
                switch (e.ColumnIndex)
                {
                    case 0: e.Value = peopleView[e.RowIndex].Id; break;
                    case 1: e.Value = peopleView[e.RowIndex].Name; break;
                    case 2: e.Value = peopleView[e.RowIndex].Surname; break;
                    case 3: e.Value = peopleView[e.RowIndex].Age; break;
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void dataDgv_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            try
            {
                switch (e.ColumnIndex)
                {
                    case 0: peopleView[e.RowIndex].Id = int.Parse(e.Value.ToString()); break;
                    case 1: peopleView[e.RowIndex].Name = e.Value.ToString(); break;
                    case 2: peopleView[e.RowIndex].Surname = e.Value.ToString(); break;
                    case 3: peopleView[e.RowIndex].Age = int.Parse(e.Value.ToString()); break;
                }
                UpdateInterface();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }        
    }
}
