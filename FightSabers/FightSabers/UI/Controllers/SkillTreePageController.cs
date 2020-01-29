﻿using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Parser;
using BeatSaberMarkupLanguage.ViewControllers;

namespace FightSabers.UI.Controllers
{
    internal class SkillTreePageController : FightSabersViewController
    {
        public override string ResourceName => "FightSabers.UI.Views.SkillTreePageView.bsml";
        public override string ContentFilePath => "C:/Users/Owens/Documents/GitHub/FightSabersshop/FightSabers/FightSabers/UI/Views/SkillTreePageView.bsml";

        [UIParams]
        private BSMLParserParams parserParams;
    }
}
