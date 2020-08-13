using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.sample
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        [Serializable]
        public class test
        {
            public int no
            {
                get;
                set;
            }
            public string item
            {
                get;
                set;
            }
        }

        public List<test> VStest
        {
            get { return (List<test>)ViewState["test"]; }
            set { ViewState["test"] = value; }
        }

        //public List<test> SStest
        //{
        //    get { return (List<test>)Session["test"]; }
        //    set { Session["test"] = value; }
        //}

        //public WebUserControl1.Preservation preservation += pre;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<test> tests = new List<test>();
                for (int i = 0; i < 100; i++)
                {
                    test test = new test()
                    {
                        no = i * 33,
                        item = i.ToString()
                    };
                    tests.Add(test);
                }
                VStest = tests;
                ListView1.DataSource = tests;
                ListView1.DataBind();
            }


            foreach(string item in Request.Form.Keys)
            {
                if (string.IsNullOrEmpty(item) || item.Contains(Button1.ClientID))
                {
                    Label4.Text = item.ToString();
                }
            }

            WebUserControl1.Preservation_Eve += pre;

        }

        //public List<test> pre()
        public void pre()
        {
            //WebUserControl1.SStest_UC = VStest;
            WebUserControl1.VStest_UC = VStest;
            //VStest = WebUserControl1.SStest_UC;
            //return "pre test";
            //return VStest;
            Label5.Text = "pre()";
        }

        protected void ListView1_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            var temp1 = DataPager1.StartRowIndex;
            var temp2 = DataPager1.MaximumRows;
            DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            var temp3 = DataPager1.StartRowIndex;
            var temp4 = DataPager1.MaximumRows;
            ListView1.DataSource = VStest;
            ListView1.DataBind();
        }

        protected void ListView1_PagePropertiesChanged(object sender, EventArgs e)
        {
            var temp1 = DataPager1.StartRowIndex;
            var temp2 = DataPager1.MaximumRows;
        }

        protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem item = (ListViewDataItem)e.Item;
                ListView innerList = (ListView)item.FindControl("ListView2");

                Type type = item.DataItem.GetType();
                var obj = Convert.ChangeType(item.DataItem, type);
                var ps = type.GetProperties();                

                Table table = new Table();
                TableRow row = new TableRow();
                foreach (var p in ps)
                {
                    TableCell cell = new TableCell();
                    Label lbl = new Label();
                    lbl.Text = DataBinder.Eval(obj, p.Name).ToString();
                    cell.Controls.Add(lbl);
                    row.Controls.Add(cell);
                }

                table.Rows.Add(row);
                table.CssClass = "";

                innerList.Controls.Add(table);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<test> tests = new List<test>();
            for (int i = 0; i < 1000; i++)
            {
                test test = new test()
                {
                    no = i * 111,
                    item = i.ToString()
                };
                tests.Add(test);
            }
            VStest = tests;
            ////WebUserControl1.DataSource = tests;
            ////WebUserControl1.DataBind();
            //WebUserControl1 webUserControl1 = new WebUserControl1();
            ////((ListView)webUserControl1.FindControl("ListView1")).DataSource = tests;
            //webUserControl1.SetData();
            ((ListView)WebUserControl1.FindControl("ListView1")).DataSource = tests;
            ((ListView)WebUserControl1.FindControl("ListView1")).DataBind();
        }
    }
}