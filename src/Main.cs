using System;
using System.Collections.Generic;
using Harmony;
using MelonLoader;
using UnityEngine;
using System.Media;
using Il2CppSystem;
using static OVRInput;
using System.IO;
using System.Text;

namespace AudicaModding
{
    public class AudicaMod : MelonMod
    {
        public static class BuildInfo
        {
            public const string Name = "VRMappingTools";  // Name of the Mod.  (MUST BE SET)
            public const string Author = "SugarBear125"; // Author of the Mod.  (Set as null if none)
            public const string Company = null; // Company that made the Mod.  (Set as null if none)
            public const string Version = "0.1"; // Version of the Mod.  (MUST BE SET)
            public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
        }
        public override void OnApplicationStart()
        {
            foreach (string name in typeof(AudicaMod).Assembly.GetManifestResourceNames())
            {
                MelonLoader.MelonLogger.Log(name);
            }
        }
        [HarmonyPatch(typeof(OVRInput), "Update")]
        private static class PatchOVRUpdate
        {
            private static bool Prefix(OVRInput __instance)
            {
                if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.All))
                {
                    string path = @"./logs/Timestamp.txt";
                    KataConfig.I.CreateDebugText("Timestamp Created", new Vector3(0f, -1f, 5f), 5f, null, false, 0.2f);
                    string convertFloatToString = System.Convert.ToString(AudioDriver.I.mCachedTick);

                    try
                    {
                        if (!File.Exists(path))
                        {
                            string createText = convertFloatToString + System.Environment.NewLine;
                            File.WriteAllText(path, createText);
                        }

                        string appendText = convertFloatToString + System.Environment.NewLine;
                        File.AppendAllText(path, appendText);

                        string readText = File.ReadAllText(path);
                        System.Console.WriteLine(readText);

                        {
                            string s = "";
                            //while ((s = sr.ReadLine()) != null)
                            {
                                System.Console.WriteLine(s);
                            }
                        }
                    }

                    catch (System.Exception EX)
                    {
                        System.Console.WriteLine(EX.ToString());

                    }

                }
                return true;
            }
        }
    }
}



