﻿using System;
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
            VStest = tests;
            ListView1.DataSource = tests;
            ListView1.DataBind();
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
    }
}