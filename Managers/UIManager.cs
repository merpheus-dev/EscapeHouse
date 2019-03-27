using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Subtegral.EscapeHouse.Managers
{
    public sealed class UIManager : AbstractManager<UIManager>, IContainer
    {
        private UIContainer _container;
        private List<Button> buttonPool = new List<Button>();

        private UIManager() { }

        public void Inject(object reference)
        {
            if (reference is UIContainer)
                _container = reference as UIContainer;
        }

        private void Start()
        {
            SubscribeUIEvents();
        }

        private void SubscribeUIEvents()
        {
            EventDispatcher.OnItemNotExists += () =>
            {
                _container.DisplayError("I need something for this!");
            };
        }

        #region Buttons
        public Button GetButtonInstance(Button buttonPrefab)
        {
            Button _instance = Instantiate(buttonPrefab, _container.Canvas.transform, true);
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