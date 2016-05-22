using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CsharpTest
{
    [TestClass]
    public class TestDialog
    {
        [TestMethod]
        public void ClearFormTest()
        {
            FrmInputs frm = new FrmInputs();
            frm.ShowDialog();
        }
    }
}