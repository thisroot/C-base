using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace ExampleWinForms
{
    using MoneyEntry;
    public partial class Form1 : Form
    {

        private double _balance;
        public Form1()
        {
            InitializeComponent();
            _balance = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void buttonAdd_Click(object sender, EventArgs e)
        {
            MoneyEntry me = new MoneyEntry();
            double income;
            double.TryParse(textBoxAmount.Text, out income);
            me.Amount = income;
            me.EntryDate = dtpDate.Value;
            me.Description = textBoxDescription.Text;
            me.Category = textBoxCategory.Text;

            AddEntry(me);
            UpdateBalance();
            ClearFields();
        }

        private void UpdateBalance()
        {
            double balance = 0;

            foreach(DataGridViewRow row in dataGridViewEntries.Rows)
            {
                double income;
                double.TryParse((row.Cells[1].Value ?? "0").ToString(), out income);
                balance += income;
            }
            textBoxBalance.Text = balance.ToString();
        }

        private void AddEntry(MoneyEntry me)
        {
            dataGridViewEntries.Rows.Add(me.IsDebit ? "Доход" : "Расход"
                , me.Amount
                , me.Description
                , me.EntryDate.ToShortDateString()
                , me.Category);
        }

        private void ClearFields()
        {
            textBoxAmount.Text = "";
            textBoxDescription.Text = "";
            textBoxCategory.Text = "";
            dtpDate.Value = DateTime.Now;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewEntries_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewEntries_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 &&  dataGridViewEntries.Rows.Count > 0)
            {
                double income;
                double.TryParse((dataGridViewEntries[e.ColumnIndex, e.RowIndex].Value ?? "0").ToString(), out income);

                dataGridViewEntries[0, e.RowIndex].Value = (income < 0) ? "Расход" : "Доход";
                UpdateBalance();
            }
        }

        private void textBoxCategory_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
