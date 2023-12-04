using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Light Data", menuName = "ScriptableObjects/Ornaments/Light Data", order = 0)]
public class LightData : ScriptableObject
{
    [SerializeField] private Color baseColor = Color.white;
    [SerializeField] private Color emissionColor = Color.white;
    [SerializeField] private float lightIntensity = 1f;
    [SerializeField] private Material material;
    [SerializeField] private string colorKey = "_BaseColor";
    [SerializeField] private string emissionKey = "_EmissionColor";

    public Color BaseColor => baseColor;
    public Color EmissionColor => emissionColor;
    public string ColorKey => colorKey;
    public string EmissionKey => emissionKey;

    public void SetUpMaterial(Material material)
    {
        material.SetColor(colorKey, baseColor);
        material.SetColor(emissionKey, emissionColor);
    }

    public void SetUpMaterial()
    {
        material.SetColor(colorKey, baseColor);
        material.SetColor(emissionKey, emissionColor);
    }

    public void SetUpLight(Light lightComponent)
    {
        lightComponent.color = emissionColor;
        lightComponent.intensity = lightIntensity;
    }
}
