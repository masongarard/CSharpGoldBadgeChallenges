using System;
using System.Collections.Generic;
using _02_Claim_Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_Method_Tests
{
    [TestClass]
    public class ClaimTests
    {
        private ClaimRepository _claimRepo;
        private Claim _claim;
        private Queue<Claim> _claimQueue = new Queue<Claim>();      
        

        [TestInitialize]
        public void Arrange()
        {
            _claimRepo = new ClaimRepository();
            _claim = new Claim(4d,ClaimType.Car,"It was too lit",420.69m, new DateTime(2019, 04, 20), new DateTime(2019,04,20), true);


        }        
        [TestMethod]
        public void AddClaimToQueueTest()
        {
            _claimQueue.Enqueue(_claim);
            int expectedClaimQueueCount = 1;
            int actualClaimQueueCount= _claimQueue.Count;

            Assert.AreEqual(expectedClaimQueueCount, actualClaimQueueCount);
        }
        [TestMethod]
        public void DealWithClaimTest()
        {
            _claimRepo.AddClaimToQueue(_claim);
            _claimRepo.AddClaimToQueue(_claim);

            Claim expectedClaim = _claimRepo.DealWithClaim();
            Claim actualClaim = _claim;
            Assert.AreEqual(expectedClaim, actualClaim);
        }

        [TestMethod]
        public void DequeueClaimTest()
        {
            _claimQueue.Enqueue(_claim);
            _claimQueue.Enqueue(_claim);
            _claimQueue.Dequeue();
            int expectedClaimQueueCount = 1;
            int actualClaimQueueCount = _claimQueue.Count;

            Assert.AreEqual(expectedClaimQueueCount, actualClaimQueueCount);            
        }
    }
}
