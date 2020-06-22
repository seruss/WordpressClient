using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordpressDesktopClient
{
    public class Tag : TreeNode
    {

        public int TagID { get; set; }
        public int ParentID { get; set; }

        public Tag(string name, int tagid, int parentid)
        {
            Text = name;
            TagID = tagid;
            ParentID = parentid;
        }
    }
}
