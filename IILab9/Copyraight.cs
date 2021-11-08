using System;
using System.Windows.Forms;

namespace IILab9
{
    public partial class Copyraight : Form
    {
        public Copyraight()
        {
            InitializeComponent();
        }

        private void Copyraight_Load(object sender, EventArgs e)
        {
            label1.Text = "<<Почему мы ещё живы? Для того, чтобы страдать? По ночам... я чувствую свою руку и ногу... даже свои пальцы. Тело, которое я потерял. Товарищи, которых я потерял, — эта боль никак не утихнет. Они будто всё ещё со мной. Ты ведь тоже это чувствуешь, правда?>>\n\n                  — Metal Gear Solid V: The Phantom Pain";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/kqkarick");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/kqkarick");
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Cursor = Cursors.Hand;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Cursor = Cursors.Default;
        }
    }
}
