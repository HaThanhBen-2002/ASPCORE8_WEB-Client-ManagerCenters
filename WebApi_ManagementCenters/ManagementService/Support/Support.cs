using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementService.Support
{
    public class Support
    {
        public static string GetCurrentDateTime()
        {
            // Lấy ngày và giờ hiện tại
            DateTime currentDateTime = DateTime.Now;

            // Format ngày giờ theo định dạng yêu cầu
            string formattedDateTime = currentDateTime.ToString("dd/MM/yyyy HH:mm:ss");

            return formattedDateTime;
        }
    }
}
