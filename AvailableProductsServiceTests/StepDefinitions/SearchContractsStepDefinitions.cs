using System;
using System.Xml;
using TechTalk.SpecFlow;

namespace AvailableProductsServiceTests.StepDefinitions
{
    [Binding]
    public class SearchContractsStepDefinitions
    {
        List<String> MusicContracts = new List<String>();
        List<String> Results = new List<String>();

        [Given(@"the supplied reference data")]
        public void GivenTheSuppliedReferenceData()
        {
            var directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var path = System.IO.Path.Combine(directory, "MusicContracts.txt");
            MusicContracts = File.ReadAllLines(path).ToList();
        }

        [When(@"user perform search by YouTube ""([^""]*)""")]
        public void WhenUserPerformSearchByYouTube(string date)
        {
            Results = Search.searchYoutube(date, MusicContracts).ToList();
        }

        [Then(@"the output should be")]
        public void ThenTheOutputShouldBe(Table table)
        {
            Assert.Equal(table.RowCount, Results.Count);
        }

        [When(@"user perform search by ITunes ""([^""]*)""")]
        public void WhenUserPerformSearchByITunes(string date)
        {
            Results = Search.searchITunes(date, MusicContracts).ToList();
        }

    }
}
