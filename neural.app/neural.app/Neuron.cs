using System;

namespace neural.app
{
    /*!
    * Класс нейрона.
    */
    class Neuron
    {
        /// Коэффициент "сглаживания".
        public const double alpha = 2.0;
        /// Имя образа, который хранит нейрон.
        public string Name;
        /// Массив весов, который хранит в себе память нейрона.
        public double[,] Weight; 
        /// Количество обучений определенному образу, т.е. количество вариантов образа в памяти.
        public int NumberOfTrainings;


        /*!
        * Конструктор.
        */
        public Neuron() { }
        
        /*!
        * Метод, который возвращает имя нейрона.
        * \return Name Имя нейрона.
        */
        public string GetName() {
            return Name;
        }

        /*!
        * Метод, который очищает память нейрона и присваивает ему новое имя.
        * \param name Имя нейрона.
        * \param x Размер по горизонтали (ArrayWidth).
        * \param y Размер по вертикали (ArrayHeight).
        */
        public void Clear(string name, int x, int y)
        {
            this.Name = name;
            Weight = new double[x, y];
            for (int i = 0; i < Weight.GetLength(0); i++)
                for (int j = 0; j < Weight.GetLength(1); j++)
                    Weight[i, j] = 0; // Обнуляем каждый элемент массива.
            NumberOfTrainings = 0; // Обнуляем количество обучений.
        }

        /*!
        * Метод, который высчитывает среднеквадратичное отклонение (RMSE).
        * \param ReceivedArray Полученный массив.
        * \return Math.Sqrt(AverageMSE) RMSE.
        */
        public double GetResult(int[,] ReceivedArray) // ReceivedArray - полученный массив.
        {
            if (Weight.GetLength(0) != ReceivedArray.GetLength(0) || Weight.GetLength(1) != ReceivedArray.GetLength(1))
                return -1;
            double MSE = 0; // Mean Squared Error.
            for (int i = 0; i < Weight.GetLength(0); i++) // Проход по массиву.
                for (int j = 0; j < Weight.GetLength(1); j++) // Проход по массиву.
                {
                    MSE += Math.Pow(Weight[i,j] - ReceivedArray[i, j], 2); // Высчитываем значение суммы квадратов разности эталонного от полученного образа.
                }
            double AverageMSE = MSE / (Weight.GetLength(0) * Weight.GetLength(1)); // Высчитываем среднее значение.
            return Math.Sqrt(AverageMSE); // Высчитываем квадратный корень из среднего значения (RMSE)
        }

        /*!
        * Метод, который добавляет входной образ в память (обучение).
        * \param ReceivedArray Полученный массив.
        */
        public void Training(int[,] ReceivedArray) // ReceivedArray - полученный массив.
        {
            // Проверка существования полученного массива и совпадения размерности с массивом из памяти.
            if (ReceivedArray != null || Weight.GetLength(0) == ReceivedArray.GetLength(0) || Weight.GetLength(1) == ReceivedArray.GetLength(1))
            {
                NumberOfTrainings++; // Увеличиваем количество обучений.
                for (int i = 0; i < Weight.GetLength(0); i++) // Идем по массиву.
                {
                    for (int j = 0; j < Weight.GetLength(1); j++) // Идем по массиву.
                    {
                        // Полученный массив должен состоять только из 0 и 1.
                        double temp = ReceivedArray[i, j] == 0 ? 0 : 1;
                        double func = 1 / (1 + Math.Exp(-alpha * temp)); // Функция активации
                        Weight[i,j] = (Weight[i,j] + func) / 2;
                        // Каждый элемент в памяти пересчитывается с учетом значения из полученного массива - ReceivedArray
                        if (Weight[i, j] > 1) Weight[i, j] = 1; // Если значение памяти больше 1, то присваиваем 1.
                        if (Weight[i, j] < 0) Weight[i, j] = 0; // Если значение памяти меньше 0, то присваиваем 0.
                    }
                }
            }
        }
    }
}
