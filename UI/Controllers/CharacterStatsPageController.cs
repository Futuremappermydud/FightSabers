﻿using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Parser;

namespace FightSabers.UI.Controllers
{
    internal class CharacterStatsPageController : FightSabersViewController
    {
        public override string ResourceName => "FightSabers.UI.Views.CharacterStatsPageView.bsml";
        public override string ContentFilePath => "C:/Users/Owen/Documents/GitHub/FightSabershop/UI/Views/CharacterStatsPageView.bsml";

        [UIParams]
        private BSMLParserParams parserParams;
    }
}
