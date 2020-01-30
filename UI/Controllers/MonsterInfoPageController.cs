using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Parser;

namespace FightSabers.UI.Controllers
{
    internal class MonsterInfoPageController : FightSabersViewController
    {
        public override string ResourceName => "FightSabers.UI.Views.MonsterInfoPageView.bsml";
        public override string ContentFilePath => "C:/Users/Owens/Documents/GitHub/FightSabershop/UI/Views/MonsterInfoPageView.bsml";

        [UIParams]
        private BSMLParserParams parserParams;

        
    }
}
