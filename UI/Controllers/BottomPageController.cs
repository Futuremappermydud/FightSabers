﻿using System.Collections.Generic;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.MenuButtons;
using BeatSaberMarkupLanguage.Parser;
using FightSabers.UI.FlowCoordinators;
using UnityEngine.UI;

namespace FightSabers.UI.Controllers
{
    internal class BottomPageController : FightSabersViewController
    {
        public override string ResourceName    => "FightSabers.UI.Views.BottomPageView.bsml";
        public override string ContentFilePath => "C:/Users/Owens/Documents/GitHub/FightSabershop/UI/Views/BottomPageView.bsml";

        [UIParams] private BSMLParserParams parserParams;

        [UIAction("quests-page-act")]
        private void QuestsPageClicked()
        {
            flowCoordinatorOwner.ActivatePage(FightSabersFlowCoordinator.PageStatus.Quests);
        }
        [UIAction("skills-page-act")]
        private void SkillsPageClicked()
        {
            flowCoordinatorOwner.ActivatePage(FightSabersFlowCoordinator.PageStatus.Skills);
        }
        [UIAction("settings-page-act")]
        private void SettingsPageClicked()
        {
            flowCoordinatorOwner.ActivatePage(FightSabersFlowCoordinator.PageStatus.Settings);
        }
        [UIAction("home-page-act")]
        private void HomePageClicked()
        {
            flowCoordinatorOwner.ActivatePage(FightSabersFlowCoordinator.PageStatus.Home);
        }
        [UIAction("profile-page-act")]
        private void ProfilePageClicked()
        {
            flowCoordinatorOwner.ActivatePage(FightSabersFlowCoordinator.PageStatus.Profile);
        }

        [UIAction("stats-page-act")]
        private void StatsPageClicked()
        {
            flowCoordinatorOwner.ActivatePage(FightSabersFlowCoordinator.PageStatus.Statistics);
        }
        [UIAction("shop-page-act")]
        private void ShopPageClicked()
        {
            flowCoordinatorOwner.ActivatePage(FightSabersFlowCoordinator.PageStatus.Shop);
        }
    }
}