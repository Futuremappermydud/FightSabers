using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components;
using BeatSaberMarkupLanguage.Parser;
using BeatSaberMarkupLanguage.ViewControllers;

namespace FightSabers.UI.Controllers
{
    internal class SaberShopPageController : FightSabersViewController
    {
        public override string ResourceName => "FightSabers.UI.Views.SaberShopPageView.bsml";
        public override string ContentFilePath => "C:/Users/Owen/Documents/GitHub/FightSabershop/UI/Views/SaberShopPageView.bsml";

        #region Properties

        [UIParams]
        private BSMLParserParams parserParams;

        private string _one;

		[UIComponent("cartList")]
		public CustomListTableData customListTableData;

		

		#endregion






	}
}
