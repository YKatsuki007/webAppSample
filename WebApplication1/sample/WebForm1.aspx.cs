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
        protected void Page_Load(object sender, EventArgs e)
        {
            List<test> tests = new List<test>();
            for(int i=0; i< 100000; i++)
            {
                test test = new test()
                {
                    no = i,
                    item = i.ToString()
                };
                tests.Add(test);
            }

            ListView1.DataSource = tests;
            ListView1.DataBind();
        }
    }
}