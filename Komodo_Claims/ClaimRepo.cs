using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Claims
{
    public class ClaimRepo
    {
        List<ClaimProp> _claimDirectory = new List<ClaimProp>();
        Queue<ClaimProp> _claimQueue = new Queue<ClaimProp>();
        public bool AddClaimToDirectory(ClaimProp claim)
        {
            foreach(ClaimProp existingClaim in _claimDirectory)
            {
                if (existingClaim.ClaimId == claim.ClaimId)
                {
                    return false;
                }
            }
            _claimDirectory.Add(claim);
            return true;
        }

        public List<ClaimProp> ViewClaim()
        {
           return _claimDirectory;
        }

        public ClaimProp GetClaimById(int claim)
        {
            foreach(ClaimProp existingClaim in _claimDirectory)
            {
                if (existingClaim.ClaimId == claim)
                {
                    return existingClaim;
                }
            }
            return null;
        }

        public Queue<ClaimProp> MakeClaimQueue()
        {
            foreach( ClaimProp claimQueue in _claimDirectory)
            {
                _claimQueue.Enqueue(claimQueue);
            }
            return _claimQueue;
        }

        public Queue<ClaimProp> GetClaimQueue()
        {
            return _claimQueue;
        }

        

        public void AddClaim(ClaimProp claim)
        {
            _claimDirectory.Add(claim);
            _claimQueue.Enqueue(claim);
        }

        public void WriteQueue()
        {
            Queue<ClaimProp> claimQueue = _claimQueue;
            ClaimProp queueOne = _claimQueue.Peek();
            Console.WriteLine("{0,0}{1,10}{2,16}{3,21 }{4,20 }{5,20 }{6,15 }", "Claim ID", "Type", "Description", "Amount", "DateOfIncident", "DateOfClaim", "Is Valid");
            foreach(ClaimProp queue in claimQueue)
            {
               Console.WriteLine("{0,-14}{1,-9}{2,-25}{3,-13 }{4,-23 }{5,-18}{6,0 }",queue.ClaimId, queue.ClaimType, queue.ClaimDescription, queue.ClaimAmount,queue.DateOfIncident.ToString("MM/dd/yy"), queue.DateOfClaim.ToString("MM/dd/yy"), queue.IsValid);

            }
            Console.WriteLine("Current Claims.");
            Console.ReadKey();

        }


        public bool UpdateClaim(int claimId, ClaimProp newContent)
        {
            ClaimProp oldContent = GetClaimById(claimId);
            if (oldContent != null)
            {
                oldContent.ClaimId = newContent.ClaimId;
                oldContent.ClaimDescription = newContent.ClaimDescription;
                oldContent.ClaimType = newContent.ClaimType;
                oldContent.ClaimAmount = newContent.ClaimAmount;
                oldContent.DateOfClaim = newContent.DateOfClaim;
                oldContent.DateOfIncident = newContent.DateOfIncident;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteClaim(int item)
        {
            ClaimProp claim = GetClaimById(item);
            bool result = _claimDirectory.Remove(claim);
            return result;
        }


    }
}
