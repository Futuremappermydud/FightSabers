using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Parser;

namespace FightSabers.UI.Controllers
{
    internal class ProfilePageController : FightSabersViewController
    {
        public override string ResourceName => "FightSabers.UI.Views.ProfilePageView.bsml";
        public override string ContentFilePath => "C:/Users/Owens/Documents/GitHub/FightSabershop/FightSabers/FightSabers/UI/Views/ProfilePageView.bsml";

        [UIParams]
        private BSMLParserParams parserParams;
    }
}
