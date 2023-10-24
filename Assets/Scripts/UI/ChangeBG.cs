using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBG : MonoBehaviour
{
    public Material[] skyboxes;
    private int index = 0;
    private bool doOnce = true;
    // Start is called before the first frame update
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && doOnce)
        {
            ChangeSkybox();
            doOnce = false;
        }
        if (Input.GetKeyUp(KeyCode.B))
        {
            doOnce = true;
        }
    }

    public void ChangeSkybox()
    {
        if (index <= skyboxes.Length)
        {
            RenderSettings.skybox = skyboxes[index];
            index++;
        }
        if (index == skyboxes.Length)
        {
            index = 0;
        }
    }
}
