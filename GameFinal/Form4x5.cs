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
    public partial class Form4x5 : Form
    {
        public SoundPlayer correct = new SoundPlayer(Properties.Resources.correct);
        public SoundPlayer win = new SoundPlayer(Properties.Resources.winning);
        Random random = new Random();
        PictureBox firstClick, secondClick;
        Image img = Properties.Resources.logo;

        public Form4x5()
        {
            InitializeComponent();
            AddPicture();
        }
        List<Image> imgList = new List<Image>()
        {
            
            Properties.Resources.amazon,
            Properties.Resources.apple,
            Properties.Resources.facebook,
            Properties.Resources.flickr,
            Properties.Resources.google,
            Properties.Resources.instagram,
            Properties.Resources.pinterest,
            Properties.Resources.twitter,
            Properties.Resources.windows,
            Properties.Resources.youtube,
            Properties.Resources.amazon,
            Properties.Resources.apple,
            Properties.Resources.facebook,
            Properties.Resources.flickr,
            Properties.Resources.google,
            Properties.Resources.instagram,
            Properties.Resources.pinterest,
            Properties.Resources.twitter,
            Properties.Resources.windows,
            Properties.Resources.youtube,
        };


        private void AddPicture() //add picture to gameform
        {
            PictureBox picBox = new PictureBox();
            int randomnumber;
            
            //int isContain
            ;  ///Kiem tra trung va Random lai
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                //isContain = 0;
                if (tableLayoutPanel1.Controls[i] is PictureBox)
                    picBox = (PictureBox)tableLayoutPanel1.Controls[i];
                else
                    continue;
                randomnumber = random.Next(0, imgList.Count);
                picBox.Image = Properties.Resources.logo;
                picBox.BackgroundImage = imgList[randomnumber];
                imgList.RemoveAt(randomnumber);



            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            //tra ve Logo cho 2 Square
            firstClick.Image = Properties.Resources.logo;
            secondClick.Image = Properties.Resources.logo;
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
            //MessageBox.Show("----EXCELLENT----");
            Winner winner = new Winner();
            winner.ShowDialog();
            //MessageBox.Show("YOU WIN", "Thong bao");
            Close();
        }
        private void img_clicked(object sender, EventArgs e)
        {
            //foreach (PictureBox picture in tableLayoutPanel1.Controls)
            //{
            //    picture.Image = Properties.Resources.logo;
            //}

            PictureBox pixclick = sender as PictureBox;
            if (firstClick != null && secondClick != null)
                return;
            if (pixclick == null)
                return;
            if (pixclick.Image == pixclick.BackgroundImage) 
                return;
            if(firstClick==null)
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
    }
}
