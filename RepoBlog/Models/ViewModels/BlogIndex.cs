using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepoBlog.Models.BaseModels;

namespace RepoBlog.Models.ViewModels
{
    public class BlogIndex
    {
        public Post Post { get; set; }
        public List<Billede> Billeder { get; set; }
    }
}
