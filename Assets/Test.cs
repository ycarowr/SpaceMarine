using System.Collections;
using System.Collections.Generic;
using SpaceMarine.Arrival;
using SpaceMarine.Opening;
using Tools;
using Tools.Dialog;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public ArrivalSceneParameters parameters;
    public TextMesh text;

    void Update()
    {
        text.text = parameters.SkipIntro.ToString();
    }
}
