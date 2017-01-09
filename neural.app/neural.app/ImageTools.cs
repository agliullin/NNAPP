using System;
using System.Drawing;

namespace neural.app
{
    /*! 
     * Класс, в котором хранятся все методы для преобразования изображения.
     */
    class ImageTools
    {
        /*! 
         * Метод, который обрезает изображение, оставляя только цифру, и преобразует в матричный код произвольного квадратного размера.
         * \param image Полученное изображение.
         * \param point Крайняя правая нижняя точка.
         * \return res Усеченный массив.
         */
        public static int[,] CutBitmapAndGetArray(Bitmap image, Point point)
        {
            int background;
            int x1 = 0, y1 = 0, x2 = point.X, y2 = point.Y; // x1 и y1 - координаты левого верхнего угла.
                                                            // x2 и y2 - координаты правого нижнего угла.
            if (image.GetPixel(x1+1, y1+1).R < 50) // Проверка цвета фона
                background = 1; // 1 - черный фон
            else background = 0; // 0 - белый фон
            if (background == 0)
            {
                for (int x = 0; x < image.Width && x1 == 0; x++) // x1 == 0 - условие необходимое для того, чтобы найти только первую точку.
                    for (int y = 0; y < image.Height && x1 == 0; y++) // x1 == 0 - условие необходимое для того, чтобы найти только первую точку.
                        if (image.GetPixel(x, y).R < 200 || image.GetPixel(x, y).G < 200 || image.GetPixel(x, y).B < 200) x1 = x; // Движемся из левого верхнего угла пока не найдем первую не белую точку.
                                                                 // Полученная точка x1;
                for (int y = 0; y < image.Height && y1 == 0; y++) // y1 == 0 - условие необходимое для того, чтобы найти только первую точку.
                    for (int x = 0; x < image.Width && y1 == 0; x++) // y1 == 0 - условие необходимое для того, чтобы найти только первую точку.
                        if (image.GetPixel(x, y).R < 200 || image.GetPixel(x, y).G < 200 || image.GetPixel(x, y).B < 200) y1 = y; // Движемся из левого верхнего угла пока не найдем первую не белую точку.
                                                                 // Полученная точка y1;
                for (int x = image.Width - 1; x >= 0 && x2 == point.X; x--) // x2 == point.X - условие необходимое для того, чтобы найти только первую точку.
                    for (int y = 0; y < image.Height && x2 == point.X; y++) // x2 == point.X - условие необходимое для того, чтобы найти только первую точку.
                        if (image.GetPixel(x, y).R < 200 || image.GetPixel(x, y).G < 200 || image.GetPixel(x, y).B < 200) x2 = x; // Движемся из правого верхнего угла пока не найдем первую не белую точку.
                                                                 // Полученная точка x2;
                for (int y = image.Height - 1; y >= 0 && y2 == point.Y; y--) // y2 == point.Y - условие необходимое для того, чтобы найти только первую точку.
                    for (int x = 0; x < image.Width && y2 == point.Y; x++) // y2 == point.Y - условие необходимое для того, чтобы найти только первую точку.
                        if (image.GetPixel(x, y).R < 200 || image.GetPixel(x, y).G < 200 || image.GetPixel(x, y).B < 200) y2 = y; // Движемся из левого нижнего угла пока не найдем первую не белую точку.
                                                                 // Полученная точка y2;
            }
            else {
                for (int x = 0; x < image.Width && x1 == 0; x++) // x1 == 0 - условие необходимое для того, чтобы найти только первую точку.
                    for (int y = 0; y < image.Height && x1 == 0; y++) // x1 == 0 - условие необходимое для того, чтобы найти только первую точку.
                        if (image.GetPixel(x, y).R > 200 || image.GetPixel(x, y).G > 200 || image.GetPixel(x, y).B > 200) x1 = x; // Движемся из левого верхнего угла пока не найдем первую не черную точку.
                                                                 // Полученная точка x1;
                for (int y = 0; y < image.Height && y1 == 0; y++) // y1 == 0 - условие необходимое для того, чтобы найти только первую точку.
                    for (int x = 0; x < image.Width && y1 == 0; x++) // y1 == 0 - условие необходимое для того, чтобы найти только первую точку.
                        if (image.GetPixel(x, y).R > 200 || image.GetPixel(x, y).G > 200 || image.GetPixel(x, y).B > 200) y1 = y; // Движемся из левого верхнего угла пока не найдем первую не черную точку.
                                                                                                                               // Полученная точка y1;
                for (int x = image.Width - 1; x >= 0 && x2 == point.X; x--) // x2 == point.X - условие необходимое для того, чтобы найти только первую точку.
                    for (int y = 0; y < image.Height && x2 == point.X; y++) // x2 == point.X - условие необходимое для того, чтобы найти только первую точку.
                        if (image.GetPixel(x, y).R > 200 || image.GetPixel(x, y).G > 200 || image.GetPixel(x, y).B > 200) x2 = x; // Движемся из правого верхнего угла пока не найдем первую не черную точку.
                                                                                                                               // Полученная точка x2;
                for (int y = image.Height - 1; y >= 0 && y2 == point.Y; y--) // y2 == point.Y - условие необходимое для того, чтобы найти только первую точку.
                    for (int x = 0; x < image.Width && y2 == point.Y; x++) // y2 == point.Y - условие необходимое для того, чтобы найти только первую точку.
                        if (image.GetPixel(x, y).R > 200 || image.GetPixel(x, y).G > 200 || image.GetPixel(x, y).B > 200) y2 = y; // Движемся из левого нижнего угла пока не найдем первую не черную точку.
                                                                                                                               // Полученная точка y2;
            }
            if (x1 == 0 && y1 == 0 && x2 == point.X && y2 == point.Y) // Если мы в итоге не изменили размер ни в одной точке, то оставляем все без изменений
                return null;
            int size = x2 - x1 > y2 - y1 ? x2 - x1 + 1 : y2 - y1 + 1; // Определяем в какой оси наш рисунок больше.
            int dX = y2 - y1 > x2 - x1 ? ((y2 - y1) - (x2 - x1)) / 2 : 0; // Если дельта Y больше чем дельта X, то делим дельта X пополам, 
                                                                          // так как придется прибавить это значение с обоих сторон.
            int dY = y2 - y1 < x2 - x1 ? ((x2 - x1) - (y2 - y1)) / 2 : 0; // Если дельта X больше, чем дельта Y, то делим дельта Y пополам, 
                                                                          // так как придется прибавить это значение с обоих сторон.
            int[,] res = new int[size, size]; // Создаем новый массив с новой размерностью.

            // В дальнейшем проверяем пиксели в полученном изображении.
            if (background == 0) // Если белый фон.
            {
                for (int x = 0; x < res.GetLength(0); x++)
                    for (int y = 0; y < res.GetLength(1); y++)
                    {
                        int currentX = x + x1 - dX;
                        int currentY = y + y1 - dY;
                        if (currentX < 0 || currentX >= point.X || currentY < 0 || currentY >= point.Y) // Если вышли за размер изображения.
                            res[x, y] = 0;
                        else {
                            if (image.GetPixel(x + x1 - dX, y + y1 - dY).R > 200 &&
                                image.GetPixel(x + x1 - dX, y + y1 - dY).G > 200 &&
                                image.GetPixel(x + x1 - dX, y + y1 - dY).B > 200) // Белый пиксель = значение 0, иначе 1.
                                res[x, y] = 0;
                            else res[x, y] = 1;
                        }
                    }
            } else // Если черный фон.
            {
                for (int x = 0; x < res.GetLength(0); x++)
                    for (int y = 0; y < res.GetLength(1); y++)
                    {
                        int currentX = x + x1 - dX;
                        int currentY = y + y1 - dY;
                        if (currentX < 0 || currentX >= point.X || currentY < 0 || currentY >= point.Y) // Если вышли за размер изображения.
                            res[x, y] = 0;
                        else
                        {
                            if (image.GetPixel(x + x1 - dX, y + y1 - dY).R < 50 &&
                                image.GetPixel(x + x1 - dX, y + y1 - dY).G < 50 &&
                                image.GetPixel(x + x1 - dX, y + y1 - dY).B < 50) // Черный пиксель = значение 0, иначе 1.
                                res[x, y] = 0;
                            else res[x, y] = 1;
                        }
                    }
            }
            return res; // Выводим новый массив, с усеченного изображения.
        }
        /*! 
         * Метод, который произвольный массив приводит к массиву стандартных размеров.
         * \param ReceivedArray Полученный массив весов.
         * \param ResultingArray Результирующий массив весов.
         * \return ResultinArray Рельтирующий массив весов.
         */
        public static int[,] Standardizing(int[,] ReceivedArray, int[,] ResultingArray)
        {
            for (int i = 0; i < ResultingArray.GetLength(0); i++)
                for (int j = 0; j < ResultingArray.GetLength(1); j++) ResultingArray[i, j] = 0;

            // Коэффициент X, по которому результирующий массив отличается от полученного.
            double СoefficientX = (double)ResultingArray.GetLength(0) / (double)ReceivedArray.GetLength(0);

            // Коэффициент Y, по которому результирующий массив отличается от полученного.
            double СoefficientY = (double)ResultingArray.GetLength(1) / (double)ReceivedArray.GetLength(1); 

            for (int i = 0; i < ReceivedArray.GetLength(0); i++)
                for (int j = 0; j < ReceivedArray.GetLength(1); j++)
                {
                    int currentX = (int)(i * СoefficientX); // Текущий X с учетом коэффициента.
                    int currentY = (int)(j * СoefficientY); // Текущий Y с учетом коэффициента.
                    if (ResultingArray[currentX, currentY] == 0)
                        ResultingArray[currentX, currentY] = ReceivedArray[i, j];
                }
            return ResultingArray;
        }


