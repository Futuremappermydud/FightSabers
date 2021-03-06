﻿using BeatSaberMarkupLanguage.ViewControllers;
using FightSabers.UI.FlowCoordinators;

namespace FightSabers.UI.Controllers
{
    internal abstract class FightSabersViewController : HotReloadableViewController
    {
        public FightSabersFlowCoordinator flowCoordinatorOwner;
    }
}