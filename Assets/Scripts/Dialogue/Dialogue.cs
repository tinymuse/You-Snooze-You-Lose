using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]
public class Dialogue : ScriptableObject
{
    public string title;
    [TextArea(3,10)]
    public string[] sentences;
    public Response[] responses;

   /* public string yesText;
    public string noText;
    public Dialogue yesOption;
    public Dialogue noOption; */

       
}
