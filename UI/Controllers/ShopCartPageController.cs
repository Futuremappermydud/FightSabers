using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components;
using BeatSaberMarkupLanguage.Parser;

namespace FightSabers.UI.Controllers
{
    internal class ShopCartPageController : FightSabersViewController
    {
        public override string ResourceName => "FightSabers.UI.Views.ShopCartPageView.bsml";
        public override string ContentFilePath => "C:/Users/Owen/Documents/GitHub/FightSabershop/UI/Views/ShopCartPageView.bsml";


        [UIParams]
        private BSMLParserParams parserParams;



    }
}
