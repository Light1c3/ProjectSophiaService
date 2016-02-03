using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectSophia.ViewModels
{
    public class BenchmarkViewModels
    {
        public class BenchmarkDTO
        {
            [Key]
            public int Id { get; set; }
            public string Username { get; set; }
            public string GameName { get; set; }
            public string AvgFPS { get; set; }
        }
        public class GameDTO
        {
            public int Id { get; set; }
            public string Username { get; set; }
            public string GameName { get; set; }
            public string CPU { get; set; }
            public string GPU { get; set; }
            public string RAM { get; set; }
            public string MinFPS { get; set; }
            public string MaxFPS { get; set; }
            public string AvgFPS { get; set; }
        }
    }
}
