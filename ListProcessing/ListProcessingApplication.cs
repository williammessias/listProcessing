using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ListProcessing
{
    public  class ListProcessApllication
    {

        public static void Main()
        {



        }

        public async Task<int?> GetOutlier(int[] array)
        {

            if (array.Length < 3)
                return null;

            for (int item = 0; item < array.Length; item++)
            {
                // if the sum of the first and last position is odd, it means that one of them is the outlier.
                if ((array[item] + array[array.Length - item - 1]) % 2 != 0)
                {
                    if ((array[item] + array[item + 1]) % 2 != 0)
                    {
                        return array[item];
                    }
                    else
                    {
                        return array[array.Length - item - 1];
                    }
                }

                if (((array.Length - item) - item == 3)
                    && item + (array.Length - item )  == array.Length
                    && ((array[item] + array[item + 1]) % 2 != 0))
                {
                    return array[item + 1];
                }


            }
            return null;

        }

        public async Task<List<object>> GetIntegersFromList(List<object> list)
        {

            if (list.Count == 0)
               return list;

            var regex = new Regex("^[0-9]+$");

            return list.Where(x => regex.IsMatch(x.ToString())).ToList();
        }


        public async Task<string> FormatWords(string[] list)
        {
            if (list.Length == 0)
                return string.Empty;


            var listFiltered = list.Where(x => !String.IsNullOrEmpty(x)).ToArray();

            StringBuilder builder = new StringBuilder();
             
            for (int item = 0; item < listFiltered.Length ; item++)
            {
                builder.Append(listFiltered[item]);

                if(item > listFiltered.Length - 3 && item < listFiltered.Length - 1)
                {
                    builder.Append(" and ");
                }
                else if(item < listFiltered.Length - 1)
                {
                    builder.Append(", ");
                }
            }

            return builder.ToString();
        }




    }
}
