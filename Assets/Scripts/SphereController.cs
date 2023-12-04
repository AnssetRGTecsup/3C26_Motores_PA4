using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    [Header("Sphere Data")]
    [SerializeField] private LightData sphereData;

    [Header("Sphere Components")]
    [SerializeField] private Light lightComponent;
    [SerializeField] private Renderer materialReference;

    private void Start()
    {
        SetUpComponents();
    }

    [ContextMenu("Set Up Colors")]
    private void SetUpComponents()
    {
        //materialReference.material.SetColor(sphereData.ColorKey, sphereData.BaseColor);
        //materialReference.material.SetColor(sphereData.EmissionKey, sphereData.EmissionColor);

        sphereData.SetUpMaterial(materialReference.material);
        sphereData.SetUpLight(lightComponent);
    }
}
