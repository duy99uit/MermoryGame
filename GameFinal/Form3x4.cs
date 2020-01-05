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
    public partial class Form3x4 : Form
    {
        public SoundPlayer correct = new SoundPlayer(Properties.Resources.correct);
        public SoundPlayer win = new SoundPlayer(Properties.Resources.winning);
        Random random = new Random();
        PictureBox firstClick, secondClick;
        Image img = Properties.Resources.google;
        public Form3x4()
        {
            InitializeComponent();
            AddPicturetoSquare();
        }
        List<Image> imgList = new List<Image>()
        {
            Properties.Resources.gmail,
            Properties.Resources.drive,
            Properties.Resources.translate,
            Properties.Resources.photo,
            Properties.Resources.playstore,
            Properties.Resources.map,


            Properties.Resources.gmail,
            Properties.Resources.drive,
            Properties.Resources.translate,
            Properties.Resources.photo,
            Properties.Resources.playstore,
            Properties.Resources.map,
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
            
            //kiem tra 2 hinh giong nhau kong
            if (firstClick.BackgroundImage.Size == secondClick.BackgroundImage.Size)
            {
                
                firstClick.Image = firstClick.BackgroundImage;
                secondClick.Image = secondClick.BackgroundImage;
                firstClick = null;
                secondClick = null;
                correct.Play();
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
            firstClick.Image = Properties.Resources.google;
            secondClick.Image = Properties.Resources.google;
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
            //MessageBox.Show("--- SO EASY ---");
            correct.Stop();
            Close();
        }
        private void AddPicturetoSquare()
        {
            PictureBox pictureBox = new PictureBox();
            int randomnumber;
            for(int i=0;i<tableLayoutPanel1.Controls.Count;i++)
            {
                if(tableLayoutPanel1.Controls[i] is PictureBox)
                    pictureBox = (PictureBox)tableLayoutPanel1.Controls[i];
                else
                    continue;
                randomnumber = random.Next(0, imgList.Count);
                pictureBox.Image = Properties.Resources.google;
                pictureBox.BackgroundImage = imgList[randomnumber];
                imgList.RemoveAt(randomnumber);

            }
        }
    }
}
