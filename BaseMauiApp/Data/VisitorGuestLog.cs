using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseMauiApp.Data
{
    [Serializable]
    public class VisitorGuestLog
    {
        public string SessionNumber { get; set; }
        public DateTime SessionDateLocal { get; set; }
        public DateTime SessionDateUTC { get; set; }
        public DateTime TradeDate { get; set; }
        public int MemberId { get; set; }
        public Tier Tier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Location Location { get; set; }
        public Action Action { get; set; }
        public bool isGuest { get; set; }
        public bool IsDoorSwipe { get; set; }

    }
}
