using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationJokeMachine
{
    public class Joke
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string  Content  { get; set; }
        public string Language { get; set; }


        public Joke(int id, string type, string content, string language )
        {
            this.Id = id;
            this.Type = type;
            this.Content = content;
            this.Language = language;
        }
    }
}
