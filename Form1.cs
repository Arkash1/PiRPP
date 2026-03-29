using System;
using System.Windows.Forms;

namespace ThreeTasks
{
    // ЗАДАЧА 1: Класс "Книга"
    // Создаём класс Book с публичными полями и методом вывода информации
    public class Book
    {
        // Публичное поле для названия книги с начальным значением
        public string title = "Неизвестно";
        // Публичное поле для автора книги
        public string author;
        // Публичное поле для года издания
        public int year;

        // Метод, возвращающий строку с информацией о книге
        public string DisplayInfo()
        {
            return "Название: " + title + ", Автор: " + author + ", Год: " + year;
        }
    }

    // ЗАДАЧА 2: Класс "Счёт в банке"
    // Создаём класс BankAccount с полями и методами для работы с балансом
    public class BankAccount
    {
        // Публичное поле для номера счёта
        public string accountNumber;
        // Публичное поле для баланса, начальное значение 0
        public double balance = 0;

        // Метод пополнения счёта, возвращает строку-сообщение
        public string Deposit(double amount)
        {
            // Увеличиваем баланс на указанную сумму
            balance += amount;
            return "Внесено " + amount + ". Текущий баланс: " + balance;
        }

        // Метод снятия со счёта, возвращает строку-сообщение
        public string Withdraw(double amount)
        {
            // Проверяем, хватает ли средств
            if (amount > balance)
            {
                return "Недостаточно средств";
            }
            // Уменьшаем баланс на указанную сумму
            balance -= amount;
            return "Снято " + amount + ". Текущий баланс: " + balance;
        }
    }

    // ЗАДАЧА 3: Структура "Точка"
    // Создаём структуру Point с полями координат и методами
    public struct Point
    {
        // Публичное поле координаты X
        public int X;
        // Публичное поле координаты Y
        public int Y;

        // Метод сдвига точки на заданные значения
        public void Move(int deltaX, int deltaY)
        {
            X += deltaX;
            Y += deltaY;
        }

        // Метод, возвращающий строку с координатами точки
        public string PrintCoordinates()
        {
            return "Точка: (" + X + ", " + Y + ")";
        }
    }

    // ФОРМА
    public partial class Form1 : Form
    {
        // Текстовое поле для вывода результатов
        private TextBox outputBox;
        // Три кнопки для запуска каждой задачи
        private Button btnTask1;
        private Button btnTask2;
        private Button btnTask3;

        public Form1()
        {
            // Настройка формы
            this.Text = "Три задачи ООП";
            this.Width = 600;
            this.Height = 500;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Создаём кнопку для задачи 1
            btnTask1 = new Button();
            btnTask1.Text = "Задача 1: Книга";
            btnTask1.Left = 20;
            btnTask1.Top = 20;
            btnTask1.Width = 170;
            btnTask1.Height = 35;
            // Привязываем обработчик нажатия
            btnTask1.Click += BtnTask1_Click;
            // Добавляем кнопку на форму
            this.Controls.Add(btnTask1);

            // Создаём кнопку для задачи 2
            btnTask2 = new Button();
            btnTask2.Text = "Задача 2: Банк";
            btnTask2.Left = 200;
            btnTask2.Top = 20;
            btnTask2.Width = 170;
            btnTask2.Height = 35;
            btnTask2.Click += BtnTask2_Click;
            this.Controls.Add(btnTask2);

            // Создаём кнопку для задачи 3
            btnTask3 = new Button();
            btnTask3.Text = "Задача 3: Точка";
            btnTask3.Left = 380;
            btnTask3.Top = 20;
            btnTask3.Width = 170;
            btnTask3.Height = 35;
            btnTask3.Click += BtnTask3_Click;
            this.Controls.Add(btnTask3);

            // Создаём многострочное текстовое поле для вывода
            outputBox = new TextBox();
            outputBox.Multiline = true;
            outputBox.Left = 20;
            outputBox.Top = 70;
            outputBox.Width = 540;
            outputBox.Height = 370;
            outputBox.ScrollBars = ScrollBars.Vertical;
            outputBox.ReadOnly = true;
            outputBox.Font = new System.Drawing.Font("Consolas", 10);
            this.Controls.Add(outputBox);
        }

        // Обработчик кнопки задачи 1
        private void BtnTask1_Click(object sender, EventArgs e)
        {
            // Очищаем поле вывода
            outputBox.Clear();
            // Добавляем заголовок
            AddLine("===== ЗАДАЧА 1: Класс «Книга» =====");
            AddLine("");

            // Создаём объект класса Book
            Book myBook = new Book();

            // Присваиваем значения полям объекта
            myBook.title = "Мастер и Маргарита";
            myBook.author = "Михаил Булгаков";
            myBook.year = 1967;

            // Вызываем метод DisplayInfo и выводим результат
            AddLine(myBook.DisplayInfo());
            AddLine("");

            // Выводим каждое поле по отдельности
            AddLine("Поле title: " + myBook.title);
            AddLine("Поле author: " + myBook.author);
            AddLine("Поле year: " + myBook.year);
        }

        // Обработчик кнопки задачи 2
        private void BtnTask2_Click(object sender, EventArgs e)
        {
            outputBox.Clear();
            AddLine("===== ЗАДАЧА 2: Класс «Счёт в банке» =====");
            AddLine("");

            // Создаём объект банковского счёта
            BankAccount account = new BankAccount();

            // Устанавливаем номер счёта
            account.accountNumber = "ACC-12345";
            AddLine("Создан счёт: " + account.accountNumber);
            AddLine("");

            // Вносим 500 на счёт
            AddLine(account.Deposit(500));

            // Снимаем 200 со счёта
            AddLine(account.Withdraw(200));

            // Пытаемся снять 400 (больше чем есть на балансе)
            AddLine(account.Withdraw(400));
        }

        // Обработчик кнопки задачи 3
        private void BtnTask3_Click(object sender, EventArgs e)
        {
            outputBox.Clear();
            AddLine("===== ЗАДАЧА 3: Структура «Точка» =====");
            AddLine("");

            // Способ 1: создание с помощью new (поля автоматически = 0)
            Point p1 = new Point();
            // Устанавливаем координаты
            p1.X = 10;
            p1.Y = 20;
            AddLine("p1 (создана через new):");
            AddLine(p1.PrintCoordinates());
            AddLine("");

            // Способ 2: без new (нужно вручную задать ВСЕ поля перед использованием)
            Point p2;
            p2.X = 3;
            p2.Y = 7;
            AddLine("p2 (создана без new):");
            AddLine(p2.PrintCoordinates());
            AddLine("");

            // Сдвигаем точку p1 на (5, -3)
            p1.Move(5, -3);
            AddLine("p1 после Move(5, -3):");
            AddLine(p1.PrintCoordinates());
        }

        // Вспомогательный метод: добавляет строку в текстовое поле
        private void AddLine(string text)
        {
            outputBox.AppendText(text + Environment.NewLine);
        }
    }
}