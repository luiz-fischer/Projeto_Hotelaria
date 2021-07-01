using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.View;

namespace Library
{
    public class ListView : System.Windows.Forms.ListView
    {
        public ListView()
        {
            this.Location = new Point(12, 175);
            this.Size = new Size(1320, 200);
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.View = Details;
            this.FullRowSelect = true;
            this.GridLines = true;
            this.AllowColumnReorder = true;
            this.Sorting = SortOrder.None;
            this.MultiSelect = true;
        }
    }
}