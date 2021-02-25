using CsvHelper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MemberClaimsCoreService.Models
{
    public class DatabaseContext : DbContext
    {
        public IEnumerable<MemberVM> GetMembers()
        {
            using (var reader = new StreamReader(".\\Files\\Member.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<MemberVM>();
                return records.ToList();
            }             
        }

        public IEnumerable<ClaimVM> GetClaims()
        {
            using (var reader = new StreamReader(".\\Files\\Claim.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                
                var records = csv.GetRecords<ClaimVM>();
                return records.ToList();
            }
        }
    }
}
