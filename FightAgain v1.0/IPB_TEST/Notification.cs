using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPB_TEST
{
    public class Notification
    {
        public String Time { get; set; }
        public String Message { get; set; }
        public Brush Color;

        public Notification(String message,NotificationType notificationType=NotificationType.Success)
        {
            Time = "["+String.Format("{0:HH:mm:ss}", DateTime.Now)+"] ";
            Message = message;
            Color = Brushes.DarkGreen;
            switch (notificationType)
            {
                case NotificationType.Fail:
                    Color = Brushes.DarkRed;
                    break;
                case NotificationType.Success:
                    Color = Brushes.DarkGreen;
                    break;
                case NotificationType.Warning:
                    Color = Brushes.OrangeRed;
                    break;
            }
        }
    }

    public enum NotificationType
    {
        Success,
        Fail,
        Warning
    }
}
