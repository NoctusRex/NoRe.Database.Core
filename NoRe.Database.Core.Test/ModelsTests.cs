using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NoRe.Database.Core.Models;

namespace NoRe.Database.Core.Test
{
    [TestClass]
    public class ModelsTests
    {
        [TestMethod]
        public void TestQuery()
        {
            Query q = new Query();
            Assert.IsTrue(string.IsNullOrEmpty(q.CommandText));
            Assert.IsTrue(q.Parameters is null);

            q = new Query("SELECT * FROM *");
            Assert.IsTrue(q.CommandText == "SELECT * FROM *");
            Assert.IsTrue(q.Parameters.Length == 0);

            q = new Query("DROP @0", "database");
            Assert.IsTrue(q.CommandText == "DROP @0");
            Assert.IsTrue(q.Parameters.Length == 1);
            Assert.IsTrue(q.Parameters[0].ToString() == "database");

            q = new Query("SELECT * FROM table WHERE columnA = @0 AND columnB = @1", "A", "B");
            Assert.IsTrue(q.CommandText == "SELECT * FROM table WHERE columnA = @0 AND columnB = @1");
            Assert.IsTrue(q.Parameters.Length == 2);
            Assert.IsTrue(q.Parameters[0].ToString() == "A");
            Assert.IsTrue(q.Parameters[1].ToString() == "B");
        }

        [TestMethod]
        public void TestColumn()
        {
            Column c = new Column();
            Assert.IsTrue(string.IsNullOrEmpty(c.Key));
            Assert.IsNull(c.Value);

            c = new Column("columnA", true);
            Assert.IsTrue(c.Key == "columnA");
            Assert.IsTrue((bool)c.Value);
            Assert.IsTrue(c.GetValue<bool>());

            c = new Column("columnA", 10);
            Assert.IsTrue(c.Key == "columnA");
            Assert.IsTrue((int)c.Value == 10);
            Assert.IsTrue(c.GetValue<int>() == 10);

            c = new Column("columnA", "Test");
            Assert.IsTrue(c.Key == "columnA");
            Assert.IsTrue((string)c.Value == "Test");
            Assert.IsTrue(c.GetValue<string>() == "Test");

            c = new Column("columnA", 10.5M);
            Assert.IsTrue(c.Key == "columnA");
            Assert.IsTrue((decimal)c.Value == 10.5M);
            Assert.IsTrue(c.GetValue<decimal>() == 10.5M);

            DateTime dt = DateTime.Now;
            c = new Column("columnA", dt);
            Assert.IsTrue(c.Key == "columnA");
            Assert.IsTrue((DateTime)c.Value == dt);
            Assert.IsTrue(c.GetValue<DateTime>() == dt);
        }

        [TestMethod]
        public void TestRow()
        {
            Row r = new Row();
            Assert.IsTrue(r.Columns.Count == 0);
            try { r.GetValue<string>("columnA"); Assert.Fail(); } catch { }

            r.Columns.Add(new Column("columnA", true));
            Assert.IsTrue(r.Columns.Count == 1);
            Assert.AreEqual(true, r.GetValue<bool>("columnA"));
            try { r.GetValue<string>("columnB"); Assert.Fail(); } catch { }

            r.Columns.Add(new Column("columnB", 10));
            r.Columns.Add(new Column("columnC", "Test"));
            r.Columns.Add(new Column("columnD", 10.5M));
            Assert.IsTrue(r.Columns.Count == 4);
            Assert.AreEqual(10, r.GetValue<int>("columnB"));
            Assert.AreEqual("Test", r.GetValue<string>("columnC"));
            Assert.AreEqual(10.5M, r.GetValue<decimal>("columnD"));
        }

        [TestMethod]
        public void TestTable()
        {
            Table t = new Table();
            Assert.IsTrue(t.Rows.Count == 0);
            Assert.IsTrue(t.DataTable is null);
            try { t.GetValue<bool>(0, "columnA"); Assert.Fail(); } catch { }

            t.Rows.Add(new Row() { Columns = { new Column("columnA", true), new Column("columnB", 10), new Column("columnC", "Test") } });
            Assert.IsTrue(t.Rows.Count == 1);
            Assert.AreEqual(true, t.GetValue<bool>(0, "columnA"));
            Assert.AreEqual(10, t.GetValue<int>(0, "columnB"));
            Assert.AreEqual("Test", t.GetValue<string>(0, "columnC"));
            try { t.GetValue<bool>(1, "columnA"); Assert.Fail(); } catch { }

            t.Rows.Add(new Row() { Columns = { new Column("columnA", false), new Column("columnB", 50), new Column("columnC", "Hello World!") } });
            Assert.IsTrue(t.Rows.Count == 2);
            Assert.AreEqual(true, t.GetValue<bool>(0, "columnA"));
            Assert.AreEqual(10, t.GetValue<int>(0, "columnB"));
            Assert.AreEqual("Test", t.GetValue<string>(0, "columnC"));
            Assert.IsTrue(t.Rows.Count == 2);
            Assert.AreEqual(false, t.GetValue<bool>(1, "columnA"));
            Assert.AreEqual(50, t.GetValue<int>(1, "columnB"));
            Assert.AreEqual("Hello World!", t.GetValue<string>(1, "columnC"));
            try { t.GetValue<bool>(2, "columnA"); Assert.Fail(); } catch { }
        }

    }
}
