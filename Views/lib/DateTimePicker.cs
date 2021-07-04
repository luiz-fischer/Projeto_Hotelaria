using System.Drawing;


namespace Library
{
    public class DateTimePicker : System.Windows.Forms.DateTimePicker
    {
        public DateTimePicker()
        {
            this.AutoSize = false;
            this.Font = new Font("Roboto", 18F, GraphicsUnit.Point);
            this.Location = new Point(600, 215);
            this.MaxDate = new System.DateTime(2021, 12, 31, 0, 0, 0, 0);
            this.MinDate = new System.DateTime(1920, 1, 1, 0, 0, 0, 0);
            this.Size = new Size(330, 100);
            this.TabIndex = 1;
            this.CalendarForeColor = Color.Red;
        }
     }
}