using MemberClaimsCoreService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberClaimsCoreService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberClaims : ControllerBase
    {
        private readonly DatabaseContext _context;
       
        public MemberClaims(DatabaseContext context)
        {
            _context = context;

        }

        [HttpGet]
        // GET: api/memberclaims/?date=2020-11-11T00:00:00
        public IActionResult GetMemberClaimsByDate(DateTime date)
        {
            var members = _context.GetMembers();
            var claims = _context.GetClaims();
            var results = from m in members
                          join c in claims on m.MemberID equals c.MemberID 
                          where c.ClaimDate <= date
                          select new MemberVM
                          {
                              MemberID = m.MemberID,
                              EnrollmentDate = m.EnrollmentDate,
                              FirstName = m.FirstName,
                              LastName = m.LastName,
                              Claims = (from c in claims
                                        where m.MemberID == c.MemberID
                                        select new ClaimVM
                                        {
                                            MemberID = c.MemberID,
                                            ClaimDate = c.ClaimDate,
                                            ClaimAmount = c.ClaimAmount
                                        }).ToList()
                          };

            return Ok(results);
        }
    }
}
