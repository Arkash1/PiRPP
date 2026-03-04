using System;
using System.Windows.Forms;

namespace AllTasksApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ЗАДАЧА 1: КАЛЬКУЛЯТОР СКИДОК

        // Метод, который рассчитывает скидку в зависимости от суммы
        private double GetDiscount(double sum)
        {
            if (sum < 1000)
                return 0;       // до 1000 — скидки нет
            else if (sum <= 5000)
                return 0.05;    // от 1000 до 5000 — 5%
            else
                return 0.10;    // свыше 5000 — 10%
        }

        // Метод, который считает итоговую сумму со скидкой
        private double CalculateFinalPrice(double sum)
        {
            double discount = GetDiscount(sum);          // получаем процент скидки
            double finalPrice = sum - (sum * discount);  // вычитаем скидку из суммы
            return finalPrice;                           // возвращаем итог
        }

        // Обработчик кнопки "Рассчитать скидку"
        private void btnCalcDiscount_Click(object sender, EventArgs e)
        {
            // Пробуем преобразовать текст в число
            if (double.TryParse(txtSum.Text, out double sum))
            {
                double discount = GetDiscount(sum);              // получаем скидку
                double finalPrice = CalculateFinalPrice(sum);    // получаем итоговую цену

                // Выводим результат в метку
                lblDiscountResult.Text = $"Скидка: {discount * 100}%\n" +
                                         $"Итого: {finalPrice:F2} руб.";
            }
            else
            {
                // Если ввод некорректный — сообщаем об ошибке
                lblDiscountResult.Text = "Введите корректную сумму!";
            }
        }

        // ЗАДАЧА 2: ПРОВЕРКА ПАРОЛЯ

        // Метод проверки длины пароля (минимум 8 символов)
        private bool CheckPasswordLength(string password)
        {
            return password.Length >= 8;  // вернёт true, если длина >= 8
        }

        // Метод проверки наличия хотя бы одной цифры в пароле
        private bool CheckPasswordDigits(string password)
        {
            // Проходим по каждому символу пароля
            foreach (char c in password)
            {
                if (char.IsDigit(c))  // если символ — цифра
                    return true;      // сразу возвращаем true
            }
            return false; // если цифр не нашли — false
        }

        // Метод, который определяет надёжность пароля
        private string ShowPasswordStrength(string password)
        {
            bool hasLength = CheckPasswordLength(password);  // проверяем длину
            bool hasDigit = CheckPasswordDigits(password);   // проверяем цифры

            if (hasLength && hasDigit)
                return "Надёжный";    // оба условия выполнены
            else if (hasLength || hasDigit)
                return "Средний";     // выполнено только одно условие
            else
                return "Слабый";      // ни одно условие не выполнено
        }

        // Обработчик кнопки "Проверить пароль"
        private void btnCheckPassword_Click(object sender, EventArgs e)
        {
            string password = txtPassword.Text;  // берём текст из поля ввода

            if (string.IsNullOrEmpty(password))  // если поле пустое
            {
                lblPasswordResult.Text = "Введите пароль!";
                return;  // выходим из метода
            }

            string strength = ShowPasswordStrength(password);  // определяем надёжность

            // Формируем подробный вывод
            lblPasswordResult.Text = $"Длина >= 8: {(CheckPasswordLength(password) ? "Да" : "Нет")}\n" +
                                     $"Есть цифры: {(CheckPasswordDigits(password) ? "Да" : "Нет")}\n" +
                                     $"Надёжность: {strength}";
        }

        // ЗАДАЧА 3: ТЕРМОМЕТР

        // Метод конвертации из Цельсия в Фаренгейты
        private double CelsiusToFahrenheit(double celsius)
        {
            return celsius * 9.0 / 5.0 + 32;  // формула перевода C -> F
        }

        // Метод конвертации из Фаренгейтов в Цельсий
        private double FahrenheitToCelsius(double fahrenheit)
        {
            return (fahrenheit - 32) * 5.0 / 9.0;  // формула перевода F -> C
        }

        // Обработчик кнопки "Конвертировать температуру"
        private void btnConvertTemp_Click(object sender, EventArgs e)
        {
            // Пробуем преобразовать введённый текст в число
            if (double.TryParse(txtTemperature.Text, out double temp))
            {
                // Проверяем, какой переключатель выбран
                if (rbCtoF.Checked)  // если выбрано "Цельсий -> Фаренгейт"
                {
                    double result = CelsiusToFahrenheit(temp);
                    lblTempResult.Text = $"{temp}°C = {result:F2}°F";
                }
                else  // если выбрано "Фаренгейт -> Цельсий"
                {
                    double result = FahrenheitToCelsius(temp);
                    lblTempResult.Text = $"{temp}°F = {result:F2}°C";
                }
            }
            else
            {
                lblTempResult.Text = "Введите корректную температуру!";
            }
        }

        // СОЗДАНИЕ ИНТЕРФЕЙСА

        // Объявляем все элементы управления как поля класса
        private TextBox txtSum, txtPassword, txtTemperature;
        private Label lblDiscountResult, lblPasswordResult, lblTempResult;
        private Button btnCalcDiscount, btnCheckPassword, btnConvertTemp;
        private RadioButton rbCtoF, rbFtoC;

        // Метод создания всех элементов интерфейса
        private void Form1_Load(object sender, EventArgs e)
        {
            // Настраиваем саму форму
            this.Text = "Три задачи в одном приложении";
            this.Size = new System.Drawing.Size(520, 620);
            this.StartPosition = FormStartPosition.CenterScreen;

            int y = 10; // начальная координата Y для размещения элементов

            // ЗАДАЧА 1: Скидки
            Label lblTitle1 = new Label();
            lblTitle1.Text = " ЗАДАЧА 1: Калькулятор скидок ";
            lblTitle1.Location = new System.Drawing.Point(10, y);
            lblTitle1.AutoSize = true;
            lblTitle1.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            this.Controls.Add(lblTitle1);
            y += 30;

            Label lblSumCaption = new Label();
            lblSumCaption.Text = "Сумма покупки (руб):";
            lblSumCaption.Location = new System.Drawing.Point(10, y);
            lblSumCaption.AutoSize = true;
            this.Controls.Add(lblSumCaption);

            txtSum = new TextBox();
            txtSum.Location = new System.Drawing.Point(180, y);
            txtSum.Width = 150;
            this.Controls.Add(txtSum);
            y += 30;

            btnCalcDiscount = new Button();
            btnCalcDiscount.Text = "Рассчитать скидку";
            btnCalcDiscount.Location = new System.Drawing.Point(10, y);
            btnCalcDiscount.Width = 150;
            btnCalcDiscount.Click += btnCalcDiscount_Click;  // подключаем обработчик
            this.Controls.Add(btnCalcDiscount);
            y += 30;

            lblDiscountResult = new Label();
            lblDiscountResult.Text = "Результат появится здесь";
            lblDiscountResult.Location = new System.Drawing.Point(10, y);
            lblDiscountResult.Size = new System.Drawing.Size(400, 50);
            this.Controls.Add(lblDiscountResult);
            y += 60;

            // ЗАДАЧА 2: Пароль
            Label lblTitle2 = new Label();
            lblTitle2.Text = " ЗАДАЧА 2: Проверка пароля ";
            lblTitle2.Location = new System.Drawing.Point(10, y);
            lblTitle2.AutoSize = true;
            lblTitle2.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            this.Controls.Add(lblTitle2);
            y += 30;

            Label lblPassCaption = new Label();
            lblPassCaption.Text = "Введите пароль:";
            lblPassCaption.Location = new System.Drawing.Point(10, y);
            lblPassCaption.AutoSize = true;
            this.Controls.Add(lblPassCaption);

            txtPassword = new TextBox();
            txtPassword.Location = new System.Drawing.Point(180, y);
            txtPassword.Width = 200;
            this.Controls.Add(txtPassword);
            y += 30;

            btnCheckPassword = new Button();
            btnCheckPassword.Text = "Проверить пароль";
            btnCheckPassword.Location = new System.Drawing.Point(10, y);
            btnCheckPassword.Width = 150;
            btnCheckPassword.Click += btnCheckPassword_Click;  // подключаем обработчик
            this.Controls.Add(btnCheckPassword);
            y += 30;

            lblPasswordResult = new Label();
            lblPasswordResult.Text = "Результат появится здесь";
            lblPasswordResult.Location = new System.Drawing.Point(10, y);
            lblPasswordResult.Size = new System.Drawing.Size(400, 60);
            this.Controls.Add(lblPasswordResult);
            y += 70;

            // ЗАДАЧА 3: Термометр
            Label lblTitle3 = new Label();
            lblTitle3.Text = " ЗАДАЧА 3: Термометр ";
            lblTitle3.Location = new System.Drawing.Point(10, y);
            lblTitle3.AutoSize = true;
            lblTitle3.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            this.Controls.Add(lblTitle3);
            y += 30;

            Label lblTempCaption = new Label();
            lblTempCaption.Text = "Температура:";
            lblTempCaption.Location = new System.Drawing.Point(10, y);
            lblTempCaption.AutoSize = true;
            this.Controls.Add(lblTempCaption);

            txtTemperature = new TextBox();
            txtTemperature.Location = new System.Drawing.Point(180, y);
            txtTemperature.Width = 150;
            this.Controls.Add(txtTemperature);
            y += 30;

            rbCtoF = new RadioButton();
            rbCtoF.Text = "Цельсий → Фаренгейт";
            rbCtoF.Location = new System.Drawing.Point(10, y);
            rbCtoF.AutoSize = true;
            rbCtoF.Checked = true;  // по умолчанию выбран этот вариант
            this.Controls.Add(rbCtoF);

            rbFtoC = new RadioButton();
            rbFtoC.Text = "Фаренгейт → Цельсий";
            rbFtoC.Location = new System.Drawing.Point(250, y);
            rbFtoC.AutoSize = true;
            this.Controls.Add(rbFtoC);
            y += 30;

            btnConvertTemp = new Button();
            btnConvertTemp.Text = "Конвертировать";
            btnConvertTemp.Location = new System.Drawing.Point(10, y);
            btnConvertTemp.Width = 150;
            btnConvertTemp.Click += btnConvertTemp_Click;  // подключаем обработчик
            this.Controls.Add(btnConvertTemp);
            y += 30;

            lblTempResult = new Label();
            lblTempResult.Text = "Результат появится здесь";
            lblTempResult.Location = new System.Drawing.Point(10, y);
            lblTempResult.Size = new System.Drawing.Size(400, 30);
            this.Controls.Add(lblTempResult);
        }
    }
}