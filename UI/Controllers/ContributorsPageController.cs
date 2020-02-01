using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Parser;
using BeatSaberMarkupLanguage.ViewControllers;
using FightSabers.UI.FlowCoordinators;

namespace FightSabers.UI.Controllers
{
    internal class ContributorsPageController : FightSabersViewController
    {
        public override string ResourceName => "FightSabers.UI.Views.ContributorsPageView.bsml";
        public override string ContentFilePath => "C:/Users/Owens/Documents/GitHub/FightSabershop/UI/Views/ContributorsPageView.bsml";

        [UIParams]
        private BSMLParserParams parserParams;

        [UIAction("home-page-act")]
        private void HomePageClicked()
        {
            flowCoordinatorOwner.ActivatePage(FightSabersFlowCoordinator.PageStatus.Home);
        }
        [UIAction("donate-link-act")]
        private void OpenDonateLink()
        {
            System.Diagnostics.Process.Start("https://ko-fi.com/shoko84");
        }
    }
}
