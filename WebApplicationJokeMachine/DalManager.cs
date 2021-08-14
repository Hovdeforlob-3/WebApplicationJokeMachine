using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationJokeMachine
{
    public class DalManager
    {
        static public List<Joke> Jokes()
        {
            List<Joke> badJoke = new List<Joke>();
            badJoke.AddRange(new List<Joke>
            {
                new Joke(1, "bad joke","Hvad kalder man røvhullet på et egern? – En nødudgang", "dk"),
                new Joke(2, "bad joke", "Jeg overvejer at gifte mig med en tysker er det over grænsen?", "dk"),
                new Joke(3, "bad joke", "Hvorfor går Bornholmer altid rundt med en saks i lommen? – Fordi det er en klippeø", "dk"),
                new Joke(4, "bad joke", "Hvordan får man en fisk til at grine? – Man putter den i kildevand", "dk" ),
                new Joke(5, "bad joke", "What’s the difference between England and a tea bag? – The tea bag stays in the cup longer", "en" ),
                new Joke(6, "bad joke", "I went to the zoo the other day. There was only a dog in it – it was a shihtzu", "en"),
                new Joke(7, "bad joke", "Two fish in a tank. One says: “How do you drive this thing?”", "en"),


                new Joke(8, "blonde joke", "Hvorfor var blondinen glad for, at samle et puzzlespil på 6 måneder? ​- Fordi der stod 2-4 år", "dk"),
                new Joke(9, "blonde joke", "En røver kommer ind i butikken og stjæler et TV. - Blondinen løber efter ham og råber “Vent, du har glemt fjernbetjeningen!”", "dk"),
                new Joke(10, "blonde joke", "Hvad kalder man en død blondine i et klædeskab? – Miss Gemmeleg ’94", "dk"),
                new Joke(11, "blonde joke", "Hvorfor faldt blondinen ned fra computerbordet? – Hun prøvede at gå på nettet", "dk"),
                new Joke(12, "blonde joke", "Two blondes fell down a hole. One said, ''It's dark in here isn't it?'' The other replied, ''I don't know; I can't see.''", "en"),
                new Joke(13, "blonde joke", "A guy was driving in a car with a blonde. He told her to stick her head out the window and see if the blinker worked. She stuck her head out and said, ''Yes, No, Yes, No, Yes...''", "en"),


                new Joke(14, "dad joke", "Hvorfor skulle skyen i skole? – Fordi den skulle lære at regne", "dk"),
                new Joke(15, "dad joke", "Hvad er det mindst talte sprog i verden?  – Tegnsprog", "dk"),
                new Joke(16, "dad joke", "Why don't crabs give to charity? Because they're shellfish.", "en"),
                new Joke(17, "dad joke", "What do you call 50 pigs and 50 deer? 100 sows and bucks", "en"),
            });
            return badJoke;
        }

        //public List<string> dadJokes = new List<string>
        //{
        //    "Hvorfor skulle skyen i skole? – Fordi den skulle lære at regne",
        //    "Hvad er det mindst talte sprog i verden? – Tegnsprog"
        //};

        //public List<string> goodJokes = new List<string>
        //{
        //    "Hvorfor (gå) over for grønt?   Når man kan blive (kørt) over for rødt?",
        //    "Hvorfor sad appelsinen og pæren alene i mørket? – Fordi pæren var gået"
        //};
    }
}
