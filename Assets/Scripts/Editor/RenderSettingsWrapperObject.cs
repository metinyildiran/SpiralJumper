using UnityEngine;
using UnityEngine.Rendering;

public class RenderSettingsWrapperObject : ScriptableObject
{
    public float ambientSkyboxAmount;
    public bool fog;
    public float fogStartDistance;
    public float fogEndDistance;
    public FogMode fogMode;
    public Color fogColor;
    public float fogDensity;
    public AmbientMode ambientMode;
    public Color ambientSkyColor;
    public Color ambientEquatorColor;
    public Color ambientGroundColor;
    public float ambientIntensity;
    public Color ambientLight;
    public Color subtractiveShadowColor;
    public Material skybox;
    public Light sun;
    public SphericalHarmonicsL2 ambientProbe;
    public Cubemap customReflection;
    public float reflectionIntensity;
    public int reflectionBounces;
    public DefaultReflectionMode defaultReflectionMode;
    public int defaultReflectionResolution;
    public float haloStrength;
    public float flareStrength;
    public float flareFadeSpeed;

    public void SetRenderSettingsFromWrapper()
    {
        RenderSettings.fog = fog;
        RenderSettings.fogStartDistance = fogStartDistance;
        RenderSettings.fogEndDistance = fogEndDistance;
        RenderSettings.fogMode = fogMode;
        RenderSettings.fogColor = fogColor;
        RenderSettings.fogDensity = fogDensity;
        RenderSettings.ambientMode = ambientMode;
        RenderSettings.ambientSkyColor = ambientSkyColor;
        RenderSettings.ambientEquatorColor = ambientEquatorColor;
        RenderSettings.ambientGroundColor = ambientGroundColor;
        RenderSettings.ambientIntensity = ambientIntensity;
        RenderSettings.ambientLight = ambientLight;
        RenderSettings.subtractiveShadowColor = subtractiveShadowColor;
        RenderSettings.skybox = skybox;
        RenderSettings.sun = sun;
        RenderSettings.ambientProbe = ambientProbe;
        RenderSettings.customReflection = customReflection;
        RenderSettings.reflectionIntensity = reflectionIntensity;
        RenderSettings.reflectionBounces = reflectionBounces;
        RenderSettings.defaultReflectionMode = defaultReflectionMode;
        RenderSettings.defaultReflectionResolution = defaultReflectionResolution;
        RenderSettings.haloStrength = haloStrength;
        RenderSettings.flareStrength = flareStrength;
        RenderSettings.flareFadeSpeed = flareFadeSpeed;
    }
    public void SetWrapperFromRenderSettings()
    {
        fog = RenderSettings.fog;
        fogStartDistance = RenderSettings.fogStartDistance;
        fogEndDistance = RenderSettings.fogEndDistance;
        fogMode = RenderSettings.fogMode;
        fogColor = RenderSettings.fogColor;
        fogDensity = RenderSettings.fogDensity;
        ambientMode = RenderSettings.ambientMode;
        ambientSkyColor = RenderSettings.ambientSkyColor;
        ambientEquatorColor = RenderSettings.ambientEquatorColor;
        ambientGroundColor = RenderSettings.ambientGroundColor;
        ambientIntensity = RenderSettings.ambientIntensity;
        ambientLight = RenderSettings.ambientLight;
        subtractiveShadowColor = RenderSettings.subtractiveShadowColor;
        skybox = RenderSettings.skybox;
        sun = RenderSettings.sun;
        ambientProbe = RenderSettings.ambientProbe;
        customReflection = (Cubemap)RenderSettings.customReflection;
        reflectionIntensity = RenderSettings.reflectionIntensity;
        reflectionBounces = RenderSettings.reflectionBounces;
        defaultReflectionMode = RenderSettings.defaultReflectionMode;
        defaultReflectionResolution = RenderSettings.defaultReflectionResolution;
        haloStrength = RenderSettings.haloStrength;
        flareStrength = RenderSettings.flareStrength;
        flareFadeSpeed = RenderSettings.flareFadeSpeed;
    }
}
