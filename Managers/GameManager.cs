using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Creates managers and gameobjects to scene
/// </summary>
namespace Subtegral.EscapeHouse.Managers
{
    public class GameManager : MonoBehaviour
    {
        public SceneGraph Graph;
        public UIContainer UIContainer;

        private GraphExecutionManager graphExecutionMananager;
        private AudioManager audioManager;
        private UIManager guiManager;
        private InventoryManager inventoryManager;
        void Awake()
        {
            guiManager = ManagerFactory.GetInstance<UIManager>();
            audioManager = ManagerFactory.GetInstance<AudioManager>();
            graphExecutionMananager = ManagerFactory.GetInstance<GraphExecutionManager>();
            inventoryManager = ManagerFactory.GetInstance<InventoryManager>();
            guiManager.Inject(UIContainer);
            graphExecutionMananager.Inject(Graph);
            Invoke("Begin", 1f);
        }

        void Begin()
        {
            graphExecutionMananager.Execute();
        }
    }
}
