using System;

namespace Task7
{
    public delegate void TemperatureHandler(string message, double temperature);

    class TemperatureSensor
    {
        public event TemperatureHandler TemperatureHigh;

        public void SetTemperature(double temp)
        {
            if (temp > 30)
            {
                if (TemperatureHigh != null)
                {
                    TemperatureHigh("Warning! High Heat Detected", temp);
                }
            }
        }
    }

    class TemperatureMonitor
    {
        public void OnHighTemperature(string message, double temp)
        {
            Console.WriteLine("Monitor Alert: " + message + " at " + temp + "°C");
        }
    }

    class Logger
    {
        public void LogTemp(string message, double temp)
        {
            Console.WriteLine("Log: " + message + " - " + temp);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TemperatureSensor sensor = new TemperatureSensor();
            TemperatureMonitor monitor = new TemperatureMonitor();
            Logger logger = new Logger();

            sensor.TemperatureHigh += monitor.OnHighTemperature;
            sensor.TemperatureHigh += logger.LogTemp;

            sensor.SetTemperature(25);
            sensor.SetTemperature(35);

            sensor.TemperatureHigh -= logger.LogTemp;

            sensor.SetTemperature(40);
        }
    }
}