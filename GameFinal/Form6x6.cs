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
   
    public partial class Form6x6 : Form
    {
        public SoundPlayer correct = new SoundPlayer(Properties.Resources.correct);
        public SoundPlayer win = new SoundPlayer(Properties.Resources.winning);
        Random random = new Random();
        PictureBox firstClick, secondClick;
        Image img = Properties.Resources.logo6x6;
        public Form6x6()
        {
            InitializeComponent();
            AddPicture();
        }
        List<Image> imgList = new List<Image>()
        {
            Properties.Resources.c,
            Properties.Resources.cshap,
            Properties.Resources.cplus,
            Properties.Resources.css,
            Properties.Resources.python,
            Properties.Resources.php,
            Properties.Resources.html,
            Properties.Resources.js,
            Properties.Resources.node,
            Properties.Resources.golang,
            Properties.Resources.react,
            Properties.Resources.java,
            Properties.Resources.swift,
            Properties.Resources.mysql,
            Properties.Resources.ruby,
            Properties.Resources.ts,
            Properties.Resources.scala,
            Properties.Resources.kotlin,

            Properties.Resources.c,
            Properties.Resources.cshap,
            Properties.Resources.cplus,
            Properties.Resources.css,
            Properties.Resources.python,
            Properties.Resources.php,
            Properties.Resources.html,
            Properties.Resources.js,
            Properties.Resources.node,
            Properties.Resources.golang,
            Properties.Resources.react,
            Properties.Resources.java,
            Properties.Resources.swift,
            Properties.Resources.mysql,
            Properties.Resources.ruby,
            Properties.Resources.ts,
            Properties.Resources.scala,
            Properties.Resources.kotlin,

        };

        private void click_image(object sender, EventArgs e)
        {
            PictureBox pixclick = sender as PictureBox;
            if (firstClick != null && secondClick != null)
                return;
            if (pixclick == null)
                return;
            if (pixclick.Image == pixclick.BackgroundImage)
                return;
            if (firstClick == null)
            {
                firstClick = pixclick;
                firstClick.Image = firstClick.BackgroundImage;
                return;
            }
            secondClick = pixclick;
            secondClick.Image = secondClick.BackgroundImage;

            if (firstClick.BackgroundImage.Size == secondClick.BackgroundImage.Size)
            {
                correct.Play();
                firstClick.Image = firstClick.BackgroundImage;
                secondClick.Image = secondClick.BackgroundImage;
                firstClick = null;
                secondClick = null;
            }
            else
            {
                timer1.Start();
            }
            CheckEndGame();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            firstClick.Image = Properties.Resources.logo6x6;
            secondClick.Image = Properties.Resources.logo6x6;
            firstClick = null;
            secondClick = null;
        }
        private void CheckEndGame()
        {
            PictureBox picture;
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)

            {
                picture = tableLayoutPanel1.Controls[i] as PictureBox;
                if (picture != null && picture.Image.Size != picture.BackgroundImage.Size)
                    return;
            }
            win.Play();
            Winner winner = new Winner();
            winner.ShowDialog();
            //MessageBox.Show("Congratulation");
            Close();
        }
        private void AddPicture() //add picture to gameform
        {
            PictureBox picBox = new PictureBox();
            int randomnumber;
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                if (tableLayoutPanel1.Controls[i] is PictureBox)
                    picBox = (PictureBox)tableLayoutPanel1.Controls[i];
                else
                    continue;
                randomnumber = random.Next(0, imgList.Count);
                picBox.Image = Properties.Resources.logo6x6;
                picBox.BackgroundImage = imgList[randomnumber];
                imgList.RemoveAt(randomnumber);
            }
        }
    }
}
