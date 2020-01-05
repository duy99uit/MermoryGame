using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace GameFinal
{
    public partial class MenuForm : Form
    {
        public SoundPlayer clicksound = new SoundPlayer(Properties.Resources.click);

        public SoundPlayer backgoundsound = new SoundPlayer(Properties.Resources.quick_thinking_G1ECM8S_);
        public MenuForm()
        {
            InitializeComponent();

            backgoundsound.Play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Application.Exit();

            //DialogResult dlr = MessageBox.Show("Exit Now ?","Mermory Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (dlr == DialogResult.Yes)
            //{
            //    Application.Exit();
            //}
            //Exit frm = new Exit();
            //frm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clicksound.Play();
            Form3x4 frm = new Form3x4();
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clicksound.Play();
            Form4x4 frm = new Form4x4();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clicksound.Play();
            Form4x5 frm = new Form4x5();
            frm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            clicksound.Play();
            Form5x5 frm = new Form5x5();
            frm.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            clicksound.Play();
            Form5x6 frm = new Form5x6();
            frm.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            backgoundsound.Stop();
            Exit frm = new Exit();
            frm.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/tduyuit");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCx9P9d1LbJ9VhuDW2o7NXuQ?view_as=subscriber");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            clicksound.Play();
            Form6x6 frm = new Form6x6();
            frm.ShowDialog();
        }
       public Info info = new Info();

        private void button4_MouseHover(object sender, EventArgs e)
        {
            //3x4
            button4.Text = "3x4";
            button4.ForeColor = Color.White;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.Text = "Easy";
            button4.ForeColor = Color.SlateBlue;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            //4x4
            button3.Text = "4x4";
            button3.ForeColor = Color.White;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.Text = "Medium";
            button3.ForeColor = Color.BlueViolet;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.Text = "4x5";
            button2.ForeColor = Color.White;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.Text = "Hard";
            button2.ForeColor = Color.DarkViolet;
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            button6.Text = "5x5";
            button6.ForeColor = Color.White;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.Text = "Elite";
            button6.ForeColor = Color.Indigo;
        }

        private void button7_MouseHover(object sender, EventArgs e)
        {
            button7.Text = "5x6";
            button7.ForeColor = Color.White;
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            button7.Text = "Expert";
            button7.ForeColor = Color.MidnightBlue;
        }

        private void button8_MouseHover(object sender, EventArgs e)
        {
            button8.Text = "6x6";
            button8.ForeColor = Color.White;
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            button8.Text = "Master";
            button8.ForeColor = Color.DarkBlue;
        }
    }
}
