using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColorRainbow : MonoBehaviour
{
    private TextMeshProUGUI playerName;
    private float newRedHue = 1.0f;
    private float newGreenHue = 0.0f;
    private float newBlueHue = 0.0f;
    private float newAlphaHue = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerName = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (newBlueHue <= 0.0f && newGreenHue <= 1.0f && newRedHue >= 1)
        {
            newGreenHue += 1.0f * Time.deltaTime;
        }
        else if (newGreenHue >= 1.0f && newRedHue >= 0.0f && newBlueHue <= 0)
        {
            newRedHue -= 1.0f * Time.deltaTime;
        }
        else if (newRedHue <= 0.0f && newBlueHue <= 1.0f && newGreenHue >= 1)
        {
            newBlueHue += 1.0f * Time.deltaTime;
        }
        else if (newBlueHue >= 1.0f && newGreenHue >= 0.0f && newRedHue <= 0)
        {
            newGreenHue -= 1.0f * Time.deltaTime;
        }
        else if (newGreenHue <= 0.0f && newRedHue <= 1.0f && newBlueHue >= 1)
        {
            newRedHue += 1.0f * Time.deltaTime;
        }
        else if (newRedHue >= 1.0f && newBlueHue >= 0.0f && newGreenHue <= 0)
        {
            newBlueHue -= 1.0f * Time.deltaTime;
        }
        playerName.color = new Color(newRedHue, newGreenHue, newBlueHue, newAlphaHue);
    }
}
