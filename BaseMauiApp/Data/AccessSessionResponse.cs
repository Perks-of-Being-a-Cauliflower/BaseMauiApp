using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseMauiApp.Data
{
    [Serializable]
    public class AccessSessionResponse
    {
        public VisitorGuestLog Visitor { get; set; }

        public virtual IEnumerable<VisitorGuestLog> Guests { get; set; } = new List<VisitorGuestLog>();

    }
}
