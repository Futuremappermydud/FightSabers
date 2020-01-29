using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Parser;
using BeatSaberMarkupLanguage.ViewControllers;

namespace FightSabers.UI.Controllers
{
    internal class ShopPageController : FightSabersViewController
    {
        public override string ResourceName => "FightSabers.UI.Views.ShopPageView.bsml";
        public override string ContentFilePath => "C:/Users/Owens/Documents/GitHub/FightSabersshop/FightSabers/FightSabers/UI/Views/ShopPageView.bsml";

        #region Properties

        [UIParams]
        private BSMLParserParams parserParams;

        private string _modStatus = "Disable";
        private string _one;

        [UIAction("ItemOne")]
        public string one
        {
            get { return _one; }
            private set
            {
                _one = value;
                NotifyPropertyChanged();
            }
        }


        #endregion






    }
}
