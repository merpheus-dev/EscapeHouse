using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Subtegral.EscapeHouse.Managers
{
    public sealed class UIManager : AbstractManager<UIManager>, IContainer
    {
        private Canvas _canvas;

        private List<Button> buttonPool = new List<Button>();

        private UIManager() { }

        public void Inject(object reference)
        {
            if (reference is Canvas)
                _canvas = reference as Canvas;
        }

        private void Start()
        {
            SubscribeUIEvents();
        }

        private void SubscribeUIEvents()
        {
            EventDispatcher.OnItemNotExists += () =>
            {

            };
        }

        #region Buttons
        public Button GetButtonInstance(Button buttonPrefab)
        {
            Button _instance = Instantiate(buttonPrefab, _canvas.transform, true);
            buttonPool.Add(_instance);
            return _instance;
        }

        public void DisposeButtons()
        {
            for(var i = 0; i < buttonPool.Count; i++)
                Destroy(buttonPool[i].gameObject);
            buttonPool.Clear();
        }
        #endregion


    }
}