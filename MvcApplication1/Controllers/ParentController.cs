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
    public class ParentController : ApiController
    { XmlDocument maindoc = new XmlDocument();


        //this function uses xml file to provide cocktail list based on the single ingredient client has sent.
        public IEnumerable<string> Get(string a)
    {
        try
        {
            string path = System.Web.HttpContext.Current.Request.MapPath("~\\Cocktail.xml");
            maindoc.Load(path);
            XmlNodeList xnl = maindoc.SelectNodes("/cocktail/recipe");
            XmlNodeList MainNodeList = maindoc.SelectNodes("/cocktail/recipe");

            List<string> titleName = new List<string>();
            foreach (XmlNode node in xnl)
            {



                //int x = node.ChildNodes.Count;

                for (int i = 0; i < node.ChildNodes.Count; i++)
                {
                    if (node.ChildNodes[i].InnerText == a)
                    {
                        titleName.Add(node.Attributes["title"].Value);
                    }

                    //titleName.Add(node.ChildNodes[i].InnerText +"   " +node.ChildNodes[i].Attributes["quantity"].Value +"   "+ node.ChildNodes[i].Attributes["measure"].Value);

                }

                // titleName.Add(node.InnerXml);


            }
            return titleName;
        }
        catch { return null; }

            }

        ////this function uses xml file to provide cocktail list based on the two ingredients client has sent.
        public IEnumerable<string> Get(string a, string b)
        {
            try { 
            string path = System.Web.HttpContext.Current.Request.MapPath("~\\Cocktail.xml");
            maindoc.Load(path);
            XmlNodeList xnl = maindoc.SelectNodes("/cocktail/recipe");
            XmlNodeList MainNodeList = maindoc.SelectNodes("/cocktail/recipe");
            
            List<string> titleName = new List<string>();
            foreach (XmlNode node in xnl)
            {
                int count = 0;


                //int x = node.ChildNodes.Count;

                for (int i = 0; i < node.ChildNodes.Count; i++)
                {
                    if (node.ChildNodes[i].InnerText == a || node.ChildNodes[i].InnerText == b)
                    {
                        count = count + 1;
                        if (count == 2)
                        {
                            titleName.Add(node.Attributes["title"].Value);
                        }
                    }

                    //titleName.Add(node.ChildNodes[i].InnerText +"   " +node.ChildNodes[i].Attributes["quantity"].Value +"   "+ node.ChildNodes[i].Attributes["measure"].Value);

                }

                // titleName.Add(node.InnerXml);


            }
            return titleName;
                }
            catch
            {
               
                return null;
            }
        }
        //public IEnumerable<string> Get(string a, string b, string c)
   
        //    maindoc.Load("C:/Users/murali/Downloads/MvcApplication1-1/MvcApplication1/MvcApplication1/Cocktail.xml");
        //    XmlNodeList xnl = maindoc.SelectNodes("/cocktail/recipe");
        //    XmlNodeList MainNodeList = maindoc.SelectNodes("/cocktail/recipe");

        //    List<string> titleName = new List<string>();
        //    foreach (XmlNode node in xnl)
        //    {



        //        //int x = node.ChildNodes.Count;

        //        for (int i = 0; i < node.ChildNodes.Count; i++)
        //        {
        //            if (node.ChildNodes[i].InnerText == a && node.ChildNodes[i].InnerText == b && node.ChildNodes[i].InnerText == c)
        //            {
        //                titleName.Add(node.Attributes["title"].Value);
        //            }

        //            //titleName.Add(node.ChildNodes[i].InnerText +"   " +node.ChildNodes[i].Attributes["quantity"].Value +"   "+ node.ChildNodes[i].Attributes["measure"].Value);

        //        }

        //        // titleName.Add(node.InnerXml);


        //    }
        //    return titleName;

        //}
        
        //
        // GET: /Parent/

        //public ActionResult Index()
        //{
        //    return View();
        //}

    }
}
