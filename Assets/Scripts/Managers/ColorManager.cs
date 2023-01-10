using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
public class ColorManager : MonoBehaviour
{
    public Volume volume;
    public Color Color;
    private Bloom bloom;
    private ColorAdjustments colorAdjust;
    private void Start()
    {
        if (volume.profile.TryGet<Bloom>(out var bloom))
        {
            this.bloom = bloom;
        }
        if (volume.profile.TryGet<ColorAdjustments>(out var colorAdjustments))
        {
            this.colorAdjust = colorAdjustments;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //bloom.tint.value = Color;
        //colorAdjust.colorFilter.value = Color;
        DoTimedRainbowLightingAnim();
    }


    // Variable of byte type data for setting Color32 value
    byte red = 0;
    byte green = 0;
    byte blue = 0;
    byte alpha = 255;
    public Material mat;

    int frameCount = 0; // Variable used to pause color changes in Light for the frame count specified with colorChangeInterval

    [SerializeField]
    int colorChangeInterval = 0;

    private void DoTimedRainbowLightingAnim() // Function for calling AnimateLightingInRainbow() in certain frames
    {
        if (colorChangeInterval == 0)
        {
            AnimateLightingInRainbow();
        }
        else if (colorChangeInterval != 0)
        {
            frameCount++; // count how many frames it has been since the last change in Light's color

            if (frameCount == colorChangeInterval)
            {
                AnimateLightingInRainbow();
                frameCount = 0;
            }
        }
    }

    private void AnimateLightingInRainbow() // Function for changing the color of Light 
    {
        // if - else statement that calculates RGB value for the color change 
        if (red == 0 && green == 0 && blue == 0)
            red = 255;
        else if (red == 0 && green < 255 && blue == 200)
            green++;
        else if (red == 0 && green == 255 && blue > 0)
            blue--;
        else if (red == 255 && green == 0 && blue < 200)
            blue++;
        else if (red == 255 && green > 0 && blue == 0)
            green--;
        else if (red > 0 && green == 0 && blue == 200)
            red--;
        else if (red < 255 && green == 255 && blue == 0)
            red++;

        bloom.tint.value = new Color32(red, green, blue, alpha); // Update the RGB value of the color of Light with the RGB value calculated from the above if-else statements
        colorAdjust.colorFilter.value = new Color32(red, green, blue, alpha);
        mat.color = new Color32(red, green, blue, alpha);

        Debug.Log("R value: " + red + " | G value: " + green + " | B value: " + blue); // Log the new RGB value in the console
    }
}
