using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;

public class Test : MonoBehaviour
{
    public TextSequence sequence;
    public DialogSystem dialogl;
    
    [Button]
    public void Wraite()
    {
        dialogl.Write(sequence);    
    }
}
