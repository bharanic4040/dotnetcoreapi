using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetHello.Core.DTOs
{
    public class SearchDto
    {

        public string Isbn { get; set; }

        public string Title { get; set; }


        public SearchDto()
        {
        }
    }
}
