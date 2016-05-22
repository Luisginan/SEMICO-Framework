using Microsoft.VisualStudio.TestTools.UnitTesting;
using Semico;
using System;
using System.Data;
using System.Diagnostics;

namespace CsharpTest
{
    [TestClass]
    public class TestClsSqlOledb
    {
        private const string DBName = "Mandiri";

        [TestMethod]
        public void ConnectionWithtext()
        {
            var err = "";
            try
            {
                ClsSqlOledb conn = new ClsSqlOledb("sa", "123456", ".", DBName);
                conn.TestConnection();
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }

            Assert.AreEqual(err, "");
        }

        [TestMethod]
        public void ConnectionWithFullText()
        {
            var err = "";
            try
            {
                string strConnection = ClsQuickCode.ProviderSQLserver("sa", "123456", ".", DBName);
                ClsSqlOledb conn = new ClsSqlOledb(strConnection);
                conn.TestConnection();
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }

            Assert.AreEqual(err, "");
        }

        [TestMethod]
        public void ConnectionWithFullTextAndTimeOut()
        {
            var err = "";
            try
            {
                string strConnection = ClsQuickCode.ProviderSQLserver("sa", "123456", ".", DBName);
                ClsSqlOledb conn = new ClsSqlOledb(strConnection, 1000);
                conn.TestConnection();
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }

            Assert.AreEqual(err, "");
        }

        [TestMethod]
        public void ConnectionWithoutInit()
        {
            var err = "";
            try
            {
                string strConnection = ClsQuickCode.ProviderSQLserver("sa", "123456", ".", DBName);
                ClsSqlOledb conn = new ClsSqlOledb();
                conn.ConnectionString = strConnection;
                conn.TimeOut = 1000;
                conn.TestConnection();
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }

            Assert.AreEqual(err, "");
        }

        [TestMethod]
        public void ExecuteQueryCheckingRows()
        {
            var err = "";
            try
            {
                string strConnection = ClsQuickCode.ProviderSQLserver("sa", "123456", ".", DBName);
                ClsSqlOledb conn = new ClsSqlOledb();
                conn.ConnectionString = strConnection;
                conn.TimeOut = 1000;
                conn.StringQuery = "select * from pelanggan";
                conn.Execute();
                if (conn.HasRows)
                {
                    int rowsCount = conn.RowCount;
                    DataTable table = conn.Table;
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }

            Assert.AreEqual(err, "");
        }

        [TestMethod]
        public void ExecuteQuerySetToTable()
        {
            var err = "";
            try
            {
                string strConnection = ClsQuickCode.ProviderSQLserver("sa", "123456", ".", DBName);
                ClsSqlOledb conn = new ClsSqlOledb();
                conn.ConnectionString = strConnection;
                conn.TimeOut = 1000;
                conn.StringQuery = "select * from pelanggan";
                DataTable table = conn.Execute();
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }

            Assert.AreEqual(err, "");
        }

        [TestMethod]
        public void ExecuteQuerySetToTableQueryParam()
        {
            var err = "";
            try
            {
                string strConnection = ClsQuickCode.ProviderSQLserver("sa", "123456", ".", DBName);
                ClsSqlOledb conn = new ClsSqlOledb();
                conn.ConnectionString = strConnection;
                conn.TimeOut = 1000;
                DataTable table = conn.Execute("select * from pelanggan");
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }

            Assert.AreEqual(err, "");
        }

        [TestMethod]
        public void ExecuteQueryWithNameNavigation()
        {
            var err = "";
            try
            {
                string strConnection = ClsQuickCode.ProviderSQLserver("sa", "123456", ".", DBName);
                ClsSqlOledb conn = new ClsSqlOledb();
                conn.ConnectionString = strConnection;
                conn.TimeOut = 1000;
                conn.Execute("select * from pelanggan");
                for (int i = 0; i < conn.RowCount - 1; i++)
                {
                    string szName = (string)conn["kdplgn"];
                    string CustszContactPerson = (string)conn["nmplgn"];
                    conn.NextRow();
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }

            Assert.AreEqual(err, "");
        }

        [TestMethod]
        public void ExecuteQueryWithIdexNavigation()
        {
            var err = "";
            try
            {
                string strConnection = ClsQuickCode.ProviderSQLserver("sa", "123456", ".", DBName);
                ClsSqlOledb conn = new ClsSqlOledb();
                conn.ConnectionString = strConnection;
                conn.TimeOut = 1000;
                conn.Execute("select * from pelanggan");
                conn.MoveFirstRow();
                for (int i = 0; i < conn.RowCount - 1; i++)
                {
                    string szName = (string)conn[0];
                    string CustszContactPerson = (string)conn[1];
                    conn.NextRow();
                }
                conn.MoveLastRow();
                for (int i = 0; i < conn.RowCount - 1; i++)
                {
                    string szName = (string)conn[0];
                    string CustszContactPerson = (string)conn[1];
                    conn.NextRow();
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }

            Assert.AreEqual(err, "");
        }

        [TestMethod]
        public void ExecuteQueryWithMoveFirstAndLastNavigation()
        {
            var err = "";
            try
            {
                string strConnection = ClsQuickCode.ProviderSQLserver("sa", "123456", ".", DBName);
                ClsSqlOledb conn = new ClsSqlOledb();
                conn.ConnectionString = strConnection;
                conn.TimeOut = 1000;
                conn.Execute("select * from pelanggan");
                conn.MoveLastRow();
                string szNameLast = (string)conn[0];
                string CustszContactPersonLast = (string)conn[1];
                conn.MoveFirstRow();
                string szNameFirst = (string)conn[0];
                string CustszContactPersonFirst = (string)conn[1];
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }

            Assert.AreEqual(err, "");
        }
    }
}