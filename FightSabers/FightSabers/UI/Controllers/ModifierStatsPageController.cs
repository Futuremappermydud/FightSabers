using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Parser;

namespace FightSabers.UI.Controllers
{
    internal class ModifierStatsPageController : FightSabersViewController
    {
        public override string ResourceName => "FightSabers.UI.Views.ModifierStatsPageView.bsml";
        public override string ContentFilePath => "C:/Users/Owens/Documents/GitHub/FightSabersshop/FightSabers/FightSabers/UI/Views/ModifierStatsPageView.bsml";

        [UIParams]
        private BSMLParserParams parserParams;
    }
}
