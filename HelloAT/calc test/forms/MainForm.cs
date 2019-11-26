using System;
using FlaUI.Core;
using FlaUI.UIA3;
using NUnit.Framework;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.AutomationElements.PatternElements;

namespace HelloAT.calc_test
{
    class MainForm  //Главное окно
    {

        public Window window { get; set; }
        public AutomationElement panel { get; set; }
        public Button button0 { get; set; }

        public Button button1 { get; set; }
        public Button button2 { get; set; }
        public Button button3 { get; set; }
        public Button button4 { get; set; }
        public Button button5 { get; set; }
        public Button button6 { get; set; }
        public Button button7 { get; set; }
        public Button button8 { get; set; }
        public Button button9 { get; set; }

        public Button buttonPlus { get; set; }
        public Button buttonMultiply { get; set; }
        public Button buttonEqual { get; set; }

        public Label textResult { get; set; }//Результат



        public MainForm (Window window)
        {
            this.window = window;
            this.window.Focus(); //окно на передний план

            panel = window.FindFirstByXPath($"//Pane");
            button0 = panel.FindFirstByXPath($"//Button[@Name=0]").AsButton();
            button1 = panel.FindFirstByXPath($"//Button[@Name=1]").AsButton();
            button2 = panel.FindFirstByXPath($"//Button[@Name=2]").AsButton();
            button3 = panel.FindFirstByXPath($"//Button[@Name=3]").AsButton();
            button4 = panel.FindFirstByXPath($"//Button[@Name=4]").AsButton();
            button5 = panel.FindFirstByXPath($"//Button[@Name=5]").AsButton();
            button6 = panel.FindFirstByXPath($"//Button[@Name=6]").AsButton();
            button7 = panel.FindFirstByXPath($"//Button[@Name=7]").AsButton();
            button8 = panel.FindFirstByXPath($"//Button[@Name=8]").AsButton();
            button9 = panel.FindFirstByXPath($"//Button[@Name=9]").AsButton();

            buttonPlus = panel.FindFirstByXPath($"//Button[@Name='Сложение']").AsButton();
            buttonMultiply = panel.FindFirstByXPath($"//Button[@Name='Умножение']").AsButton();
            buttonEqual = panel.FindFirstByXPath($"//Button[@Name='Равно']").AsButton();

            textResult = panel.FindFirstByXPath($"//Text[@AutomationId='158']").AsLabel();//Результат
        }

        


    }
}
