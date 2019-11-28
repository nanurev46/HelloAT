using System;

using FlaUI.Core;
using FlaUI.UIA3;
using NUnit.Framework;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;

using HelloAT.pos.forms;

namespace HelloAT
{
    [TestFixture]
    public class PosFirstTest
    {
        [Test]
        public void test1()
        {
            using (Application.Attach("POS.exe"))
            {
                using (var app = Application./*Launch*/Attach(@"C:\Program Files (x86)\Microsoft Dynamics AX\60\Retail POS\POS.exe"))
                {
                    using (var automation = new UIA3Automation())
                    {
                        Window window = app.GetMainWindow(automation);
                        AuthorizationForm authnForm = new AuthorizationForm(window);

                        string userBrusova = "Виктория Валерьевна Брусова";
                        string userBorovkova = "Валентина Ивановна Боровкова";
                        authnForm.loginAsUser(userBorovkova);

                        //window.Focus(); //окно на передний план
                        //DataGridView usersDGV = window.FindFirstByXPath($"//Custom//DataGrid").AsDataGridView();
                        //GridRow brusovaRow = usersDGV.FindFirstByXPath($"//DataItem//Custom[@Name='Виктория Валерьевна Брусова']").FindFirstDescendant().AsGridRow();
                        //brusovaRow.DoubleClick();

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


                        //app.WaitWhileMainHandleIsMissing();
                        //app.Close(); //Закрыть окно


                        //Assert.That(window.Title, Is.Not.Null);


                    }
                }
            }
        }
    }
}
