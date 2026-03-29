using System;
using System.Windows.Forms;

// КЛАССЫ ДЛЯ ЗАДАЧ 

// Задача 1: Класс "Книга"
public class Book
{
    public string title = "Неизвестно"; // поле с значением по умолчанию
    public int pages;                    // поле для количества страниц

    // Метод, возвращающий информацию о книге в виде строки
    public string GetInfo()
    {
        return "Книга: " + title + ", страниц: " + pages;
    }
}

// Задача 2: Класс "Студент"
public class Student
{
    public string name; // поле для имени
    public int age;     // поле для возраста

    // Конструктор без параметров — вызывает конструктор с двумя параметрами через this
    public Student() : this("Иван", 18)
    {
    }

    // Конструктор с одним параметром — вызывает конструктор с двумя параметрами через this
    public Student(string name) : this(name, 18)
    {
    }

    // Конструктор с двумя параметрами — основной
    public Student(string name, int age)
    {
        this.name = name; // this отличает поле класса от параметра
        this.age = age;
    }

    // Метод, возвращающий информацию о студенте
    public string PrintInfo()
    {
        return "Имя: " + name + ", Возраст: " + age;
    }
}

// Задача 3: Класс "Автомобиль"
public class Car
{
    public string brand = "Unknown"; // марка по умолчанию
    public string model = "Unknown"; // модель по умолчанию
    public int year = 2000;          // год по умолчанию

    // Пустой конструктор (без параметров)
    public Car()
    {
    }

    // Метод, возвращающий информацию об автомобиле
    public string GetInfo()
    {
        return brand + " " + model + " (" + year + ")";
    }
}

// Задача 4: Класс "Треугольник"
public class Triangle
{
    public double a; // сторона a
    public double b; // сторона b
    public double c; // сторона c

    // Конструктор с тремя параметрами, this разрешает конфликт имён
    public Triangle(double a, double b, double c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    // Метод проверки существования треугольника
    public bool IsValid()
    {
        return (a + b > c) && (a + c > b) && (b + c > a);
    }

    // Метод, возвращающий стороны в виде строки
    public string PrintSides()
    {
        return "Стороны: a=" + a + ", b=" + b + ", c=" + c;
    }
}

// Задача 5: Класс "Точка"
public class Point
{
    public int X = 0; // координата X по умолчанию
    public int Y = 0; // координата Y по умолчанию

    // Конструктор для инициализации координат
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    // Метод деконструкции — раскладывает объект на две переменные
    public void Deconstruct(out int x, out int y)
    {
        x = X; // передаём значение X наружу
        y = Y; // передаём значение Y наружу
    }
}

// ФОРМА 

public class Form1 : Form
{
    private TextBox outputBox; // текстовое поле для вывода результатов
    private Button btnTask1;   // кнопка для задачи 1
    private Button btnTask2;   // кнопка для задачи 2
    private Button btnTask3;   // кнопка для задачи 3
    private Button btnTask4;   // кнопка для задачи 4
    private Button btnTask5;   // кнопка для задачи 5
    private Button btnAll;     // кнопка для запуска всех задач

    public Form1()
    {
        // Настройка формы
        this.Text = "5 задач ООП";
        this.Width = 620;
        this.Height = 520;
        this.StartPosition = FormStartPosition.CenterScreen;

        // Создаём кнопки
        btnTask1 = new Button() { Text = "Задача 1", Left = 10, Top = 10, Width = 90 };
        btnTask2 = new Button() { Text = "Задача 2", Left = 105, Top = 10, Width = 90 };
        btnTask3 = new Button() { Text = "Задача 3", Left = 200, Top = 10, Width = 90 };
        btnTask4 = new Button() { Text = "Задача 4", Left = 295, Top = 10, Width = 90 };
        btnTask5 = new Button() { Text = "Задача 5", Left = 390, Top = 10, Width = 90 };
        btnAll = new Button() { Text = "Все задачи", Left = 485, Top = 10, Width = 100 };

        // Привязка обработчиков событий к кнопкам
        btnTask1.Click += (s, e) => RunTask1();
        btnTask2.Click += (s, e) => RunTask2();
        btnTask3.Click += (s, e) => RunTask3();
        btnTask4.Click += (s, e) => RunTask4();
        btnTask5.Click += (s, e) => RunTask5();
        btnAll.Click += (s, e) => RunAll();

        // Создаём многострочное текстовое поле для вывода
        outputBox = new TextBox()
        {
            Multiline = true,          // многострочный режим
            ScrollBars = ScrollBars.Vertical, // вертикальная прокрутка
            Left = 10,
            Top = 50,
            Width = 580,
            Height = 420,
            ReadOnly = true,           // только для чтения
            Font = new System.Drawing.Font("Consolas", 10) // моноширинный шрифт
        };

        // Добавляем все элементы на форму
        this.Controls.Add(btnTask1);
        this.Controls.Add(btnTask2);
        this.Controls.Add(btnTask3);
        this.Controls.Add(btnTask4);
        this.Controls.Add(btnTask5);
        this.Controls.Add(btnAll);
        this.Controls.Add(outputBox);
    }

    // Вспомогательный метод для добавления строки в текстовое поле
    private void Log(string text)
    {
        outputBox.AppendText(text + Environment.NewLine);
    }

