using System;
using TechTalk.SpecFlow;

namespace AvailableProductsServiceTests.StepDefinitions
{
    [Binding]
    public class SearchContractsStepDefinitions
    {
        [Given(@"the supplied reference data")]
        public void GivenTheSuppliedReferenceData()
        {
            throw new PendingStepException();
        }

        [When(@"user perform search by ITunes (.*)(.*)")]
        public void WhenUserPerformSearchByITunes(Decimal p0, int p1)
        {
            throw new PendingStepException();
        }

        [Then(@"the output should be")]
        public void ThenTheOutputShouldBe(Table table)
        {
            throw new PendingStepException();
        }
    }
}
