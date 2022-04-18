using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellSwitch : MonoBehaviour
{
    public bool isOn = false;
    Image imageComponent;
    Color32 onColor;
    Color32 offColor;

    // Start is called before the first frame update
    void Start()
    {
        imageComponent = GetComponent<Image>();
        onColor = new Color32(0x61, 0xD1, 0x5C, 0xFF); //color 0x61D15C
        offColor = new Color32(0x32, 0x61, 0x30, 0xFF); //color 0x326130
        TurnOn();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOn)
        {
            TurnOn();
        }
        else
        {
            TurnOff();
        }
    }

    public void TurnOn()
    {
        imageComponent.color = onColor;
    }

    public void TurnOff()
    {
        imageComponent.color = offColor;
    }
}
