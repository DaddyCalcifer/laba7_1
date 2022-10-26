using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba7_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        const int m1 = 6, m2 = 6;
        int[,] numbers = new int[m1,m2];
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.RowCount = m1;
            dataGridView1.ColumnCount = m2;
        }
        void SetArray()
        {
            for (int i = 0; i < m1; i++)
            {
                for (int j = 0; j < m2; j++)
                {
                    try
                    {
                        numbers[i, j] = Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value);
                    } catch
                    {
                        numbers[i, j] = 0;
                        dataGridView1.Rows[i].Cells[j].Value = 0;
                    }
                }
            }
        }
        static double func1(double x, double y)
        {
            return (2 * Math.Pow(Math.Cos(x - Math.PI / 6), 4)) / (0.5 + Math.Pow(Math.Sin(y), 2));
        }
        static double func2(double z)
        {
            return 1 + (Math.Pow(z, 2) / 3 + (Math.Pow(z, 2) / 5));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Сортированных строк в массиве: " + SortedLines(numbers).ToString());
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            result1.Value = Convert.ToDecimal(func1(Convert.ToDouble(numericUpDown1.Value), Convert.ToDouble(numericUpDown2.Value)));
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            result2.Value = Convert.ToDecimal(func2(Convert.ToDouble(numericUpDown5.Value)));
        }

        int SortedLines(int[,] arr)
        {
            SetArray();
            int result = 0;
            bool isSorted = false;
            for (int i = 0; i < m1; i++)
            {
                for (int j = 0; j < m2-1; j++)
                {
                    if (arr[i, j] >= arr[i, j + 1])
                    {
                        isSorted = false;
                        break;
                    }
                    else
                    {
                        isSorted = true;
                    }
                }
                if (isSorted) result++;
            }
            return result;
        }
        List<double> arr3 = new List<double>();
        private void button2_Click(object sender, EventArgs e)
        {
            arr3.Add(Convert.ToDouble(numericUpDown3.Value));
            listBox1.Items.Add(numericUpDown3.Value.ToString("N2"));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            arr3.Clear();
            listBox1.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var res = MinInArr(arr3.ToArray());
            listBox1.SelectedIndex = res;
            MessageBox.Show("Номер минимального элемента: " + res.ToString());
        }

        int MinInArr(double[] arr)
        {
            if (arr.Length > 0)
            {
                double min = arr[0];
                int min_id = 0;
                for (int i = 1; i < arr.Length; i++)
                    if (arr[i] < min)
                    {
                        min = arr[i];
                        min_id = i;
                    }
                return min_id;
            }
            else return -1;
        }
    }
}
