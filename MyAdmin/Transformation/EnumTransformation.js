var Transformation = {
    bookingStatus: function (status) {
        var res = '';

        switch (status) {
            case -1:
                res = "Hủy";
                break;

            case 0:
                res = "Chờ xử lý";
                break;

            case 1:
                res = "Chấp thuận";
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