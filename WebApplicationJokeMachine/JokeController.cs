using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;


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
            if (cat != null)
            {
                Response.Cookies.Append("catgori", cat);
            }

            return jokeManager.ListOfCat();
        }

        [HttpGet]
        [Route("joke")]
        [ApiKeyAuth]
        public List<Joke> GetJokes()
        {
            Response.Headers.Add("pref_language", "dk");
            Random rng = new Random();

            try
            {
                List<Joke> pullUsedJoksFromSession = HttpContext.Session.GetObjectFromJson<List<Joke>>("usedJokes");
               
                bool sessionListStat = jokeManager.CheckListFromItems(pullUsedJoksFromSession);
                List<Joke> getJokeFrom = jokeManager.ConmpareJokes(pullUsedJoksFromSession, sessionListStat);
                
                string headerValue = jokeManager.VaildtLanguage(Response.Headers.Values.FirstOrDefault().ToString());
                List<Joke> sortedJokes = jokeManager.SortJokes(getJokeFrom, headerValue);
                List<Joke> sortedJokesLst= jokeManager.SortCatgaroi(sortedJokes, Request.Cookies["catgori"]);

                Joke nextJoke = sortedJokesLst[rng.Next(sortedJokesLst.Count)];

                List<Joke> usedJokes = jokeManager.SetJsonValueInSession(pullUsedJoksFromSession, nextJoke);
                HttpContext.Session.SetObjectAsJson("usedJokes", usedJokes);

                return pullUsedJoksFromSession;
            }
            catch (IndexOutOfRangeException ex)
            {
                Debug.Write(ex);
                return null; 
            }
            catch(Exception ex)
            {
                Debug.Write(ex);
                return null;
            }
        }
    }
}

