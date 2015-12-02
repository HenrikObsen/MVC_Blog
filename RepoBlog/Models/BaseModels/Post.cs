using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace RepoBlog.Models.BaseModels
{
    public class Post
    {
        
        public int ID { get; set; }

        [Required]
        [StringLength(150)]
        public string Overskrift { get; set; }

        [Required]
        public string Tekst { get; set; }

        [Required]
        //[RegularExpression("^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)[0-9][0-9]$")]
        public DateTime Dato { get; set; }

        [Required]
        public string Forfatter { get; set; }

        // [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email")]
        // [DisplayName("Opdateret")]
        // [Range(0, 9999)]
        //http://regexlib.com/DisplayPatterns.aspx
    }
}