    // ЗАДАЧА 1 
    private void RunTask1()
    {
        outputBox.Clear();
        Log("===== ЗАДАЧА 1: Книга =====");

        // Создаём первую книгу и задаём поля
        Book book1 = new Book();
        book1.title = "Война и мир";
        book1.pages = 1200;

        // Создаём вторую книгу
        Book book2 = new Book();
        book2.title = "1984";
        book2.pages = 300;

        // Создаём третью книгу — название останется "Неизвестно"
        Book book3 = new Book();
        book3.pages = 500;

        // Выводим информацию
        Log(book1.GetInfo());
        Log(book2.GetInfo());
        Log(book3.GetInfo());
    }

    // ЗАДАЧА 2 
    private void RunTask2()
    {
        outputBox.Clear();
        Log("===== ЗАДАЧА 2: Студент =====");

        // Конструктор без параметров
        Student s1 = new Student();
        // Конструктор с одним параметром
        Student s2 = new Student("Петр");
        // Конструктор с двумя параметрами
        Student s3 = new Student("Мария", 20);

        Log(s1.PrintInfo());
        Log(s2.PrintInfo());
        Log(s3.PrintInfo());
    }

    // ЗАДАЧА 3 
    private void RunTask3()
    {
        outputBox.Clear();
        Log("===== ЗАДАЧА 3: Автомобиль =====");

        // Инициализатор объекта — заполняем поля прямо при создании
        Car car1 = new Car() { brand = "Toyota", model = "Camry", year = 2020 };
        Car car2 = new Car() { brand = "BMW", model = "X5", year = 2022 };
        // Год не указан — останется 2000
        Car car3 = new Car() { brand = "Lada", model = "Vesta" };

        Log(car1.GetInfo());
        Log(car2.GetInfo());
        Log(car3.GetInfo());
    }

    // ЗАДАЧА 4
    private void RunTask4()
    {
        outputBox.Clear();
        Log("===== ЗАДАЧА 4: Треугольник =====");

        // Валидный треугольник
        Triangle t1 = new Triangle(3, 4, 5);
        // Невалидный треугольник
        Triangle t2 = new Triangle(1, 2, 4);

        Log(t1.PrintSides());
        Log("Существует: " + t1.IsValid());
        Log("");
        Log(t2.PrintSides());
        Log("Существует: " + t2.IsValid());
    }

    // ЗАДАЧА 5
    private void RunTask5()
    {
        outputBox.Clear();
        Log("===== ЗАДАЧА 5: Точка =====");

        // Создаём точку (10, 20)
        Point p1 = new Point(10, 20);
        // Деконструкция — получаем x и y в отдельные переменные
        (int x, int y) = p1;
        Log("Точка 1: X=" + x + ", Y=" + y);

        // Создаём точку (5, 7)
        Point p2 = new Point(5, 7);
        // Деконструкция с игнорированием X через символ _
        (_, int onlyY) = p2;
        Log("Точка 2: только Y=" + onlyY);
    }

    // ВСЕ ЗАДАЧИ
    private void RunAll()
    {
        outputBox.Clear();

        // Задача 1
        Log("===== ЗАДАЧА 1: Книга =====");
        Book book1 = new Book(); book1.title = "Война и мир"; book1.pages = 1200;
        Book book2 = new Book(); book2.title = "1984"; book2.pages = 300;
        Book book3 = new Book(); book3.pages = 500;
        Log(book1.GetInfo());
        Log(book2.GetInfo());
        Log(book3.GetInfo());
        Log("");

        // Задача 2
        Log("===== ЗАДАЧА 2: Студент =====");
        Student s1 = new Student();
        Student s2 = new Student("Петр");
        Student s3 = new Student("Мария", 20);
        Log(s1.PrintInfo());
        Log(s2.PrintInfo());
        Log(s3.PrintInfo());
        Log("");

        // Задача 3
        Log("===== ЗАДАЧА 3: Автомобиль =====");
        Car car1 = new Car() { brand = "Toyota", model = "Camry", year = 2020 };
        Car car2 = new Car() { brand = "BMW", model = "X5", year = 2022 };
        Car car3 = new Car() { brand = "Lada", model = "Vesta" };
        Log(car1.GetInfo());
        Log(car2.GetInfo());
        Log(car3.GetInfo());
        Log("");

        // Задача 4
        Log("===== ЗАДАЧА 4: Треугольник =====");
        Triangle t1 = new Triangle(3, 4, 5);
        Triangle t2 = new Triangle(1, 2, 4);
        Log(t1.PrintSides());
        Log("Существует: " + t1.IsValid());
        Log(t2.PrintSides());
        Log("Существует: " + t2.IsValid());
        Log("");

        // Задача 5
        Log("===== ЗАДАЧА 5: Точка =====");
        Point p1 = new Point(10, 20);
        (int x, int y) = p1;
        Log("Точка 1: X=" + x + ", Y=" + y);
        Point p2 = new Point(5, 7);
        (_, int onlyY) = p2;
        Log("Точка 2: только Y=" + onlyY);
    }
}

// ТОЧКА ВХОДА

static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();             // включаем визуальные стили
        Application.SetCompatibleTextRenderingDefault(false); // совместимость рендеринга
        Application.Run(new Form1());                 // запускаем форму
    }
}