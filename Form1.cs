using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArrayTasks
{
    public class Form1 : Form
    {
        // Главные элементы управления
        private TabControl tabControl;

        public Form1()
        {
            this.Text = "Задачи с массивами — C# Windows Forms";
            this.Size = new Size(750, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 10);

            tabControl = new TabControl();
            tabControl.Dock = DockStyle.Fill;

            // Создаём вкладки для каждой задачи
            tabControl.TabPages.Add(CreateTask1Tab());
            tabControl.TabPages.Add(CreateTask2Tab());
            tabControl.TabPages.Add(CreateTask3Tab());
            tabControl.TabPages.Add(CreateTask4Tab());
            tabControl.TabPages.Add(CreateTask5Tab());
            tabControl.TabPages.Add(CreateTask6Tab());

            this.Controls.Add(tabControl);
        }

        // =====================================================
        // ЗАДАЧА 1: Сумма элементов массива (10 чисел)
        // =====================================================
        private TabPage CreateTask1Tab()
        {
            TabPage tab = new TabPage("Задача 1");
            tab.BackColor = Color.White;

            Label lblTitle = new Label
            {
                Text = "Задача 1: Сумма элементов массива (10 чисел)",
                Location = new Point(20, 15),
                AutoSize = true,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };

            Label lblInput = new Label
            {
                Text = "Введите 10 чисел через пробел:",
                Location = new Point(20, 55),
                AutoSize = true
            };

            TextBox txtInput1 = new TextBox
            {
                Location = new Point(20, 85),
                Size = new Size(500, 30)
            };

            Button btnCalc1 = new Button
            {
                Text = "Вычислить сумму",
                Location = new Point(20, 125),
                Size = new Size(200, 40),
                BackColor = Color.LightSteelBlue
            };

            TextBox txtOutput1 = new TextBox
            {
                Location = new Point(20, 180),
                Size = new Size(680, 300),
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical
            };

            btnCalc1.Click += (sender, e) =>
            {
                try
                {
                    // Разбиваем строку по пробелам и преобразуем в числа
                    string[] parts = txtInput1.Text.Trim().Split(
                        new[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length != 10)
                    {
                        MessageBox.Show("Нужно ввести ровно 10 чисел!", "Ошибка");
                        return;
                    }

                    int[] array = new int[10];
                    for (int i = 0; i < 10; i++)
                    {
                        array[i] = int.Parse(parts[i]);
                    }

                    // Вычисляем сумму
                    int sum = 0;
                    for (int i = 0; i < array.Length; i++)
                    {
                        sum += array[i];
                    }

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Массив: " + string.Join(", ", array));
                    sb.AppendLine();
                    sb.AppendLine("Пошаговое сложение:");
                    int runningSum = 0;
                    for (int i = 0; i < array.Length; i++)
                    {
                        runningSum += array[i];
                        sb.AppendLine($"  Шаг {i + 1}: добавляем {array[i]} → текущая сумма = {runningSum}");
                    }
                    sb.AppendLine();
                    sb.AppendLine($"ИТОГО: Сумма всех элементов = {sum}");

                    txtOutput1.Text = sb.ToString();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Введите корректные целые числа!", "Ошибка");
                }
            };

            tab.Controls.AddRange(new Control[] { lblTitle, lblInput, txtInput1, btnCalc1, txtOutput1 });
            return tab;
        }

        // =====================================================
        // ЗАДАЧА 2: Поиск максимума и минимума
        // =====================================================
        private TabPage CreateTask2Tab()
        {
            TabPage tab = new TabPage("Задача 2");
            tab.BackColor = Color.White;

            Label lblTitle = new Label
            {
                Text = "Задача 2: Максимум и минимум (случайные числа 1–100)",
                Location = new Point(20, 15),
                AutoSize = true,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };

            Label lblN = new Label
            {
                Text = "Размер массива N:",
                Location = new Point(20, 55),
                AutoSize = true
            };

            NumericUpDown numN = new NumericUpDown
            {
                Location = new Point(200, 52),
                Size = new Size(80, 30),
                Minimum = 1,
                Maximum = 100,
                Value = 10
            };

            Button btnGen2 = new Button
            {
                Text = "Сгенерировать и найти",
                Location = new Point(300, 47),
                Size = new Size(230, 40),
                BackColor = Color.LightGreen
            };

            TextBox txtOutput2 = new TextBox
            {
                Location = new Point(20, 100),
                Size = new Size(680, 380),
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical
            };

            btnGen2.Click += (sender, e) =>
            {
                int n = (int)numN.Value;
                Random rnd = new Random();

                int[] array = new int[n];
                for (int i = 0; i < n; i++)
                {
                    array[i] = rnd.Next(1, 101); // от 1 до 100
                }

                // Поиск максимума и минимума
                int max = array[0];
                int min = array[0];
                int maxIndex = 0;
                int minIndex = 0;

                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i] > max)
                    {
                        max = array[i];
                        maxIndex = i;
                    }
                    if (array[i] < min)
                    {
                        min = array[i];
                        minIndex = i;
                    }
                }

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Массив:");
                for (int i = 0; i < array.Length; i++)
                {
                    string marker = "";
                    if (i == maxIndex) marker = " ← MAX";
                    if (i == minIndex) marker = " ← MIN";
                    sb.AppendLine($"  [{i}] = {array[i]}{marker}");
                }
                sb.AppendLine();
                sb.AppendLine($"Максимальный элемент: {max} (индекс {maxIndex})");
                sb.AppendLine($"Минимальный элемент: {min} (индекс {minIndex})");

                txtOutput2.Text = sb.ToString();
            };

            tab.Controls.AddRange(new Control[] { lblTitle, lblN, numN, btnGen2, txtOutput2 });
            return tab;
        }

        // =====================================================
        // ЗАДАЧА 3: Подсчёт чётных и нечётных (foreach)
        // =====================================================
        private TabPage CreateTask3Tab()
        {
            TabPage tab = new TabPage("Задача 3");
            tab.BackColor = Color.White;

            Label lblTitle = new Label
            {
                Text = "Задача 3: Чётные и нечётные (15 случайных, 10–50)",
                Location = new Point(20, 15),
                AutoSize = true,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };

            Button btnGen3 = new Button
            {
                Text = "Сгенерировать и подсчитать",
                Location = new Point(20, 55),
                Size = new Size(280, 40),
                BackColor = Color.LightCoral
            };

            TextBox txtOutput3 = new TextBox
            {
                Location = new Point(20, 110),
                Size = new Size(680, 370),
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical
            };

            btnGen3.Click += (sender, e) =>
            {
                Random rnd = new Random();
                int[] array = new int[15];

                for (int i = 0; i < 15; i++)
                {
                    array[i] = rnd.Next(10, 51); // от 10 до 50
                }

                // Подсчёт через foreach
                int evenCount = 0;
                int oddCount = 0;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Массив: " + string.Join(", ", array));
                sb.AppendLine();
                sb.AppendLine("Анализ каждого элемента (foreach):");

                foreach (int num in array)
                {
                    if (num % 2 == 0)
                    {
                        evenCount++;
                        sb.AppendLine($"  {num} — чётное ✓");
                    }
                    else
                    {
                        oddCount++;
                        sb.AppendLine($"  {num} — нечётное ✗");
                    }
                }

                sb.AppendLine();
                sb.AppendLine($"Итого чётных: {evenCount}");
                sb.AppendLine($"Итого нечётных: {oddCount}");

                txtOutput3.Text = sb.ToString();
            };

            tab.Controls.AddRange(new Control[] { lblTitle, btnGen3, txtOutput3 });
            return tab;
        }

        // =====================================================
        // ЗАДАЧА 4: Реверс массива
        // =====================================================
        private TabPage CreateTask4Tab()
        {
            TabPage tab = new TabPage("Задача 4");
            tab.BackColor = Color.White;

            Label lblTitle = new Label
            {
                Text = "Задача 4: Реверс массива (5 чисел)",
                Location = new Point(20, 15),
                AutoSize = true,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };

            Label lblInput = new Label
            {
                Text = "Введите 5 чисел через пробел:",
                Location = new Point(20, 55),
                AutoSize = true
            };

            TextBox txtInput4 = new TextBox
            {
                Location = new Point(20, 85),
                Size = new Size(400, 30)
            };

            Button btnReverse4 = new Button
            {
                Text = "Реверс (новый массив)",
                Location = new Point(20, 125),
                Size = new Size(220, 40),
                BackColor = Color.Khaki
            };

            Button btnReverseInPlace = new Button
            {
                Text = "Реверс (на месте)",
                Location = new Point(260, 125),
                Size = new Size(220, 40),
                BackColor = Color.Gold
            };

            TextBox txtOutput4 = new TextBox
            {
                Location = new Point(20, 180),
                Size = new Size(680, 300),
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical
            };

            // Способ 1: создаём новый массив
            btnReverse4.Click += (sender, e) =>
            {
                try
                {
                    string[] parts = txtInput4.Text.Trim().Split(
                        new[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length != 5)
                    {
                        MessageBox.Show("Нужно ввести ровно 5 чисел!", "Ошибка");
                        return;
                    }

                    int[] original = new int[5];
                    for (int i = 0; i < 5; i++)
                        original[i] = int.Parse(parts[i]);

                    // Создаём новый массив в обратном порядке
                    int[] reversed = new int[5];
                    for (int i = 0; i < 5; i++)
                    {
                        reversed[i] = original[4 - i];
                    }

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("=== Способ 1: Новый массив ===");
                    sb.AppendLine();
                    sb.AppendLine("Исходный массив:    " + string.Join(", ", original));
                    sb.AppendLine("Обратный массив:    " + string.Join(", ", reversed));
                    sb.AppendLine();
                    sb.AppendLine("Как это работает:");
                    for (int i = 0; i < 5; i++)
                    {
                        sb.AppendLine($"  reversed[{i}] = original[{4 - i}] = {original[4 - i]}");
                    }

                    txtOutput4.Text = sb.ToString();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Введите корректные целые числа!", "Ошибка");
                }
            };

            // Способ 2: реверс на месте (без второго массива)
            btnReverseInPlace.Click += (sender, e) =>
            {
                try
                {
                    string[] parts = txtInput4.Text.Trim().Split(
                        new[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length != 5)
                    {
                        MessageBox.Show("Нужно ввести ровно 5 чисел!", "Ошибка");
                        return;
                    }

                    int[] array = new int[5];
                    for (int i = 0; i < 5; i++)
                        array[i] = int.Parse(parts[i]);

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("=== Способ 2: Реверс на месте ===");
                    sb.AppendLine();
                    sb.AppendLine("До реверса: " + string.Join(", ", array));
                    sb.AppendLine();

                    // Меняем местами элементы с начала и с конца
                    for (int i = 0; i < array.Length / 2; i++)
                    {
                        int temp = array[i];
                        array[i] = array[array.Length - 1 - i];
                        array[array.Length - 1 - i] = temp;

                        sb.AppendLine($"  Меняем [{i}] и [{array.Length - 1 - i}]: " +
                                      string.Join(", ", array));
                    }

                    sb.AppendLine();
                    sb.AppendLine("После реверса: " + string.Join(", ", array));

                    txtOutput4.Text = sb.ToString();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Введите корректные целые числа!", "Ошибка");
                }
            };

            tab.Controls.AddRange(new Control[] { lblTitle, lblInput, txtInput4,
                                                   btnReverse4, btnReverseInPlace, txtOutput4 });
            return tab;
        }

        // =====================================================
        // ЗАДАЧА 5: Циклический сдвиг вправо
        // =====================================================
        private TabPage CreateTask5Tab()
        {
            TabPage tab = new TabPage("Задача 5");
            tab.BackColor = Color.White;

            Label lblTitle = new Label
            {
                Text = "Задача 5: Циклический сдвиг вправо на 1 позицию",
                Location = new Point(20, 15),
                AutoSize = true,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };

            Label lblInput = new Label
            {
                Text = "Введите числа через пробел (любое количество):",
                Location = new Point(20, 55),
                AutoSize = true
            };

            TextBox txtInput5 = new TextBox
            {
                Location = new Point(20, 85),
                Size = new Size(500, 30),
                Text = "1 2 3 4 5"
            };

            Button btnShift5 = new Button
            {
                Text = "Сдвинуть вправо",
                Location = new Point(20, 125),
                Size = new Size(200, 40),
                BackColor = Color.LightSkyBlue
            };

            TextBox txtOutput5 = new TextBox
            {
                Location = new Point(20, 180),
                Size = new Size(680, 300),
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical
            };

            btnShift5.Click += (sender, e) =>
            {
                try
                {
                    string[] parts = txtInput5.Text.Trim().Split(
                        new[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length < 2)
                    {
                        MessageBox.Show("Введите хотя бы 2 числа!", "Ошибка");
                        return;
                    }

                    int[] array = new int[parts.Length];
                    for (int i = 0; i < parts.Length; i++)
                        array[i] = int.Parse(parts[i]);

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("До сдвига:    " + string.Join(", ", array));
                    sb.AppendLine();

                    // Сохраняем последний элемент
                    int last = array[array.Length - 1];
                    sb.AppendLine($"Шаг 1: Запоминаем последний элемент: {last}");
                    sb.AppendLine();

                    // Сдвигаем все элементы вправо на 1, начиная с конца
                    sb.AppendLine("Шаг 2: Сдвигаем элементы вправо:");
                    for (int i = array.Length - 1; i > 0; i--)
                    {
                        array[i] = array[i - 1];
                        sb.AppendLine($"  array[{i}] = array[{i - 1}] → " +
                                      string.Join(", ", array));
                    }

                    // Ставим последний на первое место
                    array[0] = last;
                    sb.AppendLine();
                    sb.AppendLine($"Шаг 3: Ставим {last} на позицию [0]");
                    sb.AppendLine();
                    sb.AppendLine("После сдвига: " + string.Join(", ", array));

                    txtOutput5.Text = sb.ToString();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Введите корректные целые числа!", "Ошибка");
                }
            };

            tab.Controls.AddRange(new Control[] { lblTitle, lblInput, txtInput5, btnShift5, txtOutput5 });
            return tab;
        }

        // =====================================================
        // ЗАДАЧА 6: Подсчёт дубликатов
        // =====================================================
        private TabPage CreateTask6Tab()
        {
            TabPage tab = new TabPage("Задача 6");
            tab.BackColor = Color.White;

            Label lblTitle = new Label
            {
                Text = "Задача 6: Подсчёт дубликатов (10 чисел)",
                Location = new Point(20, 15),
                AutoSize = true,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };

            Label lblInput = new Label
            {
                Text = "Введите 10 чисел через пробел:",
                Location = new Point(20, 55),
                AutoSize = true
            };

            TextBox txtInput6 = new TextBox
            {
                Location = new Point(20, 85),
                Size = new Size(500, 30),
                Text = "3 7 3 2 7 7 1 2 3 5"
            };

            Button btnCount6 = new Button
            {
                Text = "Подсчитать дубликаты",
                Location = new Point(20, 125),
                Size = new Size(230, 40),
                BackColor = Color.Plum
            };

            TextBox txtOutput6 = new TextBox
            {
                Location = new Point(20, 180),
                Size = new Size(680, 300),
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical
            };

            btnCount6.Click += (sender, e) =>
            {
                try
                {
                    string[] parts = txtInput6.Text.Trim().Split(
                        new[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length != 10)
                    {
                        MessageBox.Show("Нужно ввести ровно 10 чисел!", "Ошибка");
                        return;
                    }

                    int[] array = new int[10];
                    for (int i = 0; i < 10; i++)
                        array[i] = int.Parse(parts[i]);

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Массив: " + string.Join(", ", array));
                    sb.AppendLine();
                    sb.AppendLine("Подсчёт вхождений (вложенные циклы):");
                    sb.AppendLine();

                    // Массив-флаг: уже посчитали это число или нет
                    bool[] counted = new bool[10];

                    for (int i = 0; i < array.Length; i++)
                    {
                        // Если это число уже считали — пропускаем
                        if (counted[i])
                            continue;

                        int count = 0;

                        // Считаем, сколько раз array[i] встречается во всём массиве
                        for (int j = 0; j < array.Length; j++)
                        {
                            if (array[j] == array[i])
                            {
                                count++;
                                counted[j] = true; // помечаем как посчитанное
                            }
                        }

                        // Подбираем правильное слово
                        string word = "раз";
                        if (count == 1) word = "раз";
                        else if (count >= 2 && count <= 4) word = "раза";

                        sb.AppendLine($"  Число {array[i]} встречается {count} {word}");
                    }

                    txtOutput6.Text = sb.ToString();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Введите корректные целые числа!", "Ошибка");
                }
            };

            tab.Controls.AddRange(new Control[] { lblTitle, lblInput, txtInput6, btnCount6, txtOutput6 });
            return tab;
        }

        // =====================================================
        // Точка входа
        // =====================================================
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}