using System.Diagnostics.Contracts;

namespace WebAPplication.UI.UiModels
{
    public class UIWorkItem
    {
        public string name { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public string area { get; set; }
        public string iteration { get; set; }
        public string status { get; set; }
        public DateTime startdate { get; set; }
        public DateTime endate { get; set; }

    }
}
