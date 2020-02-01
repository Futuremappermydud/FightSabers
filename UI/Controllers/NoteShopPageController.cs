using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Parser;
using BeatSaberMarkupLanguage.ViewControllers;

namespace FightSabers.UI.Controllers
{
    internal class NoteShopPageController : FightSabersViewController
    {
        public override string ResourceName => "FightSabers.UI.Views.NoteShopPageView.bsml";
        public override string ContentFilePath => "C:/Users/Owens/Documents/GitHub/FightSabershop/UI/Views/NoteShopPageView.bsml";

        #region Properties

        [UIParams]
        private BSMLParserParams parserParams;

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
