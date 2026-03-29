using System;
using System.Windows.Forms;

namespace HelloAndAge
{
    public partial class Form1 : Form
    {
        // Текстовое поле для вывода результатов
        TextBox outputBox;

        public Form1()
        {
            // Настраиваем размер формы
            this.Text = "Задачи 1 и 2";
            this.Width = 500;
            this.Height = 400;

            // Кнопка для запуска Задачи 1
            Button btnTask1 = new Button();
            btnTask1.Text = "Задача 1: Приветствие";
            btnTask1.Left = 20;
            btnTask1.Top = 20;
            btnTask1.Width = 200;
            btnTask1.Click += BtnTask1_Click;
            this.Controls.Add(btnTask1);

            // Кнопка для запуска Задачи 2
            Button btnTask2 = new Button();
            btnTask2.Text = "Задача 2: Возраст";
            btnTask2.Left = 240;
            btnTask2.Top = 20;
            btnTask2.Width = 200;
            btnTask2.Click += BtnTask2_Click;
            this.Controls.Add(btnTask2);

            // Многострочное текстовое поле для вывода результатов
            outputBox = new TextBox();
            outputBox.Multiline = true;
            outputBox.Left = 20;
            outputBox.Top = 60;
            outputBox.Width = 440;
            outputBox.Height = 280;
            outputBox.ReadOnly = true;
            outputBox.ScrollBars = ScrollBars.Vertical;
            this.Controls.Add(outputBox);
        }

        // ЗАДАЧА 1

        // Метод SayHelloTo принимает строковый параметр name
        // и возвращает строку с приветствием
        void SayHelloTo(string name)
        {
            // Добавляем приветствие в текстовое поле
            outputBox.AppendText("Hello, " + name + "!" + Environment.NewLine);
        }

        // Обработчик нажатия кнопки Задачи 1
        private void BtnTask1_Click(object sender, EventArgs e)
        {
            // Очищаем поле вывода
            outputBox.Clear();
            outputBox.AppendText("=== Задача 1: Приветствие ===" + Environment.NewLine);

            // Вызываем метод три раза с разными именами
            SayHelloTo("Tom");
            SayHelloTo("Bob");
            SayHelloTo("Alice");
        }

        // ЗАДАЧА 2

        // Метод CalculateAge в сокращённой форме (с использованием =>)
        // Принимает два параметра: год рождения и текущий год
        // Возвращает вычисленный возраст
        int CalculateAge(int birthYear, int currentYear) => currentYear - birthYear;

        // Обработчик нажатия кнопки Задачи 2
        private void BtnTask2_Click(object sender, EventArgs e)
        {
            // Очищаем поле вывода
            outputBox.Clear();
            outputBox.AppendText("=== Задача 2: Калькулятор возраста ===" + Environment.NewLine);

            // Вызов метода для человека 1990 года рождения
            int age1 = CalculateAge(1990, 2024);
            outputBox.AppendText("Возраст: " + age1 + " лет" + Environment.NewLine);

            // Вызов метода для человека 2005 года рождения
            int age2 = CalculateAge(2005, 2024);
            outputBox.AppendText("Возраст: " + age2 + " лет" + Environment.NewLine);
        }
    }
}