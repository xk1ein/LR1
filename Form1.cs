using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;

namespace LR1 // TemperatureControlSystem
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        // Исходные данные
        private const int SensorCount = 24; // Количество датчиков
        private const double ControlAccuracy = 4.0; // Точность управления

        private double[] StartTemperatures = new double[SensorCount]; // Стартовые температуры датчиков (комнатная температура 25.97)

        public Form1()
        {
            InitializeComponent();
            this.Text = "Панель управления"; // Заголовок главного окна

            // Инициализация работы датчиков
            SensorStatusButton2.Click += SensorStatusButton2_Click;
            SensorStatusButton3.Click += SensorStatusButton3_Click;
            SensorStatusButton4.Click += SensorStatusButton4_Click;
            SensorStatusButton5.Click += SensorStatusButton5_Click;
            SensorStatusButton6.Click += SensorStatusButton6_Click;
            SensorStatusButton7.Click += SensorStatusButton7_Click;
            SensorStatusButton8.Click += SensorStatusButton8_Click;

            SensorStatusButton9.Click += SensorStatusButton9_Click;
            SensorStatusButton10.Click += SensorStatusButton10_Click;
            SensorStatusButton11.Click += SensorStatusButton11_Click;
            SensorStatusButton12.Click += SensorStatusButton12_Click;
            SensorStatusButton13.Click += SensorStatusButton13_Click;
            SensorStatusButton14.Click += SensorStatusButton14_Click;
            SensorStatusButton15.Click += SensorStatusButton15_Click;
            SensorStatusButton16.Click += SensorStatusButton16_Click;

            SensorStatusButton17.Click += SensorStatusButton17_Click;
            SensorStatusButton18.Click += SensorStatusButton18_Click;
            SensorStatusButton19.Click += SensorStatusButton19_Click;
            SensorStatusButton20.Click += SensorStatusButton20_Click;
            SensorStatusButton21.Click += SensorStatusButton21_Click;
            SensorStatusButton22.Click += SensorStatusButton22_Click;
            SensorStatusButton23.Click += SensorStatusButton23_Click;
            SensorStatusButton24.Click += SensorStatusButton24_Click;
        }

        public string Temperature
        {
            get
            {
               return InputSetPointTemperaturetextBox.Text; //= " 160 ";
            }
        }

        private void ShowChartButton_Click(object sender, EventArgs e) // Вызов функции построения графика работы датчика
        {
            Form2 chartWindow = new Form2(); // Инициализация формы для графика
            chartWindow.Show();
        }
                     
        // Функции определения статуса процессов таблетирования и аварии для датчиков
        private void Tableting(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature += random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempTabletingUp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + 12;
            double TempTabletingDown = SetPointTemperature - 12;

            if (currentTemperature > TempTabletingUp || currentTemperature < TempTabletingDown)
            {
                TabletingStatusLabel.Text = "Запрещено";
                TabletingStatusLabel.ForeColor = Color.Red;
            }
            else
            {
                TabletingStatusLabel.Text = "Разрешено";
                TabletingStatusLabel.ForeColor = Color.Green;
            }
        }

        private void Accident(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature -= random.Next(1); // Имитация аварии

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempAccidentUp = SetPointTemperature + 30;
            double TempAccidentDown = SetPointTemperature - 30;

            if (currentTemperature > TempAccidentUp)
            {
                TemperaturesLabel.Text = $"{Math.Round(currentTemperature, 2)}";
                
                AccidentStatusLabel.Text = "Да"; // + $"{Math.Round(currentTemperature, 2)}";
                AccidentStatusLabel.ForeColor = Color.Red;

                TabletingStatusLabel.Text = "Запрещено";
                TabletingStatusLabel.ForeColor = Color.Red;
            }
            else
            {
                AccidentStatusLabel.Text = "Нет";
                AccidentStatusLabel.ForeColor = Color.Black;
            }
        }

        // Датчик #2
        private void Tableting2(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature += random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempTabletingUp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + 12;
            double TempTabletingDown = SetPointTemperature - 12;

            if (currentTemperature > TempTabletingUp || currentTemperature < TempTabletingDown)
            {
                TabletingStatusLabel2.Text = "Запрещено";
                TabletingStatusLabel2.ForeColor = Color.Red;
            }
            else
            {
                TabletingStatusLabel2.Text = "Разрешено";
                TabletingStatusLabel2.ForeColor = Color.Green;
            }
        }

        private void Accident2(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature -= random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempAccidentUp = SetPointTemperature + 30;
            double TempAccidentDown = SetPointTemperature - 30;

            if (currentTemperature > TempAccidentUp)
            {
                TemperaturesLabel2.Text = $"{Math.Round(currentTemperature, 2)}";

                AccidentStatusLabel2.Text = "Да";
                AccidentStatusLabel2.ForeColor = Color.Red;

                TabletingStatusLabel2.Text = "Запрещено";
                TabletingStatusLabel2.ForeColor = Color.Red;
            }
            else
            {
                AccidentStatusLabel2.Text = "Нет";
                AccidentStatusLabel2.ForeColor = Color.Black;
            }
        }

        // Датчик #3
        private void Tableting3(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature += random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempTabletingUp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + 12;
            double TempTabletingDown = SetPointTemperature - 12;

            if (currentTemperature > TempTabletingUp || currentTemperature < TempTabletingDown)
            {
                TabletingStatusLabel3.Text = "Запрещено";
                TabletingStatusLabel3.ForeColor = Color.Red;
            }
            else
            {
                TabletingStatusLabel3.Text = "Разрешено";
                TabletingStatusLabel3.ForeColor = Color.Green;
            }
        }

        private void Accident3(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature -= random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempAccidentUp = SetPointTemperature + 30;
            double TempAccidentDown = SetPointTemperature - 30;

            if (currentTemperature > TempAccidentUp)
            {
                TemperaturesLabel3.Text = $"{Math.Round(currentTemperature, 2)}";

                AccidentStatusLabel3.Text = "Да";
                AccidentStatusLabel3.ForeColor = Color.Red;

                TabletingStatusLabel3.Text = "Запрещено";
                TabletingStatusLabel3.ForeColor = Color.Red;
            }
            else
            {
                AccidentStatusLabel3.Text = "Нет";
                AccidentStatusLabel3.ForeColor = Color.Black;
            }
        }

        // Датчик #4
        private void Tableting4(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature += random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempTabletingUp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + 12;
            double TempTabletingDown = SetPointTemperature - 12;

            if (currentTemperature > TempTabletingUp || currentTemperature < TempTabletingDown)
            {
                TabletingStatusLabel4.Text = "Запрещено";
                TabletingStatusLabel4.ForeColor = Color.Red;
            }
            else
            {
                TabletingStatusLabel4.Text = "Разрешено";
                TabletingStatusLabel4.ForeColor = Color.Green;
            }
        }

        private void Accident4(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature -= random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempAccidentUp = SetPointTemperature + 30;
            double TempAccidentDown = SetPointTemperature - 30;

            if (currentTemperature > TempAccidentUp)
            {
                TemperaturesLabel4.Text = $"{Math.Round(currentTemperature, 2)}";

                AccidentStatusLabel4.Text = "Да";
                AccidentStatusLabel4.ForeColor = Color.Red;

                TabletingStatusLabel4.Text = "Запрещено";
                TabletingStatusLabel4.ForeColor = Color.Red;
            }
            else
            {
                AccidentStatusLabel4.Text = "Нет";
                AccidentStatusLabel4.ForeColor = Color.Black;
            }
        }

        // Датчик #5
        private void Tableting5(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature += random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempTabletingUp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + 12;
            double TempTabletingDown = SetPointTemperature - 12;

            if (currentTemperature > TempTabletingUp || currentTemperature < TempTabletingDown)
            {
                TabletingStatusLabel5.Text = "Запрещено";
                TabletingStatusLabel5.ForeColor = Color.Red;
            }
            else
            {
                TabletingStatusLabel5.Text = "Разрешено";
                TabletingStatusLabel5.ForeColor = Color.Green;
            }
        }

        private void Accident5(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature -= random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempAccidentUp = SetPointTemperature + 30;
            double TempAccidentDown = SetPointTemperature - 30;

            if (currentTemperature > TempAccidentUp)
            {
                TemperaturesLabel5.Text = $"{Math.Round(currentTemperature, 2)}";

                AccidentStatusLabel5.Text = "Да";
                AccidentStatusLabel5.ForeColor = Color.Red;

                TabletingStatusLabel5.Text = "Запрещено";
                TabletingStatusLabel5.ForeColor = Color.Red;
            }
            else
            {
                AccidentStatusLabel5.Text = "Нет";
                AccidentStatusLabel5.ForeColor = Color.Black;
            }
        }

        // Датчик #6
        private void Tableting6(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature += random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempTabletingUp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + 12;
            double TempTabletingDown = SetPointTemperature - 12;

            if (currentTemperature > TempTabletingUp || currentTemperature < TempTabletingDown)
            {
                TabletingStatusLabel6.Text = "Запрещено";
                TabletingStatusLabel6.ForeColor = Color.Red;
            }
            else
            {
                TabletingStatusLabel6.Text = "Разрешено";
                TabletingStatusLabel6.ForeColor = Color.Green;
            }
        }

        private void Accident6(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature -= random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempAccidentUp = SetPointTemperature + 30;
            double TempAccidentDown = SetPointTemperature - 30;

            if (currentTemperature > TempAccidentUp)
            {
                TemperaturesLabel6.Text = $"{Math.Round(currentTemperature, 2)}";

                AccidentStatusLabel6.Text = "Да";
                AccidentStatusLabel6.ForeColor = Color.Red;

                TabletingStatusLabel6.Text = "Запрещено";
                TabletingStatusLabel6.ForeColor = Color.Red;
            }
            else
            {
                AccidentStatusLabel6.Text = "Нет";
                AccidentStatusLabel6.ForeColor = Color.Black;
            }
        }

        // Датчик #7
        private void Tableting7(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature += random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempTabletingUp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + 12;
            double TempTabletingDown = SetPointTemperature - 12;

            if (currentTemperature > TempTabletingUp || currentTemperature < TempTabletingDown)
            {
                TabletingStatusLabel7.Text = "Запрещено";
                TabletingStatusLabel7.ForeColor = Color.Red;
            }
            else
            {
                TabletingStatusLabel7.Text = "Разрешено";
                TabletingStatusLabel7.ForeColor = Color.Green;
            }
        }

        private void Accident7(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature -= random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempAccidentUp = SetPointTemperature + 30;
            double TempAccidentDown = SetPointTemperature - 30;

            if (currentTemperature > TempAccidentUp)
            {
                TemperaturesLabel7.Text = $"{Math.Round(currentTemperature, 2)}";

                AccidentStatusLabel7.Text = "Да";
                AccidentStatusLabel7.ForeColor = Color.Red;

                TabletingStatusLabel7.Text = "Запрещено";
                TabletingStatusLabel7.ForeColor = Color.Red;
            }
            else
            {
                AccidentStatusLabel7.Text = "Нет";
                AccidentStatusLabel7.ForeColor = Color.Black;
            }
        }

        // Датчик #8
        private void Tableting8(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature += random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempTabletingUp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + 12;
            double TempTabletingDown = SetPointTemperature - 12;

            if (currentTemperature > TempTabletingUp || currentTemperature < TempTabletingDown)
            {
                TabletingStatusLabel8.Text = "Запрещено";
                TabletingStatusLabel8.ForeColor = Color.Red;
            }
            else
            {
                TabletingStatusLabel8.Text = "Разрешено";
                TabletingStatusLabel8.ForeColor = Color.Green;
            }
        }

        private void Accident8(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature -= random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempAccidentUp = SetPointTemperature + 30;
            double TempAccidentDown = SetPointTemperature - 30;

            if (currentTemperature > TempAccidentUp)
            {
                TemperaturesLabel8.Text = $"{Math.Round(currentTemperature, 2)}";

                AccidentStatusLabel8.Text = "Да";
                AccidentStatusLabel8.ForeColor = Color.Red;

                TabletingStatusLabel8.Text = "Запрещено";
                TabletingStatusLabel8.ForeColor = Color.Red;
            }
            else
            {
                AccidentStatusLabel8.Text = "Нет";
                AccidentStatusLabel8.ForeColor = Color.Black;
            }
        }



        // Датчик #9
        private void Tableting9(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature += random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempTabletingUp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + 12;
            double TempTabletingDown = SetPointTemperature - 12;

            if (currentTemperature > TempTabletingUp || currentTemperature < TempTabletingDown)
            {
                TabletingStatusLabel9.Text = "Запрещено";
                TabletingStatusLabel9.ForeColor = Color.Red;
            }
            else
            {
                TabletingStatusLabel9.Text = "Разрешено";
                TabletingStatusLabel9.ForeColor = Color.Green;
            }
        }

        private void Accident9(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature -= random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempAccidentUp = SetPointTemperature + 30;
            double TempAccidentDown = SetPointTemperature - 30;

            if (currentTemperature > TempAccidentUp)
            {
                TemperaturesLabel9.Text = $"{Math.Round(currentTemperature, 2)}";

                AccidentStatusLabel9.Text = "Да";
                AccidentStatusLabel9.ForeColor = Color.Red;

                TabletingStatusLabel9.Text = "Запрещено";
                TabletingStatusLabel9.ForeColor = Color.Red;
            }
            else
            {
                AccidentStatusLabel9.Text = "Нет";
                AccidentStatusLabel9.ForeColor = Color.Black;
            }
        }

        // Датчик #10
        private void Tableting10(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature += random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempTabletingUp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + 12;
            double TempTabletingDown = SetPointTemperature - 12;

            if (currentTemperature > TempTabletingUp || currentTemperature < TempTabletingDown)
            {
                TabletingStatusLabel10.Text = "Запрещено";
                TabletingStatusLabel10.ForeColor = Color.Red;
            }
            else
            {
                TabletingStatusLabel10.Text = "Разрешено";
                TabletingStatusLabel10.ForeColor = Color.Green;
            }
        }

        private void Accident10(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature -= random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempAccidentUp = SetPointTemperature + 30;
            double TempAccidentDown = SetPointTemperature - 30;

            if (currentTemperature > TempAccidentUp)
            {
                TemperaturesLabel10.Text = $"{Math.Round(currentTemperature, 2)}";

                AccidentStatusLabel10.Text = "Да";
                AccidentStatusLabel10.ForeColor = Color.Red;

                TabletingStatusLabel10.Text = "Запрещено";
                TabletingStatusLabel10.ForeColor = Color.Red;
            }
            else
            {
                AccidentStatusLabel10.Text = "Нет";
                AccidentStatusLabel10.ForeColor = Color.Black;
            }
        }

        // Датчик #11
        private void Tableting11(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature += random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempTabletingUp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + 12;
            double TempTabletingDown = SetPointTemperature - 12;

            if (currentTemperature > TempTabletingUp || currentTemperature < TempTabletingDown)
            {
                TabletingStatusLabel11.Text = "Запрещено";
                TabletingStatusLabel11.ForeColor = Color.Red;
            }
            else
            {
                TabletingStatusLabel11.Text = "Разрешено";
                TabletingStatusLabel11.ForeColor = Color.Green;
            }
        }

        private void Accident11(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature -= random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempAccidentUp = SetPointTemperature + 30;
            double TempAccidentDown = SetPointTemperature - 30;

            if (currentTemperature > TempAccidentUp)
            {
                TemperaturesLabel11.Text = $"{Math.Round(currentTemperature, 2)}";

                AccidentStatusLabel11.Text = "Да";
                AccidentStatusLabel11.ForeColor = Color.Red;

                TabletingStatusLabel11.Text = "Запрещено";
                TabletingStatusLabel11.ForeColor = Color.Red;
            }
            else
            {
                AccidentStatusLabel11.Text = "Нет";
                AccidentStatusLabel11.ForeColor = Color.Black;
            }
        }

        // Датчик #12
        private void Tableting12(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature += random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempTabletingUp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + 12;
            double TempTabletingDown = SetPointTemperature - 12;

            if (currentTemperature > TempTabletingUp || currentTemperature < TempTabletingDown)
            {
                TabletingStatusLabel12.Text = "Запрещено";
                TabletingStatusLabel12.ForeColor = Color.Red;
            }
            else
            {
                TabletingStatusLabel12.Text = "Разрешено";
                TabletingStatusLabel12.ForeColor = Color.Green;
            }
        }

        private void Accident12(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature -= random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempAccidentUp = SetPointTemperature + 30;
            double TempAccidentDown = SetPointTemperature - 30;

            if (currentTemperature > TempAccidentUp)
            {
                TemperaturesLabel12.Text = $"{Math.Round(currentTemperature, 2)}";

                AccidentStatusLabel12.Text = "Да";
                AccidentStatusLabel12.ForeColor = Color.Red;

                TabletingStatusLabel12.Text = "Запрещено";
                TabletingStatusLabel12.ForeColor = Color.Red;
            }
            else
            {
                AccidentStatusLabel12.Text = "Нет";
                AccidentStatusLabel12.ForeColor = Color.Black;
            }
        }

        // Датчик #13
        private void Tableting13(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature += random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempTabletingUp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + 12;
            double TempTabletingDown = SetPointTemperature - 12;

            if (currentTemperature > TempTabletingUp || currentTemperature < TempTabletingDown)
            {
                TabletingStatusLabel13.Text = "Запрещено";
                TabletingStatusLabel13.ForeColor = Color.Red;
            }
            else
            {
                TabletingStatusLabel13.Text = "Разрешено";
                TabletingStatusLabel13.ForeColor = Color.Green;
            }
        }

        private void Accident13(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature -= random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempAccidentUp = SetPointTemperature + 30;
            double TempAccidentDown = SetPointTemperature - 30;

            if (currentTemperature > TempAccidentUp)
            {
                TemperaturesLabel13.Text = $"{Math.Round(currentTemperature, 2)}";

                AccidentStatusLabel13.Text = "Да";
                AccidentStatusLabel13.ForeColor = Color.Red;

                TabletingStatusLabel13.Text = "Запрещено";
                TabletingStatusLabel13.ForeColor = Color.Red;
            }
            else
            {
                AccidentStatusLabel13.Text = "Нет";
                AccidentStatusLabel13.ForeColor = Color.Black;
            }
        }

        // Датчик #14
        private void Tableting14(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature += random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempTabletingUp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + 12;
            double TempTabletingDown = SetPointTemperature - 12;

            if (currentTemperature > TempTabletingUp || currentTemperature < TempTabletingDown)
            {
                TabletingStatusLabel14.Text = "Запрещено";
                TabletingStatusLabel14.ForeColor = Color.Red;
            }
            else
            {
                TabletingStatusLabel14.Text = "Разрешено";
                TabletingStatusLabel14.ForeColor = Color.Green;
            }
        }

        private void Accident14(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature -= random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempAccidentUp = SetPointTemperature + 30;
            double TempAccidentDown = SetPointTemperature - 30;

            if (currentTemperature > TempAccidentUp)
            {
                TemperaturesLabel14.Text = $"{Math.Round(currentTemperature, 2)}";

                AccidentStatusLabel14.Text = "Да";
                AccidentStatusLabel14.ForeColor = Color.Red;

                TabletingStatusLabel14.Text = "Запрещено";
                TabletingStatusLabel14.ForeColor = Color.Red;
            }
            else
            {
                AccidentStatusLabel14.Text = "Нет";
                AccidentStatusLabel14.ForeColor = Color.Black;
            }
        }

        // Датчик #15
        private void Tableting15(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature += random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempTabletingUp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + 12;
            double TempTabletingDown = SetPointTemperature - 12;

            if (currentTemperature > TempTabletingUp || currentTemperature < TempTabletingDown)
            {
                TabletingStatusLabel15.Text = "Запрещено";
                TabletingStatusLabel15.ForeColor = Color.Red;
            }
            else
            {
                TabletingStatusLabel15.Text = "Разрешено";
                TabletingStatusLabel15.ForeColor = Color.Green;
            }
        }

        private void Accident15(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature -= random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempAccidentUp = SetPointTemperature + 30;
            double TempAccidentDown = SetPointTemperature - 30;

            if (currentTemperature > TempAccidentUp)
            {
                TemperaturesLabel15.Text = $"{Math.Round(currentTemperature, 2)}";

                AccidentStatusLabel15.Text = "Да";
                AccidentStatusLabel15.ForeColor = Color.Red;

                TabletingStatusLabel15.Text = "Запрещено";
                TabletingStatusLabel15.ForeColor = Color.Red;
            }
            else
            {
                AccidentStatusLabel15.Text = "Нет";
                AccidentStatusLabel15.ForeColor = Color.Black;
            }
        }

        // Датчик #16
        private void Tableting16(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature += random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempTabletingUp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + 12;
            double TempTabletingDown = SetPointTemperature - 12;

            if (currentTemperature > TempTabletingUp || currentTemperature < TempTabletingDown)
            {
                TabletingStatusLabel16.Text = "Запрещено";
                TabletingStatusLabel16.ForeColor = Color.Red;
            }
            else
            {
                TabletingStatusLabel16.Text = "Разрешено";
                TabletingStatusLabel16.ForeColor = Color.Green;
            }
        }

        private void Accident16(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature -= random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempAccidentUp = SetPointTemperature + 30;
            double TempAccidentDown = SetPointTemperature - 30;

            if (currentTemperature > TempAccidentUp)
            {
                TemperaturesLabel16.Text = $"{Math.Round(currentTemperature, 2)}";

                AccidentStatusLabel16.Text = "Да";
                AccidentStatusLabel16.ForeColor = Color.Red;

                TabletingStatusLabel16.Text = "Запрещено";
                TabletingStatusLabel16.ForeColor = Color.Red;
            }
            else
            {
                AccidentStatusLabel16.Text = "Нет";
                AccidentStatusLabel16.ForeColor = Color.Black;
            }
        }



        // Датчик #17
        private void Tableting17(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature += random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempTabletingUp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + 12;
            double TempTabletingDown = SetPointTemperature - 12;

            if (currentTemperature > TempTabletingUp || currentTemperature < TempTabletingDown)
            {
                TabletingStatusLabel17.Text = "Запрещено";
                TabletingStatusLabel17.ForeColor = Color.Red;
            }
            else
            {
                TabletingStatusLabel17.Text = "Разрешено";
                TabletingStatusLabel17.ForeColor = Color.Green;
            }
        }

        private void Accident17(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature -= random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempAccidentUp = SetPointTemperature + 30;
            double TempAccidentDown = SetPointTemperature - 30;

            if (currentTemperature > TempAccidentUp)
            {
                TemperaturesLabel17.Text = $"{Math.Round(currentTemperature, 2)}";

                AccidentStatusLabel17.Text = "Да";
                AccidentStatusLabel17.ForeColor = Color.Red;

                TabletingStatusLabel17.Text = "Запрещено";
                TabletingStatusLabel17.ForeColor = Color.Red;
            }
            else
            {
                AccidentStatusLabel17.Text = "Нет";
                AccidentStatusLabel17.ForeColor = Color.Black;
            }
        }

        // Датчик #18
        private void Tableting18(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature += random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempTabletingUp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + 12;
            double TempTabletingDown = SetPointTemperature - 12;

            if (currentTemperature > TempTabletingUp || currentTemperature < TempTabletingDown)
            {
                TabletingStatusLabel18.Text = "Запрещено";
                TabletingStatusLabel18.ForeColor = Color.Red;
            }
            else
            {
                TabletingStatusLabel18.Text = "Разрешено";
                TabletingStatusLabel18.ForeColor = Color.Green;
            }
        }

        private void Accident18(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature -= random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempAccidentUp = SetPointTemperature + 30;
            double TempAccidentDown = SetPointTemperature - 30;

            if (currentTemperature > TempAccidentUp)
            {
                TemperaturesLabel18.Text = $"{Math.Round(currentTemperature, 2)}";

                AccidentStatusLabel18.Text = "Да";
                AccidentStatusLabel18.ForeColor = Color.Red;

                TabletingStatusLabel18.Text = "Запрещено";
                TabletingStatusLabel18.ForeColor = Color.Red;
            }
            else
            {
                AccidentStatusLabel18.Text = "Нет";
                AccidentStatusLabel18.ForeColor = Color.Black;
            }
        }

        // Датчик #19
        private void Tableting19(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature += random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempTabletingUp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + 12;
            double TempTabletingDown = SetPointTemperature - 12;

            if (currentTemperature > TempTabletingUp || currentTemperature < TempTabletingDown)
            {
                TabletingStatusLabel19.Text = "Запрещено";
                TabletingStatusLabel19.ForeColor = Color.Red;
            }
            else
            {
                TabletingStatusLabel19.Text = "Разрешено";
                TabletingStatusLabel19.ForeColor = Color.Green;
            }
        }

        private void Accident19(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature -= random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempAccidentUp = SetPointTemperature + 30;
            double TempAccidentDown = SetPointTemperature - 30;

            if (currentTemperature > TempAccidentUp)
            {
                TemperaturesLabel19.Text = $"{Math.Round(currentTemperature, 2)}";

                AccidentStatusLabel19.Text = "Да";
                AccidentStatusLabel19.ForeColor = Color.Red;

                TabletingStatusLabel19.Text = "Запрещено";
                TabletingStatusLabel19.ForeColor = Color.Red;
            }
            else
            {
                AccidentStatusLabel19.Text = "Нет";
                AccidentStatusLabel19.ForeColor = Color.Black;
            }
        }

        // Датчик #20
        private void Tableting20(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature += random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempTabletingUp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + 12;
            double TempTabletingDown = SetPointTemperature - 12;

            if (currentTemperature > TempTabletingUp || currentTemperature < TempTabletingDown)
            {
                TabletingStatusLabel20.Text = "Запрещено";
                TabletingStatusLabel20.ForeColor = Color.Red;
            }
            else
            {
                TabletingStatusLabel20.Text = "Разрешено";
                TabletingStatusLabel20.ForeColor = Color.Green;
            }
        }

        private void Accident20(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature -= random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempAccidentUp = SetPointTemperature + 30;
            double TempAccidentDown = SetPointTemperature - 30;

            if (currentTemperature > TempAccidentUp)
            {
                TemperaturesLabel20.Text = $"{Math.Round(currentTemperature, 2)}";

                AccidentStatusLabel20.Text = "Да";
                AccidentStatusLabel20.ForeColor = Color.Red;

                TabletingStatusLabel20.Text = "Запрещено";
                TabletingStatusLabel20.ForeColor = Color.Red;
            }
            else
            {
                AccidentStatusLabel20.Text = "Нет";
                AccidentStatusLabel20.ForeColor = Color.Black;
            }
        }

        // Датчик #21
        private void Tableting21(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature += random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempTabletingUp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + 12;
            double TempTabletingDown = SetPointTemperature - 12;

            if (currentTemperature > TempTabletingUp || currentTemperature < TempTabletingDown)
            {
                TabletingStatusLabel21.Text = "Запрещено";
                TabletingStatusLabel21.ForeColor = Color.Red;
            }
            else
            {
                TabletingStatusLabel21.Text = "Разрешено";
                TabletingStatusLabel21.ForeColor = Color.Green;
            }
        }

        private void Accident21(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature -= random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempAccidentUp = SetPointTemperature + 30;
            double TempAccidentDown = SetPointTemperature - 30;

            if (currentTemperature > TempAccidentUp)
            {
                TemperaturesLabel21.Text = $"{Math.Round(currentTemperature, 2)}";

                AccidentStatusLabel21.Text = "Да";
                AccidentStatusLabel21.ForeColor = Color.Red;

                TabletingStatusLabel21.Text = "Запрещено";
                TabletingStatusLabel21.ForeColor = Color.Red;
            }
            else
            {
                AccidentStatusLabel21.Text = "Нет";
                AccidentStatusLabel21.ForeColor = Color.Black;
            }
        }

        // Датчик #22
        private void Tableting22(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature += random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempTabletingUp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + 12;
            double TempTabletingDown = SetPointTemperature - 12;

            if (currentTemperature > TempTabletingUp || currentTemperature < TempTabletingDown)
            {
                TabletingStatusLabel22.Text = "Запрещено";
                TabletingStatusLabel22.ForeColor = Color.Red;
            }
            else
            {
                TabletingStatusLabel22.Text = "Разрешено";
                TabletingStatusLabel22.ForeColor = Color.Green;
            }
        }

        private void Accident22(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature -= random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempAccidentUp = SetPointTemperature + 30;
            double TempAccidentDown = SetPointTemperature - 30;

            if (currentTemperature > TempAccidentUp)
            {
                TemperaturesLabel22.Text = $"{Math.Round(currentTemperature, 2)}";

                AccidentStatusLabel22.Text = "Да";
                AccidentStatusLabel22.ForeColor = Color.Red;

                TabletingStatusLabel22.Text = "Запрещено";
                TabletingStatusLabel22.ForeColor = Color.Red;
            }
            else
            {
                AccidentStatusLabel22.Text = "Нет";
                AccidentStatusLabel22.ForeColor = Color.Black;
            }
        }

        // Датчик #23
        private void Tableting23(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature += random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempTabletingUp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + 12;
            double TempTabletingDown = SetPointTemperature - 12;

            if (currentTemperature > TempTabletingUp || currentTemperature < TempTabletingDown)
            {
                TabletingStatusLabel23.Text = "Запрещено";
                TabletingStatusLabel23.ForeColor = Color.Red;
            }
            else
            {
                TabletingStatusLabel23.Text = "Разрешено";
                TabletingStatusLabel23.ForeColor = Color.Green;
            }
        }

        private void Accident23(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature -= random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempAccidentUp = SetPointTemperature + 30;
            double TempAccidentDown = SetPointTemperature - 30;

            if (currentTemperature > TempAccidentUp)
            {
                TemperaturesLabel23.Text = $"{Math.Round(currentTemperature, 2)}";

                AccidentStatusLabel23.Text = "Да";
                AccidentStatusLabel23.ForeColor = Color.Red;

                TabletingStatusLabel23.Text = "Запрещено";
                TabletingStatusLabel23.ForeColor = Color.Red;
            }
            else
            {
                AccidentStatusLabel23.Text = "Нет";
                AccidentStatusLabel23.ForeColor = Color.Black;
            }
        }

        // Датчик #24
        private void Tableting24(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature += random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempTabletingUp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + 12;
            double TempTabletingDown = SetPointTemperature - 12;

            if (currentTemperature > TempTabletingUp || currentTemperature < TempTabletingDown)
            {
                TabletingStatusLabel24.Text = "Запрещено";
                TabletingStatusLabel24.ForeColor = Color.Red;
            }
            else
            {
                TabletingStatusLabel24.Text = "Разрешено";
                TabletingStatusLabel24.ForeColor = Color.Green;
            }
        }

        private void Accident24(double currentTemperature)
        {
            Random random = new Random();

            currentTemperature -= random.Next(1);

            double SetPointTemperature = Convert.ToDouble(InputSetPointTemperaturetextBox.Text);
            double TempAccidentUp = SetPointTemperature + 30;
            double TempAccidentDown = SetPointTemperature - 30;

            if (currentTemperature > TempAccidentUp)
            {
                TemperaturesLabel24.Text = $"{Math.Round(currentTemperature, 2)}";

                AccidentStatusLabel24.Text = "Да";
                AccidentStatusLabel24.ForeColor = Color.Red;

                TabletingStatusLabel24.Text = "Запрещено";
                TabletingStatusLabel24.ForeColor = Color.Red;
            }
            else
            {
                AccidentStatusLabel24.Text = "Нет";
                AccidentStatusLabel24.ForeColor = Color.Black;
            }
        }



        // Функции работы датчиков
        private async void SensorStatusButton_Click(object sender, EventArgs e)
        {
            if (InputSetPointTemperaturetextBox.Text == " ") // Проверка на наличие необходимых данных (Температуры уставки)
            {
                DialogResult msg = DialogResult.OK;
                msg = MessageBox.Show("Необходимо ввести температуру уставки!",
                            "Температура уставки",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowChartButton.Click += ShowChartButton_Click;

            double LowerCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + ControlAccuracy;
            double UpperCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) - ControlAccuracy;

            Stopwatch t = new Stopwatch(); // Главный таймер

            if (SensorStatusButton.Text == "Включить")
            {
                SensorStatusButton.Text = "Выключить";

                // Имитация таймера для сбора времени при расчетах повторного нагревания/остывания
                double time = 0.1;
                double timeOut = 0.1;

                int i = 0; // Переменная для отсчета итерации (после первого нагревания)
                double ControlTemperature = 0.0; // Переменная для фиксирования температуры до процедуры нагревания

                t.Start();
                t.Restart();
                                
                while (SensorStatusButton.Text == "Выключить")
                {
                    if (StartTemperatures[0] < LowerCriticalTemp && t.Elapsed.TotalSeconds < 0.6) // Нагреваем ни сразу
                    {
                        StartTemperatures[0] = 25.97;
                    }
                    else if (StartTemperatures[0] < LowerCriticalTemp) // Если температура ниже верхнего предельного значения
                    {
                        HeaterConditionLabel.Text = "Включен"; // При нагревании прибор вкл, при остывании - выкл
                        HeaterConditionLabel.ForeColor = Color.DarkGreen;

                        if (i == 0) // Срабатывает только один раз - при первом нагревании
                        {
                            StartTemperatures[0] = 210 * (1 - Math.Exp(-0.22 * t.Elapsed.TotalSeconds)); // Нагревание
                            await Task.Delay(350);
                            TemperaturesLabel.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();
                        }
                        else // Срабатывает после первого остывания и далее (i == 1)
                        {
                            double tempTime = 0.1;

                            do
                            {
                                StartTemperatures[0] = ControlTemperature + 210 * (1 - Math.Exp(-0.22 * tempTime)); // Вторая итерация нагревания и далее
                                await Task.Delay(350);
                                TemperaturesLabel.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                                tempTime += timeOut;
                                time += timeOut;

                                Tableting(StartTemperatures[0]);
                                Accident(StartTemperatures[0]);
                            } while (StartTemperatures[0] < LowerCriticalTemp && SensorStatusButton.Text == "Выключить");
                        }
                    }
                    else if (StartTemperatures[0] >= LowerCriticalTemp) // Иначе если температура выше верхнего предельного значения, функция выполняется пока температура выше нижнего предельного значения
                    {
                        HeaterConditionLabel.Text = "Выключен";
                        HeaterConditionLabel.ForeColor = Color.DarkSlateBlue;

                        double tempTime = 0.1;

                        do
                        {
                            StartTemperatures[0] = 175 * (Math.Exp(-0.13 * tempTime)); // Остывание
                            await Task.Delay(350);
                            TemperaturesLabel.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                            tempTime += timeOut;
                            time += timeOut;

                            Tableting(StartTemperatures[0]);
                            Accident(StartTemperatures[0]);
                        } while (StartTemperatures[0] > UpperCriticalTemp && SensorStatusButton.Text == "Выключить");
                    }
                    i = 1; // присваивается 1 после первой итерации нагревания (проверочная итерация для предотвращения резкого остывания/нагревания выше/ниже предельных значений)
                    ControlTemperature = StartTemperatures[0];
                    time += timeOut;
                }
            }
            else if (SensorStatusButton.Text == "Выключить")
            {
                SensorStatusButton.Text = "Включить";
                t.Reset();
            }
        }

        private async void SensorStatusButton2_Click(object sender, EventArgs e)
        {
            if (InputSetPointTemperaturetextBox.Text == "") // Проверка на наличие необходимых данных (Температуры уставки)
            {
                DialogResult msg = DialogResult.OK;
                msg = MessageBox.Show("Необходимо ввести температуру уставки!",
                            "Температура уставки",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowChartButton2.Click += ShowChartButton_Click;

            double LowerCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + ControlAccuracy;
            double UpperCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) - ControlAccuracy;

            Stopwatch t = new Stopwatch(); // Главный таймер

            if (SensorStatusButton2.Text == "Включить")
            {
                SensorStatusButton2.Text = "Выключить";

                // Имитация таймера для сбора времени при расчетах повторного нагревания/остывания
                double time = 0.1;
                double timeOut = 0.1;

                int i = 0; // Переменная для отсчета итерации (после первого нагревания)
                double ControlTemperature = 0.0; // Переменная для фиксирования температуры до процедуры нагревания
                
                t.Start();
                t.Restart();

                while (SensorStatusButton2.Text == "Выключить")
                {
                    if (StartTemperatures[0] < LowerCriticalTemp && t.Elapsed.TotalSeconds < 0.6) // Нагреваем ни сразу
                    {
                        StartTemperatures[0] = 25.97;
                    }
                    else if (StartTemperatures[0] < LowerCriticalTemp) // Если температура ниже верхнего предельного значения
                    {
                        HeaterConditionLabel2.Text = "Включен"; // При нагревании прибор вкл, при остывании - выкл
                        HeaterConditionLabel2.ForeColor = Color.DarkGreen;

                        if (i == 0) // Срабатывает только один раз - при первом нагревании
                        {
                            StartTemperatures[0] = 210 * (1 - Math.Exp(-0.22 * t.Elapsed.TotalSeconds)); // Нагревание
                            await Task.Delay(350);
                            TemperaturesLabel2.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();
                        }
                        else // Срабатывает после первого остывания и далее (i == 1)
                        {
                            double tempTime = 0.1;

                            do
                            {
                                StartTemperatures[0] = ControlTemperature + 210 * (1 - Math.Exp(-0.22 * tempTime)); // Вторая итерация нагревания и далее
                                await Task.Delay(350);
                                TemperaturesLabel2.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                                tempTime += timeOut;
                                time += timeOut;

                                Tableting2(StartTemperatures[0]);
                                Accident2(StartTemperatures[0]);
                            } while (StartTemperatures[0] < LowerCriticalTemp && SensorStatusButton2.Text == "Выключить");
                        }
                    }
                    else if (StartTemperatures[0] >= LowerCriticalTemp) // Иначе если температура выше верхнего предельного значения, функция выполняется пока температура выше нижнего предельного значения
                    {
                        HeaterConditionLabel2.Text = "Выключен";
                        HeaterConditionLabel2.ForeColor = Color.DarkSlateBlue;

                        double tempTime = 0.1;

                        do
                        {
                            StartTemperatures[0] = 175 * (Math.Exp(-0.13 * tempTime)); // Остывание
                            await Task.Delay(350);
                            TemperaturesLabel2.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                            tempTime += timeOut;
                            time += timeOut;

                            Tableting2(StartTemperatures[0]);
                            Accident2(StartTemperatures[0]);
                        } while (StartTemperatures[0] > UpperCriticalTemp && SensorStatusButton2.Text == "Выключить");
                    }
                    i = 1; // присваивается 1 после первой итерации нагревания (проверочная итерация для предотвращения резкого остывания/нагревания выше/ниже предельных значений)
                    ControlTemperature = StartTemperatures[0];
                    time += timeOut;
                }
            }
            else if (SensorStatusButton2.Text == "Выключить")
            {
                SensorStatusButton2.Text = "Включить";
                t.Reset();
            }
        }

        private async void SensorStatusButton3_Click(object sender, EventArgs e)
        {
            if (InputSetPointTemperaturetextBox.Text == "") // Проверка на наличие необходимых данных (Температуры уставки)
            {
                DialogResult msg = DialogResult.OK;
                msg = MessageBox.Show("Необходимо ввести температуру уставки!",
                            "Температура уставки",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowChartButton3.Click += ShowChartButton_Click;

            double LowerCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + ControlAccuracy;
            double UpperCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) - ControlAccuracy;

            Stopwatch t = new Stopwatch(); // Главный таймер

            if (SensorStatusButton3.Text == "Включить")
            {
                SensorStatusButton3.Text = "Выключить";

                // Имитация таймера для сбора времени при расчетах повторного нагревания/остывания
                double time = 0.1;
                double timeOut = 0.1;

                int i = 0; // Переменная для отсчета итерации (после первого нагревания)
                double ControlTemperature = 0.0; // Переменная для фиксирования температуры до процедуры нагревания

                t.Start();
                t.Restart();

                while (SensorStatusButton3.Text == "Выключить")
                {
                    if (StartTemperatures[0] < LowerCriticalTemp && t.Elapsed.TotalSeconds < 0.6) // Нагреваем ни сразу
                    {
                        StartTemperatures[0] = 25.97;
                    }
                    else if (StartTemperatures[0] < LowerCriticalTemp) // Если температура ниже верхнего предельного значения
                    {
                        HeaterConditionLabel3.Text = "Включен"; // При нагревании прибор вкл, при остывании - выкл
                        HeaterConditionLabel3.ForeColor = Color.DarkGreen;

                        if (i == 0) // Срабатывает только один раз - при первом нагревании
                        {
                            StartTemperatures[0] = 210 * (1 - Math.Exp(-0.22 * t.Elapsed.TotalSeconds)); // Нагревание
                            await Task.Delay(350);
                            TemperaturesLabel3.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();
                        }
                        else // Срабатывает после первого остывания и далее (i == 1)
                        {
                            double tempTime = 0.1;

                            do
                            {
                                StartTemperatures[0] = ControlTemperature + 210 * (1 - Math.Exp(-0.22 * tempTime)); // Вторая итерация нагревания и далее
                                await Task.Delay(350);
                                TemperaturesLabel3.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                                tempTime += timeOut;
                                time += timeOut;

                                Tableting3(StartTemperatures[0]);
                                Accident3(StartTemperatures[0]);
                            } while (StartTemperatures[0] < LowerCriticalTemp && SensorStatusButton3.Text == "Выключить");
                        }
                    }
                    else if (StartTemperatures[0] >= LowerCriticalTemp) // Иначе если температура выше верхнего предельного значения, функция выполняется пока температура выше нижнего предельного значения
                    {
                        HeaterConditionLabel3.Text = "Выключен";
                        HeaterConditionLabel3.ForeColor = Color.DarkSlateBlue;

                        double tempTime = 0.1;

                        do
                        {
                            StartTemperatures[0] = 175 * (Math.Exp(-0.13 * tempTime)); // Остывание
                            await Task.Delay(350);
                            TemperaturesLabel3.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                            tempTime += timeOut;
                            time += timeOut;

                            Tableting3(StartTemperatures[0]);
                            Accident3(StartTemperatures[0]);
                        } while (StartTemperatures[0] > UpperCriticalTemp && SensorStatusButton3.Text == "Выключить");
                    }
                    i = 1; // присваивается 1 после первой итерации нагревания (проверочная итерация для предотвращения резкого остывания/нагревания выше/ниже предельных значений)
                    ControlTemperature = StartTemperatures[0];
                    time += timeOut;
                }
            }
            else if (SensorStatusButton3.Text == "Выключить")
            {
                SensorStatusButton3.Text = "Включить";
                t.Reset();
            }
        }

        private async void SensorStatusButton4_Click(object sender, EventArgs e)
        {
            if (InputSetPointTemperaturetextBox.Text == "") // Проверка на наличие необходимых данных (Температуры уставки)
            {
                DialogResult msg = DialogResult.OK;
                msg = MessageBox.Show("Необходимо ввести температуру уставки!",
                            "Температура уставки",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowChartButton4.Click += ShowChartButton_Click;

            double LowerCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + ControlAccuracy;
            double UpperCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) - ControlAccuracy;

            Stopwatch t = new Stopwatch(); // Главный таймер

            if (SensorStatusButton4.Text == "Включить")
            {
                SensorStatusButton4.Text = "Выключить";

                // Имитация таймера для сбора времени при расчетах повторного нагревания/остывания
                double time = 0.1;
                double timeOut = 0.1;

                int i = 0; // Переменная для отсчета итерации (после первого нагревания)
                double ControlTemperature = 0.0; // Переменная для фиксирования температуры до процедуры нагревания

                t.Start();
                t.Restart();

                while (SensorStatusButton4.Text == "Выключить")
                {
                    if (StartTemperatures[0] < LowerCriticalTemp && t.Elapsed.TotalSeconds < 0.6) // Нагреваем ни сразу
                    {
                        StartTemperatures[0] = 25.97;
                    }
                    else if (StartTemperatures[0] < LowerCriticalTemp) // Если температура ниже верхнего предельного значения
                    {
                        HeaterConditionLabel4.Text = "Включен"; // При нагревании прибор вкл, при остывании - выкл
                        HeaterConditionLabel4.ForeColor = Color.DarkGreen;

                        if (i == 0) // Срабатывает только один раз - при первом нагревании
                        {
                            StartTemperatures[0] = 210 * (1 - Math.Exp(-0.22 * t.Elapsed.TotalSeconds)); // Нагревание
                            await Task.Delay(350);
                            TemperaturesLabel4.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();
                        }
                        else // Срабатывает после первого остывания и далее (i == 1)
                        {
                            double tempTime = 0.1;

                            do
                            {
                                StartTemperatures[0] = ControlTemperature + 210 * (1 - Math.Exp(-0.22 * tempTime)); // Вторая итерация нагревания и далее
                                await Task.Delay(350);
                                TemperaturesLabel4.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                                tempTime += timeOut;
                                time += timeOut;

                                Tableting4(StartTemperatures[0]);
                                Accident4(StartTemperatures[0]);
                            } while (StartTemperatures[0] < LowerCriticalTemp && SensorStatusButton4.Text == "Выключить");
                        }
                    }
                    else if (StartTemperatures[0] >= LowerCriticalTemp) // Иначе если температура выше верхнего предельного значения, функция выполняется пока температура выше нижнего предельного значения
                    {
                        HeaterConditionLabel4.Text = "Выключен";
                        HeaterConditionLabel4.ForeColor = Color.DarkSlateBlue;

                        double tempTime = 0.1;

                        do
                        {
                            StartTemperatures[0] = 175 * (Math.Exp(-0.13 * tempTime)); // Остывание
                            await Task.Delay(350);
                            TemperaturesLabel4.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                            tempTime += timeOut;
                            time += timeOut;

                            Tableting4(StartTemperatures[0]);
                            Accident4(StartTemperatures[0]);
                        } while (StartTemperatures[0] > UpperCriticalTemp && SensorStatusButton4.Text == "Выключить");
                    }
                    i = 1; // присваивается 1 после первой итерации нагревания (проверочная итерация для предотвращения резкого остывания/нагревания выше/ниже предельных значений)
                    ControlTemperature = StartTemperatures[0];
                    time += timeOut;
                }
            }
            else if (SensorStatusButton4.Text == "Выключить")
            {
                SensorStatusButton4.Text = "Включить";
                t.Reset();
            }
        }

        private async void SensorStatusButton5_Click(object sender, EventArgs e)
        {
            if (InputSetPointTemperaturetextBox.Text == "") // Проверка на наличие необходимых данных (Температуры уставки)
            {
                DialogResult msg = DialogResult.OK;
                msg = MessageBox.Show("Необходимо ввести температуру уставки!",
                            "Температура уставки",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowChartButton5.Click += ShowChartButton_Click;

            double LowerCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + ControlAccuracy;
            double UpperCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) - ControlAccuracy;

            Stopwatch t = new Stopwatch(); // Главный таймер

            if (SensorStatusButton5.Text == "Включить")
            {
                SensorStatusButton5.Text = "Выключить";

                // Имитация таймера для сбора времени при расчетах повторного нагревания/остывания
                double time = 0.1;
                double timeOut = 0.1;

                int i = 0; // Переменная для отсчета итерации (после первого нагревания)
                double ControlTemperature = 0.0; // Переменная для фиксирования температуры до процедуры нагревания

                t.Start();
                t.Restart();

                while (SensorStatusButton5.Text == "Выключить")
                {
                    if (StartTemperatures[0] < LowerCriticalTemp && t.Elapsed.TotalSeconds < 0.6) // Нагреваем ни сразу
                    {
                        StartTemperatures[0] = 25.97;
                    }
                    else if (StartTemperatures[0] < LowerCriticalTemp) // Если температура ниже верхнего предельного значения
                    {
                        HeaterConditionLabel5.Text = "Включен"; // При нагревании прибор вкл, при остывании - выкл
                        HeaterConditionLabel5.ForeColor = Color.DarkGreen;

                        if (i == 0) // Срабатывает только один раз - при первом нагревании
                        {
                            StartTemperatures[0] = 210 * (1 - Math.Exp(-0.22 * t.Elapsed.TotalSeconds)); // Нагревание
                            await Task.Delay(350);
                            TemperaturesLabel5.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();
                        }
                        else // Срабатывает после первого остывания и далее (i == 1)
                        {
                            double tempTime = 0.1;

                            do
                            {
                                StartTemperatures[0] = ControlTemperature + 210 * (1 - Math.Exp(-0.22 * tempTime)); // Вторая итерация нагревания и далее
                                await Task.Delay(350);
                                TemperaturesLabel5.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                                tempTime += timeOut;
                                time += timeOut;

                                Tableting5(StartTemperatures[0]);
                                Accident5(StartTemperatures[0]);
                            } while (StartTemperatures[0] < LowerCriticalTemp && SensorStatusButton5.Text == "Выключить");
                        }
                    }
                    else if (StartTemperatures[0] >= LowerCriticalTemp) // Иначе если температура выше верхнего предельного значения, функция выполняется пока температура выше нижнего предельного значения
                    {
                        HeaterConditionLabel5.Text = "Выключен";
                        HeaterConditionLabel5.ForeColor = Color.DarkSlateBlue;

                        double tempTime = 0.1;

                        do
                        {
                            StartTemperatures[0] = 175 * (Math.Exp(-0.13 * tempTime)); // Остывание
                            await Task.Delay(350);
                            TemperaturesLabel5.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                            tempTime += timeOut;
                            time += timeOut;

                            Tableting5(StartTemperatures[0]);
                            Accident5(StartTemperatures[0]);
                        } while (StartTemperatures[0] > UpperCriticalTemp && SensorStatusButton5.Text == "Выключить");
                    }
                    i = 1; // присваивается 1 после первой итерации нагревания (проверочная итерация для предотвращения резкого остывания/нагревания выше/ниже предельных значений)
                    ControlTemperature = StartTemperatures[0];
                    time += timeOut;
                }
            }
            else if (SensorStatusButton5.Text == "Выключить")
            {
                SensorStatusButton5.Text = "Включить";
                t.Reset();
            }
        }

        private async void SensorStatusButton6_Click(object sender, EventArgs e)
        {
            if (InputSetPointTemperaturetextBox.Text == "") // Проверка на наличие необходимых данных (Температуры уставки)
            {
                DialogResult msg = DialogResult.OK;
                msg = MessageBox.Show("Необходимо ввести температуру уставки!",
                            "Температура уставки",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowChartButton6.Click += ShowChartButton_Click;

            double LowerCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + ControlAccuracy;
            double UpperCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) - ControlAccuracy;

            Stopwatch t = new Stopwatch(); // Главный таймер

            if (SensorStatusButton6.Text == "Включить")
            {
                SensorStatusButton6.Text = "Выключить";

                // Имитация таймера для сбора времени при расчетах повторного нагревания/остывания
                double time = 0.1;
                double timeOut = 0.1;

                int i = 0; // Переменная для отсчета итерации (после первого нагревания)
                double ControlTemperature = 0.0; // Переменная для фиксирования температуры до процедуры нагревания

                t.Start();
                t.Restart();

                while (SensorStatusButton6.Text == "Выключить")
                {
                    if (StartTemperatures[0] < LowerCriticalTemp && t.Elapsed.TotalSeconds < 0.6) // Нагреваем ни сразу
                    {
                        StartTemperatures[0] = 25.97;
                    }
                    else if (StartTemperatures[0] < LowerCriticalTemp) // Если температура ниже верхнего предельного значения
                    {
                        HeaterConditionLabel6.Text = "Включен"; // При нагревании прибор вкл, при остывании - выкл
                        HeaterConditionLabel6.ForeColor = Color.DarkGreen;

                        if (i == 0) // Срабатывает только один раз - при первом нагревании
                        {
                            StartTemperatures[0] = 210 * (1 - Math.Exp(-0.22 * t.Elapsed.TotalSeconds)); // Нагревание
                            await Task.Delay(350);
                            TemperaturesLabel6.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();
                        }
                        else // Срабатывает после первого остывания и далее (i == 1)
                        {
                            double tempTime = 0.1;

                            do
                            {
                                StartTemperatures[0] = ControlTemperature + 210 * (1 - Math.Exp(-0.22 * tempTime)); // Вторая итерация нагревания и далее
                                await Task.Delay(350);
                                TemperaturesLabel6.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                                tempTime += timeOut;
                                time += timeOut;

                                Tableting6(StartTemperatures[0]);
                                Accident6(StartTemperatures[0]);
                            } while (StartTemperatures[0] < LowerCriticalTemp && SensorStatusButton6.Text == "Выключить");
                        }
                    }
                    else if (StartTemperatures[0] >= LowerCriticalTemp) // Иначе если температура выше верхнего предельного значения, функция выполняется пока температура выше нижнего предельного значения
                    {
                        HeaterConditionLabel6.Text = "Выключен";
                        HeaterConditionLabel6.ForeColor = Color.DarkSlateBlue;

                        double tempTime = 0.1;

                        do
                        {
                            StartTemperatures[0] = 175 * (Math.Exp(-0.13 * tempTime)); // Остывание
                            await Task.Delay(350);
                            TemperaturesLabel6.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                            tempTime += timeOut;
                            time += timeOut;

                            Tableting6(StartTemperatures[0]);
                            Accident6(StartTemperatures[0]);
                        } while (StartTemperatures[0] > UpperCriticalTemp && SensorStatusButton6.Text == "Выключить");
                    }
                    i = 1; // присваивается 1 после первой итерации нагревания (проверочная итерация для предотвращения резкого остывания/нагревания выше/ниже предельных значений)
                    ControlTemperature = StartTemperatures[0];
                    time += timeOut;
                }
            }
            else if (SensorStatusButton6.Text == "Выключить")
            {
                SensorStatusButton6.Text = "Включить";
                t.Reset();
            }
        }

        private async void SensorStatusButton7_Click(object sender, EventArgs e)
        {
            if (InputSetPointTemperaturetextBox.Text == "") // Проверка на наличие необходимых данных (Температуры уставки)
            {
                DialogResult msg = DialogResult.OK;
                msg = MessageBox.Show("Необходимо ввести температуру уставки!",
                            "Температура уставки",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowChartButton7.Click += ShowChartButton_Click;

            double LowerCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + ControlAccuracy;
            double UpperCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) - ControlAccuracy;

            Stopwatch t = new Stopwatch(); // Главный таймер

            if (SensorStatusButton7.Text == "Включить")
            {
                SensorStatusButton7.Text = "Выключить";

                // Имитация таймера для сбора времени при расчетах повторного нагревания/остывания
                double time = 0.1;
                double timeOut = 0.1;

                int i = 0; // Переменная для отсчета итерации (после первого нагревания)
                double ControlTemperature = 0.0; // Переменная для фиксирования температуры до процедуры нагревания

                t.Start();
                t.Restart();

                while (SensorStatusButton7.Text == "Выключить")
                {
                    if (StartTemperatures[0] < LowerCriticalTemp && t.Elapsed.TotalSeconds < 0.6) // Нагреваем ни сразу
                    {
                        StartTemperatures[0] = 25.97;
                    }
                    else if (StartTemperatures[0] < LowerCriticalTemp) // Если температура ниже верхнего предельного значения
                    {
                        HeaterConditionLabel7.Text = "Включен"; // При нагревании прибор вкл, при остывании - выкл
                        HeaterConditionLabel7.ForeColor = Color.DarkGreen;

                        if (i == 0) // Срабатывает только один раз - при первом нагревании
                        {
                            StartTemperatures[0] = 210 * (1 - Math.Exp(-0.22 * t.Elapsed.TotalSeconds)); // Нагревание
                            await Task.Delay(350);
                            TemperaturesLabel7.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();
                        }
                        else // Срабатывает после первого остывания и далее (i == 1)
                        {
                            double tempTime = 0.1;

                            do
                            {
                                StartTemperatures[0] = ControlTemperature + 210 * (1 - Math.Exp(-0.22 * tempTime)); // Вторая итерация нагревания и далее
                                await Task.Delay(350);
                                TemperaturesLabel7.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                                tempTime += timeOut;
                                time += timeOut;

                                Tableting7(StartTemperatures[0]);
                                Accident7(StartTemperatures[0]);
                            } while (StartTemperatures[0] < LowerCriticalTemp && SensorStatusButton7.Text == "Выключить");
                        }
                    }
                    else if (StartTemperatures[0] >= LowerCriticalTemp) // Иначе если температура выше верхнего предельного значения, функция выполняется пока температура выше нижнего предельного значения
                    {
                        HeaterConditionLabel7.Text = "Выключен";
                        HeaterConditionLabel7.ForeColor = Color.DarkSlateBlue;

                        double tempTime = 0.1;

                        do
                        {
                            StartTemperatures[0] = 175 * (Math.Exp(-0.13 * tempTime)); // Остывание
                            await Task.Delay(350);
                            TemperaturesLabel7.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                            tempTime += timeOut;
                            time += timeOut;

                            Tableting7(StartTemperatures[0]);
                            Accident7(StartTemperatures[0]);
                        } while (StartTemperatures[0] > UpperCriticalTemp && SensorStatusButton7.Text == "Выключить");
                    }
                    i = 1; // присваивается 1 после первой итерации нагревания (проверочная итерация для предотвращения резкого остывания/нагревания выше/ниже предельных значений)
                    ControlTemperature = StartTemperatures[0];
                    time += timeOut;
                }
            }
            else if (SensorStatusButton7.Text == "Выключить")
            {
                SensorStatusButton7.Text = "Включить";
                t.Reset();
            }
        }

        private async void SensorStatusButton8_Click(object sender, EventArgs e)
        {
            if (InputSetPointTemperaturetextBox.Text == "") // Проверка на наличие необходимых данных (Температуры уставки)
            {
                DialogResult msg = DialogResult.OK;
                msg = MessageBox.Show("Необходимо ввести температуру уставки!",
                            "Температура уставки",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowChartButton8.Click += ShowChartButton_Click;

            double LowerCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + ControlAccuracy;
            double UpperCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) - ControlAccuracy;

            Stopwatch t = new Stopwatch(); // Главный таймер

            if (SensorStatusButton8.Text == "Включить")
            {
                SensorStatusButton8.Text = "Выключить";

                // Имитация таймера для сбора времени при расчетах повторного нагревания/остывания
                double time = 0.1;
                double timeOut = 0.1;

                int i = 0; // Переменная для отсчета итерации (после первого нагревания)
                double ControlTemperature = 0.0; // Переменная для фиксирования температуры до процедуры нагревания

                t.Start();
                t.Restart();

                while (SensorStatusButton8.Text == "Выключить")
                {
                    if (StartTemperatures[0] < LowerCriticalTemp && t.Elapsed.TotalSeconds < 0.6) // Нагреваем ни сразу
                    {
                        StartTemperatures[0] = 25.97;
                    }
                    else if (StartTemperatures[0] < LowerCriticalTemp) // Если температура ниже верхнего предельного значения
                    {
                        HeaterConditionLabel8.Text = "Включен"; // При нагревании прибор вкл, при остывании - выкл
                        HeaterConditionLabel8.ForeColor = Color.DarkGreen;

                        if (i == 0) // Срабатывает только один раз - при первом нагревании
                        {
                            StartTemperatures[0] = 210 * (1 - Math.Exp(-0.22 * t.Elapsed.TotalSeconds)); // Нагревание
                            await Task.Delay(350);
                            TemperaturesLabel8.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();
                        }
                        else // Срабатывает после первого остывания и далее (i == 1)
                        {
                            double tempTime = 0.1;

                            do
                            {
                                StartTemperatures[0] = ControlTemperature + 210 * (1 - Math.Exp(-0.22 * tempTime)); // Вторая итерация нагревания и далее
                                await Task.Delay(350);
                                TemperaturesLabel8.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                                tempTime += timeOut;
                                time += timeOut;

                                Tableting8(StartTemperatures[0]);
                                Accident8(StartTemperatures[0]);
                            } while (StartTemperatures[0] < LowerCriticalTemp && SensorStatusButton8.Text == "Выключить");
                        }
                    }
                    else if (StartTemperatures[0] >= LowerCriticalTemp) // Иначе если температура выше верхнего предельного значения, функция выполняется пока температура выше нижнего предельного значения
                    {
                        HeaterConditionLabel8.Text = "Выключен";
                        HeaterConditionLabel8.ForeColor = Color.DarkSlateBlue;

                        double tempTime = 0.1;

                        do
                        {
                            StartTemperatures[0] = 175 * (Math.Exp(-0.13 * tempTime)); // Остывание
                            await Task.Delay(350);
                            TemperaturesLabel8.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                            tempTime += timeOut;
                            time += timeOut;

                            Tableting8(StartTemperatures[0]);
                            Accident8(StartTemperatures[0]);
                        } while (StartTemperatures[0] > UpperCriticalTemp && SensorStatusButton8.Text == "Выключить");
                    }
                    i = 1; // присваивается 1 после первой итерации нагревания (проверочная итерация для предотвращения резкого остывания/нагревания выше/ниже предельных значений)
                    ControlTemperature = StartTemperatures[0];
                    time += timeOut;
                }
            }
            else if (SensorStatusButton8.Text == "Выключить")
            {
                SensorStatusButton8.Text = "Включить";
                t.Reset();
            }
        }



        private async void SensorStatusButton9_Click(object sender, EventArgs e)
        {
            if (InputSetPointTemperaturetextBox.Text == "") // Проверка на наличие необходимых данных (Температуры уставки)
            {
                DialogResult msg = DialogResult.OK;
                msg = MessageBox.Show("Необходимо ввести температуру уставки!",
                            "Температура уставки",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowChartButton9.Click += ShowChartButton_Click;

            double LowerCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + ControlAccuracy;
            double UpperCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) - ControlAccuracy;

            Stopwatch t = new Stopwatch(); // Главный таймер

            if (SensorStatusButton9.Text == "Включить")
            {
                SensorStatusButton9.Text = "Выключить";

                // Имитация таймера для сбора времени при расчетах повторного нагревания/остывания
                double time = 0.1;
                double timeOut = 0.1;

                int i = 0; // Переменная для отсчета итерации (после первого нагревания)
                double ControlTemperature = 0.0; // Переменная для фиксирования температуры до процедуры нагревания

                t.Start();
                t.Restart();

                while (SensorStatusButton9.Text == "Выключить")
                {
                    if (StartTemperatures[0] < LowerCriticalTemp && t.Elapsed.TotalSeconds < 0.6) // Нагреваем ни сразу
                    {
                        StartTemperatures[0] = 25.97;
                    }
                    else if (StartTemperatures[0] < LowerCriticalTemp) // Если температура ниже верхнего предельного значения
                    {
                        HeaterConditionLabel9.Text = "Включен"; // При нагревании прибор вкл, при остывании - выкл
                        HeaterConditionLabel9.ForeColor = Color.DarkGreen;

                        if (i == 0) // Срабатывает только один раз - при первом нагревании
                        {
                            StartTemperatures[0] = 210 * (1 - Math.Exp(-0.22 * t.Elapsed.TotalSeconds)); // Нагревание
                            await Task.Delay(350);
                            TemperaturesLabel9.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();
                        }
                        else // Срабатывает после первого остывания и далее (i == 1)
                        {
                            double tempTime = 0.1;

                            do
                            {
                                StartTemperatures[0] = ControlTemperature + 210 * (1 - Math.Exp(-0.22 * tempTime)); // Вторая итерация нагревания и далее
                                await Task.Delay(350);
                                TemperaturesLabel9.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                                tempTime += timeOut;
                                time += timeOut;

                                Tableting9(StartTemperatures[0]);
                                Accident9(StartTemperatures[0]);
                            } while (StartTemperatures[0] < LowerCriticalTemp && SensorStatusButton9.Text == "Выключить");
                        }
                    }
                    else if (StartTemperatures[0] >= LowerCriticalTemp) // Иначе если температура выше верхнего предельного значения, функция выполняется пока температура выше нижнего предельного значения
                    {
                        HeaterConditionLabel9.Text = "Выключен";
                        HeaterConditionLabel9.ForeColor = Color.DarkSlateBlue;

                        double tempTime = 0.1;

                        do
                        {
                            StartTemperatures[0] = 175 * (Math.Exp(-0.13 * tempTime)); // Остывание
                            await Task.Delay(350);
                            TemperaturesLabel9.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                            tempTime += timeOut;
                            time += timeOut;

                            Tableting9(StartTemperatures[0]);
                            Accident9(StartTemperatures[0]);
                        } while (StartTemperatures[0] > UpperCriticalTemp && SensorStatusButton9.Text == "Выключить");
                    }
                    i = 1; // присваивается 1 после первой итерации нагревания (проверочная итерация для предотвращения резкого остывания/нагревания выше/ниже предельных значений)
                    ControlTemperature = StartTemperatures[0];
                    time += timeOut;
                }
            }
            else if (SensorStatusButton9.Text == "Выключить")
            {
                SensorStatusButton9.Text = "Включить";
                t.Reset();
            }
        }

        private async void SensorStatusButton10_Click(object sender, EventArgs e)
        {
            if (InputSetPointTemperaturetextBox.Text == "") // Проверка на наличие необходимых данных (Температуры уставки)
            {
                DialogResult msg = DialogResult.OK;
                msg = MessageBox.Show("Необходимо ввести температуру уставки!",
                            "Температура уставки",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowChartButton10.Click += ShowChartButton_Click;

            double LowerCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + ControlAccuracy;
            double UpperCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) - ControlAccuracy;

            Stopwatch t = new Stopwatch(); // Главный таймер

            if (SensorStatusButton10.Text == "Включить")
            {
                SensorStatusButton10.Text = "Выключить";

                // Имитация таймера для сбора времени при расчетах повторного нагревания/остывания
                double time = 0.1;
                double timeOut = 0.1;

                int i = 0; // Переменная для отсчета итерации (после первого нагревания)
                double ControlTemperature = 0.0; // Переменная для фиксирования температуры до процедуры нагревания

                t.Start();
                t.Restart();

                while (SensorStatusButton10.Text == "Выключить")
                {
                    if (StartTemperatures[0] < LowerCriticalTemp && t.Elapsed.TotalSeconds < 0.6) // Нагреваем ни сразу
                    {
                        StartTemperatures[0] = 25.97;
                    }
                    else if (StartTemperatures[0] < LowerCriticalTemp) // Если температура ниже верхнего предельного значения
                    {
                        HeaterConditionLabel10.Text = "Включен"; // При нагревании прибор вкл, при остывании - выкл
                        HeaterConditionLabel10.ForeColor = Color.DarkGreen;

                        if (i == 0) // Срабатывает только один раз - при первом нагревании
                        {
                            StartTemperatures[0] = 210 * (1 - Math.Exp(-0.22 * t.Elapsed.TotalSeconds)); // Нагревание
                            await Task.Delay(350);
                            TemperaturesLabel10.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();
                        }
                        else // Срабатывает после первого остывания и далее (i == 1)
                        {
                            double tempTime = 0.1;

                            do
                            {
                                StartTemperatures[0] = ControlTemperature + 210 * (1 - Math.Exp(-0.22 * tempTime)); // Вторая итерация нагревания и далее
                                await Task.Delay(350);
                                TemperaturesLabel10.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                                tempTime += timeOut;
                                time += timeOut;

                                Tableting10(StartTemperatures[0]);
                                Accident10(StartTemperatures[0]);
                            } while (StartTemperatures[0] < LowerCriticalTemp && SensorStatusButton10.Text == "Выключить");
                        }
                    }
                    else if (StartTemperatures[0] >= LowerCriticalTemp) // Иначе если температура выше верхнего предельного значения, функция выполняется пока температура выше нижнего предельного значения
                    {
                        HeaterConditionLabel10.Text = "Выключен";
                        HeaterConditionLabel10.ForeColor = Color.DarkSlateBlue;

                        double tempTime = 0.1;

                        do
                        {
                            StartTemperatures[0] = 175 * (Math.Exp(-0.13 * tempTime)); // Остывание
                            await Task.Delay(350);
                            TemperaturesLabel10.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                            tempTime += timeOut;
                            time += timeOut;

                            Tableting10(StartTemperatures[0]);
                            Accident10(StartTemperatures[0]);
                        } while (StartTemperatures[0] > UpperCriticalTemp && SensorStatusButton10.Text == "Выключить");
                    }
                    i = 1; // присваивается 1 после первой итерации нагревания (проверочная итерация для предотвращения резкого остывания/нагревания выше/ниже предельных значений)
                    ControlTemperature = StartTemperatures[0];
                    time += timeOut;
                }
            }
            else if (SensorStatusButton10.Text == "Выключить")
            {
                SensorStatusButton10.Text = "Включить";
                t.Reset();
            }
        }

        private async void SensorStatusButton11_Click(object sender, EventArgs e)
        {
            if (InputSetPointTemperaturetextBox.Text == "") // Проверка на наличие необходимых данных (Температуры уставки)
            {
                DialogResult msg = DialogResult.OK;
                msg = MessageBox.Show("Необходимо ввести температуру уставки!",
                            "Температура уставки",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowChartButton11.Click += ShowChartButton_Click;

            double LowerCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + ControlAccuracy;
            double UpperCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) - ControlAccuracy;

            Stopwatch t = new Stopwatch(); // Главный таймер

            if (SensorStatusButton11.Text == "Включить")
            {
                SensorStatusButton11.Text = "Выключить";

                // Имитация таймера для сбора времени при расчетах повторного нагревания/остывания
                double time = 0.1;
                double timeOut = 0.1;

                int i = 0; // Переменная для отсчета итерации (после первого нагревания)
                double ControlTemperature = 0.0; // Переменная для фиксирования температуры до процедуры нагревания

                t.Start();
                t.Restart();

                while (SensorStatusButton11.Text == "Выключить")
                {
                    if (StartTemperatures[0] < LowerCriticalTemp && t.Elapsed.TotalSeconds < 0.6) // Нагреваем ни сразу
                    {
                        StartTemperatures[0] = 25.97;
                    }
                    else if (StartTemperatures[0] < LowerCriticalTemp) // Если температура ниже верхнего предельного значения
                    {
                        HeaterConditionLabel11.Text = "Включен"; // При нагревании прибор вкл, при остывании - выкл
                        HeaterConditionLabel11.ForeColor = Color.DarkGreen;

                        if (i == 0) // Срабатывает только один раз - при первом нагревании
                        {
                            StartTemperatures[0] = 210 * (1 - Math.Exp(-0.22 * t.Elapsed.TotalSeconds)); // Нагревание
                            await Task.Delay(350);
                            TemperaturesLabel11.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();
                        }
                        else // Срабатывает после первого остывания и далее (i == 1)
                        {
                            double tempTime = 0.1;

                            do
                            {
                                StartTemperatures[0] = ControlTemperature + 210 * (1 - Math.Exp(-0.22 * tempTime)); // Вторая итерация нагревания и далее
                                await Task.Delay(350);
                                TemperaturesLabel11.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                                tempTime += timeOut;
                                time += timeOut;

                                Tableting11(StartTemperatures[0]);
                                Accident11(StartTemperatures[0]);
                            } while (StartTemperatures[0] < LowerCriticalTemp && SensorStatusButton11.Text == "Выключить");
                        }
                    }
                    else if (StartTemperatures[0] >= LowerCriticalTemp) // Иначе если температура выше верхнего предельного значения, функция выполняется пока температура выше нижнего предельного значения
                    {
                        HeaterConditionLabel11.Text = "Выключен";
                        HeaterConditionLabel11.ForeColor = Color.DarkSlateBlue;

                        double tempTime = 0.1;

                        do
                        {
                            StartTemperatures[0] = 175 * (Math.Exp(-0.13 * tempTime)); // Остывание
                            await Task.Delay(350);
                            TemperaturesLabel11.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                            tempTime += timeOut;
                            time += timeOut;

                            Tableting11(StartTemperatures[0]);
                            Accident11(StartTemperatures[0]);
                        } while (StartTemperatures[0] > UpperCriticalTemp && SensorStatusButton11.Text == "Выключить");
                    }
                    i = 1; // присваивается 1 после первой итерации нагревания (проверочная итерация для предотвращения резкого остывания/нагревания выше/ниже предельных значений)
                    ControlTemperature = StartTemperatures[0];
                    time += timeOut;
                }
            }
            else if (SensorStatusButton11.Text == "Выключить")
            {
                SensorStatusButton11.Text = "Включить";
                t.Reset();
            }
        }

        private async void SensorStatusButton12_Click(object sender, EventArgs e)
        {
            if (InputSetPointTemperaturetextBox.Text == "") // Проверка на наличие необходимых данных (Температуры уставки)
            {
                DialogResult msg = DialogResult.OK;
                msg = MessageBox.Show("Необходимо ввести температуру уставки!",
                            "Температура уставки",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowChartButton12.Click += ShowChartButton_Click;

            double LowerCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + ControlAccuracy;
            double UpperCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) - ControlAccuracy;

            Stopwatch t = new Stopwatch(); // Главный таймер

            if (SensorStatusButton12.Text == "Включить")
            {
                SensorStatusButton12.Text = "Выключить";

                // Имитация таймера для сбора времени при расчетах повторного нагревания/остывания
                double time = 0.1;
                double timeOut = 0.1;

                int i = 0; // Переменная для отсчета итерации (после первого нагревания)
                double ControlTemperature = 0.0; // Переменная для фиксирования температуры до процедуры нагревания

                t.Start();
                t.Restart();

                while (SensorStatusButton12.Text == "Выключить")
                {
                    if (StartTemperatures[0] < LowerCriticalTemp && t.Elapsed.TotalSeconds < 0.6) // Нагреваем ни сразу
                    {
                        StartTemperatures[0] = 25.97;
                    }
                    else if (StartTemperatures[0] < LowerCriticalTemp) // Если температура ниже верхнего предельного значения
                    {
                        HeaterConditionLabel12.Text = "Включен"; // При нагревании прибор вкл, при остывании - выкл
                        HeaterConditionLabel12.ForeColor = Color.DarkGreen;

                        if (i == 0) // Срабатывает только один раз - при первом нагревании
                        {
                            StartTemperatures[0] = 210 * (1 - Math.Exp(-0.22 * t.Elapsed.TotalSeconds)); // Нагревание
                            await Task.Delay(350);
                            TemperaturesLabel12.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();
                        }
                        else // Срабатывает после первого остывания и далее (i == 1)
                        {
                            double tempTime = 0.1;

                            do
                            {
                                StartTemperatures[0] = ControlTemperature + 210 * (1 - Math.Exp(-0.22 * tempTime)); // Вторая итерация нагревания и далее
                                await Task.Delay(350);
                                TemperaturesLabel12.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                                tempTime += timeOut;
                                time += timeOut;

                                Tableting12(StartTemperatures[0]);
                                Accident12(StartTemperatures[0]);
                            } while (StartTemperatures[0] < LowerCriticalTemp && SensorStatusButton12.Text == "Выключить");
                        }
                    }
                    else if (StartTemperatures[0] >= LowerCriticalTemp) // Иначе если температура выше верхнего предельного значения, функция выполняется пока температура выше нижнего предельного значения
                    {
                        HeaterConditionLabel12.Text = "Выключен";
                        HeaterConditionLabel12.ForeColor = Color.DarkSlateBlue;

                        double tempTime = 0.1;

                        do
                        {
                            StartTemperatures[0] = 175 * (Math.Exp(-0.13 * tempTime)); // Остывание
                            await Task.Delay(350);
                            TemperaturesLabel12.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                            tempTime += timeOut;
                            time += timeOut;

                            Tableting12(StartTemperatures[0]);
                            Accident12(StartTemperatures[0]);
                        } while (StartTemperatures[0] > UpperCriticalTemp && SensorStatusButton12.Text == "Выключить");
                    }
                    i = 1; // присваивается 1 после первой итерации нагревания (проверочная итерация для предотвращения резкого остывания/нагревания выше/ниже предельных значений)
                    ControlTemperature = StartTemperatures[0];
                    time += timeOut;
                }
            }
            else if (SensorStatusButton12.Text == "Выключить")
            {
                SensorStatusButton12.Text = "Включить";
                t.Reset();
            }
        }

        private async void SensorStatusButton13_Click(object sender, EventArgs e)
        {
            if (InputSetPointTemperaturetextBox.Text == "") // Проверка на наличие необходимых данных (Температуры уставки)
            {
                DialogResult msg = DialogResult.OK;
                msg = MessageBox.Show("Необходимо ввести температуру уставки!",
                            "Температура уставки",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowChartButton13.Click += ShowChartButton_Click;

            double LowerCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + ControlAccuracy;
            double UpperCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) - ControlAccuracy;

            Stopwatch t = new Stopwatch(); // Главный таймер

            if (SensorStatusButton13.Text == "Включить")
            {
                SensorStatusButton13.Text = "Выключить";

                // Имитация таймера для сбора времени при расчетах повторного нагревания/остывания
                double time = 0.1;
                double timeOut = 0.1;

                int i = 0; // Переменная для отсчета итерации (после первого нагревания)
                double ControlTemperature = 0.0; // Переменная для фиксирования температуры до процедуры нагревания

                t.Start();
                t.Restart();

                while (SensorStatusButton13.Text == "Выключить")
                {
                    if (StartTemperatures[0] < LowerCriticalTemp && t.Elapsed.TotalSeconds < 0.6) // Нагреваем ни сразу
                    {
                        StartTemperatures[0] = 25.97;
                    }
                    else if (StartTemperatures[0] < LowerCriticalTemp) // Если температура ниже верхнего предельного значения
                    {
                        HeaterConditionLabel13.Text = "Включен"; // При нагревании прибор вкл, при остывании - выкл
                        HeaterConditionLabel13.ForeColor = Color.DarkGreen;

                        if (i == 0) // Срабатывает только один раз - при первом нагревании
                        {
                            StartTemperatures[0] = 210 * (1 - Math.Exp(-0.22 * t.Elapsed.TotalSeconds)); // Нагревание
                            await Task.Delay(350);
                            TemperaturesLabel13.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();
                        }
                        else // Срабатывает после первого остывания и далее (i == 1)
                        {
                            double tempTime = 0.1;

                            do
                            {
                                StartTemperatures[0] = ControlTemperature + 210 * (1 - Math.Exp(-0.22 * tempTime)); // Вторая итерация нагревания и далее
                                await Task.Delay(350);
                                TemperaturesLabel13.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                                tempTime += timeOut;
                                time += timeOut;

                                Tableting13(StartTemperatures[0]);
                                Accident13(StartTemperatures[0]);
                            } while (StartTemperatures[0] < LowerCriticalTemp && SensorStatusButton13.Text == "Выключить");
                        }
                    }
                    else if (StartTemperatures[0] >= LowerCriticalTemp) // Иначе если температура выше верхнего предельного значения, функция выполняется пока температура выше нижнего предельного значения
                    {
                        HeaterConditionLabel13.Text = "Выключен";
                        HeaterConditionLabel13.ForeColor = Color.DarkSlateBlue;

                        double tempTime = 0.1;

                        do
                        {
                            StartTemperatures[0] = 175 * (Math.Exp(-0.13 * tempTime)); // Остывание
                            await Task.Delay(350);
                            TemperaturesLabel13.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                            tempTime += timeOut;
                            time += timeOut;

                            Tableting13(StartTemperatures[0]);
                            Accident13(StartTemperatures[0]);
                        } while (StartTemperatures[0] > UpperCriticalTemp && SensorStatusButton13.Text == "Выключить");
                    }
                    i = 1; // присваивается 1 после первой итерации нагревания (проверочная итерация для предотвращения резкого остывания/нагревания выше/ниже предельных значений)
                    ControlTemperature = StartTemperatures[0];
                    time += timeOut;
                }
            }
            else if (SensorStatusButton13.Text == "Выключить")
            {
                SensorStatusButton13.Text = "Включить";
                t.Reset();
            }
        }

        private async void SensorStatusButton14_Click(object sender, EventArgs e)
        {
            if (InputSetPointTemperaturetextBox.Text == "") // Проверка на наличие необходимых данных (Температуры уставки)
            {
                DialogResult msg = DialogResult.OK;
                msg = MessageBox.Show("Необходимо ввести температуру уставки!",
                            "Температура уставки",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowChartButton14.Click += ShowChartButton_Click;

            double LowerCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + ControlAccuracy;
            double UpperCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) - ControlAccuracy;

            Stopwatch t = new Stopwatch(); // Главный таймер

            if (SensorStatusButton14.Text == "Включить")
            {
                SensorStatusButton14.Text = "Выключить";

                // Имитация таймера для сбора времени при расчетах повторного нагревания/остывания
                double time = 0.1;
                double timeOut = 0.1;

                int i = 0; // Переменная для отсчета итерации (после первого нагревания)
                double ControlTemperature = 0.0; // Переменная для фиксирования температуры до процедуры нагревания

                t.Start();
                t.Restart();

                while (SensorStatusButton14.Text == "Выключить")
                {
                    if (StartTemperatures[0] < LowerCriticalTemp && t.Elapsed.TotalSeconds < 0.6) // Нагреваем ни сразу
                    {
                        StartTemperatures[0] = 25.97;
                    }
                    else if (StartTemperatures[0] < LowerCriticalTemp) // Если температура ниже верхнего предельного значения
                    {
                        HeaterConditionLabel14.Text = "Включен"; // При нагревании прибор вкл, при остывании - выкл
                        HeaterConditionLabel14.ForeColor = Color.DarkGreen;

                        if (i == 0) // Срабатывает только один раз - при первом нагревании
                        {
                            StartTemperatures[0] = 210 * (1 - Math.Exp(-0.22 * t.Elapsed.TotalSeconds)); // Нагревание
                            await Task.Delay(350);
                            TemperaturesLabel14.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();
                        }
                        else // Срабатывает после первого остывания и далее (i == 1)
                        {
                            double tempTime = 0.1;

                            do
                            {
                                StartTemperatures[0] = ControlTemperature + 210 * (1 - Math.Exp(-0.22 * tempTime)); // Вторая итерация нагревания и далее
                                await Task.Delay(350);
                                TemperaturesLabel14.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                                tempTime += timeOut;
                                time += timeOut;

                                Tableting14(StartTemperatures[0]);
                                Accident14(StartTemperatures[0]);
                            } while (StartTemperatures[0] < LowerCriticalTemp && SensorStatusButton14.Text == "Выключить");
                        }
                    }
                    else if (StartTemperatures[0] >= LowerCriticalTemp) // Иначе если температура выше верхнего предельного значения, функция выполняется пока температура выше нижнего предельного значения
                    {
                        HeaterConditionLabel14.Text = "Выключен";
                        HeaterConditionLabel14.ForeColor = Color.DarkSlateBlue;

                        double tempTime = 0.1;

                        do
                        {
                            StartTemperatures[0] = 175 * (Math.Exp(-0.13 * tempTime)); // Остывание
                            await Task.Delay(350);
                            TemperaturesLabel14.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                            tempTime += timeOut;
                            time += timeOut;

                            Tableting14(StartTemperatures[0]);
                            Accident14(StartTemperatures[0]);
                        } while (StartTemperatures[0] > UpperCriticalTemp && SensorStatusButton14.Text == "Выключить");
                    }
                    i = 1; // присваивается 1 после первой итерации нагревания (проверочная итерация для предотвращения резкого остывания/нагревания выше/ниже предельных значений)
                    ControlTemperature = StartTemperatures[0];
                    time += timeOut;
                }
            }
            else if (SensorStatusButton14.Text == "Выключить")
            {
                SensorStatusButton14.Text = "Включить";
                t.Reset();
            }
        }

        private async void SensorStatusButton15_Click(object sender, EventArgs e)
        {
            if (InputSetPointTemperaturetextBox.Text == "") // Проверка на наличие необходимых данных (Температуры уставки)
            {
                DialogResult msg = DialogResult.OK;
                msg = MessageBox.Show("Необходимо ввести температуру уставки!",
                            "Температура уставки",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowChartButton15.Click += ShowChartButton_Click;

            double LowerCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + ControlAccuracy;
            double UpperCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) - ControlAccuracy;

            Stopwatch t = new Stopwatch(); // Главный таймер

            if (SensorStatusButton15.Text == "Включить")
            {
                SensorStatusButton15.Text = "Выключить";

                // Имитация таймера для сбора времени при расчетах повторного нагревания/остывания
                double time = 0.1;
                double timeOut = 0.1;

                int i = 0; // Переменная для отсчета итерации (после первого нагревания)
                double ControlTemperature = 0.0; // Переменная для фиксирования температуры до процедуры нагревания

                t.Start();
                t.Restart();

                while (SensorStatusButton15.Text == "Выключить")
                {
                    if (StartTemperatures[0] < LowerCriticalTemp && t.Elapsed.TotalSeconds < 0.6) // Нагреваем ни сразу
                    {
                        StartTemperatures[0] = 25.97;
                    }
                    else if (StartTemperatures[0] < LowerCriticalTemp) // Если температура ниже верхнего предельного значения
                    {
                        HeaterConditionLabel15.Text = "Включен"; // При нагревании прибор вкл, при остывании - выкл
                        HeaterConditionLabel15.ForeColor = Color.DarkGreen;

                        if (i == 0) // Срабатывает только один раз - при первом нагревании
                        {
                            StartTemperatures[0] = 210 * (1 - Math.Exp(-0.22 * t.Elapsed.TotalSeconds)); // Нагревание
                            await Task.Delay(350);
                            TemperaturesLabel15.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();
                        }
                        else // Срабатывает после первого остывания и далее (i == 1)
                        {
                            double tempTime = 0.1;

                            do
                            {
                                StartTemperatures[0] = ControlTemperature + 210 * (1 - Math.Exp(-0.22 * tempTime)); // Вторая итерация нагревания и далее
                                await Task.Delay(350);
                                TemperaturesLabel15.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                                tempTime += timeOut;
                                time += timeOut;

                                Tableting15(StartTemperatures[0]);
                                Accident15(StartTemperatures[0]);
                            } while (StartTemperatures[0] < LowerCriticalTemp && SensorStatusButton15.Text == "Выключить");
                        }
                    }
                    else if (StartTemperatures[0] >= LowerCriticalTemp) // Иначе если температура выше верхнего предельного значения, функция выполняется пока температура выше нижнего предельного значения
                    {
                        HeaterConditionLabel15.Text = "Выключен";
                        HeaterConditionLabel15.ForeColor = Color.DarkSlateBlue;

                        double tempTime = 0.1;

                        do
                        {
                            StartTemperatures[0] = 175 * (Math.Exp(-0.13 * tempTime)); // Остывание
                            await Task.Delay(350);
                            TemperaturesLabel15.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                            tempTime += timeOut;
                            time += timeOut;

                            Tableting15(StartTemperatures[0]);
                            Accident15(StartTemperatures[0]);
                        } while (StartTemperatures[0] > UpperCriticalTemp && SensorStatusButton15.Text == "Выключить");
                    }
                    i = 1; // присваивается 1 после первой итерации нагревания (проверочная итерация для предотвращения резкого остывания/нагревания выше/ниже предельных значений)
                    ControlTemperature = StartTemperatures[0];
                    time += timeOut;
                }
            }
            else if (SensorStatusButton15.Text == "Выключить")
            {
                SensorStatusButton15.Text = "Включить";
                t.Reset();
            }
        }

        private async void SensorStatusButton16_Click(object sender, EventArgs e)
        {
            if (InputSetPointTemperaturetextBox.Text == "") // Проверка на наличие необходимых данных (Температуры уставки)
            {
                DialogResult msg = DialogResult.OK;
                msg = MessageBox.Show("Необходимо ввести температуру уставки!",
                            "Температура уставки",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowChartButton16.Click += ShowChartButton_Click;

            double LowerCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + ControlAccuracy;
            double UpperCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) - ControlAccuracy;

            Stopwatch t = new Stopwatch(); // Главный таймер

            if (SensorStatusButton16.Text == "Включить")
            {
                SensorStatusButton16.Text = "Выключить";

                // Имитация таймера для сбора времени при расчетах повторного нагревания/остывания
                double time = 0.1;
                double timeOut = 0.1;

                int i = 0; // Переменная для отсчета итерации (после первого нагревания)
                double ControlTemperature = 0.0; // Переменная для фиксирования температуры до процедуры нагревания

                t.Start();
                t.Restart();

                while (SensorStatusButton16.Text == "Выключить")
                {
                    if (StartTemperatures[0] < LowerCriticalTemp && t.Elapsed.TotalSeconds < 0.6) // Нагреваем ни сразу
                    {
                        StartTemperatures[0] = 25.97;
                    }
                    else if (StartTemperatures[0] < LowerCriticalTemp) // Если температура ниже верхнего предельного значения
                    {
                        HeaterConditionLabel16.Text = "Включен"; // При нагревании прибор вкл, при остывании - выкл
                        HeaterConditionLabel16.ForeColor = Color.DarkGreen;

                        if (i == 0) // Срабатывает только один раз - при первом нагревании
                        {
                            StartTemperatures[0] = 210 * (1 - Math.Exp(-0.22 * t.Elapsed.TotalSeconds)); // Нагревание
                            await Task.Delay(350);
                            TemperaturesLabel16.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();
                        }
                        else // Срабатывает после первого остывания и далее (i == 1)
                        {
                            double tempTime = 0.1;

                            do
                            {
                                StartTemperatures[0] = ControlTemperature + 210 * (1 - Math.Exp(-0.22 * tempTime)); // Вторая итерация нагревания и далее
                                await Task.Delay(350);
                                TemperaturesLabel16.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                                tempTime += timeOut;
                                time += timeOut;

                                Tableting16(StartTemperatures[0]);
                                Accident16(StartTemperatures[0]);
                            } while (StartTemperatures[0] < LowerCriticalTemp && SensorStatusButton16.Text == "Выключить");
                        }
                    }
                    else if (StartTemperatures[0] >= LowerCriticalTemp) // Иначе если температура выше верхнего предельного значения, функция выполняется пока температура выше нижнего предельного значения
                    {
                        HeaterConditionLabel16.Text = "Выключен";
                        HeaterConditionLabel16.ForeColor = Color.DarkSlateBlue;

                        double tempTime = 0.1;

                        do
                        {
                            StartTemperatures[0] = 175 * (Math.Exp(-0.13 * tempTime)); // Остывание
                            await Task.Delay(350);
                            TemperaturesLabel16.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                            tempTime += timeOut;
                            time += timeOut;

                            Tableting16(StartTemperatures[0]);
                            Accident16(StartTemperatures[0]);
                        } while (StartTemperatures[0] > UpperCriticalTemp && SensorStatusButton16.Text == "Выключить");
                    }
                    i = 1; // присваивается 1 после первой итерации нагревания (проверочная итерация для предотвращения резкого остывания/нагревания выше/ниже предельных значений)
                    ControlTemperature = StartTemperatures[0];
                    time += timeOut;
                }
            }
            else if (SensorStatusButton16.Text == "Выключить")
            {
                SensorStatusButton16.Text = "Включить";
                t.Reset();
            }
        }



        private async void SensorStatusButton17_Click(object sender, EventArgs e)
        {
            if (InputSetPointTemperaturetextBox.Text == "") // Проверка на наличие необходимых данных (Температуры уставки)
            {
                DialogResult msg = DialogResult.OK;
                msg = MessageBox.Show("Необходимо ввести температуру уставки!",
                            "Температура уставки",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowChartButton17.Click += ShowChartButton_Click;

            double LowerCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + ControlAccuracy;
            double UpperCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) - ControlAccuracy;

            Stopwatch t = new Stopwatch(); // Главный таймер

            if (SensorStatusButton17.Text == "Включить")
            {
                SensorStatusButton17.Text = "Выключить";

                // Имитация таймера для сбора времени при расчетах повторного нагревания/остывания
                double time = 0.1;
                double timeOut = 0.1;

                int i = 0; // Переменная для отсчета итерации (после первого нагревания)
                double ControlTemperature = 0.0; // Переменная для фиксирования температуры до процедуры нагревания

                t.Start();
                t.Restart();

                while (SensorStatusButton17.Text == "Выключить")
                {
                    if (StartTemperatures[0] < LowerCriticalTemp && t.Elapsed.TotalSeconds < 0.6) // Нагреваем ни сразу
                    {
                        StartTemperatures[0] = 25.97;
                    }
                    else if (StartTemperatures[0] < LowerCriticalTemp) // Если температура ниже верхнего предельного значения
                    {
                        HeaterConditionLabel17.Text = "Включен"; // При нагревании прибор вкл, при остывании - выкл
                        HeaterConditionLabel17.ForeColor = Color.DarkGreen;

                        if (i == 0) // Срабатывает только один раз - при первом нагревании
                        {
                            StartTemperatures[0] = 210 * (1 - Math.Exp(-0.22 * t.Elapsed.TotalSeconds)); // Нагревание
                            await Task.Delay(350);
                            TemperaturesLabel17.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();
                        }
                        else // Срабатывает после первого остывания и далее (i == 1)
                        {
                            double tempTime = 0.1;

                            do
                            {
                                StartTemperatures[0] = ControlTemperature + 210 * (1 - Math.Exp(-0.22 * tempTime)); // Вторая итерация нагревания и далее
                                await Task.Delay(350);
                                TemperaturesLabel17.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                                tempTime += timeOut;
                                time += timeOut;

                                Tableting17(StartTemperatures[0]);
                                Accident17(StartTemperatures[0]);
                            } while (StartTemperatures[0] < LowerCriticalTemp && SensorStatusButton17.Text == "Выключить");
                        }
                    }
                    else if (StartTemperatures[0] >= LowerCriticalTemp) // Иначе если температура выше верхнего предельного значения, функция выполняется пока температура выше нижнего предельного значения
                    {
                        HeaterConditionLabel17.Text = "Выключен";
                        HeaterConditionLabel17.ForeColor = Color.DarkSlateBlue;

                        double tempTime = 0.1;

                        do
                        {
                            StartTemperatures[0] = 175 * (Math.Exp(-0.13 * tempTime)); // Остывание
                            await Task.Delay(350);
                            TemperaturesLabel17.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                            tempTime += timeOut;
                            time += timeOut;

                            Tableting17(StartTemperatures[0]);
                            Accident17(StartTemperatures[0]);
                        } while (StartTemperatures[0] > UpperCriticalTemp && SensorStatusButton17.Text == "Выключить");
                    }
                    i = 1; // присваивается 1 после первой итерации нагревания (проверочная итерация для предотвращения резкого остывания/нагревания выше/ниже предельных значений)
                    ControlTemperature = StartTemperatures[0];
                    time += timeOut;
                }
            }
            else if (SensorStatusButton17.Text == "Выключить")
            {
                SensorStatusButton17.Text = "Включить";
                t.Reset();
            }
        }

        private async void SensorStatusButton18_Click(object sender, EventArgs e)
        {
            if (InputSetPointTemperaturetextBox.Text == "") // Проверка на наличие необходимых данных (Температуры уставки)
            {
                DialogResult msg = DialogResult.OK;
                msg = MessageBox.Show("Необходимо ввести температуру уставки!",
                            "Температура уставки",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowChartButton18.Click += ShowChartButton_Click;

            double LowerCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + ControlAccuracy;
            double UpperCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) - ControlAccuracy;

            Stopwatch t = new Stopwatch(); // Главный таймер

            if (SensorStatusButton18.Text == "Включить")
            {
                SensorStatusButton18.Text = "Выключить";

                // Имитация таймера для сбора времени при расчетах повторного нагревания/остывания
                double time = 0.1;
                double timeOut = 0.1;

                int i = 0; // Переменная для отсчета итерации (после первого нагревания)
                double ControlTemperature = 0.0; // Переменная для фиксирования температуры до процедуры нагревания

                t.Start();
                t.Restart();

                while (SensorStatusButton18.Text == "Выключить")
                {
                    if (StartTemperatures[0] < LowerCriticalTemp && t.Elapsed.TotalSeconds < 0.6) // Нагреваем ни сразу
                    {
                        StartTemperatures[0] = 25.97;
                    }
                    else if (StartTemperatures[0] < LowerCriticalTemp) // Если температура ниже верхнего предельного значения
                    {
                        HeaterConditionLabel18.Text = "Включен"; // При нагревании прибор вкл, при остывании - выкл
                        HeaterConditionLabel18.ForeColor = Color.DarkGreen;

                        if (i == 0) // Срабатывает только один раз - при первом нагревании
                        {
                            StartTemperatures[0] = 210 * (1 - Math.Exp(-0.22 * t.Elapsed.TotalSeconds)); // Нагревание
                            await Task.Delay(350);
                            TemperaturesLabel18.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();
                        }
                        else // Срабатывает после первого остывания и далее (i == 1)
                        {
                            double tempTime = 0.1;

                            do
                            {
                                StartTemperatures[0] = ControlTemperature + 210 * (1 - Math.Exp(-0.22 * tempTime)); // Вторая итерация нагревания и далее
                                await Task.Delay(350);
                                TemperaturesLabel18.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                                tempTime += timeOut;
                                time += timeOut;

                                Tableting18(StartTemperatures[0]);
                                Accident18(StartTemperatures[0]);
                            } while (StartTemperatures[0] < LowerCriticalTemp && SensorStatusButton18.Text == "Выключить");
                        }
                    }
                    else if (StartTemperatures[0] >= LowerCriticalTemp) // Иначе если температура выше верхнего предельного значения, функция выполняется пока температура выше нижнего предельного значения
                    {
                        HeaterConditionLabel18.Text = "Выключен";
                        HeaterConditionLabel18.ForeColor = Color.DarkSlateBlue;

                        double tempTime = 0.1;

                        do
                        {
                            StartTemperatures[0] = 175 * (Math.Exp(-0.13 * tempTime)); // Остывание
                            await Task.Delay(350);
                            TemperaturesLabel18.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                            tempTime += timeOut;
                            time += timeOut;

                            Tableting18(StartTemperatures[0]);
                            Accident18(StartTemperatures[0]);
                        } while (StartTemperatures[0] > UpperCriticalTemp && SensorStatusButton18.Text == "Выключить");
                    }
                    i = 1; // присваивается 1 после первой итерации нагревания (проверочная итерация для предотвращения резкого остывания/нагревания выше/ниже предельных значений)
                    ControlTemperature = StartTemperatures[0];
                    time += timeOut;
                }
            }
            else if (SensorStatusButton18.Text == "Выключить")
            {
                SensorStatusButton18.Text = "Включить";
                t.Reset();
            }
        }

        private async void SensorStatusButton19_Click(object sender, EventArgs e)
        {
            if (InputSetPointTemperaturetextBox.Text == "") // Проверка на наличие необходимых данных (Температуры уставки)
            {
                DialogResult msg = DialogResult.OK;
                msg = MessageBox.Show("Необходимо ввести температуру уставки!",
                            "Температура уставки",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowChartButton19.Click += ShowChartButton_Click;

            double LowerCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + ControlAccuracy;
            double UpperCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) - ControlAccuracy;

            Stopwatch t = new Stopwatch(); // Главный таймер

            if (SensorStatusButton19.Text == "Включить")
            {
                SensorStatusButton19.Text = "Выключить";

                // Имитация таймера для сбора времени при расчетах повторного нагревания/остывания
                double time = 0.1;
                double timeOut = 0.1;

                int i = 0; // Переменная для отсчета итерации (после первого нагревания)
                double ControlTemperature = 0.0; // Переменная для фиксирования температуры до процедуры нагревания

                t.Start();
                t.Restart();

                while (SensorStatusButton19.Text == "Выключить")
                {
                    if (StartTemperatures[0] < LowerCriticalTemp && t.Elapsed.TotalSeconds < 0.6) // Нагреваем ни сразу
                    {
                        StartTemperatures[0] = 25.97;
                    }
                    else if (StartTemperatures[0] < LowerCriticalTemp) // Если температура ниже верхнего предельного значения
                    {
                        HeaterConditionLabel19.Text = "Включен"; // При нагревании прибор вкл, при остывании - выкл
                        HeaterConditionLabel19.ForeColor = Color.DarkGreen;

                        if (i == 0) // Срабатывает только один раз - при первом нагревании
                        {
                            StartTemperatures[0] = 210 * (1 - Math.Exp(-0.22 * t.Elapsed.TotalSeconds)); // Нагревание
                            await Task.Delay(350);
                            TemperaturesLabel19.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();
                        }
                        else // Срабатывает после первого остывания и далее (i == 1)
                        {
                            double tempTime = 0.1;

                            do
                            {
                                StartTemperatures[0] = ControlTemperature + 210 * (1 - Math.Exp(-0.22 * tempTime)); // Вторая итерация нагревания и далее
                                await Task.Delay(350);
                                TemperaturesLabel19.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                                tempTime += timeOut;
                                time += timeOut;

                                Tableting19(StartTemperatures[0]);
                                Accident19(StartTemperatures[0]);
                            } while (StartTemperatures[0] < LowerCriticalTemp && SensorStatusButton19.Text == "Выключить");
                        }
                    }
                    else if (StartTemperatures[0] >= LowerCriticalTemp) // Иначе если температура выше верхнего предельного значения, функция выполняется пока температура выше нижнего предельного значения
                    {
                        HeaterConditionLabel19.Text = "Выключен";
                        HeaterConditionLabel19.ForeColor = Color.DarkSlateBlue;

                        double tempTime = 0.1;

                        do
                        {
                            StartTemperatures[0] = 175 * (Math.Exp(-0.13 * tempTime)); // Остывание
                            await Task.Delay(350);
                            TemperaturesLabel19.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                            tempTime += timeOut;
                            time += timeOut;

                            Tableting19(StartTemperatures[0]);
                            Accident19(StartTemperatures[0]);
                        } while (StartTemperatures[0] > UpperCriticalTemp && SensorStatusButton19.Text == "Выключить");
                    }
                    i = 1; // присваивается 1 после первой итерации нагревания (проверочная итерация для предотвращения резкого остывания/нагревания выше/ниже предельных значений)
                    ControlTemperature = StartTemperatures[0];
                    time += timeOut;
                }
            }
            else if (SensorStatusButton19.Text == "Выключить")
            {
                SensorStatusButton19.Text = "Включить";
                t.Reset();
            }
        }

        private async void SensorStatusButton20_Click(object sender, EventArgs e)
        {
            if (InputSetPointTemperaturetextBox.Text == "") // Проверка на наличие необходимых данных (Температуры уставки)
            {
                DialogResult msg = DialogResult.OK;
                msg = MessageBox.Show("Необходимо ввести температуру уставки!",
                            "Температура уставки",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowChartButton20.Click += ShowChartButton_Click;

            double LowerCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + ControlAccuracy;
            double UpperCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) - ControlAccuracy;

            Stopwatch t = new Stopwatch(); // Главный таймер

            if (SensorStatusButton20.Text == "Включить")
            {
                SensorStatusButton20.Text = "Выключить";

                // Имитация таймера для сбора времени при расчетах повторного нагревания/остывания
                double time = 0.1;
                double timeOut = 0.1;

                int i = 0; // Переменная для отсчета итерации (после первого нагревания)
                double ControlTemperature = 0.0; // Переменная для фиксирования температуры до процедуры нагревания

                t.Start();
                t.Restart();

                while (SensorStatusButton20.Text == "Выключить")
                {
                    if (StartTemperatures[0] < LowerCriticalTemp && t.Elapsed.TotalSeconds < 0.6) // Нагреваем ни сразу
                    {
                        StartTemperatures[0] = 25.97;
                    }
                    else if (StartTemperatures[0] < LowerCriticalTemp) // Если температура ниже верхнего предельного значения
                    {
                        HeaterConditionLabel20.Text = "Включен"; // При нагревании прибор вкл, при остывании - выкл
                        HeaterConditionLabel20.ForeColor = Color.DarkGreen;

                        if (i == 0) // Срабатывает только один раз - при первом нагревании
                        {
                            StartTemperatures[0] = 210 * (1 - Math.Exp(-0.22 * t.Elapsed.TotalSeconds)); // Нагревание
                            await Task.Delay(350);
                            TemperaturesLabel20.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();
                        }
                        else // Срабатывает после первого остывания и далее (i == 1)
                        {
                            double tempTime = 0.1;

                            do
                            {
                                StartTemperatures[0] = ControlTemperature + 210 * (1 - Math.Exp(-0.22 * tempTime)); // Вторая итерация нагревания и далее
                                await Task.Delay(350);
                                TemperaturesLabel20.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                                tempTime += timeOut;
                                time += timeOut;

                                Tableting20(StartTemperatures[0]);
                                Accident20(StartTemperatures[0]);
                            } while (StartTemperatures[0] < LowerCriticalTemp && SensorStatusButton20.Text == "Выключить");
                        }
                    }
                    else if (StartTemperatures[0] >= LowerCriticalTemp) // Иначе если температура выше верхнего предельного значения, функция выполняется пока температура выше нижнего предельного значения
                    {
                        HeaterConditionLabel20.Text = "Выключен";
                        HeaterConditionLabel20.ForeColor = Color.DarkSlateBlue;

                        double tempTime = 0.1;

                        do
                        {
                            StartTemperatures[0] = 175 * (Math.Exp(-0.13 * tempTime)); // Остывание
                            await Task.Delay(350);
                            TemperaturesLabel20.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                            tempTime += timeOut;
                            time += timeOut;

                            Tableting20(StartTemperatures[0]);
                            Accident20(StartTemperatures[0]);
                        } while (StartTemperatures[0] > UpperCriticalTemp && SensorStatusButton20.Text == "Выключить");
                    }
                    i = 1; // присваивается 1 после первой итерации нагревания (проверочная итерация для предотвращения резкого остывания/нагревания выше/ниже предельных значений)
                    ControlTemperature = StartTemperatures[0];
                    time += timeOut;
                }
            }
            else if (SensorStatusButton20.Text == "Выключить")
            {
                SensorStatusButton20.Text = "Включить";
                t.Reset();
            }
        }

        private async void SensorStatusButton21_Click(object sender, EventArgs e)
        {
            if (InputSetPointTemperaturetextBox.Text == "") // Проверка на наличие необходимых данных (Температуры уставки)
            {
                DialogResult msg = DialogResult.OK;
                msg = MessageBox.Show("Необходимо ввести температуру уставки!",
                            "Температура уставки",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowChartButton21.Click += ShowChartButton_Click;

            double LowerCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + ControlAccuracy;
            double UpperCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) - ControlAccuracy;

            Stopwatch t = new Stopwatch(); // Главный таймер

            if (SensorStatusButton21.Text == "Включить")
            {
                SensorStatusButton21.Text = "Выключить";

                // Имитация таймера для сбора времени при расчетах повторного нагревания/остывания
                double time = 0.1;
                double timeOut = 0.1;

                int i = 0; // Переменная для отсчета итерации (после первого нагревания)
                double ControlTemperature = 0.0; // Переменная для фиксирования температуры до процедуры нагревания

                t.Start();
                t.Restart();

                while (SensorStatusButton21.Text == "Выключить")
                {
                    if (StartTemperatures[0] < LowerCriticalTemp && t.Elapsed.TotalSeconds < 0.6) // Нагреваем ни сразу
                    {
                        StartTemperatures[0] = 25.97;
                    }
                    else if (StartTemperatures[0] < LowerCriticalTemp) // Если температура ниже верхнего предельного значения
                    {
                        HeaterConditionLabel21.Text = "Включен"; // При нагревании прибор вкл, при остывании - выкл
                        HeaterConditionLabel21.ForeColor = Color.DarkGreen;

                        if (i == 0) // Срабатывает только один раз - при первом нагревании
                        {
                            StartTemperatures[0] = 210 * (1 - Math.Exp(-0.22 * t.Elapsed.TotalSeconds)); // Нагревание
                            await Task.Delay(350);
                            TemperaturesLabel21.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();
                        }
                        else // Срабатывает после первого остывания и далее (i == 1)
                        {
                            double tempTime = 0.1;

                            do
                            {
                                StartTemperatures[0] = ControlTemperature + 210 * (1 - Math.Exp(-0.22 * tempTime)); // Вторая итерация нагревания и далее
                                await Task.Delay(350);
                                TemperaturesLabel21.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                                tempTime += timeOut;
                                time += timeOut;

                                Tableting21(StartTemperatures[0]);
                                Accident21(StartTemperatures[0]);
                            } while (StartTemperatures[0] < LowerCriticalTemp && SensorStatusButton21.Text == "Выключить");
                        }
                    }
                    else if (StartTemperatures[0] >= LowerCriticalTemp) // Иначе если температура выше верхнего предельного значения, функция выполняется пока температура выше нижнего предельного значения
                    {
                        HeaterConditionLabel21.Text = "Выключен";
                        HeaterConditionLabel21.ForeColor = Color.DarkSlateBlue;

                        double tempTime = 0.1;

                        do
                        {
                            StartTemperatures[0] = 175 * (Math.Exp(-0.13 * tempTime)); // Остывание
                            await Task.Delay(350);
                            TemperaturesLabel21.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                            tempTime += timeOut;
                            time += timeOut;

                            Tableting21(StartTemperatures[0]);
                            Accident21(StartTemperatures[0]);
                        } while (StartTemperatures[0] > UpperCriticalTemp && SensorStatusButton21.Text == "Выключить");
                    }
                    i = 1; // присваивается 1 после первой итерации нагревания (проверочная итерация для предотвращения резкого остывания/нагревания выше/ниже предельных значений)
                    ControlTemperature = StartTemperatures[0];
                    time += timeOut;
                }
            }
            else if (SensorStatusButton21.Text == "Выключить")
            {
                SensorStatusButton21.Text = "Включить";
                t.Reset();
            }
        }

        private async void SensorStatusButton22_Click(object sender, EventArgs e)
        {
            if (InputSetPointTemperaturetextBox.Text == "") // Проверка на наличие необходимых данных (Температуры уставки)
            {
                DialogResult msg = DialogResult.OK;
                msg = MessageBox.Show("Необходимо ввести температуру уставки!",
                            "Температура уставки",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowChartButton22.Click += ShowChartButton_Click;

            double LowerCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + ControlAccuracy;
            double UpperCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) - ControlAccuracy;

            Stopwatch t = new Stopwatch(); // Главный таймер

            if (SensorStatusButton22.Text == "Включить")
            {
                SensorStatusButton22.Text = "Выключить";

                // Имитация таймера для сбора времени при расчетах повторного нагревания/остывания
                double time = 0.1;
                double timeOut = 0.1;

                int i = 0; // Переменная для отсчета итерации (после первого нагревания)
                double ControlTemperature = 0.0; // Переменная для фиксирования температуры до процедуры нагревания

                t.Start();
                t.Restart();

                while (SensorStatusButton22.Text == "Выключить")
                {
                    if (StartTemperatures[0] < LowerCriticalTemp && t.Elapsed.TotalSeconds < 0.6) // Нагреваем ни сразу
                    {
                        StartTemperatures[0] = 25.97;
                    }
                    else if (StartTemperatures[0] < LowerCriticalTemp) // Если температура ниже верхнего предельного значения
                    {
                        HeaterConditionLabel22.Text = "Включен"; // При нагревании прибор вкл, при остывании - выкл
                        HeaterConditionLabel22.ForeColor = Color.DarkGreen;

                        if (i == 0) // Срабатывает только один раз - при первом нагревании
                        {
                            StartTemperatures[0] = 210 * (1 - Math.Exp(-0.22 * t.Elapsed.TotalSeconds)); // Нагревание
                            await Task.Delay(350);
                            TemperaturesLabel22.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();
                        }
                        else // Срабатывает после первого остывания и далее (i == 1)
                        {
                            double tempTime = 0.1;

                            do
                            {
                                StartTemperatures[0] = ControlTemperature + 210 * (1 - Math.Exp(-0.22 * tempTime)); // Вторая итерация нагревания и далее
                                await Task.Delay(350);
                                TemperaturesLabel22.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                                tempTime += timeOut;
                                time += timeOut;

                                Tableting22(StartTemperatures[0]);
                                Accident22(StartTemperatures[0]);
                            } while (StartTemperatures[0] < LowerCriticalTemp && SensorStatusButton22.Text == "Выключить");
                        }
                    }
                    else if (StartTemperatures[0] >= LowerCriticalTemp) // Иначе если температура выше верхнего предельного значения, функция выполняется пока температура выше нижнего предельного значения
                    {
                        HeaterConditionLabel22.Text = "Выключен";
                        HeaterConditionLabel22.ForeColor = Color.DarkSlateBlue;

                        double tempTime = 0.1;

                        do
                        {
                            StartTemperatures[0] = 175 * (Math.Exp(-0.13 * tempTime)); // Остывание
                            await Task.Delay(350);
                            TemperaturesLabel22.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                            tempTime += timeOut;
                            time += timeOut;

                            Tableting22(StartTemperatures[0]);
                            Accident22(StartTemperatures[0]);
                        } while (StartTemperatures[0] > UpperCriticalTemp && SensorStatusButton22.Text == "Выключить");
                    }
                    i = 1; // присваивается 1 после первой итерации нагревания (проверочная итерация для предотвращения резкого остывания/нагревания выше/ниже предельных значений)
                    ControlTemperature = StartTemperatures[0];
                    time += timeOut;
                }
            }
            else if (SensorStatusButton22.Text == "Выключить")
            {
                SensorStatusButton22.Text = "Включить";
                t.Reset();
            }
        }

        private async void SensorStatusButton23_Click(object sender, EventArgs e)
        {
            if (InputSetPointTemperaturetextBox.Text == "") // Проверка на наличие необходимых данных (Температуры уставки)
            {
                DialogResult msg = DialogResult.OK;
                msg = MessageBox.Show("Необходимо ввести температуру уставки!",
                            "Температура уставки",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowChartButton23.Click += ShowChartButton_Click;

            double LowerCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + ControlAccuracy;
            double UpperCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) - ControlAccuracy;

            Stopwatch t = new Stopwatch(); // Главный таймер

            if (SensorStatusButton23.Text == "Включить")
            {
                SensorStatusButton23.Text = "Выключить";

                // Имитация таймера для сбора времени при расчетах повторного нагревания/остывания
                double time = 0.1;
                double timeOut = 0.1;

                int i = 0; // Переменная для отсчета итерации (после первого нагревания)
                double ControlTemperature = 0.0; // Переменная для фиксирования температуры до процедуры нагревания

                t.Start();
                t.Restart();

                while (SensorStatusButton23.Text == "Выключить")
                {
                    if (StartTemperatures[0] < LowerCriticalTemp && t.Elapsed.TotalSeconds < 0.6) // Нагреваем ни сразу
                    {
                        StartTemperatures[0] = 25.97;
                    }
                    else if (StartTemperatures[0] < LowerCriticalTemp) // Если температура ниже верхнего предельного значения
                    {
                        HeaterConditionLabel23.Text = "Включен"; // При нагревании прибор вкл, при остывании - выкл
                        HeaterConditionLabel23.ForeColor = Color.DarkGreen;

                        if (i == 0) // Срабатывает только один раз - при первом нагревании
                        {
                            StartTemperatures[0] = 210 * (1 - Math.Exp(-0.22 * t.Elapsed.TotalSeconds)); // Нагревание
                            await Task.Delay(350);
                            TemperaturesLabel23.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();
                        }
                        else // Срабатывает после первого остывания и далее (i == 1)
                        {
                            double tempTime = 0.1;

                            do
                            {
                                StartTemperatures[0] = ControlTemperature + 210 * (1 - Math.Exp(-0.22 * tempTime)); // Вторая итерация нагревания и далее
                                await Task.Delay(350);
                                TemperaturesLabel23.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                                tempTime += timeOut;
                                time += timeOut;

                                Tableting23(StartTemperatures[0]);
                                Accident23(StartTemperatures[0]);
                            } while (StartTemperatures[0] < LowerCriticalTemp && SensorStatusButton23.Text == "Выключить");
                        }
                    }
                    else if (StartTemperatures[0] >= LowerCriticalTemp) // Иначе если температура выше верхнего предельного значения, функция выполняется пока температура выше нижнего предельного значения
                    {
                        HeaterConditionLabel23.Text = "Выключен";
                        HeaterConditionLabel23.ForeColor = Color.DarkSlateBlue;

                        double tempTime = 0.1;

                        do
                        {
                            StartTemperatures[0] = 175 * (Math.Exp(-0.13 * tempTime)); // Остывание
                            await Task.Delay(350);
                            TemperaturesLabel23.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                            tempTime += timeOut;
                            time += timeOut;

                            Tableting23(StartTemperatures[0]);
                            Accident23(StartTemperatures[0]);
                        } while (StartTemperatures[0] > UpperCriticalTemp && SensorStatusButton23.Text == "Выключить");
                    }
                    i = 1; // присваивается 1 после первой итерации нагревания (проверочная итерация для предотвращения резкого остывания/нагревания выше/ниже предельных значений)
                    ControlTemperature = StartTemperatures[0];
                    time += timeOut;
                }
            }
            else if (SensorStatusButton23.Text == "Выключить")
            {
                SensorStatusButton23.Text = "Включить";
                t.Reset();
            }
        }

        private async void SensorStatusButton24_Click(object sender, EventArgs e)
        {
            if (InputSetPointTemperaturetextBox.Text == "") // Проверка на наличие необходимых данных (Температуры уставки)
            {
                DialogResult msg = DialogResult.OK;
                msg = MessageBox.Show("Необходимо ввести температуру уставки!",
                            "Температура уставки",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowChartButton24.Click += ShowChartButton_Click;

            double LowerCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) + ControlAccuracy;
            double UpperCriticalTemp = Convert.ToDouble(InputSetPointTemperaturetextBox.Text) - ControlAccuracy;

            Stopwatch t = new Stopwatch(); // Главный таймер

            if (SensorStatusButton24.Text == "Включить")
            {
                SensorStatusButton24.Text = "Выключить";

                // Имитация таймера для сбора времени при расчетах повторного нагревания/остывания
                double time = 0.1;
                double timeOut = 0.1;

                int i = 0; // Переменная для отсчета итерации (после первого нагревания)
                double ControlTemperature = 0.0; // Переменная для фиксирования температуры до процедуры нагревания

                t.Start();
                t.Restart();

                while (SensorStatusButton24.Text == "Выключить")
                {
                    if (StartTemperatures[0] < LowerCriticalTemp && t.Elapsed.TotalSeconds < 0.6) // Нагреваем ни сразу
                    {
                        StartTemperatures[0] = 25.97;
                    }
                    else if (StartTemperatures[0] < LowerCriticalTemp) // Если температура ниже верхнего предельного значения
                    {
                        HeaterConditionLabel24.Text = "Включен"; // При нагревании прибор вкл, при остывании - выкл
                        HeaterConditionLabel24.ForeColor = Color.DarkGreen;

                        if (i == 0) // Срабатывает только один раз - при первом нагревании
                        {
                            StartTemperatures[0] = 210 * (1 - Math.Exp(-0.22 * t.Elapsed.TotalSeconds)); // Нагревание
                            await Task.Delay(350);
                            TemperaturesLabel24.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();
                        }
                        else // Срабатывает после первого остывания и далее (i == 1)
                        {
                            double tempTime = 0.1;

                            do
                            {
                                StartTemperatures[0] = ControlTemperature + 210 * (1 - Math.Exp(-0.22 * tempTime)); // Вторая итерация нагревания и далее
                                await Task.Delay(350);
                                TemperaturesLabel24.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                                tempTime += timeOut;
                                time += timeOut;

                                Tableting24(StartTemperatures[0]);
                                Accident24(StartTemperatures[0]);
                            } while (StartTemperatures[0] < LowerCriticalTemp && SensorStatusButton24.Text == "Выключить");
                        }
                    }
                    else if (StartTemperatures[0] >= LowerCriticalTemp) // Иначе если температура выше верхнего предельного значения, функция выполняется пока температура выше нижнего предельного значения
                    {
                        HeaterConditionLabel24.Text = "Выключен";
                        HeaterConditionLabel24.ForeColor = Color.DarkSlateBlue;

                        double tempTime = 0.1;

                        do
                        {
                            StartTemperatures[0] = 175 * (Math.Exp(-0.13 * tempTime)); // Остывание
                            await Task.Delay(350);
                            TemperaturesLabel24.Text = (StartTemperatures[0] - (StartTemperatures[0] % 0.01)).ToString();

                            tempTime += timeOut;
                            time += timeOut;

                            Tableting24(StartTemperatures[0]);
                            Accident24(StartTemperatures[0]);
                        } while (StartTemperatures[0] > UpperCriticalTemp && SensorStatusButton24.Text == "Выключить");
                    }
                    i = 1; // присваивается 1 после первой итерации нагревания (проверочная итерация для предотвращения резкого остывания/нагревания выше/ниже предельных значений)
                    ControlTemperature = StartTemperatures[0];
                    time += timeOut;
                }
            }
            else if (SensorStatusButton24.Text == "Выключить")
            {
                SensorStatusButton24.Text = "Включить";
                t.Reset();
            }
        }
    }
}
