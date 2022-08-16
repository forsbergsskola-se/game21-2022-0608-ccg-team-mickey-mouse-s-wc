using System;
using UnityEngine;

namespace Meta.ShoppingSystem.Ads {
    public class RewardedAdsLimit : MonoBehaviour {
        public AdDay adDay;
        
        private void OnEnable() {
            adDay = new AdDay();
            adDay.TryLoadData();
        }

        public bool CanWatchAdd(){
            return adDay.dateOfAdWatch < DateTime.Today;
        }

        public void Save() {
            adDay.Save();
        }
    }
}