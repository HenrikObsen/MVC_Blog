using System;


namespace RepoBlog.Models.BaseModels
{
    public class Post
    {
        public int ID { get; set; }
        public string Overskrift { get; set; }
        public string Tekst { get; set; }
        public DateTime Dato { get; set; }
        public string Forfatter { get; set; }

    }
}
