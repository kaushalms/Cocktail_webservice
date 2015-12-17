using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcApplication1.Controllers
{
    public class RecipeController : ApiController


    {
        

        XmlDocument maindoc = new XmlDocument();
     
        //function returns  specific Cocktail details as per Client request in the form list.
        public IEnumerable<string> Get(string title)
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

                    if (node.Attributes["title"].Value == title)
                    {
                        //int x = node.ChildNodes.Count;

                        for (int i = 0; i < node.ChildNodes.Count; i++)
                        {
                            if (node.ChildNodes[i].Name == "ingredient")
                            {
                                titleName.Add(node.ChildNodes[i].InnerXml + "   " + node.ChildNodes[i].Attributes["quantity"].Value + "   " + node.ChildNodes[i].Attributes["measure"].Value);
                            }
                            else
                            {
                                titleName.Add(node.ChildNodes[i].InnerXml);
                            }

                        }

                        //titleName.Add(node.InnerText);


                        //titleName.Add(node.OuterXml);


                    }


                }

                return titleName;
            }
            catch { return null; }
        }

        //this is used to return specific recipe details to client depending on the client request.
        public IEnumerable<string> Get(string title, string field)
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

                    if (node.Attributes["title"].Value == title)
                    {
                        //int x = node.ChildNodes.Count;

                        for (int i = 0; i < node.ChildNodes.Count; i++)
                        {
                            if (node.ChildNodes[i].InnerText == field)
                            {
                                titleName.Add(node.ChildNodes[i].Attributes["quantity"].Value + " " + node.ChildNodes[i].Attributes["measure"].Value);
                            }


                        }

                        //titleName.Add(node.InnerText);


                        //titleName.Add(node.OuterXml);


                    }


                }

                return titleName;
            }
            catch { return null; }

        }
        public IEnumerable<string> Get(string titlevalue, int a)
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

                    if (node.Attributes["title"].Value == titlevalue)
                    {
                        //int x = node.ChildNodes.Count;

                        for (int i = 0; i < node.ChildNodes.Count; i++)
                        {

                            if (node.ChildNodes[i].Name == "glass")
                            {
                                titleName.Add(node.ChildNodes[i].InnerText);
                            }
                            if (node.ChildNodes[i].Name == "garnish")
                            {
                                titleName.Add(node.ChildNodes[i].InnerText);
                            }
                            if (node.ChildNodes[i].Name == "step")
                            {
                                titleName.Add(node.ChildNodes[i].InnerText);
                            }


                        }

                        //titleName.Add(node.InnerText);


                        //titleName.Add(node.OuterXml);


                    }


                }

                return titleName;
            }
            catch { return null; }

        }


    }
}
