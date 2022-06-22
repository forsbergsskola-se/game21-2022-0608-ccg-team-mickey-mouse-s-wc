using System;
using FMODUnity;
using UnityEditor;
using UnityEngine;

namespace Meta.Inventory.FighterInventory {
    [CustomEditor(typeof(CardCreator))]
    public class CardCreatorEditor : Editor {
        public SerializedProperty Cards;
        private bool showPosition = true;

        private void OnEnable() {
            Cards = serializedObject.FindProperty("CardCreator");
        }

        public override void OnInspectorGUI ()
        {
            serializedObject.Update ();
            CardCreator cardCreator = target as CardCreator;
            EditorGUI.indentLevel++;

            for (int i = 0; i < cardCreator.AllCards.Length; i++) {
                var card = cardCreator.AllCards[i];
                showPosition = EditorGUILayout.Foldout(showPosition, "Select a gameobject");
                if (showPosition) {
                    if (Selection.activeTransform) {
                        card.FighterImage = (Texture2D)EditorGUILayout.ObjectField("Image", card.FighterImage, typeof(Texture2D), allowSceneObjects: true);
                        card.Name = EditorGUILayout.TextField ("Name", card.Name);
                        card.Attack = EditorGUILayout.FloatField("Attack", card.Attack);
                        card.MaxHealth = EditorGUILayout.FloatField("Max health", card.MaxHealth);
                        card.Speed = EditorGUILayout.FloatField("Speed", card.Speed);
                        card.Rarity = (Rarity) EditorGUILayout.EnumPopup("Rarity", card.Rarity);
                        card.Alignment = (Alignment) EditorGUILayout.EnumPopup("Alignment", card.Alignment);
                    }

                }
                
                if (!Selection.activeTransform) {
                    showPosition = false;
                }
            }
            
            
            EditorGUI.indentLevel++;
        }
    }
}