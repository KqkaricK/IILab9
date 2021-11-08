using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace IILab9
{
    public partial class Form1 : Form
    {
        OleDbConnection cn;
        OleDbCommand cm;
        OleDbDataAdapter da;
        DataTable dt;
        int[] z;
        int count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Pro f = new Pro();
            f.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Directory.GetCurrentDirectory() + @"\data.accdb");
            cn.Open();
            cm = new OleDbCommand("Select * from Cool", cn);
            dt = new DataTable();
            da = new OleDbDataAdapter(cm);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            z = new int[dataGridView1.ColumnCount - 2];
            label1.Text = dataGridView1.Rows[count].Cells[0].Value.ToString() + " " + dataGridView1.Rows[count].Cells[1].Value.ToString();
            for (int i = 2; i <= dataGridView1.ColumnCount - 1; i++)
            {
                z[i - 2] = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           if (count != dataGridView1.RowCount - 2)
           {
                for (int i = 2; i <= dataGridView1.ColumnCount - 1; i++)
                {
                    if (dataGridView1.Rows[count].Cells[i].Value.ToString() == "True")
                        z[i - 2]++;
                    else
                        z[i - 2]--;
                }
                count++;
                label1.Text = dataGridView1.Rows[count].Cells[0].Value.ToString() + " " + dataGridView1.Rows[count].Cells[1].Value.ToString();
            }
           else
           {
                button1.Enabled = false;
                button2.Enabled = false;
                for (int i = 2; i <= dataGridView1.ColumnCount - 1; i++)
                {
                    if (z[i - 2] < 10 && z[i - 2] > -1)
                    {
                        listBox1.Items.Add("0" + z[i - 2] + " " + dataGridView1.Columns[i].HeaderText);
                    }
                    else if (z[i - 2] > -10 && z[i - 2] < 0)
                    {
                        listBox1.Items.Add("-0" + z[i - 2] * -1 + " " + dataGridView1.Columns[i].HeaderText);
                    }
                    else
                    {
                        listBox1.Items.Add(z[i - 2] + " " + dataGridView1.Columns[i].HeaderText);
                    }

                }
                listBox1.Visible = true;
                string t1 = listBox1.Items[dataGridView1.ColumnCount - 3].ToString();
                t1 = t1.Remove(2, t1.Length - 3);
                string t2 = listBox1.Items[dataGridView1.ColumnCount - 4].ToString();
                t2 = t2.Remove(2, t2.Length - 3);
                if (t1 == t2)
                {
                    string tmp = listBox1.Items[dataGridView1.ColumnCount - 4].ToString();
                    tmp = tmp.Remove(0, 2);
                    label1.Text = listBox1.Items[dataGridView1.ColumnCount - 3].ToString() + " или " + tmp;
                    label1.Text = label1.Text.Remove(0, 2);
                }
                else
                {
                    label1.Text = listBox1.Items[dataGridView1.ColumnCount - 3].ToString();
                    label1.Text = label1.Text.Remove(0, 2);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (count != dataGridView1.RowCount - 2)
            {
                for (int i = 2; i <= dataGridView1.ColumnCount - 1; i++)
                {
                    if (dataGridView1.Rows[count].Cells[i].Value.ToString() == "True")
                        z[i - 2]--;
                    else
                        z[i - 2]++;
                }
                count++;
                label1.Text = dataGridView1.Rows[count].Cells[0].Value.ToString() + " " + dataGridView1.Rows[count].Cells[1].Value.ToString();
            }
            else
            {
                button1.Enabled = false;
                button2.Enabled = false;
                for (int i = 2; i <= dataGridView1.ColumnCount - 1; i++)
                {
                    if (z[i - 2] < 10 && z[i - 2] > -1)
                    {
                        listBox1.Items.Add("0" + z[i - 2] + " " + dataGridView1.Columns[i].HeaderText);
                    }
                    else if (z[i - 2] > -10 && z[i - 2] < 0)
                    {
                        listBox1.Items.Add("-0" + z[i - 2] * -1 + " " + dataGridView1.Columns[i].HeaderText);
                    }
                    else
                    {
                        listBox1.Items.Add(z[i - 2] + " " + dataGridView1.Columns[i].HeaderText);
                    }

                }
                listBox1.Visible = true;
                string t1 = listBox1.Items[dataGridView1.ColumnCount - 3].ToString();
                t1 = t1.Remove(2, t1.Length - 3);
                string t2 = listBox1.Items[dataGridView1.ColumnCount - 4].ToString();
                t2 = t2.Remove(2, t2.Length - 3);
                if (t1 == t2)
                {
                    string tmp = listBox1.Items[dataGridView1.ColumnCount - 4].ToString();
                    tmp = tmp.Remove(0, 2);
                    label1.Text = listBox1.Items[dataGridView1.ColumnCount - 3].ToString() + " или " + tmp;
                    label1.Text = label1.Text.Remove(0, 2);
                }
                else
                {
                    label1.Text = listBox1.Items[dataGridView1.ColumnCount - 3].ToString();
                    label1.Text = label1.Text.Remove(0, 2);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11)
            {
                Copyraight C = new Copyraight();
                C.Show();
            }
        }
    }
}
