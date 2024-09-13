using easycnc_core.Data;

namespace easycnc_core.Areas.System.Request
{
    public class UserRequest : BaseRequest
    {
        public string? Username { get; set; }
        public int DeptId { get; set; }
    }
}
