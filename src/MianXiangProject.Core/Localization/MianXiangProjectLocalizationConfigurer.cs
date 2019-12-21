using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace MianXiangProject.Localization
{
    public static class MianXiangProjectLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(MianXiangProjectConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(MianXiangProjectLocalizationConfigurer).GetAssembly(),
                        "MianXiangProject.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
