using UnityEngine;
using System.Collections;

public class ChangeCanvas : MonoBehaviour {

    public new Camera camera;


    public void UpgradeCanvas()
    {

        camera.transform.position = new Vector3(-28.65f, 0, 0);

    }
    public void MainCanvas()
    {
        camera.transform.position = new Vector3(0,0,0);
    }
}
