using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Meta.Oliver_Mad_Experiments{
    public class DesignerFactory : MonoBehaviour{
      
    
        #region Editor
#if UNITY_EDITOR
        [CustomEditor(typeof(DesignerFactory))]
        public class DesignerFactoryEditor : Editor{
            static OwnedCard ownedCard = new OwnedCard();
             string guid = "";
            public override void OnInspectorGUI(){
                base.OnInspectorGUI();
                DesignerFactory factory = (DesignerFactory) target;
                EditorGUILayout.Space();
                EditorGUILayout.LabelField("-Factory-");
                EditorGUILayout.Space();
                EditorGUILayout.LabelField("Valid ID Input must follow this style: 00000000-0000-0000-0000-000000000000");
                guid  =  EditorGUILayout.TextField("ID", guid);
              
                ownedCard.Attack = EditorGUILayout.FloatField("Attack", ownedCard.Attack);
                ownedCard.Speed= EditorGUILayout.FloatField("Speed", ownedCard.Speed);
                ownedCard.MaxHealth= EditorGUILayout.FloatField("MaxHealth", ownedCard.MaxHealth);
                ownedCard.Alignment=  (Alignment)EditorGUILayout.EnumPopup("Alignment", ownedCard.Alignment);
                ownedCard.Level=(short) EditorGUILayout.IntField("Level", ownedCard.Level);
                ownedCard.Name= EditorGUILayout.TextField("Name", ownedCard.Name);
                ownedCard.Rarity= (Rarity)EditorGUILayout.EnumPopup("Rarity", ownedCard.Rarity);
                ownedCard.SpriteName = EditorGUILayout.TextField("SpriteName", ownedCard.SpriteName);
                //ownedCard.FighterImage = (Sprite) EditorGUILayout.ObjectField("Sprite",  ownedCard.FighterImage, typeof(Sprite), true);

                
                
                if (GUILayout.Button("Create New Owned Card")){
                    this.CreateNewOwnedCard(ownedCard);
                }
            }

            public void CreateNewOwnedCard(OwnedCard _ownedCard){
                  ownedCard.ID = new StringGUID(guid);
                ownedCard.Save();
            }
        }

        
#endif
        #endregion
    
    
    
    }
}