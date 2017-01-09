using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace neural.app
{
    /*!
     * Класс, который выводит окно графического редактора, созданного при помощи Windows Form.
     */
    public partial class AdditionForm : Form
    {
        /// Точка, с которого начинается рисование.
        private Point StartPoint;
        /// Нейронная сеть.
        private NeuralNetwork NN;
        /// Массив, который хранит в себе матричный код изображения определенного размера(ArrayWidth* ArrayHeight).
        private int[,] arr;
        /*!
         * Конструктор.
         * \param NN Нейронная сеть.
         */
        public AdditionForm(NeuralNetwork NN)
        {
            InitializeComponent();
            this.NN = NN;
            pictureBox1.Image = (Image)new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }
        /*!
         * Метод, который рисует линию от StartPoint до места, где зажата кнопка мыши.
         */
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point EndPoint = new Point(e.X, e.Y);
                Bitmap image = (Bitmap)pictureBox1.Image;
                using (Graphics g = Graphics.FromImage(image))
                {
                    g.DrawLine(new Pen(Color.Black, 4), StartPoint, EndPoint);
                }
                pictureBox1.Image = image;
                StartPoint = EndPoint;
            }
        }
        /*!
         * Метод, который определяет StartPoint на pictureBox.
         */
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            StartPoint = new Point(e.X, e.Y);
        }
        /*!
         * Метод, который добавляет в нейронную сеть введенный нами образ из графического редактора.
         */
        private void button1_Click(object sender, EventArgs e)
        {
            int[,] getArr = ImageTools.CutBitmapFromPaintAndGetArray((Bitmap)pictureBox1.Image, new Point(pictureBox1.Width, pictureBox1.Height));
            if (getArr == null) return;
            arr = ImageTools.Standardizing(getArr, new int[NeuralNetwork.ArrayWidth, NeuralNetwork.ArrayHeight]);
            if (textBox1.Text != null)
            {
                string get = textBox1.Text;
                NN.SetTraining(get, arr);
                NN.Save();
                Close();
            }
            else MessageBox.Show("Пустое текстовое поле."); 
            
        }
        /*!
         * Метод, который очищает окно графического редактора.
         */
        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = (Image)new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }
    }
}
