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

namespace LR1 // TemperatureControlSystem
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        // Исходные данные
        private const int SensorCount = 24; // Количество датчиков
        private const double ControlAccuracy = 4.0; // Точность управления

        private const double time = 0.0; // Начальное значение времени
        private const double timeStep = 0.087428911; // Период опроса датчиков

        private const double SetPointTemp = 170; // Температура уставки
        // потом нужно будет брать значение из текстового бокса
                
        private double LowerCriticalTemp = SetPointTemp + ControlAccuracy; // Верхний предел критической ситуации
        private double UpperCriticalTemp = SetPointTemp - ControlAccuracy; // Нижний предел критической ситуации

        private double[] StartTemperatures = new double[SensorCount]; // Стартовые температуры датчиков = 25.97 (24 датчика, сделала массив для 24 значений)

        private bool[] HeaterCondition = new bool[SensorCount]; // Состояние нагревателя для всех датчиков (вкл 1/выкл 0)

        // new Random random = new Random(); // Переменная для отслеживания критической ситуации (можно сделать функцию с добавление рандомного значения, тем самым проверив, что процесс остановится)

        Form2 chartWindow = new Form2(); // Инициализация формы для графика

        Timer temperatureTimer = new Timer(); // Таймер (для реализации обновления данных в реальном времени на Form1)

        public Form1()
        {
            InitializeComponent();
            this.Text = "Панель управления"; // Заголовок главного окна (свойства не отработали)

            InitializeTemperatureSystem();
            
            // Запускаем таймер для обновления температуры
            temperatureTimer.Interval = 1000; // Обновление каждые 2 секунды
            temperatureTimer.Tick += TemperatureTimerUpdate;
            temperatureTimer.Start();

            ShowChartButton.Click += ShowChartButton_Click; // Срабатывает при нажатии кнопки "Открыть график"
            ShowChartButton2.Click += ShowChartButton_Click;
        }

        private void ShowChartButton_Click(object sender, EventArgs e) // График для датчиков
        {
            chartWindow.Show(); // Отрабатывает только один раз(
        }

        private void InitializeTemperatureSystem() // Функция инициализации начальных температур
        {
            for (int i = 0; i < SensorCount; i++)
            {
               StartTemperatures[i] = 25.97; // Стартовая температура датчиков - комнатная
            }
        }

        // Функция для обновления температуры на форме в label (должна запускаться после нажатия кнопки "Включить"
        private void TemperatureTimerUpdate(object sender, EventArgs e)
        {
           for (int i = 0; i < SensorCount; i++)
           {
                // Обновляем значение температуры
                UpdateTemperature(ref StartTemperatures[i], i);
               
                // Обновляем текст состояния датчиков
                //Controls[$"TemperaturesLabel{i + 1}"].Text = $"Датчик {i + 1}: Температура: {StartTemperatures[i]}°C";
                //Controls[$"HeaterConditionLabel{i + 1}"].Text = HeaterCondition[i] ? $"{i + 1}: Включен" : $"{i + 1}: Выключен";
           }
        }

        // Функция, описывающая логику обновления температуры
        private void UpdateTemperature(ref double currentTemperature, int index) // Логика обновления температуры (взять потом из функции для построения графика)
        {      
            if (currentTemperature < (SetPointTemp - ControlAccuracy) && !HeaterCondition[index])
            {
                HeaterCondition[index] = true;
            }
            else if (currentTemperature >= SetPointTemp && HeaterCondition[index])
            {
                HeaterCondition[index] = false;
            }

            if (HeaterCondition[index]) // Если нагреватель включен, нагреваем
            {
                currentTemperature = 210*(1 - Math.Exp(-0.22 * time)); // функция нагрева
            }
            else // иначе если нагреватель выключен
            {
                currentTemperature = 175*(Math.Exp(-0.13 * time)); // функция остывания
            }
            // дальше скорее всего шаг времени нужно прибавлять (хотя нафига....)
        }
    }
}
