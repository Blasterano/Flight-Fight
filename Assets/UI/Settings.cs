using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public AudioMixer audiomix;
    public Dropdown resolution_dropdown;

    private AudioPlayer audioPlayer;
    Resolution[] resolutions;

    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;
        resolution_dropdown.ClearOptions();

        audioPlayer = FindObjectOfType<AudioPlayer>();

        List<string> options = new List<string>();

        int current_resolution_index = 0;
        for(int i=0;i<resolutions.Length;i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) 
            {
                current_resolution_index = i;
            }
        }
        resolution_dropdown.AddOptions(options);
        resolution_dropdown.value = current_resolution_index;
        resolution_dropdown.RefreshShownValue();

    }

    public void Resolution(int resolution_idx)
    {
        audioPlayer.PlayClip();
        Resolution resolution = resolutions[resolution_idx];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void Volume(float volume)
    {
        audioPlayer.PlayClip();
        audiomix.SetFloat("Volume", volume);
    }
    public void Quality(int fx_index)
    {
        audioPlayer.PlayClip();
        QualitySettings.SetQualityLevel(fx_index);
    }
    public void FullScreen(bool isfull)
    {
        audioPlayer.PlayClip();
        Screen.fullScreen = isfull;
    }
}
