
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ListProcessing.Tests
{
    public class ListProcessApplicationTest
    {
       
        [InlineData(new int[] { 1, 12, 2, 6, 4, 8, 12, 24, 22, 18, 16, 84, 1520, 2420 },1)]
        [InlineData(new int[] { 12, 3, 5, 1, 7, 9, 11, 13, 19, 21, 25, 27, 29 }, 12)]
        [InlineData(new int[] { 99, 2, 5}, 2)]
        [InlineData(new int[] { 2,99, 5 }, 2)]
        [InlineData(new int[] { 2, 4, 5 }, 5)]
        [Trait("GetOutlier", "return the outlier")]
        [Theory]
        public async Task GetOutlier_ListProcess_Apllication_Return_The_Outlier(int[] arrayTest, int correctOutlier)
        {

            var listTest = new ListProcessApllication();

            var result = await listTest.GetOutlier(arrayTest);

            Assert.Equal(correctOutlier, result);
        }


        [Trait("GetOutlier", "returns null because the array is less than 3")]
        [Fact(DisplayName = "Returns null")]
        public async Task GetOutlier_ListProcess_Apllication_array_Less_Than_3()
        {
            var arrayTest = new int[] { 12, 3};

            var listTest = new ListProcessApllication();

            var result = await listTest.GetOutlier(arrayTest);

            Assert.Null(result);
        }

        [InlineData(new int[] { 44, 12, 2, 6, 4, 8, 12, 24, 22, 18, 16, 84, 1520, 2420 })]
        [InlineData(new int[] { 55, 3, 5, 1, 7, 9, 11, 13, 19, 21, 25, 27, 29 })]
        [InlineData(new int[] { 99, 93, 5 })]
        [InlineData(new int[] { 79, 99, 5 })]
        [InlineData(new int[] { 2, 4, 1444 })]
        [Trait("GetOutlier", "Return null - outlier not informed")]
        [Theory]
        public async Task GetOutlier_ListProcess_Apllication_array_outlier_not_informed_array(int[] arrayTest)
        {

            var listTest = new ListProcessApllication();

            var result = await listTest.GetOutlier(arrayTest);

            Assert.Null(result);
        }


        [Trait("GetIntegersFromList", "Return null - Empty list")]
        [Fact]
        public async Task GetIntegersFromList_Empty()
        {
            var listTest = new ListProcessApllication();

            var result = await listTest.GetIntegersFromList(new List<object>());

            Assert.Empty(result);
        }


        [Trait("GetIntegersFromList", "Return only integers")]
        [Fact]
        public async Task GetIntegersFromList_Return_Only_Integers()
        {
            var correctList = new List<object>() { 1, "banana", "Test"};

            var listTest = new ListProcessApllication();

            var result = await listTest.GetIntegersFromList(correctList);

            Assert.Single(result);

            Assert.Equal(1, result.FirstOrDefault());
        }



        [Trait("FormatWords", "return empty string")]
        [Fact]
        public async Task FormatWords_Return_Empty_String()
        {
            var stringList = new string[]{};

            var listTest = new ListProcessApllication();

            var result = await listTest.FormatWords(stringList);

            Assert.Empty(result);
        }

        [Theory]
        [InlineData(new string[] { "ninja", "samurai", "ronin" },"ninja, samurai and ronin")]
        [InlineData(new string[] { "ninja", "", "ronin" }, "ninja and ronin")]
        [Trait("FormatWords", "returns formatted string")]
        public async Task FormatWords_Returns_Formatted_String (string[] stringList, string correctResult )
        {
            var listTest = new ListProcessApllication();

            var result = await listTest.FormatWords(stringList);

            Assert.Equal(correctResult, result);
        }


    }

}
