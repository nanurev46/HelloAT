using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlaUI.UIA3;
using System.Diagnostics;
using FlaUI.Core;

namespace HelloAT
{
    [TestFixture]
    public class TestClass1
    {
        [Test]
        public void CalcAttachWithAbsoluteExePath()
        {
            using (Application.Launch("calc.exe"))
            {
                using (var app = Application.Attach(@"C:\WINDOWS\system32\calc.exe"))
                {
                    using (var automation = new UIA3Automation())
                    {
                        var window = app.GetMainWindow(automation);
                        Assert.That(window, Is.Not.Null);
                        Assert.That(window.Title, Is.Not.Null);
                    }
                }
            }
        }
    }
}
