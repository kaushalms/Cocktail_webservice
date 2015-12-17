using MvcApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;
using System.Xml.Linq;

namespace MvcApplication1.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        XmlDocument maindoc= new XmlDocument();

        //returns a list of all recipes present in xml file to client
        public IEnumerable<Recipe> Get()
        {
            try { 
            List<Recipe> employees = new List<Recipe>();

            string path = System.Web.HttpContext.Current.Request.MapPath("~\\Cocktail.xml");

            XDocument doc = XDocument.Load(path);
            foreach (XElement element in doc.Descendants("recipe"))
            {
                Recipe recipe = new Recipe();
                recipe.ingredients = new List<Ingredient>();
                recipe.title = element.Element("title").Value;
                recipe.type = element.Element("type").Value;
                //Ingredient ing = new Ingredient();
                for (int i = 0; i < element.Elements("ingredient").Count(); i++)
                {
                    Ingredient ing = new Ingredient();
                    String ingredient = (string)(element.Elements("ingredient").ElementAt(i).Value);
                    String quantity = (string)(element.Elements("ingredient").ElementAt(i).Attribute("quantity"));
                    String measure = (string)(element.Elements("ingredient").ElementAt(i).Attribute("measure"));
                    ing.ingredient = ingredient;
                    ing.quantity = quantity;
                    ing.measure = measure;
                    recipe.ingredients.Add(ing);
                }

                recipe.step = element.Element("step").Value;
                recipe.glass = element.Element("glass").Value;
                recipe.garnish = element.Element("garnish").Value;
                recipe.strength = element.Element("strength").Value;
                recipe.preparation = element.Element("preparation").Value;
                employees.Add(recipe);
            }
            return employees;
            }
            catch{return null;}
        }

        //returns specific recipe based on client request.
        public Recipe Get(string a, int z)
        {
            try{
            Recipe recipe = new Recipe();
            string path = System.Web.HttpContext.Current.Request.MapPath("~\\Cocktail.xml");

            XDocument doc = XDocument.Load(path);

            foreach (XElement element in doc.Descendants("recipe"))
            {

                if (element.Element("title").Value == a)
                {

                    recipe.ingredients = new List<Ingredient>();
                    recipe.title = element.Element("title").Value;
                    recipe.type = element.Element("type").Value;
                    //Ingredient ing = new Ingredient();
                    for (int i = 0; i < element.Elements("ingredient").Count(); i++)
                    {
                        Ingredient ing = new Ingredient();
                        String ingredient = (string)(element.Elements("ingredient").ElementAt(i).Value);
                        String quantity = (string)(element.Elements("ingredient").ElementAt(i).Attribute("quantity"));
                        String measure = (string)(element.Elements("ingredient").ElementAt(i).Attribute("measure"));
                        ing.ingredient = ingredient;
                        ing.quantity = quantity;
                        ing.measure = measure;
                        recipe.ingredients.Add(ing);
                    }

                    recipe.step = element.Element("step").Value;
                    recipe.glass = element.Element("glass").Value;
                    recipe.garnish = element.Element("garnish").Value;
                    recipe.strength = element.Element("strength").Value;
                    recipe.preparation = element.Element("preparation").Value;
                    //employees.Add(recipe);
                }
            }
            return recipe;
        }
        catch
    {return null;}
        }
        

        //returns a list of all distinct properties like ingredients, titles, types etc from xml file depending on the property client has requested for.
        public IEnumerable<string> Get(string a)
        {
            try
            {
                string path = System.Web.HttpContext.Current.Request.MapPath("~\\Cocktail.xml");
                maindoc.Load(path);
                XmlNodeList MainNodeList = maindoc.GetElementsByTagName(a);
                switch (a)
                {
                    case "title":
                        List<string> titleName = new List<string>();
                        foreach (System.Xml.XmlNode item in MainNodeList)
                        {
                            titleName.Add(item.InnerXml);
                        }
                        List<string> title = titleName.Distinct().ToList();
                        return title;
                    case "type":
                        List<string> typelist = new List<string>();
                        foreach (System.Xml.XmlNode item in MainNodeList)
                        {
                            typelist.Add(item.InnerXml);
                        }
                        List<string> type = typelist.Distinct().ToList();
                        return type;
                    case "ingredient":
                        List<string> ingredient = new List<string>();
                        foreach (System.Xml.XmlNode item in MainNodeList)
                        {
                            ingredient.Add(item.InnerXml);
                        }
                        List<string> ingredients = ingredient.Distinct().ToList();
                        return ingredients;
                    case "step":
                        List<string> steplist = new List<string>();
                        foreach (System.Xml.XmlNode item in MainNodeList)
                        {
                            steplist.Add(item.InnerXml);
                        }
                        List<string> steps = steplist.Distinct().ToList();
                        return steps;
                    case "glass":
                        List<string> glasslist = new List<string>();
                        foreach (System.Xml.XmlNode item in MainNodeList)
                        {
                            glasslist.Add(item.InnerXml);
                        }
                        List<string> glass = glasslist.Distinct().ToList();
                        return glass;
                    case "garnish":
                        List<string> garnishlist = new List<string>();
                        foreach (System.Xml.XmlNode item in MainNodeList)
                        {
                            garnishlist.Add(item.InnerXml);
                        }
                        List<string> garnish = garnishlist.Distinct().ToList();
                        return garnish;
                    case "strength":
                        List<string> strengthlist = new List<string>();
                        foreach (System.Xml.XmlNode item in MainNodeList)
                        {
                            strengthlist.Add(item.InnerXml);
                        }
                        List<string> strength = strengthlist.Distinct().ToList();
                        return strength;
                    case "preparation":
                        List<string> preparationlist = new List<string>();
                        foreach (System.Xml.XmlNode item in MainNodeList)
                        {
                            preparationlist.Add(item.InnerXml);
                        }
                        List<string> preparation = preparationlist.Distinct().ToList();
                        return preparation;
                    default:
                        //  Console.WriteLine("Default case");
                        return null;

                }
            }
            catch { return null; }
           
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        

        //first converts recipe object in xml nodes.
        //post recipe object that client has sent in xml file
        public void Post([FromBody]Recipe recipe)
        {
            try
            {
                string path = System.Web.HttpContext.Current.Request.MapPath("~\\Cocktail.xml");
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode recipeNode = doc.CreateNode(XmlNodeType.Element, "recipe", null);
                XmlAttribute recipeAttribute = doc.CreateAttribute("title");
                recipeAttribute.Value = recipe.title;
                recipeNode.Attributes.Append(recipeAttribute);
                XmlNode recipeTitleNode = doc.CreateElement("title");
                recipeTitleNode.InnerText = recipe.title;
                XmlNode recipeTypeNode = doc.CreateElement("type");
                recipeTypeNode.InnerText = recipe.type;
                XmlNode recipeStepNode = doc.CreateElement("step");
                recipeStepNode.InnerText = recipe.step;
                XmlNode recipeGlassNode = doc.CreateElement("glass");
                recipeGlassNode.InnerText = recipe.type;
                XmlNode recipeGarnishNode = doc.CreateElement("garnish");
                recipeGarnishNode.InnerText = recipe.garnish;
                XmlNode recipeStrengthNode = doc.CreateElement("strength");
                recipeStrengthNode.InnerText = recipe.strength;
                XmlNode recipePreparationNode = doc.CreateElement("preparation");
                recipePreparationNode.InnerText = recipe.preparation;
                recipeNode.AppendChild(recipeTitleNode);
                recipeNode.AppendChild(recipeTypeNode);
                //List<Ingredient> ingredients = new List<Ingredient>();
                //ingredients = recipe.ingredients;
                foreach (Ingredient i in recipe.ingredients)
                {
                    XmlNode recipeIngreNode = doc.CreateElement("ingredient");
                    recipeIngreNode.InnerText = i.ingredient;
                    XmlAttribute ingAttributeQuantity = doc.CreateAttribute("quantity");
                    ingAttributeQuantity.Value = i.quantity;
                    recipeIngreNode.Attributes.Append(ingAttributeQuantity);
                    XmlAttribute ingAttributeMeasure = doc.CreateAttribute("measure");
                    ingAttributeMeasure.Value = i.measure;
                    recipeIngreNode.Attributes.Append(ingAttributeMeasure);
                    recipeNode.AppendChild(recipeIngreNode);
                }

                recipeNode.AppendChild(recipeStepNode);
                recipeNode.AppendChild(recipeGlassNode);
                recipeNode.AppendChild(recipeGarnishNode);
                recipeNode.AppendChild(recipeStrengthNode);
                recipeNode.AppendChild(recipePreparationNode);
                doc.DocumentElement.AppendChild(recipeNode);
                doc.Save(path);
            }
            catch { }

        }
        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}