using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Parser;
using DocumentFormat.OpenXml.Drawing.Charts;
using HMUI;
using System;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

namespace FightSabers.UI.Controllers
{
    internal class ProfilePageController : FightSabersViewController
    {
        
      

        public override string ResourceName => "FightSabers.UI.Views.ProfilePageView.bsml";
        public override string ContentFilePath => "C:/Users/Owens/Documents/GitHub/FightSabershop/UI/Views/ProfilePageView.bsml";

        [UIParams]
        private BSMLParserParams parserParams;

        [UIComponent("img")] private RawImage img;
        protected override void DidActivate(bool firstActivation, ActivationType type)
        {
            
            var imgRectTransform = img.transform as RectTransform;
            imgRectTransform.sizeDelta = new Vector2(Width, imgRectTransform.sizeDelta.y);
            base.DidActivate(firstActivation, type);
            var tex = BS_Utils.Gameplay.GetUserInfo.GetUserAvatar();
            img.texture = tex;
            
            
        }


         public String _Name = BS_Utils.Gameplay.GetUserInfo.GetUserName();
        [UIValue("Name")]
        public String Name
        {
            get { return _Name; }
            private set
            {
                _Name = value;
                NotifyPropertyChanged();
            }
        } 
    }

}
