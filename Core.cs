using Il2Cpp;
using MelonLoader;
using UnityEngine;

[assembly: MelonInfo(typeof(SeedDisplay.Core), "SeedDisplay", "2.0.0", "Jayden", null)]
[assembly: MelonGame("Notional Games", "Beltmatic")]

namespace SeedDisplay
{
    public class Core : MelonMod
    {
        private readonly GUIStyle centered = new();

        public override void OnInitializeMelon()
        {
            centered.normal.textColor = Color.white;
        }

        public override void OnGUI()
        {
            GUI.Box(new Rect(10, 10, 200, 20), GameManager.Instance.AnySimulation.Seed.ToString(), centered);
        }
    }
}