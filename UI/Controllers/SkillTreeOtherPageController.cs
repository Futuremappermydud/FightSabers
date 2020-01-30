using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Parser;
using BeatSaberMarkupLanguage.ViewControllers;

namespace FightSabers.UI.Controllers
{
    internal class SkillTreeOtherPageController : FightSabersViewController
    {
        public override string ResourceName => "FightSabers.UI.Views.SkillTreeOtherPageView.bsml";
        public override string ContentFilePath => "C:/Users/Owen/Documents/GitHub/FightSabershop/UI/Views/SkillTreeOtherPageView.bsml";

        [UIParams]
        private BSMLParserParams parserParams;
    }
}
