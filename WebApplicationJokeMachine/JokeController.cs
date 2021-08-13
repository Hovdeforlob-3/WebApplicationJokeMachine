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

        // GET: api/<JokeController>
        [HttpGet]
        public List<Joke> Get()
        {
            JokeManager jokeManager = new JokeManager();
            List<Joke> pullUsedJoksFromSession = HttpContext.Session.GetObjectFromJson<List<Joke>>("usedJokes");

            var sessionListStat = jokeManager.CheckListFromItems(pullUsedJoksFromSession);
            Random rng = new Random();

            Response.Headers.Add("pref_language", "en");
            List<Joke> getJokeFrom = jokeManager.ConmpareJokes(pullUsedJoksFromSession, sessionListStat);
            List<Joke> sortedJokes = jokeManager.SortJokes(getJokeFrom, Response.Headers.Values.FirstOrDefault().ToString());

            var nextJoke = sortedJokes[rng.Next(sortedJokes.Count)];


            if (HttpContext.Session.GetObjectFromJson<List<Joke>>("usedJokes") == null)
            {
                pullUsedJoksFromSession = new List<Joke>();
                pullUsedJoksFromSession.Add(nextJoke);
                HttpContext.Session.SetObjectAsJson("usedJokes", pullUsedJoksFromSession);
            }
            else
            {
                pullUsedJoksFromSession.Add(nextJoke);
                HttpContext.Session.SetObjectAsJson("usedJokes", pullUsedJoksFromSession);
            }


            HttpContext.Session.SetObjectAsJson("usedJokes", pullUsedJoksFromSession);
            var ff = HttpContext.Session.GetObjectFromJson<List<Joke>>("usedJokes");
            return pullUsedJoksFromSession;
        }
    }
}
