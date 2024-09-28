﻿using System.Globalization;

namespace MovieAPIDemo.Entities
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string  Description { get; set; }
        //List of Actors
        public ICollection<Person> Actors { get; set; }

        public string Language { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string CoverImage { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }


    }
}
