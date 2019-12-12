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
using FlaUI.Core.Input;
using FlaUI.Core.WindowsAPI;

namespace HelloAT.pos.FormElements
{
    class DataGridPOS : DataGridView
    {
        public DataGridPOS(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }
        //
        // Summary:
        //Возвращает хедер
        public GridHeader getHeader()
        {
            return this.FindFirstByXPath($"//Header//").AsGridHeader();
        }
        //
        // Summary:
        //Возвращает строки грида списком
        public List<List<string>> getRowsAsList()
        {
            List<List<string>> result = new List<List<string>>();

            //если грид пустой - вовзращаем пустой список
            if (this.AsDataGridView().Patterns.Grid.Pattern.RowCount == 0)
            { return result; }

            //формируем список опрераторов класса listOperators из грида        
            if (this.AsDataGridView().Patterns.Scroll.Pattern.VerticalViewSize == 100)//если все строки грида поместились на форме и не надо скролить
            {
                for (int i = 0; i < this.AsDataGridView().Patterns.Grid.Pattern.RowCount; i++)
                {
                    result.Add(new List<string>());

                    for (int j = 0; j < this.AsDataGridView().FindAllByXPath($"//DataItem[{i+1}]//Custom").Count(); j++)
                        //БУДЕТ РАБОТАТЬ, ЕСЛИ В ПУСТОЙ ЯЧЕЙКЕ БУДЕТ СОДЕРЖАТЬСЯ ЭЛЕМЕНТ text
                        try
                        {
                            Label l = this.AsDataGridView().FindFirstByXPath($"//DataItem[{i + 1}]//Custom[{j}]//Text").AsLabel();

                            result[i].Add(l.Text);//записываем содержимое ячеек j-й строки
                        }
                        catch { }
                }
            }
            else //если надо скроллить
            {

                    this.AsDataGridView().Patterns.Scroll.Pattern.SetScrollPercent(-1, 0);//скроллим грид вверх до упора
                    this.AsDataGridView().FindFirstByXPath($"//DataItem[1]").AsGridRow().Click();//кликаем по 1 строке грида
                    int i = 0;
                    //int flag = 0;
                    while (i < this.AsDataGridView().Patterns.Grid.Pattern.RowCount)
                    //for (int i = 0; i < this.AsDataGridView().Patterns.Grid.Pattern.RowCount; i++)
                    {
                        result.Add(new List<string>());
                        for (int j = 0; j < this.AsDataGridView().FindAllByXPath($"//DataItem[{i + 1}]//Custom").Count(); j++)//идем по столбцам выделенной строки
                        {
                            //БУДЕТ РАБОТАТЬ, ЕСЛИ В ПУСТОЙ ЯЧЕЙКЕ БУДЕТ СОДЕРЖАТЬСЯ ЭЛЕМЕНТ text
                                Label l = this.AsDataGridView().FindFirstByXPath($"//DataItem[{i + 1}]//Custom[{j}]//Text").AsLabel();
                                result[i].Add(l.Text);//записываем содержимое ячеек j-й строки
                            
                            //if (this.Patterns.Scroll.Pattern.VerticalScrollPercent < 100) { flag++; }
                        }
                        Keyboard.Press(VirtualKeyShort.DOWN);
                        i++;
                    }

            }

            //формируем список опрераторов класса listOperators из грида


            return result;
        }
        //
        // Summary:
        //Возвращает строку грида по номеру столбца и содержимому ячейки
        public DataGridViewRow getRowByColumnNumber(int columnNumber, string cellContent)
        {
            DataGridViewRow result = null;//выводим HEADER, если содержимое не найдено
            //string xpathOfColumnName = $"//Header//HeaderItem[{columnNumber + 1}]";

            string xpathOfCell;
            string s;
            for (int i = 0; i < this.Patterns.Grid.Pattern.RowCount; i++)
            {
                try
                {
                    xpathOfCell = $"//DataItem[{i+1}]//Custom[{columnNumber}]";
                    s = FindFirstByXPath(xpathOfCell).AsLabel().Text;
                    if (this.FindFirstByXPath(xpathOfCell).AsLabel().Text.Contains(cellContent))
                    {
                        //return this.FindFirstByXPath(xpathOfCell).FindFirstDescendant().AsGridRow();
                        return this.AsDataGridView().Rows[i];
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
