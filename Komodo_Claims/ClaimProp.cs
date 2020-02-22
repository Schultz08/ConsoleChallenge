using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Claims
{
    public enum ClaimType { Car, Home, Theft}
    public class ClaimProp
    {
        public ClaimProp() { }

        public ClaimProp(int claimId, ClaimType claimType, string claimDescription, string claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimId = claimId;
            ClaimType = claimType;
            ClaimDescription = claimDescription;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
   
        }
        //Claim ClaimID
        public int ClaimId { get; set; }
        //ClaimType
        public ClaimType ClaimType { get; set; }
        //Description
        public string ClaimDescription { get; set; }
        //ClaimAmount
        public string ClaimAmount { get; set; }
        //DateOfIncident
        public DateTime DateOfIncident { get; set; }

        public DateTime DateOfClaim { get; set; }
        //DateOfClaim
        public bool IsValid 
        { 
            get 
            { 
                if ((DateOfClaim - DateOfIncident).TotalDays <= 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } 
        }
        //IsValid
    }

    //A ClaimType could be the following:
    //Car
    //Home
    //Theft
}
