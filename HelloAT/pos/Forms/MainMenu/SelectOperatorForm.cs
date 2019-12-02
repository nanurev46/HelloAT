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

            operatorsDataGrid = new DataGridPOS(window.FindFirstByXPath($"//Custom//DataGrid").AsDataGridView().BasicAutomationElement);


            /*
            this.operatorsDataGrid = new DataGridPOS (window.FindFirstByXPath($"//Custom//DataGrid").AsDataGridView());
            this.listOperators = new List<Operator>();

            List<List<string>> operatorListFromGrid = this.operatorsDataGrid.getRowsAsList();
            //формируем список опрераторов класса listOperators из грида
            string code_temp = "";  //код оператора
            string name_temp = "";  //ФИО оператора
            string xpath_code = $"";
            string xpath_name = $"";
            for (int i = 1; i < users.Patterns.Grid.Pattern.RowCount; i++)
            {
                //парсим код
                xpath_code = $"//DataItem[" + i + "]//Custom[1]//Text";
                code_temp = users.FindFirstByXPath(xpath_code).AsLabel().Name.ToString();
                //парсим ФИО
                xpath_name = $"//DataItem[" + i + "]//Custom[2]//Text";
                name_temp = users.FindFirstByXPath(xpath_name).AsLabel().Name.ToString();

                //добавляем в список с проверкой на начальника
                if (name_temp.Contains("Брусова") || name_temp.Contains("Стрелкова"))
                {
                    this.listOperators.Add(new Operator(code_temp, name_temp, true));
                }
                else
                {
                    this.listOperators.Add(new Operator(code_temp, name_temp));
                }
            }

          */
        }


        /*
        public GridRow getRowByName (string name)
        {
            string xpath = $"//DataItem//Custom[@Name='" + name + "']";
            return users.FindFirstByXPath(xpath).FindFirstDescendant().AsGridRow();
        }
        */

        /*
        public void loginByName(string user)
        {
            if (!getRowByName(user).IsOffscreen) { users.Patterns.Scroll.Pattern.Scroll(0, FlaUI.Core.Definitions.ScrollAmount.LargeIncrement); }

            getRowByName(user).DoubleClick();
        }
        */
    }
    }
