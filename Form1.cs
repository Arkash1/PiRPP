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
            Text = "Массивы";
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

        TabPage MakeTab(string title, string btnText, out TextBox inp, out TextBox outp, out Button btn)
        {
            var tab = new TabPage(title);
            inp = new TextBox { Location = new Point(20, 20), Size = new Size(500, 25) };
            btn = new Button { Text = btnText, Location = new Point(20, 55), Size = new Size(250, 35) };
            outp = new TextBox { Location = new Point(20, 100), Size = new Size(630, 370), Multiline = true, ReadOnly = true, ScrollBars = ScrollBars.Vertical };
            tab.Controls.AddRange(new Control[] { inp, btn, outp });
            return tab;
        }

        int[] Parse(string text)
        {
            try
            {
                string[] p = text.Trim().Split(' ');
                int[] a = new int[p.Length];
                for (int i = 0; i < p.Length; i++) a[i] = int.Parse(p[i]);
                return a;
            }
            catch { return null; }
        }

        // Задача 1
        TabPage Task1()
        {
            var tab = MakeTab("1.Сумма", "Посчитать", out var inp, out var outp, out var btn);
            inp.Text = "5 3 8 1 9 2 7 4 6 10";
            btn.Click += (s, e) =>
            {
                int[] a = Parse(inp.Text);
                if (a == null || a.Length != 10) { MessageBox.Show("Введите 10 чисел"); return; }
                int sum = 0;
                var sb = new StringBuilder();
                for (int i = 0; i < a.Length; i++)
                {
                    sum += a[i];
                    sb.AppendLine($"+ {a[i]} = {sum}");
                }
                sb.AppendLine($"\nИтого: {sum}");
                outp.Text = sb.ToString();
            };
            return tab;
        }

        // Задача 2
        TabPage Task2()
        {
            var tab = MakeTab("2.Мин/Макс", "Генерировать", out var inp, out var outp, out var btn);
            inp.Text = "10";
            btn.Click += (s, e) =>
            {
                if (!int.TryParse(inp.Text, out int n) || n < 1) { MessageBox.Show("Введите N"); return; }
                var rnd = new Random();
                int[] a = new int[n];
                for (int i = 0; i < n; i++) a[i] = rnd.Next(1, 101);

                int max = a[0], min = a[0], maxI = 0, minI = 0;
                for (int i = 1; i < n; i++)
                {
                    if (a[i] > max) { max = a[i]; maxI = i; }
                    if (a[i] < min) { min = a[i]; minI = i; }
                }
                outp.Text = $"Массив: {string.Join(", ", a)}\n\nМакс: {max} [индекс {maxI}]\nМин: {min} [индекс {minI}]";
            };
            return tab;
        }

        // Задача 3
        TabPage Task3()
        {
            var tab = MakeTab("3.Чёт/Нечёт", "Генерировать", out var inp, out var outp, out var btn);
            inp.Visible = false;
            btn.Click += (s, e) =>
            {
                var rnd = new Random();
                int[] a = new int[15];
                for (int i = 0; i < 15; i++) a[i] = rnd.Next(10, 51);

                int even = 0, odd = 0;
                foreach (int x in a)
                {
                    if (x % 2 == 0) even++;
                    else odd++;
                }
                outp.Text = $"Массив: {string.Join(", ", a)}\n\nЧётных: {even}\nНечётных: {odd}";
            };
            return tab;
        }

        // Задача 4
        TabPage Task4()
        {
            var tab = MakeTab("4.Реверс", "Перевернуть", out var inp, out var outp, out var btn);
            inp.Text = "10 20 30 40 50";
            btn.Click += (s, e) =>
            {
                int[] a = Parse(inp.Text);
                if (a == null || a.Length != 5) { MessageBox.Show("Введите 5 чисел"); return; }
                string before = string.Join(", ", a);

                for (int i = 0; i < a.Length / 2; i++)
                {
                    int tmp = a[i];
                    a[i] = a[a.Length - 1 - i];
                    a[a.Length - 1 - i] = tmp;
                }
                outp.Text = $"До: {before}\nПосле: {string.Join(", ", a)}";
            };
            return tab;
        }

        // Задача 5
        TabPage Task5()
        {
            var tab = MakeTab("5.Сдвиг", "Сдвинуть", out var inp, out var outp, out var btn);
            inp.Text = "1 2 3 4 5";
            btn.Click += (s, e) =>
            {
                int[] a = Parse(inp.Text);
                if (a == null || a.Length < 2) { MessageBox.Show("Введите числа"); return; }
                string before = string.Join(", ", a);

                int last = a[a.Length - 1];
                for (int i = a.Length - 1; i > 0; i--)
                    a[i] = a[i - 1];
                a[0] = last;

                outp.Text = $"До: {before}\nПосле: {string.Join(", ", a)}";
            };
            return tab;
        }

        // Задача 6
        TabPage Task6()
        {
            var tab = MakeTab("6.Дубликаты", "Подсчитать", out var inp, out var outp, out var btn);
            inp.Text = "3 7 3 2 7 7 1 2 3 5";
            btn.Click += (s, e) =>
            {
                int[] a = Parse(inp.Text);
                if (a == null || a.Length != 10) { MessageBox.Show("Введите 10 чисел"); return; }

                bool[] done = new bool[10];
                var sb = new StringBuilder();
                for (int i = 0; i < a.Length; i++)
                {
                    if (done[i]) continue;
                    int count = 0;
                    for (int j = 0; j < a.Length; j++)
                        if (a[j] == a[i]) { count++; done[j] = true; }
                    sb.AppendLine($"Число {a[i]} — {count} раз(а)");
                }
                outp.Text = sb.ToString();
            };
            return tab;
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }
}
