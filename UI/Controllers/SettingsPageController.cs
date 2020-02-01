using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Parser;
using BeatSaberMarkupLanguage.ViewControllers;
using FightSabers.UI.FlowCoordinators;

namespace FightSabers.UI.Controllers
{
    internal class SettingsPageController : FightSabersViewController
    {
        public override string ResourceName => "FightSabers.UI.Views.SettingsPageView.bsml";
        public override string ContentFilePath => "C:/Users/Owens/Documents/GitHub/FightSabershop/UI/Views/SettingsPageView.bsml";

        [UIParams]
        private BSMLParserParams parserParams;

        [UIAction("home-page-act")]
        private void HomePageClicked()
        {
            flowCoordinatorOwner.ActivatePage(FightSabersFlowCoordinator.PageStatus.Home);
        }
    }
}
