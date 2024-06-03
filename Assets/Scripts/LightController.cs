using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light directionalLight;
    public Light player;
    // Start is called before the first frame update
    void Start()
    {
        directionalLight.enabled = false;
        player.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
