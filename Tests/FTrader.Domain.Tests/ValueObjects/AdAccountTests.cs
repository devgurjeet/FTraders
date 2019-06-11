using FTraders.Domain.Exceptions;
using FTraders.Domain.ValueObjects;
using Xunit;

namespace FTrader.Domain.Tests.ValueObjects
{
    public class AdAccountTests
    {
        [Fact]
        public void ShouldHaveCorrectDomainAndName()
        {
            var account = AdAccount.For("FS\\Gurjeet");

            Assert.Equal("FS", account.Domain);
            Assert.Equal("Gurjeet", account.Name);
        }

        [Fact]
        public void ToStringReturnsCorrectFormat()
        {
            const string value = "FS\\Gurjeet";

            var account = AdAccount.For(value);

            Assert.Equal(value, account.ToString());
        }

        [Fact]
        public void ImplicitConversionToStringResultsInCorrectString()
        {
            const string value = "FS\\Gurjeet";

            var account = AdAccount.For(value);

            string result = account;

            Assert.Equal(value, result);
        }

        [Fact]
        public void ExplicitConversionFromStringSetsDomainAndName()
        {
            var account = (AdAccount)"FS\\Gurjeet";

            Assert.Equal("FS", account.Domain);
            Assert.Equal("Gurjeet", account.Name);
        }

        [Fact]
        public void ShouldThrowAdAccountInvalidExceptionForInvalidAdAccount()
        {
            Assert.Throws<AdAccountInvalidException>(() => (AdAccount)"FSGurjeet");
        }
    }
}
