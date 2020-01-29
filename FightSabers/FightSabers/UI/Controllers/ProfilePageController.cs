﻿using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Parser;

namespace FightSabers.UI.Controllers
{
    internal class ProfilePageController : FightSabersViewController
    {
        public override string ResourceName => "FightSabers.UI.Views.QuestPickerPageView.bsml";
        public override string ContentFilePath => "C:/Users/Owens/Documents/GitHub/FightSabersshop/FightSabers/FightSabers/UI/Views/QuestPickerPageView.bsml";

        [UIParams]
        private BSMLParserParams parserParams;
    }
}
