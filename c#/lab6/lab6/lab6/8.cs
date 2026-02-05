using System;

namespace Task8
{
    public delegate void ClickHandler(object sender, string buttonName);

    class Button
    {
        public string Name { get; set; }
        public event ClickHandler Click;

        public Button(string name)
        {
            Name = name;
        }

        public void PerformClick()
        {
            if (Click != null)
            {
                Click(this, Name);
            }
        }
    }

    class FormHandler
    {
        public void OnClick(object sender, string name)
        {
            Console.WriteLine("FormHandler: Button " + name + " was clicked.");
        }
    }

    class Logger
    {
        public void LogClick(object sender, string name)
        {
            Console.WriteLine("Logger: Click event received from " + name);
        }
    }

    class Program8
    {
        static void Main(string[] args)
        {
            Button btn = new Button("Submit");
            FormHandler handler = new FormHandler();
            Logger logger = new Logger();

            btn.Click += handler.OnClick;
            btn.Click += logger.LogClick;

            btn.Click += (sender, name) => Console.WriteLine("Lambda: Clicked " + name);

            btn.PerformClick();
        }
    }
}