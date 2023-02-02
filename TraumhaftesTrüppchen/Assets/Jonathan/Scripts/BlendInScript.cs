using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class BlendInScript : MonoBehaviour
{
    public PostProcessVolume blendIn;
    public float blendInSpeed;
    private Vignette vignette;
    private void Start()
    {
        blendIn.profile.TryGetSettings(out vignette);
    }
    private void Update()
    {
        if(vignette.intensity.value >= 0.55f)
        vignette.intensity.value -= blendInSpeed * Time.deltaTime;
    }
}
