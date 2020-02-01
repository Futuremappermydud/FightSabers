using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Parser;
using BeatSaberMarkupLanguage.ViewControllers;
using FightSabers.UI.FlowCoordinators;
using TMPro;

namespace FightSabers.UI.Controllers
{
    internal class MainShopPageController : FightSabersViewController
    {
        public override string ResourceName => "FightSabers.UI.Views.MainShopPageView.bsml";
        public override string ContentFilePath => "C:/Users/Owens/Documents/GitHub/FightSabershop/UI/Views/MainShopPageView.bsml";

        #region Properties

        [UIParams]
        private BSMLParserParams parserParams;


        [UIComponent("note-button")]
        private TextMeshProUGUI text;

        [UIAction("plat-page-act")]
        private void PlatPageClicked()
        {
            flowCoordinatorOwner.ActivatePage(FightSabersFlowCoordinator.PageStatus.Platformshop);
        }
        [UIAction("saber-page-act")]
        private void SaberPageClicked()
        {
            flowCoordinatorOwner.ActivatePage(FightSabersFlowCoordinator.PageStatus.Sabershop);
        }
        [UIAction("note-page-act")]
        private void NotePageClicked()
        {
            flowCoordinatorOwner.ActivatePage(FightSabersFlowCoordinator.PageStatus.Noteshop);
        }
        [UIAction("note-hover")]
        private void NoteHover()
        {
            text.text = "Hey look, the text changed";
        }
        #endregion






    }
}
