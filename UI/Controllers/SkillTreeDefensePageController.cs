using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Parser;
using BeatSaberMarkupLanguage.ViewControllers;

namespace FightSabers.UI.Controllers
{
    internal class SkillTreeDefensePageController : FightSabersViewController
    {
        public override string ResourceName => "FightSabers.UI.Views.SkillTreeDefensePageView.bsml";
        public override string ContentFilePath => "C:/Users/Owen/Documents/GitHub/FightSabershop/UI/Views/SkillTreeDefensePageView.bsml";

        [UIParams]
        private BSMLParserParams parserParams;
    }
}
