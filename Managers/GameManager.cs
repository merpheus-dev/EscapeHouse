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
        public Canvas Canvas;

        private GraphExecutionManager graphExecutionMananager;
        private AudioManager audioManager;
        private UIManager guiManager;
        private InventoryManager inventoryManager;
        void Start()
        {
            guiManager = ManagerFactory.GetInstance<UIManager>();
            audioManager = ManagerFactory.GetInstance<AudioManager>();
            graphExecutionMananager = ManagerFactory.GetInstance<GraphExecutionManager>();
            guiManager.Inject(Canvas);
            graphExecutionMananager.Inject(Graph);
            Invoke("Begin", 1f);
        }

        void Begin()
        {
            graphExecutionMananager.Execute();
        }
    }
}
