using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectSophia.ViewModels
{
    public class GameViewModels
    {
        public class GameDTO
        {
            [Key]
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public int Year { get; set; }
            public string ShortLink { get; set; }
            public string Publisher { get; set; }
            public string ImageUrl { get; set; }
            public int MarkCount { get; set; }
        }
    }
}
