namespace FlightSearchEngine.Utilities
{
    public static class QueryStringUtilities
    {

        public static Dictionary<string, string> CastQueryFilterToDictionary(string queryFilter)
        {

            var queryStringDictionary = new Dictionary<string, string>();

            var listOfStrings = new List<string>();

            var splitedQueryFilter = queryFilter.Split("&");

            foreach (var item in splitedQueryFilter)
            {
                var singleQueryKeyValue = item.Split("=");

                queryStringDictionary.Add(key: singleQueryKeyValue[0], value: singleQueryKeyValue[1]);
            }

            return queryStringDictionary;

        }

        public static IEnumerable<KeyValuePair<string, string>> FilterOutNullValuePairs(Dictionary<string, string> dictionary)
        {

            return dictionary.Where(v => v.Value.Length > 0);

        }

        public static string GetQueryString(IEnumerable<KeyValuePair<string, string>> keyValuePairs)
        {
            var listofStrings = new List<string>();

            foreach (var item in keyValuePairs)
            {
                listofStrings.Add(String.Join("=", item.Key, item.Value));
            }

            return String.Join("&", listofStrings);

        }
    }
}
