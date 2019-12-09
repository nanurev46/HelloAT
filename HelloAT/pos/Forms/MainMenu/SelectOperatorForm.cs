using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FlaUI.Core.AutomationElements;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.AutomationElements.Scrolling;
using FlaUI.Core.Patterns;

using HelloAT.pos.FormElements;

namespace HelloAT.pos.forms

{
    class SelectOperatorForm
    {
        public Window window { get; set; }
        public DataGridPOS operatorsDataGrid { get; set; } //grid со списком операторов
        public List<Operator> listOperators { get; }    //список операторов класса listOperators

        public SelectOperatorForm(Window window)
        {
            this.window = window;
            window.Focus();
            
            this.operatorsDataGrid = new DataGridPOS (window.FindFirstByXPath($"//Custom//DataGrid").AsDataGridView().BasicAutomationElement);
            this.listOperators = new List<Operator>();

            List<List<string>> operatorListFromGrid = this.operatorsDataGrid.getRowsAsList();
            for (int i = 0; i < operatorListFromGrid.Count; i++)
            {
                this.listOperators.Add(new Operator(operatorListFromGrid[i][0], operatorListFromGrid[i][1]));
            }

        }
        //
        // Summary:
        //Авторизация по ФИО оператора (по вхождению)
        public void loginByName(string partOfOperatorsName)
        {
            //if (!getRowByName(user).IsOffscreen) { users.Patterns.Scroll.Pattern.Scroll(0, FlaUI.Core.Definitions.ScrollAmount.LargeIncrement); }

            //operatorsDataGrid.getRowByColumnNumber(2, partOfOperatorsName).DoubleClick();
            // DataGridViewRow row = operatorsDataGrid.getRowByColumnNumber(2, partOfOperatorsName);
            //row.Patterns.ScrollItem.Pattern.ScrollIntoView();



            DataGridViewRow row = operatorsDataGrid.getRowByColumnNumber(2, "Боровкова");
            row.Patterns.ScrollItem.Pattern.ScrollIntoView();

            row = operatorsDataGrid.getRowByColumnNumber(2, partOfOperatorsName);
            row.Patterns.ScrollItem.Pattern.ScrollIntoView();
            //if (flag) { operatorsDataGrid.Patterns.Scroll.Pattern.SetScrollPercent(-1, 100); }
            row.Click();

        }

    }
    }
