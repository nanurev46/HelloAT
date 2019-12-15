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
        //Конструктор
        public DataGridPOS(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }
        //Возвращает кол-во столбцов
        public int getColCount()
        {
            return this.AsDataGridView().Patterns.Grid.Pattern.ColumnCount;
        }
        //Возвращает xPath хедера
        public string xPathOfHeader()
        {
            return "//Header";
        }
        //Возвращает хедер
        public GridHeader getHeader()
        {
            return this.FindFirstByXPath(this.xPathOfHeader()).AsGridHeader();
        }
        //Возвращает xPath n-й ячейки хедера
        public string xPathOfHeaderItem(int numberOfColumn)
        {
            return this.xPathOfHeader() + $"//HeaderItem[{numberOfColumn}]";
        }
        //Возвращает xPath ячейки хедера по атрибуту NAME
        public string xPathOfHeaderItem(string name)
        {
            return this.xPathOfHeader() + $"//HeaderItem[{name}']";
        }
        //Возвращает ячейку хедера по xPath
        public GridHeaderItem getHeaderItemByXPath(string xPath)
        {
            return this.FindFirstByXPath(xPath).AsGridHeaderItem();
        }
        //Возвращает xPath n-й строки
        public string xPathOfRow(int numberOfRow)
        {
            return $"//DataItem[{numberOfRow}]";
        }
        //Возвращает строку по xPath
        public GridRow getRowByXPath(string xPath)
        {
            return this.FindFirstByXPath(xPath).AsGridRow();
        }
        //Возвращает xPath n-й ячейки
        public string xPathOfCell(int numberOfColumn)
        {
            return $"//Custom[{numberOfColumn}]";
        }
        //Возвращает xPath n-й ячейки m-й строки
        public string xPathOfCell(int numberOfRow, int numberOfColumn)
        {
            return this.xPathOfRow(numberOfRow) + this.xPathOfCell(numberOfColumn);
        }
        //Возвращает xPath ячейки по атрибуту NAME
        public string xPathOfCell(string name)
        {
            return $"//Custom[@Name='{name}']";
        }
        //Возвращает xPath ячейки по номеру строки и атрибуту NAME
        public string xPathOfCell(int numberOfRow, string name)
        {
            return this.xPathOfRow(numberOfRow) + this.xPathOfCell(name);
        }
        //Возвращает ячейку строки по xPath
        public GridCell getCellByXPath(string xPath)
        {
            return this.FindFirstByXPath(xPath).AsGridCell();
        }
        //Возвращает кол-во строк
        public int getRowCount()
        {
            return this/*.AsDataGridView()*/.Patterns.Grid.Pattern.RowCount;
        }
        //Возвращает кол-ва строк, доступных при текущем положении скролла
        public int getRowCountNowExist()
        {
            return this.FindAllByXPath("//DataItem").Length;
        }
        //Возвращает % вертикального отображения содержимсго грида на форме (если 100% - скролла нет)
        public double getVerticalViewSize()
        {
            return this.AsDataGridView().Patterns.Scroll.Pattern.VerticalViewSize;
        }
         //Возвращает % горизонтального отображения содержимсго грида на форме (если 100% - скролла нет)
        public double getHorizontalViewSize()
        {
            return this.AsDataGridView().Patterns.Scroll.Pattern.HorizontalViewSize;
        }
         //Возвращает % вертикального скролла (-1 - скролла нет, 0 - если в крайнем верхнем, 100 - если в крайнем нижнем)
        public double getVerticalScrollPercent()
        {
            return this.AsDataGridView().Patterns.Scroll.Pattern.VerticalScrollPercent;
        }
        //Возвращает % горизонтального скролла (-1 - скролла нет, 0 - если в крайнем левом, 100 - если в крайнем правом)
        public double getHorizontalScrollPercent()
        {
            return this.AsDataGridView().Patterns.Scroll.Pattern.HorizontalScrollPercent;
        }
         //Устанавливает % горизонтального и вертикального скроллов скролла (-1 - скролла нет, 0 - если начале (лево/верх), 100 - если в конце(правон/низ))
        public void setScrollPercent(double horizontalPercent, double verticalPercent)
        {
            this.AsDataGridView().Patterns.Scroll.Pattern.SetScrollPercent(horizontalPercent, verticalPercent);
        }
        // true - если есть вертикальный скролл
        public bool verticalScrollIsExists()
        {
            if (this.getVerticalViewSize() > 0 && this.getVerticalViewSize() < 100)
                return true;
            else
                return false;
        }
        // true - если есть горизонтальный скролл
        public bool horizontalScrollIsExists()
        {
            if (this.getHorizontalViewSize() > 0 && this.getHorizontalViewSize() < 100)
                return true;
            else
                return false;
        }
        //Возвращает строки грида списком списков
        public List<List<string>> getRowsAsList()
        {
            List<List<string>> result = new List<List<string>>();

            //если грид пустой - вовзращаем пустой список
            if (this.getRowCount() == 0)
            { return result; }

            //формируем список опрераторов класса listOperators из грида        
            if (!this.verticalScrollIsExists())//если все строки грида поместились на форме и не надо скролить
            {
                for (int i = 0; i < this.getRowCount(); i++)
                {
                    result.Add(new List<string>());

                    for (int j = 0; j < this.getColCount(); j++)
                        //БУДЕТ РАБОТАТЬ, ЕСЛИ В ПУСТОЙ ЯЧЕЙКЕ БУДЕТ СОДЕРЖАТЬСЯ ЭЛЕМЕНТ text
                        try
                        {
                            /*
                            Label l = this.AsDataGridView().FindFirstByXPath($"//DataItem[{i + 1}]//Custom[{j+1}]//Text").AsLabel();

                            result[i].Add(l.Text);//записываем содержимое ячеек j-й строки
                            */
                            result[i].Add(getCellByXPath(this.xPathOfCell(i + 1, j + 1)).Name);
                        }
                        catch { }
                }
            }
            else //если надо скроллить
            {
                this.setScrollPercent(this.getHorizontalScrollPercent(), 0); //скроллим грид вверх до упора
                //int allRowsCount = this.getRowCount();
                int existRowsCount = this.getRowCountNowExist();

                this.getRowByXPath(this.xPathOfRow(1)).Click();//кликаем по 1 строке грида
                int i = 0;

                while (i < this.getRowCount())
                {
                    result.Add(new List<string>());
                    for (int j = 0; j < this.getColCount(); j++)//идем по столбцам выделенной строки
                    {
                        //если дошли до последней существующей строки - всё время записываем последнюю 
                        //(т.к. № дальне меняться не будет)
                        if (i < existRowsCount)
                        { result[i].Add(this.getCellByXPath(this.xPathOfCell(i + 1, j + 1)).Name); }
                        else
                        { result[i].Add(this.getCellByXPath(this.xPathOfCell(existRowsCount + 1, j + 1)).Name); }

                    }
                    Keyboard.Press(VirtualKeyShort.DOWN);
                        i++;
                }
                this.setScrollPercent(this.getHorizontalScrollPercent(), 0);//возвращаем скролл грида в самый верх
            }

            //формируем список опрераторов класса listOperators из грида


            return result;
        }
         //Возвращает строку грида по номеру столбца и содержимому ячейки
        public DataGridViewRow getRowByColumnNumber(int columnNumber, string cellContent)
        {
            DataGridViewRow result = null;//null - если строка не найдена

            string xpathOfCell;
            string s;
            for (int i = 0; i < this.getRowCount(); i++)
            {
                try
                {
                    xpathOfCell = $"//DataItem[{i+1}]//Custom[{columnNumber}]";

                    if (this.FindFirstByXPath(xpathOfCell).AsLabel().Text.Contains(cellContent))
                    {
                        return this.AsDataGridView().Rows[i];
                    }
                }
                catch
                { }
            }

            return result;
        }
        //Возвращает строку грида по номеру названию столбца и содержимому ячейки
       /* public DataGridViewRow getRowByColumnName(string colName, string cellContent)
    {
        DataGridViewRow result = null;//null - если строка не найдена

        string xpathOfCell;
        string s;
        for (int i = 0; i < this.getRowCount(); i++)
        {
            try
            {
                xpathOfCell = $"//DataItem[{i + 1}]//Custom[{columnNumber}]";

                if (this.FindFirstByXPath(xpathOfCell).AsLabel().Text.Contains(cellContent))
                {
                    return this.AsDataGridView().Rows[i];
                }
            }
            catch
            { }
        }

        return result;
    }*/
    }
}
