using UnityEngine;

namespace NotEnoughMadness
{
    public class NEMFreezeCam : MonoBehaviour
    {
        Cam_Main cameraMain = Cam_Main.gameCam;
        void Update()
        {
            Cursor.lockState = CursorLockMode.Confined;
            cameraMain.viewLookAt = this.transform.forward;
        }
    }

}
