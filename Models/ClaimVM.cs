using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberClaimsCoreService.Models
{
    public class ClaimVM
    {
        public int MemberID { get; set; }
        public DateTime ClaimDate { get; set; }
        public float ClaimAmount { get; set; }

    }
}
