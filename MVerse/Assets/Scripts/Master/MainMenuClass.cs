using UnityEditor;
using UnityEngine;
using RamsesTheThird.VARMAP.GameMenu;

namespace RamsesTheThird.MainMenu
{
    public class MainMenuClass : MonoBehaviour
    {
        private static MainMenuClass _singleton;

        private void Awake()
        {
            if(_singleton)
            {
                Destroy(gameObject);
            }
            else
            {
                _singleton = this;
            }
        }

        private void OnGUI()
        {
            GUILayout.BeginArea(Screen.safeArea);

            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();

            if(GUILayout.Button("Start Game"))
            {
                VARMAP_GameMenu.START_GAME(out _);
            }

            GUILayout.EndHorizontal();
            GUILayout.EndVertical();

            GUILayout.EndArea();
        }

        private void OnDestroy()
        {
            if(_singleton == this)
            {
                _singleton = null;
            }
        }
    }
}