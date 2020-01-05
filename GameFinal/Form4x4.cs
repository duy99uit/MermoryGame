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
    public partial class Form4x4 : Form
    {
        public SoundPlayer correct = new SoundPlayer(Properties.Resources.correct);
        public SoundPlayer win = new SoundPlayer(Properties.Resources.winning);
        Random random = new Random();
        PictureBox firstClick, secondClick;
        Image img = Properties.Resources.logo4x4;
        public Form4x4()
        {
            InitializeComponent();
            AddPicture();
        }
        List<Image> imgList = new List<Image>()
        {
            Properties.Resources.chrome,
            Properties.Resources.coccoc,
            Properties.Resources.edge,
            Properties.Resources.opera,
            Properties.Resources.maxthon,
            Properties.Resources.safari,
            Properties.Resources.uc,
            Properties.Resources.firefox,
            Properties.Resources.chrome,
            Properties.Resources.coccoc,
            Properties.Resources.edge,
            Properties.Resources.opera,
            Properties.Resources.maxthon,
            Properties.Resources.safari,
            Properties.Resources.uc,
            Properties.Resources.firefox,
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
            /// Kich hoat Timer
            else
            {
                timer1.Start();
            }
            CheckEndGame();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
           
            firstClick.Image = Properties.Resources.logo4x4;
            secondClick.Image = Properties.Resources.logo4x4;
            firstClick = null;
            secondClick = null;
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
                picBox.Image = Properties.Resources.logo4x4;
                picBox.BackgroundImage = imgList[randomnumber];
                imgList.RemoveAt(randomnumber);
            }
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
            //MessageBox.Show("----GREAT----");
            Close();
        }
    }
}
