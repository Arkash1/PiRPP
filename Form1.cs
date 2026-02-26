using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ArrayTasks
{
    public class Form1 : Form
    {
        private TabControl tabs;

        public Form1()
        {
            Text = "Задачи с массивами";
            Size = new Size(700, 550);
            StartPosition = FormStartPosition.CenterScreen;

            tabs = new TabControl { Dock = DockStyle.Fill };

            tabs.TabPages.Add(Task1());
            tabs.TabPages.Add(Task2());
            tabs.TabPages.Add(Task3());
            tabs.TabPages.Add(Task4());
            tabs.TabPages.Add(Task5());
            tabs.TabPages.Add(Task6());

            Controls.Add(tabs);
        }

        // Помощник: создаёт вкладку с полем ввода, кнопкой и полем вывода
        TabPage MakeTab(string title, string btnText, Color color,
                        out TextBox input, out TextBox output, out Button btn)
        {
            var tab = new TabPage(title) { BackColor = Color.White };

            input = new TextBox { Location = new Point(20, 20), Size = new Size(500, 25) };

            btn = new Button
            {
                Text = btnText,
                Location = new Point(20, 55),
                Size = new Size(250, 35),
                BackColor = color
            };

            output = new TextBox
            {
                Location = new Point(20, 100),
                Size = new Size(630, 370),
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical
            };

            tab.Controls.AddRange(new Control[] { input, btn, output });
            return tab;
        }

        // ЗАДАЧА 1: Сумма 10 чисел
        TabPage Task1()
        {
            var tab = MakeTab("1. Сумма", "Посчитать сумму", Color.LightSteelBlue,
                              out var inp, out var outp, out var btn);
            inp.Text = "5 3 8 1 9 2 7 4 6 10";

            btn.Click += (s, e) =>
            {
                int[] a = Parse(inp.Text);
                if (a == null || a.Length != 10) { Msg("Введите 10 чисел"); return; }

                int sum = 0;
                var sb = new StringBuilder("Массив: " + string.Join(", ", a) + "\r\n\r\n");

                for (int i = 0; i < a.Length; i++)
                {
                    sum += a[i];
                    sb.AppendLine($"  + {a[i]} = {sum}");
                }
                sb.AppendLine($"\r\nСумма = {sum}");
                outp.Text = sb.ToString();
            };
            return tab;
        }

        // ЗАДАЧА 2: Максимум и минимум
        TabPage Task2()
        {
            var tab = MakeTab("2. Мин/Макс", "Сгенерировать", Color.LightGreen,
                              out var inp, out var outp, out var btn);
            inp.Text = "10";

            btn.Click += (s, e) =>
            {
                if (!int.TryParse(inp.Text, out int n) || n < 1) { Msg("Введите N"); return; }

                var rnd = new Random();
                int[] a = new int[n];
                for (int i = 0; i < n; i++) a[i] = rnd.Next(1, 101);

                int max = a[0], min = a[0], maxI = 0, minI = 0;
                for (int i = 1; i < n; i++)
                {
                    if (a[i] > max) { max = a[i]; maxI = i; }
                    if (a[i] < min) { min = a[i]; minI = i; }
                }

                var sb = new StringBuilder("Массив: " + string.Join(", ", a) + "\r\n\r\n");
                sb.AppendLine($"Максимум: {max} (индекс {maxI})");
                sb.AppendLine($"Минимум:  {min} (индекс {minI})");
                outp.Text = sb.ToString();
            };
            return tab;
        }

        // ЗАДАЧА 3: Чётные / нечётные
        TabPage Task3()
        {
            var tab = MakeTab("3. Чёт/Нечёт", "Сгенерировать", Color.LightCoral,
                              out var inp, out var outp, out var btn);
            inp.Visible = false;

            btn.Click += (s, e) =>
            {
                var rnd = new Random();
                int[] a = new int[15];
                for (int i = 0; i < 15; i++) a[i] = rnd.Next(10, 51);

                int even = 0, odd = 0;
                var sb = new StringBuilder("Массив: " + string.Join(", ", a) + "\r\n\r\n");

                foreach (int x in a)
                {
                    if (x % 2 == 0) { even++; sb.AppendLine($"  {x} — чётное"); }
                    else { odd++; sb.AppendLine($"  {x} — нечётное"); }
                }
                sb.AppendLine($"\r\nЧётных: {even}, Нечётных: {odd}");
                outp.Text = sb.ToString();
            };
            return tab;
        }

        // ЗАДАЧА 4: Реверс
        TabPage Task4()
        {
            var tab = MakeTab("4. Реверс", "Перевернуть", Color.Khaki,
                              out var inp, out var outp, out var btn);
            inp.Text = "10 20 30 40 50";

            btn.Click += (s, e) =>
            {
                int[] a = Parse(inp.Text);
                if (a == null || a.Length != 5) { Msg("Введите 5 чисел"); return; }

                var sb = new StringBuilder("До:    " + string.Join(", ", a) + "\r\n\r\n");

                // Реверс на месте
                for (int i = 0; i < a.Length / 2; i++)
                {
                    int tmp = a[i];
                    a[i] = a[a.Length - 1 - i];
                    a[a.Length - 1 - i] = tmp;
                    sb.AppendLine($"  Меняем [{i}] и [{a.Length - 1 - i}]: {string.Join(", ", a)}");
                }
                sb.AppendLine($"\r\nПосле: {string.Join(", ", a)}");
                outp.Text = sb.ToString();
            };
            return tab;
        }

        // ЗАДАЧА 5: Сдвиг вправо
        TabPage Task5()
        {
            var tab = MakeTab("5. Сдвиг", "Сдвинуть вправо", Color.LightSkyBlue,
                              out var inp, out var outp, out var btn);
            inp.Text = "1 2 3 4 5";

            btn.Click += (s, e) =>
            {
                int[] a = Parse(inp.Text);
                if (a == null || a.Length < 2) { Msg("Введите хотя бы 2 числа"); return; }

                var sb = new StringBuilder("До:    " + string.Join(", ", a) + "\r\n\r\n");

                int last = a[a.Length - 1];
                for (int i = a.Length - 1; i > 0; i--)
                    a[i] = a[i - 1];
                a[0] = last;

                sb.AppendLine("После: " + string.Join(", ", a));
                outp.Text = sb.ToString();
            };
            return tab;
        }

        // ЗАДАЧА 6: Дубликаты
        TabPage Task6()
        {
            var tab = MakeTab("6. Дубликаты", "Подсчитать", Color.Plum,
                              out var inp, out var outp, out var btn);
            inp.Text = "3 7 3 2 7 7 1 2 3 5";

            btn.Click += (s, e) =>
            {
                int[] a = Parse(inp.Text);
                if (a == null || a.Length != 10) { Msg("Введите 10 чисел"); return; }

                bool[] done = new bool[10];
                var sb = new StringBuilder("Массив: " + string.Join(", ", a) + "\r\n\r\n");

                for (int i = 0; i < a.Length; i++)
                {
                    if (done[i]) continue;
                    int count = 0;
                    for (int j = 0; j < a.Length; j++)
                    {
                        if (a[j] == a[i]) { count++; done[j] = true; }
                    }
                    sb.AppendLine($"  Число {a[i]} встречается {count} раз(а)");
                }
                outp.Text = sb.ToString();
            };
            return tab;
        }

        // Вспомогательные методы 
        int[] Parse(string text)
        {
            try
            {
                var parts = text.Trim().Split(new[] { ' ', ',', ';' },
                            StringSplitOptions.RemoveEmptyEntries);
                int[] arr = new int[parts.Length];
                for (int i = 0; i < parts.Length; i++)
                    arr[i] = int.Parse(parts[i]);
                return arr;
            }
            catch { return null; }
        }

        void Msg(string text) => MessageBox.Show(text, "Ошибка");

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }
} 

