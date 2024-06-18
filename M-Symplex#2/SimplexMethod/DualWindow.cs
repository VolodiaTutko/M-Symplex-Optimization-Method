using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SimplexMethod
{
    public partial class DualWindow : Form
    {
        public DualWindow()
        {
            InitializeComponent();
        }

        public void ShowConstraints(double[][] coefficients, double[] constants, string[] signs, double[] funcCoef, bool isMax)
        {
            
            dataGridView.Rows.Clear();
            dataGridView.ColumnCount = coefficients.Length + 2;
            dataGridView.RowHeadersVisible = false;

           
            for (int i = 0; i < coefficients.Length; i++)
            {
                dataGridView.Columns[i].Name = "x" + (i + 1).ToString();
            }
            dataGridView.Columns[dataGridView.ColumnCount - 2].Name = "Sign";
            dataGridView.Columns[dataGridView.ColumnCount - 1].Name = "Constant";

           
            for (int i = 0; i < coefficients[0].Length; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView);

                for (int j = 0; j < coefficients.Length; j++)
                {
                   
                    row.Cells[j].Value = coefficients[j][i];
                }

               
                string originalSign = signs[i];
                string replacedSign = originalSign == ">=" ? "<=" : originalSign == "<=" ? ">=" : "=";
                row.Cells[dataGridView.ColumnCount - 2].Value = replacedSign;

                row.Cells[dataGridView.ColumnCount - 1].Value = constants[i];

                dataGridView.Rows.Add(row);
            }

           
            dataGridViewFunction.Rows.Clear();
            dataGridViewFunction.ColumnCount = funcCoef.Length; 

           
            for (int i = 0; i < funcCoef.Length; i++)
            {
                dataGridViewFunction.Columns[i].Name = "y" + (i + 1).ToString();
            }

            
            DataGridViewRow functionRow = new DataGridViewRow();
            functionRow.CreateCells(dataGridViewFunction);
            for (int i = 0; i < funcCoef.Length; i++)
            {
                functionRow.Cells[i].Value = funcCoef[i];
            }
            dataGridViewFunction.Rows.Add(functionRow);

            
            if (isMax)
            {
                isMaxLabel.Text = "min";
            }
            else
            {
                isMaxLabel.Text = "max";
            }
        }


        private void DualWindow_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
