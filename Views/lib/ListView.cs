using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.View;

namespace Library 
{
    public class ListView : System.Windows.Forms.ListView
    {
        public ListView( )
        {
            this.Size = new Size(1050, 200);
            this.Font = new Font("Roboto", 14F, GraphicsUnit.Point);
            this.View = Details;
            this.FullRowSelect = true;
            this.GridLines = true;
            this.AllowColumnReorder = true;
            this.Sorting = SortOrder.None;
            this.MultiSelect = true;
        }
    }
}