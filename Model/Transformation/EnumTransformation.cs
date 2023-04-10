using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Transformation
{
    public static class EnumTransformation
    {
        public static string BookingStatus(int status)
        {
            var res = String.Empty;

            switch (status)
            {
                case -1:
                    res = "Hủy";
                    break;

                case 0:
                    res = "Chưa xác nhận";
                    break;

                case 1:
                    res = "Đã xác nhận";
                    break;

                case 999:
                    res = "Hoàn thành";
                    break;

                default:
                    res = "Không xác định";
                    break;
            }

            return res;
        }
    }
}
