using System.Collections;
using System.Linq;
using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Parser;
using DigitalRuby.Tween;
using FightSabers.Core;
using FightSabers.Settings;
using FightSabers.UI.FlowCoordinators;
using FightSabers.Utilities;
using HMUI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;
using FightSabers;
using System;

namespace FightSabers.UI.Controllers
{
    internal class ProfilePageController : FightSabersViewController
    {



        public override string ResourceName => "FightSabers.UI.Views.ProfilePageView.bsml";
        public override string ContentFilePath => "C:/Users/Owens/Documents/GitHub/FightSabershop/UI/Views/ProfilePageView.bsml";

        [UIParams]
        private BSMLParserParams parserParams;

        public static OverlayViewController instance;

        [UIComponent("img")] private RawImage img;
        protected override void DidActivate(bool firstActivation, ActivationType type)
        {
            ulong userid = BS_Utils.Gameplay.GetUserInfo.GetUserID();
            base.DidActivate(firstActivation, type);
            var tex = BS_Utils.Gameplay.GetUserInfo.GetUserAvatar();
            img.texture = tex;
            var scale = img.transform.localScale;
            scale[1] *= -1;
            img.transform.localScale = scale;
            //Level text
            Level = $"Level {SaveDataManager.instance.SaveData.level}";
            //Current exp
            exp = $"0 / {ExperienceSystem.instance.TotalNeededExperienceForNextLevel}";

            //Coins
            Coins = GetNumbers($"Coins {SaveDataManager.instance.SaveData.Coins}");
            experienceContainerState = Plugin.config.Value.Enabled;
            Flownmonstercount = GetNumbers($"flownMonsterCount {SaveDataManager.instance.SaveData.flownMonsterCount}");
            killmonsters = GetNumbers($"killMonsterCount {SaveDataManager.instance.SaveData.killMonsterCount}");

            //ProgressBar
            var tx = Texture2D.whiteTexture;
            var sprite = Sprite.Create(tx, new Rect(0, 0, tx.width, tx.height), Vector2.one * 0.5f, 100, 1);
            _progressBgBarImage.sprite = sprite;
            _progressBgBarImage.color = new Color(0, 0, 0, 0.85f);
            _progressBarImage.sprite = sprite;
            _progressBarImage.type = Image.Type.Filled;
            _progressBarImage.fillAmount = 0f;
            _progressBarImage.fillMethod = Image.FillMethod.Horizontal;
            _progressBarImage.color = new Color32(0, 255, 0, 80);
            _progressBarImage.material = null;
        }

        private static string GetNumbers(string input)
        {
            return new string(input.Where(c => char.IsDigit(c)).ToArray());
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
        string _Coins;
        [UIValue("Coins")]

        public string Coins
        {
            get { return _Coins; }
            private set
            {
                _Coins = value;
                NotifyPropertyChanged();
            }
        }
        ulong _userid;
        [UIValue("userid")]

        public ulong userid
        {
            get { return _userid; }
            private set
            {
                _userid = value;
                NotifyPropertyChanged();
            }
        }
        string _monsterKillCount;
        [UIValue("killmonsters")]

        public string killmonsters
        {
            get { return _monsterKillCount; }
            private set
            {
                _monsterKillCount = value;
                NotifyPropertyChanged();
            }
        }string _Flownmonstercount;
        [UIValue("Flownmonstercount")]

        public string Flownmonstercount
        {
            get { return _Flownmonstercount; }
            private set
            {
                _Flownmonstercount = value;
                NotifyPropertyChanged();
            }
        }

        string _exp;
        [UIValue("experienceContainerState")]

        public string exp
        {
            get { return _exp; }
            private set
            {
                _exp = value;
                NotifyPropertyChanged();
            }
        }

        string _Level;
        [UIValue("Level")]

        public string Level
        {
            get { return _Level; }
            private set
            {
                _Level = value;
                NotifyPropertyChanged();


            }

        }
        bool _experienceContainerState;
        [UIValue("exp")]

        public bool experienceContainerState
        {
            get { return _experienceContainerState; }
            private set
            {
                _experienceContainerState = value;
                NotifyPropertyChanged();


            }

        }
        [UIComponent("progress-bar-img")]
        private Image _progressBarImage;

        [UIComponent("progress-bg-bar-img")]
        private Image _progressBgBarImage;

        [UIObject("main-background")] private GameObject _mainBackground;
        [UIObject("progress-bar-stack")] private GameObject _progressBarStack;
    }
}
