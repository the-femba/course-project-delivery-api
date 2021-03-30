using Flx.Delivery.Application.Utils;
using System.Linq;
using Xunit;

namespace Flx.Delivery.Application.Tests.Tests
{
    public class StringUtilTest
    {
        [Fact]
        public void GenerateString_WithLength17_IsLength17()
        {
            var generatedString = StringUtil.GenerateString(length: 17);

            Assert.True(generatedString.Length == 17);
        }

        [Fact]
        public void GenerateString_WithMask_IsOnlyMaskSymbols()
        {
            var mask = "123";

            var generatedString = StringUtil.GenerateString(mask: mask);

            Assert.True(!generatedString.Any(e => !mask.Contains(e)));
        }
    }
}
