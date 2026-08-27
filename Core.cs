using Il2Cpp;
using MelonLoader;
using UnityEngine;
using UnityEngine.SceneManagement;

[assembly: MelonInfo(typeof(SeedDisplay.Core), "SeedDisplay", "1.0.0", "Jayden", null)]
[assembly: MelonGame("Notional Games", "Beltmatic")]

namespace SeedDisplay
{
    public class Core : MelonMod
    {
        GameManager gm;
        GUIStyle centered;
        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Initialized.");
        }

        public override void OnGUI()
        {
            if (gm == null)
            {
                GameObject dummy = new();
                UnityEngine.Object.DontDestroyOnLoad(dummy);
                Scene ddolScene = dummy.scene;
                UnityEngine.Object.Destroy(dummy);
                GameObject gameManagerGO = null;
                var rootObjects = ddolScene.GetRootGameObjects();
                foreach (var GO in rootObjects)
                {
                    if (GO != null && GO.name == "GameManager")
                    {
                        gameManagerGO = GO;
                        break;
                    }
                }
                gm = gameManagerGO.GetComponent<GameManager>();
            }
            if (gm.RealSimulation != null)
            {
                if (centered == null)
                {
                    centered = new GUIStyle();
                    centered.normal.textColor = Color.white;
                }
                GUI.Box(new Rect(10, 10, 200, 20), gm.RealSimulation.Seed.ToString(), centered);
            }
        }
    }
}