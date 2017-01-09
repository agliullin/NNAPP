using System;
using System.Collections.Generic;
using System.IO;

namespace neural.app
{
    /*!
    * Класс, который хранит в себе нейроны.
    */
    public class NeuralNetwork
    {
        /// Количество по горизонтали.
        public const int ArrayWidth = 20;
        /// Количество по вертикали.
        public const int ArrayHeight = 20;
        /// Путь файла хранения сети.
        private const string Memory = @"memory.txt";
        /// Типизированный список нейронов.
        private List<Neuron> Neurons = null;

        /*!
        * Конструктор.
        */
        public NeuralNetwork()
        {
            Neurons = CreationNetwork();
        }
        /*!
        * Метод, который открывает файл хранения сети и данные из этого файла преобразовывает в типизированный список нейронов.
        */
        private static List<Neuron> CreationNetwork()
        {
            if (!File.Exists(Memory)) // Существует ли файл "Memory".
                return new List<Neuron>(); // Если не существует файл памяти, то выведем пустой список
            string[] lines = File.ReadAllLines(Memory); // Считываем все строки с файла "Memory".
            if (lines.Length == 0) // Если память пуста.
                return new List<Neuron>(); // Выведем пустой список.
            List<Neuron> res = new List<Neuron>(); // Создание списка.
            foreach (string line in lines) res.Add(CreationNeuron(line)); // Пока есть данные из памяти, создаем нейрон.
            return res; // Выводим список нейронов.
        }
        /*!
         * Метод, который преобразует полученную строку из памяти в класс нейрона.
         * \param line Строка из файла Memory.
         * \return neuron Нейрон.
         */
        private static Neuron CreationNeuron(string line)
        {
            Neuron neuron = new Neuron(); // Создаем нейрон.
            string []input = line.Split('#'); // Получаем строковый массив данных о нейроне, разделив полученную строку по знаку '#'.
            neuron.Name = input[0]; // Нейрону присвоим имя.
            neuron.NumberOfTrainings = Convert.ToInt32(input[1]); // Нейрону присвоим количество обучений.
            string[] weight = input[2].Split(';'); // Получаем строковый массив весов нейрона, разделив по знаку ';'.
            int arrSize = (int)Math.Sqrt(weight.Length); // Получаем размерность массива, т.к. массив квадратный используем Math.Sqrt().
            neuron.Weight = new double[arrSize, arrSize]; // Создаем массив весов для данного нейрона с определенной размерностью.
            int index = 0; // Индекс для того, чтобы пройти по всем полученным данным из памяти.
            for (int i = 0; i < arrSize; i++)
                for (int j = 0; j < arrSize; j++)
                {
                    neuron.Weight[i, j] = Double.Parse(weight[index]); // Преобразует строчное значение массива в double
                    index++;
                }
            return neuron; // Выводим нейрон.
        }
        /*!
         * Метод, который распознает полученный образ.
         * \param arr Массив весов.
         * \return result Результат распознавания (образ).
         */
        public string Recognition(int[,] arr)
        {
            string Result = null;
            double Value = 1;
            foreach (var Neuron in Neurons) // Проходимся по всем нейронам.
            {
                double Deviation = Neuron.GetResult(arr); // Берем среднеквадратичное отклонение данного образа от эталонного.
                if (Deviation < Value) // Если данное отклонение наименьшее.
                {
                    Value = Deviation; // Наименьшее отклонение
                    Result = Neuron.GetName(); // Берем имя образа с наименьшим среднеквадратичным отклонением.
                }
            }
            return Result; // Выводим название образа.
        }

        /*!
         * Метод, который возвращает массив имен всех имеющихся образов из памяти.
         * \return res Список названий образов.
         */
        public string[] GetNamesOfNeurons()
        {
            var res = new List<string>(); // Создаем список названий образов.
            for (int i = 0; i < Neurons.Count; i++)
                res.Add(Neurons[i].GetName()); // Добавляем названия образов нейронов.
            res.Sort(); // Сортируем полученные имена
            return res.ToArray(); // Выводим список, преобразовав в массив строк.
        }

        /*!
         * Метод, который заносит новый образ в память.
         * \param ReceivedName Имя образа.
         * \param ReceivedArray Полученный массив весов.
         */
        public void SetTraining(string ReceivedName, int[,] ReceivedArray)
        {
            Neuron Neuron = Neurons.Find(v => v.Name.Equals(ReceivedName)); // В типизированном списке ищем данный нейрон по полученному имени.
                                                                            // v => v.Name.Equals(ReceivedName) - предикат.
            if (Neuron == null) // Проверка наличия нейрона с таким именем. Если не существует, создадим новыи и добавим в память.
            {                   
                Neuron = new Neuron(); // Создаем нейрон.
                Neuron.Clear(ReceivedName, ArrayWidth, ArrayHeight); // Очищаем память.
                Neurons.Add(Neuron); // Добавляем нейрон в память.
            }
            Neuron.Training(ReceivedArray); // Обучим нейрон новому образу.
        }

        /*!
         * Метод, который сохраняет данные в память.
         */
        public void Save()
        {
            string text = "";
            foreach (var Neuron in Neurons) { // Проходим по всем нейронам из памяти.
                text += Neuron.Name + "#";
                text += Neuron.NumberOfTrainings.ToString() + "#";
                for (int i = 0; i < ArrayHeight; i++)
                {
                    for (int j = 0; j < ArrayWidth; j++)
                    {
                        text += Neuron.Weight[i,j].ToString() + ";";
                    }
                }
                text += "\n";
            }
            System.IO.File.WriteAllText(Memory, text); // Сохраняем память, в отформатированном виде в файл "Memory".
        }
    }
}
