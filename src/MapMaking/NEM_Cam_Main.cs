using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

namespace NotEnoughMadness.MapMaking
{
    public class NEM_Cam_Main : MonoBehaviour
    {
        void Awake()
        {
            // The camera settings here mirror VANILLA MPN CAMERA SETTINGS
            /*gameObject.tag = "MainCamera";

            Camera camera = gameObject.AddComponent<Camera>();
            camera.clearFlags = CameraClearFlags.Skybox;
            camera.backgroundColor = Color.black;

            camera.toggleCullingMasks(new Dictionary<string, bool>() {
                {"Nothing", false },
                {"Everything", false },
                {"Default", true },
                {"TransparentFX", true },
                {"Ignore Raycast", true },
                {"Water", true },
                {"UI", false },
                {"Terrain", true },
                {"Character", true },
                {"Projectile", true },
                {"Debris", true },
                {"Interactive", true },
                {"Obstacle", true },
                {"Item", true },
                {"TerrainInvis", true },
                {"GUI", false },
                {"CharacterHits", true },
                {"Fence", true },
                {"CharacterIntangible", true },
                {"ObjectBlock", true },
                {"CharacterBlock", true },
                {"Interface", false },
                {"Decal", true },
                {"BlockAim", true },
                {"PathBlock", true },
                {"BulletBlock", true },
                {"EventArea", true },
                {"TerrainObstacle", true },
                {"ProjectileSoft", true },
                {"HazardTrigger", true },
                {"SightBlock", true }
            });

            camera.orthographic = false; // ortograpic false means projection is PERSPECTIVE
            // camera fov value is always VERTICAL FOV
            // in unity editor theres an option for horizontal fov but under the hood it converts it to vertical anyways and the horizontal is just cosmetic, AND its not exposed to the api here so i cant change it to horizontal 
            camera.fieldOfView = 33;
            camera.usePhysicalProperties = false;
            camera.nearClipPlane = .3f;
            camera.farClipPlane = 1000f;
            camera.rect = new Rect(new Vector2(0, 0), new Vector2(1, 1));
            camera.depth = -1;
            camera.renderingPath = RenderingPath.UsePlayerSettings;
            camera.targetTexture = null; // probably dont need to set it explicitly here but ah well
            camera.useOcclusionCulling = true;
            camera.allowHDR = false;
            camera.allowMSAA = true;
            camera.allowDynamicResolution = false;
            camera.targetDisplay = 0; // 0 is display 1 i think??


            // Create camera main from MPN

            Cam_Main camMain = gameObject.AddComponent<Cam_Main>();
            camMain.myCamera = camera; // camera from up there in the code
            */

            // ok ok instead of recreating manually, ,,  ,  INSTANTIATE PREFAB that exists in vanilla
            GameObject cameraGamePrefab = Instantiate(Resources.Load("cameras/Camera_Game")) as GameObject;
            cameraGamePrefab.transform.position = gameObject.transform.position;
            cameraGamePrefab.transform.rotation = gameObject.transform.rotation;
            cameraGamePrefab.transform.localScale = gameObject.transform.localScale;


            // COMMENCE SELF DESTRUCT SEQUENCE 
            Destroy(gameObject);
        }
    }

    /*static class CameraExtensions
    {
        public static void toggleCullingMasks(this Camera camera, Dictionary<string, bool> layerBools)
        {
            foreach(string layerName in layerBools.Keys)
            {
                bool enable = layerBools[layerName];

                if (enable == true)
                {
                    // OR enables the bit
                    camera.cullingMask |= 1 << LayerMask.NameToLayer(layerName);
                }
                else
                {
                    // AND disables the bit
                    camera.cullingMask &= ~(1 << LayerMask.NameToLayer(layerName));
                }
            }
            
        }
    }*/
}
