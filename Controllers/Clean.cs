using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace Controller
{  
    public class Clean
    {
        public static Model.Clean AddClean(int roomId)
        {
            try
            {
                Model.Room.GetRoom(roomId);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Quarto não cadastrado!");
            }
            return new Model.Clean(roomId);
        }

        public static Model.Clean Add(
            Model.Employee employee,
            Model.Room room,
            DateTime scheduledDate
        )
        {
            return new Model.Clean(employee, room, scheduledDate);
        }

        public static List<Model.Clean> GetCleans()
        {
            return Model.Clean.GetCleans();
        }

        public static Model.Clean GetClean(int cleanId)
        {
            return Model.Clean.GetClean(cleanId);
        }

        public static void DeleteClean(int cleanId)
        {
            Model.Clean.DeleteClean(cleanId);
        }
        
    }
}


