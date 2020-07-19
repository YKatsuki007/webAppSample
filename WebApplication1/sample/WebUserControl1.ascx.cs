using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.sample
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        //public WebUserControl1(ListView paramlistView)
        //{
        //    this.ListView1 = paramlistView;
        //}

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

        protected void Page_Load(object sender, EventArgs e)
        {
            //List<test> tests = new List<test>();
            //for (int i = 0; i < 100000; i++)
            //{
            //    test test = new test()
            //    {
            //        no = i * 33,
            //        item = i.ToString()
            //    };
            //    tests.Add(test);
            //}
            //VStest = tests;
            //ListView1.DataSource = tests;
            //ListView1.DataBind();
            if(IsPostBack)
            SetData();
        }

        public void SetData()
        {
            List<test> tests = new List<test>();
            for (int i = 0; i < 100000; i++)
            {
                test test = new test()
                {
                    no = i * 111,
                    item = i.ToString()
                };
                tests.Add(test);
            }
            VStest = tests;
            ListView1.DataSource = tests;
            ListView1.DataBind();
            //((ListView)FindControl(ListView1.ClientID)).DataSource = tests;
            //((ListView)FindControl(ListView1.ClientID)).DataBind();
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
    }
}