        /*! 
         * Метод, который преобразует изображение также как и метод CutBitmapAndGetArray(), но только из гарфического редактора.
         * \param image Полученное изображение.
         * \param point Крайняя правая нижняя точка.
         * \return res Усеченный массив.
         */
        public static int[,] CutBitmapFromPaintAndGetArray(Bitmap image, Point point)
        {
            int x1 = 0, y1 = 0, x2 = point.X, y2 = point.Y; // x1 и y1 - координаты левого верхнего угла.
                                                            // x2 и y2 - координаты правого нижнего угла.
            for (int x = 0; x < image.Width && x1 == 0; x++) // x1 == 0 - условие необходимое для того, чтобы найти только первую точку.
                for (int y = 0; y < image.Height && x1 == 0; y++) // x1 == 0 - условие необходимое для того, чтобы найти только первую точку.
                    if (image.GetPixel(x, y).ToArgb() != 0) x1 = x; // Движемся из левого верхнего угла пока не найдем первую не белую точку.
                                                             // Полученная точка x1;
            for (int y = 0; y < image.Height && y1 == 0; y++) // y1 == 0 - условие необходимое для того, чтобы найти только первую точку.
                for (int x = 0; x < image.Width && y1 == 0; x++) // y1 == 0 - условие необходимое для того, чтобы найти только первую точку.
                    if (image.GetPixel(x, y).ToArgb() != 0) y1 = y; // Движемся из левого верхнего угла пока не найдем первую не белую точку.
                                                             // Полученная точка y1;
            for (int x = image.Width - 1; x >= 0 && x2 == point.X; x--) // x2 == point.X - условие необходимое для того, чтобы найти только первую точку.
                for (int y = 0; y < image.Height && x2 == point.X; y++) // x2 == point.X - условие необходимое для того, чтобы найти только первую точку.
                    if (image.GetPixel(x, y).ToArgb() != 0) x2 = x; // Движемся из правого верхнего угла пока не найдем первую не белую точку.
                                                             // Полученная точка x2;
            for (int y = image.Height - 1; y >= 0 && y2 == point.Y; y--) // y2 == point.Y - условие необходимое для того, чтобы найти только первую точку.
                for (int x = 0; x < image.Width && y2 == point.Y; x++) // y2 == point.Y - условие необходимое для того, чтобы найти только первую точку.
                    if (image.GetPixel(x, y).ToArgb() != 0) y2 = y; // Движемся из левого нижнего угла пока не найдем первую не белую точку.
                                                             // Полученная точка y2;

            if (x1 == 0 && y1 == 0 && x2 == point.X && y2 == point.Y) // Если мы в итоге не изменили размер ни в одной точке, то оставляем все без изменений
                return null;

            int size = x2 - x1 > y2 - y1 ? x2 - x1 + 1 : y2 - y1 + 1; // Определяем в какой оси наш рисунок больше.
            int dX = y2 - y1 > x2 - x1 ? ((y2 - y1) - (x2 - x1)) / 2 : 0; // Если дельта Y больше чем дельта X, то делим дельта X пополам, 
                                                                          // так как придется прибавить это значение с обоих сторон.
            int dY = y2 - y1 < x2 - x1 ? ((x2 - x1) - (y2 - y1)) / 2 : 0; // Если дельта X больше, чем дельта Y, то делим дельта Y пополам, 
                                                                          // так как придется прибавить это значение с обоих сторон.
            int[,] res = new int[size, size]; // Создаем новый массив с новой размерностью.
            // В дальнейшем проверяем пиксели в полученном изображении.
            // Если белый цвет, то в массиве данному элементу присвиваем 1.
            // Если черный цвет, то в массиве данному элементу присваиваем 0.
            for (int x = 0; x < res.GetLength(0); x++)
                for (int y = 0; y < res.GetLength(1); y++)
                {
                    int currentX = x + x1 - dX;
                    int currentY = y + y1 - dY;
                    if (currentX < 0 || currentX >= point.X || currentY < 0 || currentY >= point.Y)  // Если вышли за размер изображения.
                        res[x, y] = 0;
                    else 
                        res[x, y] = image.GetPixel(x + x1 - dX, y + y1 - dY).ToArgb() == 0 ? 0 : 1; // Если пиксель белый то значение 0, иначе 1
                }
            return res; // Выводим новый массив, с усеченного изображения.
        }
    }
}
