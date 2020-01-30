using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Parser;
using BeatSaberMarkupLanguage.ViewControllers;

namespace FightSabers.UI.Controllers
{
    internal class SkillTreeAttackPageController : FightSabersViewController
    {
        public override string ResourceName => "FightSabers.UI.Views.SkillTreeAttackPageView.bsml";
        public override string ContentFilePath => "C:/Users/Owen/Documents/GitHub/FightSabershop/UI/Views/SkillTreeAttackPageView.bsml";

        [UIParams]
        private BSMLParserParams parserParams;
    }
}
