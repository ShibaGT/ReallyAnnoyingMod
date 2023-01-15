using BepInEx;
using System;
using UnityEngine;
using System.ComponentModel;
using Utilla;
using Photon.Pun;

namespace ReallyAnnoyingMod
{
    /// <summary>
    /// This is your mod's main class.
    /// </summary>

    /* This attribute tells Utilla to look for [ModdedGameJoin] and [ModdedGameLeave] */
    [Description("HauntedModMenu")]
    [ModdedGamemode]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        bool inRoom;
        bool on;

        void Start()
        {
            on = false;
            inRoom = false;
            Utilla.Events.GameInitialized += OnGameInitialized;
        }

        void OnEnable()
        {
            on = true;

            HarmonyPatches.ApplyHarmonyPatches();
        }

        void OnDisable()
        {
            on = false;

            HarmonyPatches.RemoveHarmonyPatches();
        }

        void OnGameInitialized(object sender, EventArgs e)
        {

        }

        void Update()
        {
            if (PhotonNetwork.InRoom)
            {
                if (on)
                {
                    System.Random rnd = new System.Random();
                    GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(rnd.Next(3, 153), false, 0.5f);
                }
            }
        }
        [ModdedGamemodeJoin]
        public void OnJoin(string gamemode)
        {
            inRoom = true;
        }

        [ModdedGamemodeLeave]
        public void OnLeave(string gamemode)
        {
            inRoom = false;
        }
    }
}
