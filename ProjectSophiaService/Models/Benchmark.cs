using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectSophiaService.Models
{
    public class Benchmark
    {
        //Basic Data
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }

        //System Specs of the user's machine
        public string CPU { get; set; }
        public string GPU { get; set; }
        public string RAM { get; set; }

        //Benchmark results
        public string MinFPS { get; set; }
        public string MaxFPS { get; set; }
        public string AvgFPS { get; set; }

        //Foreign Key
        public int GameId { get; set; }
        // Navigation property
        [ForeignKey("GameId")]
        public virtual Game Game { get; set; }
    }
}