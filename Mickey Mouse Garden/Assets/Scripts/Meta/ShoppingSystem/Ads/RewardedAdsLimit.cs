using System;
using UnityEngine;

namespace Meta.ShoppingSystem.Ads {
    public class RewardedAdsLimit : MonoBehaviour {
        public Day day;
        
        private void OnEnable() {
            day = new Day();
            day.TryLoadData();
        }

        public bool CanWatchAdd() {
            if (day.dateOfAdWatch < DateTime.Today) {
                return true;
            }

            return false;
        }

        public void Save() {
            day.Save();
        }
    }
}