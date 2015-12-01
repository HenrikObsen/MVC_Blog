using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepoBlog.Models.BaseModels;
using RepoBlog.Models.ViewModels;

namespace RepoBlog.Factories
{
    public class PostFac: AutoFac<Post>
    {
        BilledFac billedFac = new BilledFac();

        public List<BlogIndex> GetIndexData()
        {
            List<BlogIndex> listBlogIndex = new List<BlogIndex>();
            foreach (var post in GetAll())
            {
                BlogIndex blogIndex = new BlogIndex();
                blogIndex.Post = post;
                blogIndex.Billeder = billedFac.GetBy("PostID", post.ID);
                listBlogIndex.Add(blogIndex);
            }
            return listBlogIndex;
        }
    }
}
