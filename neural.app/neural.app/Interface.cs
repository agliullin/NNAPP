using AForge.Video.FFMPEG;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace neural.app
{
    /*!
     * Класс, который выводит главное окно, созданного при помощи Windows Form, для работы с искусственной нейронной сетью.
     */
    public partial class Interface : Form
    {
        /// Нейронная сеть.
        private NeuralNetwork NN;
        /// Массив, который хранит в себе матричный код изображения определенного размера(ArrayWidth* ArrayHeight).
        private int[,] arr;
        /// Массив, который хранит в себе матричный код изображения произвольного размера.
        private int[,] image;
        /// Изображение, которое является кадром из видеофайла.
        public Bitmap img;
        /// Хранит в себе путь до изображений(кадров из видеофайла). 
        private string Dir = @"C:\Users\Albert\Desktop\neural.app\neural.app\bin\Debug";
        /*!
         * Конструктор.
         */
        public Interface()
        {
            string[] files = Directory.GetFiles(Dir, "*.bmp");
            foreach (string fl in files)
            {
                string filename = Path.GetFileName(fl);
                File.Delete(filename);
            }
            InitializeComponent();
            NN = new NeuralNetwork();
            test();
        }
        /*!
         * Метод, который распознает образ и выводит данные об образах в виде текста.
         */
        private void recognize()
        {
            string text = "Полученные образы: " + Environment.NewLine;
            int symbolOne = 0, symbolTwo = 0, 
                symbolThree = 0, symbolFour = 0, 
                symbolFive = 0, symbolSix = 0, 
                symbolSeven = 0, symbolEight = 0,
                symbolNine = 0, symbolZero = 0; // Переменные для определения количества определенных образов.
            int index = 0; // Переменная для переноса строки.
            Stopwatch timer = new Stopwatch(); // Создание таймера.
            timer.Start(); // Запуск таймера.
            for (int i = 0;  ; i++)
            {
                try
                {
                    img = new Bitmap(i + ".bmp"); // Получаем файл (кадр видеофайла).
                    image = ImageTools.CutBitmapAndGetArray(img, new Point(img.Width, img.Height)); // Обрезаем изображение.
                    arr = ImageTools.Standardizing(image, new int[NeuralNetwork.ArrayWidth, NeuralNetwork.ArrayHeight]); // Приводим изображение к нормальному размеру.
                    string symbol = NN.Recognition(arr); // Распознаем образ.
                    text += symbol + " ";
                    if (symbol == "0")
                        symbolZero++;
                    else if (symbol == "1")
                        symbolOne++;
                    else if (symbol == "2")
                        symbolTwo++;
                    else if (symbol == "3")
                        symbolThree++;
                    else if (symbol == "4")
                        symbolFour++;
                    else if (symbol == "5")
                        symbolFive++;
                    else if (symbol == "6")
                        symbolSix++;
                    else if (symbol == "7")
                        symbolSeven++;
                    else if (symbol == "8")
                        symbolEight++;
                    else if (symbol == "9")
                        symbolNine++;

                    index++;
                    if (index == 32) { // Если в строке 32 символа, переходим на следующую строку.
                        text += Environment.NewLine;
                        index = 0;
                    }
                }
                catch
                {
                    timer.Stop(); // Остановка таймера.
                    System.IO.File.WriteAllText(@"time.txt", timer.ElapsedMilliseconds.ToString()); // Запись времени распознавания в файл "time" в миллисекундах.
                    DialogResult res = MessageBox.Show("Распознано " + i + " образов", "", MessageBoxButtons.OK);
                    break;
                }
               
            }
            text += Environment.NewLine + "Количество чисел в данном видео:" + Environment.NewLine + "0 - " + symbolZero + Environment.NewLine + 
                "1 - " + symbolOne + Environment.NewLine + "2 - " + symbolTwo + Environment.NewLine +
            "3 - " + symbolThree + Environment.NewLine + "4 - " + symbolFour + Environment.NewLine + "5 - " + symbolFive + Environment.NewLine + "6 - " +
            symbolSix + Environment.NewLine +
            "7 - " + symbolSeven + Environment.NewLine + "8 - " + symbolEight + Environment.NewLine + "9 - " + symbolNine + Environment.NewLine;
            textBox1.Text = text; // Вывод результата распознавания.
        }


        /*!
         * Метод, который по клику обрабатывает видео.
         */
        private void обработатьВидеоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VideoFileReader reader = new VideoFileReader();
            OpenFileDialog open_dialog = new OpenFileDialog(); // Создание диалогового окна для выбора файла
            open_dialog.Filter = "Video Files(*.WMV;*.AVI;*.MP4)|*.WMV;*.AVI;*.MP4|All files (*.*)|*.*"; // Формат загружаемого файла
            if (open_dialog.ShowDialog() == DialogResult.OK) // Если в окне была нажата кнопка "ОК"
            {
                reader.Open(open_dialog.FileName);
                int index = 0;
                for (int i = 25; ; i++) // После 25 кадра.
                {
                    try
                    {
                        Bitmap videoFrame = reader.ReadVideoFrame();
                            if (i % 30 == 0 && videoFrame != null) // Каждый 30 кадр, т.к. видеофайл 30 кадров в секунду.
                            {
                                 videoFrame.Save(index + ".bmp"); // Сохраняем кадр.
                                 index++;
                            }
                        videoFrame.Dispose(); // Освобождаем память.
                    }
                    catch
                    {
                        DialogResult res = MessageBox.Show("Получено " + index + " образов", "", MessageBoxButtons.OK);
                        break;
                    }
                }
                reader.Close(); // Закрываем VideoFileReader.

            }
        }
        /*!
         * Метод, который по клику вызывает функцию распознавания образов.
         */
        private void распознатьОбразыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            recognize();
        }
        /*!
         * Метод, который по клику выходит из программы.
         */
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NN.Save();
            Close();

        }
        /*!
         * Метод, который по клику вызывает окно графического редактора для добавления нового образа (обучения).
         */
        private void добавитьОбразToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form resultForm = new AdditionForm(NN); 
            resultForm.Show();
        }

        public void test()
        {
            string Text = "";
            for (int i = 0; i < 10; i++)
            {
                Bitmap img = new Bitmap(@"Test\" + i + ".png"); // Открываем изображение.
                int[,] image = ImageTools.CutBitmapAndGetArray(img, new Point(img.Width, img.Height)); // Обрезаем изображение.
                int[,] arr = ImageTools.Standardizing(image, new int[NeuralNetwork.ArrayWidth, NeuralNetwork.ArrayHeight]); // Стандартизируем размерность.
                Text += NN.Recognition(arr) + " "; // Распознаем образ.
            }
            System.IO.File.WriteAllText(@"test.txt", Text); // Записываем данные в текстовый файл.
        }
        
    }
}
