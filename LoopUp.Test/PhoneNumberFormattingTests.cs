using LoopUp.Data;
using LoopUp.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoopUp.Test
{
    [TestClass]
    public class PhoneNumberFormattingTests
    {
        [TestMethod]
        public void WhenGiven44InternationalPrefixShouldReplaceThisWithZero()
        {
            var repository = new Repository();
            var formattingService = new PhoneNumberFormattingService(repository);
            string unformattedNumber = "+442012345678";
            
            var formattedNumber = formattingService.FormatPhoneNumber(unformattedNumber);

            Assert.AreEqual(formattedNumber.Substring(0, 1), "0");
        }

        [TestMethod]
        public void WhenGivenForeignIternationalPrefixShouldReturnNumberUnformatted()
        {
            var repository = new Repository();
            var formattingService = new PhoneNumberFormattingService(repository);
            string unformattedNumber = "+452012345678";

            var formattedNumber = formattingService.FormatPhoneNumber(unformattedNumber);

            Assert.AreEqual(formattedNumber, unformattedNumber);
        }

        [TestMethod]
        public void WhenGiven10CharNumberStarting01ShouldReturnWithAppropriateSpacing()
        {
            var repository = new Repository();
            var formattingService = new PhoneNumberFormattingService(repository);
            string unformattedNumber1 = "+44123456789";
            string unformattedNumber2 = "+44169775678";

            var formattedNumber1 = formattingService.FormatPhoneNumber(unformattedNumber1);
            var formattedNumber2 = formattingService.FormatPhoneNumber(unformattedNumber2);

            Assert.AreEqual(formattedNumber1, "01234 56789");
            Assert.AreEqual(formattedNumber2, "016977 5678");
        }

        [TestMethod]
        public void WhenGiven11CharNumberStarting01ShouldReturnWithAppropriateSpacing()
        {
            var repository = new Repository();
            var formattingService = new PhoneNumberFormattingService(repository);
            string unformattedNumber1 = "+441234567890";
            string unformattedNumber2 = "+441121231234";
            string unformattedNumber3 = "+441211231234";
            string unformattedNumber4 = "+441339712345";
            string unformattedNumber5 = "+441339812345";
            string unformattedNumber6 = "+441387312345";
            string unformattedNumber7 = "+441524212345";
            string unformattedNumber8 = "+441539412345";
            string unformattedNumber9 = "+441539512345";
            string unformattedNumber10 = "+441539612345";
            string unformattedNumber11 = "+441697312345";
            string unformattedNumber12 = "+441697412345";
            string unformattedNumber13 = "+441697712345";
            string unformattedNumber14 = "+441768312345";
            string unformattedNumber15 = "+441768412345";
            string unformattedNumber16 = "+441768712345";
            string unformattedNumber17 = "+441946712345";
            string unformattedNumber18 = "+441975512345";
            string unformattedNumber19 = "+441975612345";

            var formattedNumber1 = formattingService.FormatPhoneNumber(unformattedNumber1);
            var formattedNumber2 = formattingService.FormatPhoneNumber(unformattedNumber2);
            var formattedNumber3 = formattingService.FormatPhoneNumber(unformattedNumber3);
            var formattedNumber4 = formattingService.FormatPhoneNumber(unformattedNumber4);
            var formattedNumber5 = formattingService.FormatPhoneNumber(unformattedNumber5);
            var formattedNumber6 = formattingService.FormatPhoneNumber(unformattedNumber6);
            var formattedNumber7 = formattingService.FormatPhoneNumber(unformattedNumber7);
            var formattedNumber8 = formattingService.FormatPhoneNumber(unformattedNumber8);
            var formattedNumber9 = formattingService.FormatPhoneNumber(unformattedNumber9);
            var formattedNumber10 = formattingService.FormatPhoneNumber(unformattedNumber10);
            var formattedNumber11 = formattingService.FormatPhoneNumber(unformattedNumber11);
            var formattedNumber12 = formattingService.FormatPhoneNumber(unformattedNumber12);
            var formattedNumber13 = formattingService.FormatPhoneNumber(unformattedNumber13);
            var formattedNumber14 = formattingService.FormatPhoneNumber(unformattedNumber14);
            var formattedNumber15 = formattingService.FormatPhoneNumber(unformattedNumber15);
            var formattedNumber16 = formattingService.FormatPhoneNumber(unformattedNumber16);
            var formattedNumber17 = formattingService.FormatPhoneNumber(unformattedNumber17);
            var formattedNumber18 = formattingService.FormatPhoneNumber(unformattedNumber18);
            var formattedNumber19 = formattingService.FormatPhoneNumber(unformattedNumber19);

            Assert.AreEqual(formattedNumber1, "01234 567890");
            Assert.AreEqual(formattedNumber2, "0112 123 1234");
            Assert.AreEqual(formattedNumber3, "0121 123 1234");
            Assert.AreEqual(formattedNumber4, "013397 12345");
            Assert.AreEqual(formattedNumber5, "013398 12345");
            Assert.AreEqual(formattedNumber6, "013873 12345");
            Assert.AreEqual(formattedNumber7, "015242 12345");
            Assert.AreEqual(formattedNumber8, "015394 12345");
            Assert.AreEqual(formattedNumber9, "015395 12345");
            Assert.AreEqual(formattedNumber10, "015396 12345");
            Assert.AreEqual(formattedNumber11, "016973 12345");
            Assert.AreEqual(formattedNumber12, "016974 12345");
            Assert.AreEqual(formattedNumber13, "016977 12345");
            Assert.AreEqual(formattedNumber14, "017683 12345");
            Assert.AreEqual(formattedNumber15, "017684 12345");
            Assert.AreEqual(formattedNumber16, "017687 12345");
            Assert.AreEqual(formattedNumber17, "019467 12345");
            Assert.AreEqual(formattedNumber18, "019755 12345");
            Assert.AreEqual(formattedNumber19, "019756 12345");     
        }

        [TestMethod]
        public void WhenGiven11CharNumberStarting02ShouldReturnWithAppropriateSpacing()
        {
            var repository = new Repository();
            var formattingService = new PhoneNumberFormattingService(repository);
            string unformattedNumber1 = "+442112341234";
            
            var formattedNumber1 = formattingService.FormatPhoneNumber(unformattedNumber1);
            
            Assert.AreEqual(formattedNumber1, "021 1234 1234");
        }

        [TestMethod]
        public void WhenGiven11CharNumberStarting03ShouldReturnWithAppropriateSpacing()
        {
            var repository = new Repository();
            var formattingService = new PhoneNumberFormattingService(repository);
            string unformattedNumber1 = "+443121231234";

            var formattedNumber1 = formattingService.FormatPhoneNumber(unformattedNumber1);

            Assert.AreEqual(formattedNumber1, "0312 123 1234");
        }

        [TestMethod]
        public void WhenGiven11CharNumberStarting05ShouldReturnWithAppropriateSpacing()
        {
            var repository = new Repository();
            var formattingService = new PhoneNumberFormattingService(repository);
            string unformattedNumber1 = "+445123123456";

            var formattedNumber1 = formattingService.FormatPhoneNumber(unformattedNumber1);

            Assert.AreEqual(formattedNumber1, "05123 123456");
        }

        [TestMethod]
        public void WhenGiven11CharNumberStarting07ShouldReturnWithAppropriateSpacing()
        {
            var repository = new Repository();
            var formattingService = new PhoneNumberFormattingService(repository);
            string unformattedNumber1 = "+447123123456";

            var formattedNumber1 = formattingService.FormatPhoneNumber(unformattedNumber1);

            Assert.AreEqual(formattedNumber1, "07123 123456");
        }

        [TestMethod]
        public void WhenGiven10CharNumberStarting0800ShouldReturnWithAppropriateSpacing()
        {
            var repository = new Repository();
            var formattingService = new PhoneNumberFormattingService(repository);
            string unformattedNumber1 = "+44800123456";

            var formattedNumber1 = formattingService.FormatPhoneNumber(unformattedNumber1);

            Assert.AreEqual(formattedNumber1, "0800 123456");
        }

        [TestMethod]
        public void WhenGiven11CharNumberStarting08ShouldReturnWithAppropriateSpacing()
        {
            var repository = new Repository();
            var formattingService = new PhoneNumberFormattingService(repository);
            string unformattedNumber1 = "+448121231234";

            var formattedNumber1 = formattingService.FormatPhoneNumber(unformattedNumber1);

            Assert.AreEqual(formattedNumber1, "0812 123 1234");
        }

        [TestMethod]
        public void WhenGiven11CharNumberStarting09ShouldReturnWithAppropriateSpacing()
        {
            var repository = new Repository();
            var formattingService = new PhoneNumberFormattingService(repository);
            string unformattedNumber1 = "+449121231234";

            var formattedNumber1 = formattingService.FormatPhoneNumber(unformattedNumber1);

            Assert.AreEqual(formattedNumber1, "0912 123 1234");
        }
    }
}
