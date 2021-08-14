using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationJokeMachine
{
    [Route("api/Jokes")]
    [ApiController]
    public class JokeController : ControllerBase
    {
        JokeManager jokeManager = new JokeManager();

        // GET: api/<JokeController>
        [HttpGet]
        public List<string> Get(string cat)
        {
            #region old
            //List<Joke> pullUsedJoksFromSession = HttpContext.Session.GetObjectFromJson<List<Joke>>("usedJokes");

            //var sessionListStat = jokeManager.CheckListFromItems(pullUsedJoksFromSession);
            //Random rng = new Random();

            //Response.Headers.Add("pref_language", "dk");
            //List<Joke> getJokeFrom = jokeManager.ConmpareJokes(pullUsedJoksFromSession, sessionListStat);
            ///*List<Joke>*/ sortedJokes = jokeManager.SortJokes(getJokeFrom, Response.Headers.Values.FirstOrDefault().ToString());

            //var nextJoke = sortedJokes[rng.Next(sortedJokes.Count)];


            //if (HttpContext.Session.GetObjectFromJson<List<Joke>>("usedJokes") == null)
            //{
            //    pullUsedJoksFromSession = new List<Joke>();
            //    pullUsedJoksFromSession.Add(nextJoke);
            //    HttpContext.Session.SetObjectAsJson("usedJokes", pullUsedJoksFromSession);
            //}
            //else
            //{
            //    pullUsedJoksFromSession.Add(nextJoke);
            //    HttpContext.Session.SetObjectAsJson("usedJokes", pullUsedJoksFromSession);
            //}


            //HttpContext.Session.SetObjectAsJson("usedJokes", pullUsedJoksFromSession);
            //var ff = HttpContext.Session.GetObjectFromJson<List<Joke>>("usedJokes");
            //return pullUsedJoksFromSession;
            #endregion

            if (cat != null)
            {
                Response.Cookies.Append("catgori", cat);
            }

            //Response.Headers.Add("Apikey", "mykey");

            return jokeManager.ListOfCat();
        }

        [HttpGet]
        [Route("joke")]
        [ApiKeyAuth]
        public List<Joke> GetJokes()
        {
            //Response.Headers.Add("Apikey", "mykey");
            List<Joke> pullUsedJoksFromSession = HttpContext.Session.GetObjectFromJson<List<Joke>>("usedJokes"); // input

            var sessionListStat = jokeManager.CheckListFromItems(pullUsedJoksFromSession);
            Random rng = new Random();

            Response.Headers.Add("pref_language", "dk"); //output
            List<Joke> getJokeFrom = jokeManager.ConmpareJokes(pullUsedJoksFromSession, sessionListStat);
            List<Joke> sortedJokes = jokeManager.SortJokes(getJokeFrom, Response.Headers.Values.FirstOrDefault().ToString()); // input


            //var fsdfe = Request.Cookies["catgori"];
            List<Joke> gg = jokeManager.SortCatgaroi(sortedJokes, Request.Cookies["catgori"]); //input
            var nextJoke = gg[rng.Next(gg.Count)];



            if (HttpContext.Session.GetObjectFromJson<List<Joke>>("usedJokes") == null) //input
            {
                pullUsedJoksFromSession = new List<Joke>();
                pullUsedJoksFromSession.Add(nextJoke);
                HttpContext.Session.SetObjectAsJson("usedJokes", pullUsedJoksFromSession); //output
            }
            else
            {
                pullUsedJoksFromSession.Add(nextJoke);
                HttpContext.Session.SetObjectAsJson("usedJokes", pullUsedJoksFromSession); //output
            }


            HttpContext.Session.SetObjectAsJson("usedJokes", pullUsedJoksFromSession); //output
            var ff = HttpContext.Session.GetObjectFromJson<List<Joke>>("usedJokes"); // input
            return pullUsedJoksFromSession;


        }
    }
}
