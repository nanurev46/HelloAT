using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using FlaUI.Core.AutomationElements;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.AutomationElements.Scrolling;
using FlaUI.Core.Patterns;
using FlaUI.Core;

namespace HelloAT.pos.FormElements
{
    class DataGridPOS : DataGridView
    {
        public DataGridPOS(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }       
        //
        // Summary:
        //Возвращает строки грида списком
        public List<List<string>> getRowsAsList()
        {
            List<List<string>> result = new List<List<string>>();

            //формируем список опрераторов класса listOperators из грида
            for (int i = 0; i < this.AsDataGridView().Patterns.Grid.Pattern.RowCount; i++)
            {
                result.Add(new List<string>());

                for (int j = 0; j < this.AsDataGridView().FindAllByXPath($"//DataItem[" + (i + 1) + "]//Custom").Count(); j++)
                    //БУДЕТ РАБОТАТЬ, ЕСЛИ В ПУСТОЙ ЯЧЕЙКЕ БУДЕТ СОДЕРЖАТЬСЯ ЭЛЕМЕНТ text
                    try
                    {
                        Label l = this.AsDataGridView().FindFirstByXPath($"//DataItem[" + (i + 1) + "]//Custom[" + j + "]//Text").AsLabel();

                        result[i].Add(l.Text);
                    }
                    catch { }
            }
           
            return result;
        }
        //
        // Summary:
        //Возвращает строку грида по номеру столбца и содержимому ячейки
        public GridRow getRowByColumnNumber(int columnNumber, string cellContent)
        {
            GridRow result = this.FindFirstByXPath($"//Header//").AsGridRow();//выводим HEADER, если содержимое не найдено
            //string xpathOfColumnName = $"//Header//HeaderItem[{columnNumber + 1}]";

            string xpathOfCell = $"//DataItem//Custom[{columnNumber}]";
            for (int i = 0; i < this.Patterns.Grid.Pattern.RowCount; )
            {
                try
                {
                    if (this.FindFirstByXPath(xpathOfCell).AsLabel().Text.Contains(cellContent))
                    {
                        return this.FindFirstByXPath(xpathOfCell).FindFirstDescendant().AsGridRow();
                    }
                }
                catch
                { }
            }


            //string xpath = $"//DataItem//Custom[{columnNumber}]//Text[@Name='{cellContent}']";
            return result;
        }
    }

}
