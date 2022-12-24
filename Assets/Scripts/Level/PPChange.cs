using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
//using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering.PostProcessing;

public class PPChange : MonoBehaviour
{
    private PostProcessVolume volume;
    private ColorGrading colorGrading;
    public LightChange lightChange;

    private void Start()
    {
        volume = GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out colorGrading);

    }

    public void LightChange()
    {
        colorGrading.brightness.Override(lightChange.lightValue);
    }
}
