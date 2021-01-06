using UnityEngine;
using UnityEngine.SceneManagement;

[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;
    [SerializeField, Range(0, 520)] private float TimeOfDay;


    private void Update()
    {
        if (Preset == null)
            return;

        if (Application.isPlaying)
        {
            TimeOfDay += Time.deltaTime;
            TimeOfDay %= 520; 
            UpdateLighting(TimeOfDay / 520f);
        }
        else
        {
            UpdateLighting(TimeOfDay / 520f);
        }
        if(TimeOfDay < 347 && TimeOfDay > 349)
        {
            AudioSource[] sources = GameObject.FindGameObjectWithTag("Player").GetComponents<AudioSource>();
            foreach (var source in sources)
            {
                if(source.playOnAwake == false)
                {
                    source.Play();
                }
            }
        } 

        if (TimeOfDay >= 350)
        {
            PlayerPrefs.SetInt("enableDog", PlayerPrefs.GetInt("enableDog", 1) + 1);
            SceneManager.LoadScene("Slaapkamer");
        }
    }


    private void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);

        if (DirectionalLight != null)
        {
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);

            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }

    }

    private void OnValidate()
    {
        if (DirectionalLight != null)
            return;

        if (RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if (light.type == LightType.Directional)
                {
                    DirectionalLight = light;
                    return;
                }
            }
        }
    }
}