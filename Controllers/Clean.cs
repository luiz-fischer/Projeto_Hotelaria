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
                Model.Room.GetRoomId(roomId);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Quarto não cadastrado!");
            }
            return new Model.Clean(roomId);
        }

        public static Model.Clean GetCleansByRoom(int roomId)
        {
            return Model.Clean.GetCleanByRoom(roomId);
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

        public static void SetCleanDone(int cleanId, int employeeId)
        {
            Model.Clean clean = GetClean(cleanId);
            try
            {
                Model.Employee.GetEmployee(employeeId);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Funcionário não encontrado!");
            }

            if (string.IsNullOrEmpty(clean.Date.ToString()))
            {
                Model.Clean.SetCleanDone(cleanId, employeeId);
            }
        }
    }
}
