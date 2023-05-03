using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Newtonsoft.Json;
using CommunityToolkit.Mvvm.ComponentModel;
using System.IO;

namespace YoHoLauncher.Components
{
    public partial class Configuration : ObservableObject
    {
        [ObservableProperty]
        [JsonIgnore]
        private string currentLanguage;
    }

    public partial class Configuration : ObservableObject
    {
        public static Configuration Load()
        {
            var file = new FileInfo("Configurations.json");

            if (!file.Exists)
            {
                var defaultData = Default();
                File.WriteAllText(file.FullName, JsonConvert.SerializeObject(defaultData, Formatting.Indented));
                return defaultData;
            }

            return JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(file.FullName));
        }

        public static Configuration Default()
        {
            return new Configuration
            {
                CurrentLanguage = "en-US",
            };
        }
    }
}
