using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Subtegral.EscapeHouse.Managers;
using System;
using UnityEngine.UI;
using TMPro;
namespace Subtegral.EscapeHouse
{
    [Serializable]
    public class UIContainer
    {
        public Canvas Canvas;
#pragma warning disable
        [SerializeField]
        private TextMeshProUGUI DisplayText;
#pragma warning disable
        [SerializeField]
        private GameObject DisplayGO;

        public void DisplayError(string text)
        {
            DisplayText.text = text;
            DisplayGO.SetActive(true);
        }
    }

}