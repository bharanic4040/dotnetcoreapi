
using System.ComponentModel.DataAnnotations;

namespace DotNetHello.Core.Entities
{
    public class Search
    {
        [Key]
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }


        public Search()
        {

        }

       
    }
}
