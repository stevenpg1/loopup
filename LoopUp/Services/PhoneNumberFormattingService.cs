using System;
using System.Collections.Generic;
using System.Text;
using LoopUp.Data;
using LoopUp.Model;

namespace LoopUp.Services
{
    public class PhoneNumberFormattingService
    {
        private IRepository _repository;

        public PhoneNumberFormattingService(IRepository repository)
        {
            _repository = repository;
        }

        public List<UKFormatter> UKPhoneNumberFormats()
        {
            return _repository.GetUKFormats();
        }

        public string FormatPhoneNumber(string unformattedPhoneNumber)
        {
            unformattedPhoneNumber = ReplaceInternationalPrefixWithZero(unformattedPhoneNumber);

            if (unformattedPhoneNumber.Substring(0,1) == "+")
            {
                //not a uk phone number
                return unformattedPhoneNumber;
            }
            else
            {
                string matchedFormat = matchUncontigousFormat(unformattedPhoneNumber);

                if (matchedFormat == string.Empty) matchedFormat = GetMatchingFormat(unformattedPhoneNumber);

                return ReplaceWildCardsWithNumbers(matchedFormat, unformattedPhoneNumber);
            }
        }

        private string ReplaceInternationalPrefixWithZero(string unformattedPhoneNumber)
        {
            if (unformattedPhoneNumber.Substring(0, 3) == "+44") return unformattedPhoneNumber.Replace("+44", "0");

            return unformattedPhoneNumber;
        }

        private string matchUncontigousFormat(string unformattedPhoneNumber)
        {
            if (unformattedPhoneNumber.Substring(0, 2) == "01" && unformattedPhoneNumber.Substring(3, 1) == "1") return "01#1 ### ####";

            return string.Empty;
        }

        private string GetMatchingFormat(string unformattedPhoneNumber)
        {
            var ukPhoneNumberFormats = UKPhoneNumberFormats();
            //Do not return matched format until all formats have been scrutinized. because some later formats replace earlier ones.
            string formatToReturn = string.Empty;
            foreach (var ukFormat in ukPhoneNumberFormats)
            {
                if (unformattedPhoneNumber.Substring(0, ukFormat.Matcher.Length) == ukFormat.Matcher && unformattedPhoneNumber.Length == ukFormat.Length)
                {
                    formatToReturn = ukFormat.Format;
                }
            }

            return formatToReturn;
        }

        private string ReplaceWildCardsWithNumbers(string matchedFormat, string unformattedNumber)
        {
            int numberOfNonSpaceCharacters = 0;
            var formattedNumber = new StringBuilder();
            foreach (char charInString in matchedFormat)
            {
                if (charInString != ' ')
                {
                    numberOfNonSpaceCharacters++;
                    formattedNumber.Append(unformattedNumber.Substring(numberOfNonSpaceCharacters - 1, 1));
                }
                else
                {
                    formattedNumber.Append(' ');
                }
            }

            return formattedNumber.ToString();
        }


    }
}
