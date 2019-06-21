using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claim_Classes
{
    public class ClaimRepository
    {
        private Queue<Claim> _claimQueue = new Queue<Claim>();        

        public Queue<Claim> ShowAllClaims()
        {
            return _claimQueue;
        }
        public void AddClaimToQueue(Claim newClam)
        {
            _claimQueue.Enqueue(newClam);
        }

        public Claim DealWithClaim()
        {
           return _claimQueue.Peek();            
        }

        public void DequeueClaim()
        {
            _claimQueue.Dequeue();            
        }           
    }
}
