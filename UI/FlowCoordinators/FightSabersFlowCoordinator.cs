﻿using System;
using System.Collections.Generic;
using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.ViewControllers;
using FightSabers.UI.Controllers;
using HMUI;



namespace FightSabers.UI.FlowCoordinators
{
    internal class FightSabersFlowCoordinator : FlowCoordinator
    {


        public void Awake()
        {
         BeatSaberUI.CreateViewController<SaberPreviewPageController>();
            
        }
        public enum PageStatus
        {
            Home,
            Skills,
            Profile,
            Quests,
            Statistics,
            Shop,
            Contributors,
            Sabershop,
            Noteshop,
            Platformshop,
            Settings
        }

        public FlowCoordinator      oldCoordinator;
        public BottomPageController bottomController;

        public PageStatus CurrentPageStatus { get; private set; }

        protected override void DidActivate(bool firstActivation, ActivationType activationType)
        {
            if (activationType != ActivationType.AddedToHierarchy)
                return;
            CurrentPageStatus = PageStatus.Home;
            var homeController = BeatSaberUI.CreateViewController<HomePageController>();
            bottomController = BeatSaberUI.CreateViewController<BottomPageController>();
            bottomController.flowCoordinatorOwner = homeController.flowCoordinatorOwner = this;
            ProvideInitialViewControllers(homeController, null, null, bottomController);
        }

        public void ActivatePage(PageStatus status)
        {
            if (status == CurrentPageStatus) return;
            FightSabersViewController controller;
            switch (status)
            {
                case PageStatus.Home:
                    controller = BeatSaberUI.CreateViewController<HomePageController>();
                    ReplaceTopViewController(controller, null, false, ViewController.SlideAnimationDirection.Left);
                    SetLeftScreenViewController(null);
                    SetRightScreenViewController(null);
                    ProvideInitialViewControllers(controller, null, null, bottomController);
                    break;
                case PageStatus.Skills:
                    controller = BeatSaberUI.CreateViewController<SkillTreeAttackPageController>();
                    ReplaceTopViewController(controller, null, false, ViewController.SlideAnimationDirection.Left);
                    SetLeftScreenViewController(BeatSaberUI.CreateViewController<SkillTreeDefensePageController>(), false);
                    SetRightScreenViewController(BeatSaberUI.CreateViewController<SkillTreeOtherPageController>(), false);
                    ProvideInitialViewControllers(controller, null, null, bottomController);
                    break;
                case PageStatus.Profile:
                    controller = BeatSaberUI.CreateViewController<ProfilePageController>();
                    ReplaceTopViewController(controller, null, false, ViewController.SlideAnimationDirection.Left);
                    SetLeftScreenViewController(null);
                    SetRightScreenViewController(null);
                    ProvideInitialViewControllers(controller, null, null, bottomController);
                    break;
                case PageStatus.Quests:
                    controller = BeatSaberUI.CreateViewController<QuestPickerPageController>();
                    ReplaceTopViewController(controller, null, false, ViewController.SlideAnimationDirection.Right);
                    SetRightScreenViewController(null);
                    ProvideInitialViewControllers(controller, null, null, bottomController);
                    SetLeftScreenViewController(BeatSaberUI.CreateViewController<CurrentQuestPageController>(), false);
                    break;
                case PageStatus.Statistics:
                    controller = BeatSaberUI.CreateViewController<CharacterStatsPageController>();
                    ReplaceTopViewController(controller, null, false, ViewController.SlideAnimationDirection.Left);
                    ProvideInitialViewControllers(controller, null, null, bottomController);
                    SetLeftScreenViewController(BeatSaberUI.CreateViewController<MonsterInfoPageController>(), false);
                    SetRightScreenViewController(BeatSaberUI.CreateViewController<ModifierStatsPageController>(), false);
                    break;
                case PageStatus.Shop:
                    controller = BeatSaberUI.CreateViewController<MainShopPageController>();
                    ReplaceTopViewController(controller, null, false, ViewController.SlideAnimationDirection.Left);
                    SetLeftScreenViewController(null);
                    SetRightScreenViewController(null);
                    ProvideInitialViewControllers(controller, null, null, bottomController);
                    break;
                case PageStatus.Sabershop:
                    controller = BeatSaberUI.CreateViewController<SaberShopPageController>();
                    ReplaceTopViewController(controller, null, false, ViewController.SlideAnimationDirection.Left);
                    SetLeftScreenViewController(BeatSaberUI.CreateViewController<ShopCartPageController>(), false);
                    SetRightScreenViewController(BeatSaberUI.CreateViewController<SaberPreviewPageController>(), false);
                    ProvideInitialViewControllers(controller, null, null, bottomController);
                    break;
                case PageStatus.Noteshop:
                    controller = BeatSaberUI.CreateViewController<NoteShopPageController>();
                    ReplaceTopViewController(controller, null, false, ViewController.SlideAnimationDirection.Left);
                    SetLeftScreenViewController(BeatSaberUI.CreateViewController<ShopCartPageController>(), false);
                    SetRightScreenViewController(null);
                    ProvideInitialViewControllers(controller, null, null, bottomController);
                    break;
                case PageStatus.Platformshop:
                    controller = BeatSaberUI.CreateViewController<PlatformShopPageController>();
                    ReplaceTopViewController(controller, null, false, ViewController.SlideAnimationDirection.Left);
                    SetLeftScreenViewController(BeatSaberUI.CreateViewController<ShopCartPageController>(), false);
                    SetRightScreenViewController(null);
                    ProvideInitialViewControllers(controller, null, null, bottomController);
                    break;
                case PageStatus.Contributors:
                    controller = BeatSaberUI.CreateViewController<ContributorsPageController>();
                    ReplaceTopViewController(controller, null, false, ViewController.SlideAnimationDirection.Left);
                    SetLeftScreenViewController(null);
                    SetRightScreenViewController(null);
                    ProvideInitialViewControllers(controller, null, null, bottomController);
                    break;
                case PageStatus.Settings:
                    controller = BeatSaberUI.CreateViewController<SettingsPageController>();
                    ReplaceTopViewController(controller, null, false, ViewController.SlideAnimationDirection.Left);
                    SetLeftScreenViewController(null);
                    SetRightScreenViewController(null);
                    ProvideInitialViewControllers(controller, null, null, bottomController);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, null);
            }
            controller.flowCoordinatorOwner = this;
            CurrentPageStatus = status;
        }
    }
}