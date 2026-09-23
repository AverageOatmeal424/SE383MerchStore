using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Storefront.Models;
using Storefront.Pages;
using System.Xml.Linq;
using Xunit;

namespace StorefrontUnitTest
{
    public class StorefrontUnitTest
    {
        private string FName;

        [Theory]
        [InlineData("John")]
        [InlineData(null)]
        public void TestUtilizeName(string fName)
        {
            String FName = fName;
            if (string.IsNullOrWhiteSpace(FName))
            {
                FName = "User";
            }
        }

        public MerchModel merch { get; set; }
        private readonly IConfiguration _configuration;

        [Fact]
        public void TestOnPost()
        {
            if (merch is null == false)
            {
                MerchDataAccessLayer factory = new
                MerchDataAccessLayer(_configuration);

                factory.Create(merch);
            }
        }
    }
}
