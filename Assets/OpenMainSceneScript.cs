using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMainSceneScript : MonoBehaviour
{
public void GotoNextSceneAction ()
    {
        Application.LoadLevel ("GAMEPLAYSCENE");
    }
}
