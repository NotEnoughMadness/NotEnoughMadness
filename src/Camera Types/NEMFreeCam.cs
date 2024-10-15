using HarmonyLib;
using UnityEngine;

namespace NotEnoughMadness
{
    public class NEMFreeCam : MonoBehaviour
    {
        Vector3 lastMouse = new Vector3(255f, 255f, 255f);
        int speedMult = 1;
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

            // todo: 
            // MAKE RETICLE / TARGET_MAIN AIM WHERE YOUR CAMERA IS LOOKING AT

            // MOUSE AND ROTATION HANDLING

            // weird calculations because on my (xdef) pc it returns numbers in the thousands when i move my mouse slightly :V

            //float rotationY = Input.GetAxis("Mouse Y") / 1000f / 10f;
            //float rotationX = Input.GetAxis("Mouse X") / 1000f / 10f;

            //rotationY *= NEMConfig.CameraSensivity.Value;
            //rotationX *= NEMConfig.CameraSensivity.Value;


            //Debug.Log(rotationY);

            this.lastMouse.x = Input.GetAxis("Mouse X") / 1000f / 2f * .9f;
            this.lastMouse.y = Input.GetAxis("Mouse Y") / 1000f / 2f * .9f;
            this.lastMouse.z = 0f;

            this.lastMouse = new Vector3(-this.lastMouse.y * NEMConfig.CameraSensivity.Value, this.lastMouse.x * NEMConfig.CameraSensivity.Value, 0f);
            this.lastMouse = new Vector3(base.transform.eulerAngles.x + this.lastMouse.x, base.transform.eulerAngles.y + this.lastMouse.y, 0f);

            base.transform.localEulerAngles = this.lastMouse;


            //transform.localEulerAngles = Vector3.new();
            //transform.Rotate


            


            // KEYBOARD AND POSITION HANDLING

            

            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                speedMult = 2;
            }
            else
            {
                speedMult = 1;
            }

            // z is forward backward
            // x is right left
            // y is up down
            if (Input.GetKey(NEMConfig.CameraMoveForward.Value))
            {
                this.transform.Translate(Vector3.forward * NEMConfig.CameraSpeed.Value * speedMult * Time.unscaledDeltaTime, Space.Self);
            }
            if (Input.GetKey(NEMConfig.CameraMoveBackward.Value))
            {
                this.transform.Translate(Vector3.back * NEMConfig.CameraSpeed.Value * speedMult * Time.unscaledDeltaTime, Space.Self);
            }
            if (Input.GetKey(NEMConfig.CameraMoveLeft.Value))
            {
                this.transform.Translate(Vector3.left * NEMConfig.CameraSpeed.Value * speedMult * Time.unscaledDeltaTime, Space.Self);
            }
            if (Input.GetKey(NEMConfig.CameraMoveRight.Value))
            {
                this.transform.Translate(Vector3.right * NEMConfig.CameraSpeed.Value * speedMult * Time.unscaledDeltaTime, Space.Self);
            }
            if (Input.GetKey(NEMConfig.CameraMoveUp.Value))
            {
                this.transform.Translate(Vector3.up * NEMConfig.CameraSpeed.Value * speedMult * Time.unscaledDeltaTime, Space.World);
            }
            if (Input.GetKey(NEMConfig.CameraMoveDown.Value))
            {
                this.transform.Translate(Vector3.down * NEMConfig.CameraSpeed.Value * speedMult * Time.unscaledDeltaTime, Space.World);
            }

            // do the stuff

            Cam_Main.gameCamPosition = this.transform.position;
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
