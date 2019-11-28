using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FlaUI.Core.AutomationElements;
using FlaUI.Core.AutomationElements.Infrastructure;

namespace HelloAT.pos.forms
{
    class AuthorizationForm
    {
        public Window window { get; set; }
        public DataGridView users { get; set; }
    
        public AuthorizationForm (Window window)
        {
            this.window = window;
            this.users = window.FindFirstByXPath($"//Custom//DataGrid").AsDataGridView();

            window.Focus();
        }

        public GridRow getRowByUser (string user)
        {
            string xpath = $"//DataItem//Custom[@Name='" + user + "']";
            return users.FindFirstByXPath(xpath).FindFirstDescendant().AsGridRow();
        }

        public void loginAsUser(string user)
        {
            if (!getRowByUser(user).IsOffscreen) { users.AsVerticalScrollBar().ScrollDownLarge(); }

            getRowByUser(user).DoubleClick();
        }
    }
}
