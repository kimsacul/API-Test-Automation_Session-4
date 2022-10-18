using ServiceReference1;

namespace API_Test_Automation_Session_4
{
    [TestClass]
    public class SoapTests
    {
        //Global Variable

        private static CountryInfoServiceSoapTypeClient? countryInfoServiceSoapTypeClient = null;

        [TestInitialize]
        public void TestInit()
        {
            countryInfoServiceSoapTypeClient = new CountryInfoServiceSoapTypeClient(CountryInfoServiceSoapTypeClient.EndpointConfiguration.CountryInfoServiceSoap);
        }

        [TestMethod]
        public void AscOrderCountryCode()
        {
            // Create a test method to validate the return of ‘ListOfCountryNamesByCode()’ API is by Ascending Order of Country Code
            var countryCodes = countryInfoServiceSoapTypeClient.ListOfCountryNamesByCode();
            var sorted = countryCodes.OrderBy(a => a.sISOCode);
            Assert.IsTrue(countryCodes.SequenceEqual(sorted));
        }

        [TestMethod]
        public void InvalidCountry()
        {
            // Create a test method to validate the return of ‘ListOfCountryNamesByCode()’ API is by Ascending Order of Country Code
            string countryISOCode = "1000";
            var countryName = countryInfoServiceSoapTypeClient.CountryName(countryISOCode);
            Assert.AreEqual(countryName, "Country not found in the database");
        }
        [TestMethod]
        public void FindLastCountry()
        {
            // Create a test method to validate the return of ‘ListOfCountryNamesByCode()’ API is by Ascending Order of Country Code
            var countryCodes = countryInfoServiceSoapTypeClient.ListOfCountryNamesByCode();

            int x = countryCodes.Count();
            var lastCountryCodeByName = countryCodes[x - 1].sName;
            var countryName = countryInfoServiceSoapTypeClient.CountryName(countryCodes[x - 1].sISOCode);
            Assert.AreEqual(lastCountryCodeByName,countryName);
        }
    }
}