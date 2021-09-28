using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace TelephoneDirectory.Localization
{
    public static class TelephoneDirectoryLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(TelephoneDirectoryConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(TelephoneDirectoryLocalizationConfigurer).GetAssembly(),
                        "TelephoneDirectory.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
