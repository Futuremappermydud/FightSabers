
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components;
using BeatSaberMarkupLanguage.Parser;
using BeatSaberMarkupLanguage.ViewControllers;
using CustomSaber.Data;
using CustomSaber.Settings;
using CustomSaber.Utilities;
using HMUI;
using System;
using UnityEngine;

namespace FightSabers.UI.Controllers
{
    internal class PlatformShopPageController : FightSabersViewController
    {
        public override string ResourceName => "FightSabers.UI.Views.PlatformShopPageView.bsml";
        public override string ContentFilePath => "C:/Users/Owen/Documents/GitHub/FightSabershop/UI/Views/PlatformShopPageView.bsml";

        #region Properties

        [UIParams]
        private BSMLParserParams parserParams;

        private string _one;

        [UIAction("ItemOne")]
        public string one
        {
            get { return _one; }
            private set
            {
                _one = value;
                NotifyPropertyChanged();
            }
        }


		[UIComponent("PlatformsList")]
		public CustomListTableData customListTableData;

		[UIAction("PlatformSelect")]
		private void PlatformSelect(TableView ignored1, int idx)
		{
			PlatformManager.Instance.SetPlatform(idx);
			try
			{
				Resources.FindObjectsOfTypeAll<PlayerDataModelSO>()[0].playerData.overrideEnvironmentSettings.overrideEnvironments = false;
			}
			catch (Exception e)
			{
				Plugin.Log(e);
			}

		

		#endregion






	}
}
