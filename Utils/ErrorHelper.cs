using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Utils
{
    public static class ErrorHelper
    {

        private static List<ErrorModel> GetSettings()
        {
            var filename = "errors.json";
            var path = $"{System.IO.Directory.GetCurrentDirectory()}/{filename}";
            return JsonConvert.DeserializeObject<List<ErrorModel>>(System.IO.File.ReadAllText(path));
        }

        public static ErrorModel GetError(int code)
        {
            return GetSettings().FirstOrDefault(x => x.Code == code);
        }
    }
}
