using System;
using System.Windows.Forms;

namespace BookAndVisitor
{
    // ЗАДАЧА 1: Класс Book
    public class Book
    {
        // Публичные поля с значениями по умолчанию
        public string title = "Неизвестно";
        public string author = "Неизвестен";
        public int year = 0;

        // Метод, возвращающий информацию о книге в виде строки
        public string GetInfo()
        {
            return "«" + title + "», " + author + " (" + year + ")";
        }
    }

    // ЗАДАЧА 2: Класс Visitor
    public class Visitor
    {
        // Публичное поле для имени посетителя
        public string name;

        // Статическое поле — общее для всех объектов класса
        // Хранит количество созданных посетителей
        public static int totalVisitors = 0;

        // Конструктор, принимающий имя посетителя
        public Visitor(string visitorName)
        {
            name = visitorName;       // Сохраняем имя
            totalVisitors++;          // Увеличиваем общий счётчик на 1
        }

        // Метод, возвращающий имя конкретного посетителя
        public string PrintInfo()
        {
            return "Посетитель: " + name;
        }

        // Статический метод — вызывается через класс, а не через объект
        // Возвращает общее количество посетителей
        public static string ShowTotalVisitors()
        {
            return "Всего посетителей создано: " + totalVisitors;
        }
    }

    // ФОРМА
    public class Form1 : Form
    {
        // Элементы интерфейса
        private Button btnTask1;
        private Button btnTask2;
        private TextBox txtOutput;

        public Form1()
        {
            // Настройка формы
            this.Text = "Книжная полка и Умный счётчик";
            this.Width = 500;
            this.Height = 400;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Кнопка для запуска Задачи 1
            btnTask1 = new Button();
            btnTask1.Text = "Задача 1: Книги";
            btnTask1.Left = 20;
            btnTask1.Top = 20;
            btnTask1.Width = 200;
            btnTask1.Height = 40;
            btnTask1.Click += BtnTask1_Click;  // Привязываем обработчик нажатия
            this.Controls.Add(btnTask1);

            // Кнопка для запуска Задачи 2
            btnTask2 = new Button();
            btnTask2.Text = "Задача 2: Посетители";
            btnTask2.Left = 250;
            btnTask2.Top = 20;
            btnTask2.Width = 200;
            btnTask2.Height = 40;
            btnTask2.Click += BtnTask2_Click;  // Привязываем обработчик нажатия
            this.Controls.Add(btnTask2);

            // Текстовое поле для вывода результатов
            txtOutput = new TextBox();
            txtOutput.Left = 20;
            txtOutput.Top = 80;
            txtOutput.Width = 440;
            txtOutput.Height = 260;
            txtOutput.Multiline = true;         // Многострочный режим
            txtOutput.ReadOnly = true;          // Только для чтения
            txtOutput.ScrollBars = ScrollBars.Vertical;  // Вертикальная прокрутка
            txtOutput.Font = new System.Drawing.Font("Consolas", 11);
            this.Controls.Add(txtOutput);
        }

        // Обработчик кнопки Задачи 1
        private void BtnTask1_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();  // Очищаем текстовое поле

            // Создаём первый объект книги
            Book myBook = new Book();
            myBook.title = "Война и мир";
            myBook.author = "Лев Толстой";
            myBook.year = 1869;

            // Создаём второй объект книги (значения по умолчанию)
            Book unknownBook = new Book();

            // Выводим информацию
            txtOutput.AppendText("=== Задача 1: Книжная полка ===" + Environment.NewLine);
            txtOutput.AppendText(Environment.NewLine);
            txtOutput.AppendText("Книга 1: " + myBook.GetInfo() + Environment.NewLine);
            txtOutput.AppendText("Книга 2: " + unknownBook.GetInfo() + Environment.NewLine);
        }

        // Обработчик кнопки Задачи 2
        private void BtnTask2_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();  // Очищаем текстовое поле

            // Сбрасываем счётчик перед демонстрацией
            Visitor.totalVisitors = 0;

            // Создаём трёх посетителей
            Visitor v1 = new Visitor("Анна");
            Visitor v2 = new Visitor("Борис");
            Visitor v3 = new Visitor("Виктор");

            // Выводим информацию о каждом
            txtOutput.AppendText("=== Задача 2: Умный счётчик ===" + Environment.NewLine);
            txtOutput.AppendText(Environment.NewLine);
            txtOutput.AppendText(v1.PrintInfo() + Environment.NewLine);
            txtOutput.AppendText(v2.PrintInfo() + Environment.NewLine);
            txtOutput.AppendText(v3.PrintInfo() + Environment.NewLine);
            txtOutput.AppendText(Environment.NewLine);

            // Вызываем статический метод через имя класса
            txtOutput.AppendText(Visitor.ShowTotalVisitors() + Environment.NewLine);
        }
    }

    // ТОЧКА ВХОДА 
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());  // Запускаем форму
        }
    }
}
