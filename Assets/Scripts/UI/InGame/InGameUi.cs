﻿using Assets.Scripts.UI.InGame.Rebinds;
using UnityEngine;

namespace Assets.Scripts.UI.InGame
{
    public class InGameUi : MonoBehaviour
    {
        public HUD.HUD HUD;
        public InGameMenu Menu;
        public SpawnMenu SpawnMenu;
        public GraphicSettingMenu GraphicSettingMenu;
        public RebindsMenu RebindsMenu;

        private static int _activeMenus;

        public static void OnMenuOpened()
        {
            Debug.Log("Menu opened");
            _activeMenus++;
        }

        public static void OnMenuClosed()
        {
            Debug.Log("Menu closed");
            if (_activeMenus == 0)
            {
                Debug.LogError("Tried to close a menu while there was none");
            }
            else
            {
                _activeMenus--;
            }
        }

        public static bool IsMenuOpen()
        {
            return _activeMenus > 0;
        }

        void OnEnable()
        {
            HUD.gameObject.SetActive(true);
            SpawnMenu.gameObject.SetActive(true);
            GraphicSettingMenu.gameObject.SetActive(false);
            Menu.gameObject.SetActive(false);
            RebindsMenu.gameObject.SetActive(false);
        }

        private void Update()
        {
            // The Escape key unlocks the cursor in the editor,
            // which is why exiting the menu messes with TPS.
            if (UnityEngine.Input.GetKeyDown(KeyCode.P))
                Menu.gameObject.SetActive(!Menu.isActiveAndEnabled);
        }
    }
}