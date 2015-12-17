using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;


namespace MvcApplication1.Controllers
{
    public class CountController : ApiController
    {
        XmlDocument maindoc = new XmlDocument();

        //this function is used to  count number of ingredients in the recipe from the xml file and provide it to client
        public IEnumerable<string> Get(string a) 
        {
            try
            {
                string path = System.Web.HttpContext.Current.Request.MapPath("~\\Cocktail.xml");
                maindoc.Load(path);
                XmlNodeList xnl = maindoc.SelectNodes("/cocktail/recipe");
                XmlNodeList MainNodeList = maindoc.SelectNodes("/cocktail/recipe");

                int titlename = 0;
                string title1 = null;
                List<string> title = new List<string>();

                foreach (XmlNode node in xnl)
                {


                    if (node.Attributes["title"].Value == a)
                    {
                        for (int i = 0; i < node.ChildNodes.Count; i++)
                        {

                            if (node.ChildNodes[i].Name == "ingredient")
                            {
                                titlename = titlename + 1;
                            }

                        }

                    }
                    //int x = node.ChildNodes.Count;



                    // titleName.Add(node.InnerXml);


                }
                title1 = titlename.ToString();
                title.Add(title1);

                return title;
            }
            catch { return null; }
        }
    }
}
