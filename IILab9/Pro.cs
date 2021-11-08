using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace IILab9
{
    public partial class Pro : Form
    {
        OleDbCommand cm;
        OleDbConnection cn;
        OleDbDataAdapter da;
        OleDbCommandBuilder cb;
        DataTable dt;
        Random rnd = new Random();

        public Pro()
        {
            InitializeComponent();
        }

        private void Pro_Load(object sender, EventArgs e)
        {
            cn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Directory.GetCurrentDirectory() + @"\data.accdb");
            cn.Open();
            cm = new OleDbCommand("Select * from Cool", cn);
            dt = new DataTable();
            da = new OleDbDataAdapter(cm);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            if (name == "")
                name = rnd.Next().ToString();
            cm = new OleDbCommand("ALTER TABLE Cool ADD COLUMN " + name + " BIT NULL", cn);
            dt = new DataTable();
            da = new OleDbDataAdapter(cm);
            da.Fill(dt);
            cm = new OleDbCommand("Select * from Cool", cn);
            dt = new DataTable();
            da = new OleDbDataAdapter(cm);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cb = new OleDbCommandBuilder(da);
            da.Update(dt);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.ColumnCount - 1;
            string name = dataGridView1.Columns[index].HeaderText;
            cm = new OleDbCommand("ALTER TABLE Cool DROP COLUMN " + name, cn);
            dt = new DataTable();
            da = new OleDbDataAdapter(cm);
            da.Fill(dt);
            cm = new OleDbCommand("Select * from Cool", cn);
            dt = new DataTable();
            da = new OleDbDataAdapter(cm);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
