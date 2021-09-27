using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverEffects : MonoBehaviour
{
    public void FullOpacity()
    {
        int opacity = ((int)this.GetComponent<Image>().color.a);
        opacity = 255;
    }


}
