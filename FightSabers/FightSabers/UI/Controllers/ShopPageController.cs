using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Parser;

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
        [UIValue("switch-plugin-btn-status")]
        public string modStatus
        {
            get { return _modStatus; }
            private set
            {
                _modStatus = value;
                NotifyPropertyChanged();
            }
        }




        private string _versionText = "Version 0.0.0";
        [UIValue("version-text")]
        public string versionText
        {
            get { return _versionText; }
            private set
            {
                _versionText = value;
                NotifyPropertyChanged();
            }
        }

        #endregion






    }
}
