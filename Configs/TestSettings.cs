using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c__basic_SD5858_VoThiBeThi_section1.Configs
{
    public class LoginData
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class TestSettings
    {
        public string BaseUrl { get; set; }
        public string LoginUrl { get; set; }
        public string ProductsUrl { get; set; }

        public LoginData ValidLogin { get; set; }
        public LoginData InvalidLogin { get; set; }

        public static TestSettings LoadSettings()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configs", "TestData.json");
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<TestSettings>(json);
        }
    }
}
