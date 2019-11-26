using System;

using FlaUI.Core;
using FlaUI.UIA3;
using NUnit.Framework;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;

using HelloAT.calc_test;


namespace HelloAT
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void CalcAttachWithAbsoluteExePath()
        {
            using (Application.Attach("calc.exe"))
            {
                using (var app = Application./*Launch*/Attach(@"C:\WINDOWS\system32\calc.exe"))
                {
                    using (var automation = new UIA3Automation())
                    {
                        Window window = app.GetMainWindow(automation);
                        MainForm mainForm = new MainForm(window);

                        //window.Focus(); //окно на передний план

                        /*
                        var panel = window.FindFirstByXPath($"//Pane");
                        Button button1 = panel.FindFirstByXPath($"//Button[@Name=1]").AsButton();
                        Button button2 = panel.FindFirstByXPath($"//Button[@Name=2]").AsButton();
                        Button button3 = panel.FindFirstByXPath($"//Button[@Name=3]").AsButton();

                        Button buttonPlus = panel.FindFirstByXPath($"//Button[@Name='Сложение']").AsButton();
                        Button buttonMultiply = panel.FindFirstByXPath($"//Button[@Name='Умножение']").AsButton();
                        Button buttonEqual = panel.FindFirstByXPath($"//Button[@Name='Равно']").AsButton();

                        Label textResult = panel.FindFirstByXPath($"//Text[@AutomationId='158']").AsLabel();//Результат

                        button1.Click();
                        buttonPlus.Click();
                        button2.Click();
                        buttonMultiply.Click();
                        button3.Click();
                        buttonEqual.Click();
                        */

                        mainForm.button1.Click();
                        mainForm.buttonPlus.Click();
                        mainForm.button2.Click();
                        mainForm.buttonMultiply.Click();
                        mainForm.button3.Click();
                        mainForm.buttonEqual.Click();


                        Assert.That(mainForm.textResult.Text.Equals("9"));

                        //app.WaitWhileMainHandleIsMissing();
                        //app.Close(); //Закрыть окно


                        //Assert.That(window.Title, Is.Not.Null);


                    }
                }
            }
        }
    }
}
