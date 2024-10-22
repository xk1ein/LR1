using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LR1
{
    public partial class Form2 : Form
    {
        public Form2(double Temp)
        {
            InitializeComponent();
            InitializeChart();

            double TempU = Temp;

            Chart temperatureChart = (Chart)this.Controls.Find("Figure", true)[0]; // Вызов функции построения
            PlotTemperature(temperatureChart,  TempU);
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

            Series series = temperatureChart.Series["Temperature"];
            series.Color = Color.Red;
            series.BorderWidth = 2; 
            series.BorderColor = Color.Red;
            this.Controls.Add(temperatureChart);
        }

        public string SetPoint_(string temp_)
        {     
            return temp_;
        }

        // функция построения графика отличается от логики изменения температуры способом инициализации временных интервалов (timer/ time, timeTemp, timeOut)
        private void PlotTemperature(Chart temperatureChart, double TempU) // Смодулированный график работы датчика
        {
            double SetPointTemp = TempU; // Температура уставки

            // Исходные данные
            double ControlAccuracy = 4.0; // Точность управления
                     
            double LowerCriticalTemp = SetPointTemp + ControlAccuracy; // Верхний предел критической ситуации 
            double UpperCriticalTemp = SetPointTemp - ControlAccuracy; // Нижний предел критической ситуации

            double currentTemperature = 25.97;
            double time = 0.1;
            double timeOut = 0.1;
            int i = 0;
            double ControlTemperature = 0.0;

            temperatureChart.Series["Temperature"].Points.Clear(); // Перед построением графика для каждого датчика стираем предыдущие данные

            while (time <= 10)
            {
                if (currentTemperature < LowerCriticalTemp && time <= 0.6)
                {
                    currentTemperature = 25.97;
                    temperatureChart.Series["Temperature"].Points.AddXY(time, currentTemperature);
                }
                else if (currentTemperature < LowerCriticalTemp && time > 0.6)
                {
                    if (i == 0)
                    {
                        double tempTime = 0.1;
                        while (currentTemperature < LowerCriticalTemp)
                        {
                            currentTemperature = 210 * (1 - Math.Exp(-0.22 * tempTime));
                            temperatureChart.Series["Temperature"].Points.AddXY(time, currentTemperature);

                            tempTime += timeOut;
                            time += timeOut;
                        }
                    }
                    else
                    {
                        double tempTime = 0.1;
                        while (currentTemperature < LowerCriticalTemp)
                        {
                            currentTemperature = ControlTemperature + 210 * (1 - Math.Exp(-0.22 * tempTime));
                            temperatureChart.Series["Temperature"].Points.AddXY(time, currentTemperature);

                            tempTime += timeOut;
                            time += timeOut;
                        }
                    }
                }
                else if (currentTemperature >= LowerCriticalTemp && time > 0.6)
                {
                    double tempTime = 0.1;
                    while (currentTemperature > UpperCriticalTemp)
                    {
                        currentTemperature = 175 * (Math.Exp(-0.13 * tempTime));
                        
                        tempTime += timeOut;
                        time += timeOut;
                    }
                }
                i = 1;
                ControlTemperature = currentTemperature;
                
                temperatureChart.Series["Temperature"].Points.AddXY(time, currentTemperature);
                time += timeOut;
            }
        }
    }
}
