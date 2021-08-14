using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationJokeMachine
{
    public class JokeManager
    {
        static public List<Joke> Jokes()
        {
            return DalManager.Jokes();
        }


        public List<string> ListOfCat()
        {
            var lstOfJokes = DalManager.Jokes();
            var lstOfAllCat = new List<string>();

            foreach (var item in lstOfJokes)
            {
                lstOfAllCat.Add(item.Type);
            }
            
            return lstOfAllCat.Distinct().ToList();
        }

        public List<Joke> ConmpareJokes(List<Joke> sessionUsedJokes, bool checkSession)
        {
            List<Joke> fullListOfJokes = Jokes();
            if (checkSession)
            {
                foreach (var item in fullListOfJokes.ToList())
                {
                    foreach (var sItem in sessionUsedJokes)
                    {
                        if (item.Id == sItem.Id)
                        {
                            var itemToRemove = fullListOfJokes.Single(r => r.Id == sItem.Id);
                            fullListOfJokes.Remove(itemToRemove);
                        }
                    }
                }
            }

            List<Joke> missingJoke = fullListOfJokes;
            return missingJoke;
        }

        public bool CheckListFromItems(List<Joke> sessionList)
        {
            if (sessionList == null)
                return false;

            else
                return true;
        }

        //public List<Joke> CheackForSessionList(List<Joke> sessionJokes)
        //{
        //    List<Joke> usedJokes = HttpContext.Session.GetObjectFromJson<List<Joke>>("usedJokes");

        //    if (HttpContext.Session.GetObjectFromJson<List<Joke>>("usedJokes") == null)
        //    {
        //        usedJokes = new List<Joke>();
        //        usedJokes.Add(new Joke { Name = productName, Price = price });
        //        HttpContext.Session.SetObjectAsJson("usedJokes", usedJokes);
        //    }
        //    else
        //    {
        //        ShoppingCart.Add(new Joke { Name = productName, Price = price });
        //        HttpContext.Session.SetObjectAsJson("usedJokes", usedJokes);
        //    }
        //    return usedJokes;
        //}

        public List<Joke> SortJokes(List<Joke> listOfJokes, string headerValue)
        {
            List<Joke> sort = new List<Joke>();


            if (headerValue == "dk")
            {
                sort = listOfJokes.Where(o => o.Language == "dk").ToList();
            }
            else if (headerValue == "en")
            {
                sort = listOfJokes.Where(o => o.Language == "en").ToList();
            }
            else
            {
                sort = listOfJokes;
            }
            return sort;
        }

        public List<Joke> SortCatgaroi(List<Joke> listOfJokes, string userCat)
        {
            List<Joke> sort = new List<Joke>();


            if (userCat != null)
            {
                sort = listOfJokes.Where(o => o.Type == userCat).ToList();
            }
            else
            {
                sort = listOfJokes;
            }
            return sort;
        }
    }
}
