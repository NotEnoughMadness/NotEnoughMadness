using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NotEnoughMadness
{
    public class NEMFpsCam : MonoBehaviour
    {
        Vector3 lastMouse = new Vector3(255f, 255f, 255f);
        Cam_Main cameraMain = Cam_Main.gameCam;
        Traverse camTraverse = Traverse.Create(Cam_Main.gameCam);

        void Update()
        {
            if (Game_Manager.ReturnPaused())
            {
                Cursor.lockState = CursorLockMode.Confined;
                return;
            }
            Cursor.lockState = CursorLockMode.Locked;

            cameraMain.myCamera.fieldOfView = NEMConfig.CameraFOV.Value;

            this.lastMouse.x = Input.GetAxis("Mouse X") / 1000f / 2f * .9f;
            this.lastMouse.y = Input.GetAxis("Mouse Y") / 1000f / 2f * .9f;
            this.lastMouse.z = 0f;

            this.lastMouse = new Vector3(-this.lastMouse.y * NEMConfig.CameraSensivity.Value, this.lastMouse.x * NEMConfig.CameraSensivity.Value, 0f);
            this.lastMouse = new Vector3(base.transform.eulerAngles.x + this.lastMouse.x, base.transform.eulerAngles.y + this.lastMouse.y, 0f);

            base.transform.localEulerAngles = this.lastMouse;

            Cam_Main.gameCamPosition = Controller_Base.PlayerOne.gameObject.transform.position;
            Cam_Main.UpdateFloorPlane();
            SwainAudio.CamMod = 0.75f + Vector3.Distance(this.transform.position, cameraMain.viewPosition) / 60f;
            SwainAudio.ViewTargetEars = (Cam_Main.FocalCharacter_Global ? cameraMain.ReturnFocalCharacterPosition(false) : (Vector3.one * 9999f));
            SwainAudio.CamForward = this.transform.forward;
            SwainAudio.CamUp = this.transform.up;
            Game_Manager.currentManager.transform.rotation = Quaternion.LookRotation(SwainAudio.CamForward, SwainAudio.CamUp);

            // doesnt exist this.autoSnapPosition = false;
            camTraverse.Field("autoSnapPosition").SetValue(false);

            Game_Manager.ManageSoundSource();
        }
    }

}
