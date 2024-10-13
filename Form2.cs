using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LR1
{
    public partial class Form2 : Form
    {
        // Исходные данные
        private const int SensorCount = 24; // Количество датчиков
        private const double ControlAccuracy = 4.0; // Точность управления

        private const double SetPointTemp = 170; // Температура уставки

        private double LowerCriticalTemp = SetPointTemp + ControlAccuracy; // Верхний предел критической ситуации
        private double UpperCriticalTemp = SetPointTemp - ControlAccuracy; // Нижний предел критической ситуации

        public Form2()
        {
            InitializeComponent();
            InitializeChart(); // скорее всего, инициализацию графика нужно будет потом на второе окно перебросить

            Chart temperatureChart = (Chart)this.Controls.Find("Figure", true)[0];
            PlotTemperature(temperatureChart);
        }

        private void InitializeChart() // Функция инициализации графика
        {
            Chart temperatureChart = new Chart();
            temperatureChart.Dock = DockStyle.Fill;
            temperatureChart.ChartAreas.Add(new ChartArea("MainArea"));
            temperatureChart.Series.Add(new Series("Temperature")
            {
                ChartType = SeriesChartType.Line
            });

            temperatureChart.Name = "Figure";
            this.Controls.Add(temperatureChart);
        }

        private void PlotTemperature(Chart temperatureChart) // График изменения температуры от времени
        {
            double currentTemperature = 25.97; // Строим график от комнатной температуры
            double time = 0.0;
            double timeOut; // Переменная для сброса времени при повторном нагревании/охлаждении
            double timeStep = 0.087428911; // Период опроса датчиков
            bool heater_status = false;

            temperatureChart.Series["Temperature"].Points.Clear();

            while (time <= 10) // Произвольное значение времени для демонстрации процесса
            {
                if (currentTemperature < LowerCriticalTemp && time <= 0.6)  // Верхний предел критической ситуации 174
                {
                    currentTemperature = 25.97;
                }
                else if (currentTemperature < LowerCriticalTemp && time > 0.6) // Нагревание до верхней границы (174)
                {
                    heater_status = true; // Включаем нагреватель
                    currentTemperature = 210 * (1 - Math.Exp(-0.22 * time)); // Функция нагревания
                }
                else if (currentTemperature >= LowerCriticalTemp && currentTemperature >= UpperCriticalTemp) // Температура >= 174 и Температура >= 166
                {
                    timeOut = time;
                    timeOut = 0.1; // сброс времени для охлаждения
                    heater_status = false; // Выключаем нагреватель
                    currentTemperature = 175 * Math.Exp(-0.13 * timeOut); // Функция остывания
                }
                else if (currentTemperature < UpperCriticalTemp || currentTemperature <= LowerCriticalTemp) // Температура ниже минимально допустимой границы
                {
                    timeOut = time;
                    timeOut = 0.1; // Сброс времени для нагрева
                    heater_status = true; // Включаем нагреватель
                    currentTemperature = 210 * (1 - Math.Exp(-0.22 * timeOut)); // Функция нагревания
                    if (currentTemperature > LowerCriticalTemp)
                    {
                        currentTemperature = 175 * Math.Exp(-0.13 * time);
                    }
                    // Нагревается почему-то до 200, нужно последнее условие пересмотреть потом
                }
                time += timeStep;
                temperatureChart.Series["Temperature"].Points.AddXY(time, currentTemperature);
            }
        }
    }
}
