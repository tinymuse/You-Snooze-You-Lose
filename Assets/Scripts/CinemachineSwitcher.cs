using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineSwitcher : MonoBehaviour
{
    public bool overworldCamera = true;
  //  public CinemachineVirtualCamera vcam1; // overworldcam
  //  public CinemachineVirtualCamera vcam2; // npccam
    public Animator animator;

    public void SwitchState()
    {
        if (overworldCamera)
        {
            animator.Play("npcCam");
        }
        else
        {
            animator.Play("overworldCam");
        }
        overworldCamera = !overworldCamera;
    }


    /*public void SwitchPriority()
    {
        print("switched");
        if (overworldCamera)
        {
            vcam1.Priority = 0;
            vcam2.Priority = 1;
            overworldCamera = false;
        }
        else
        {
            vcam1.Priority = 1;
            vcam2.Priority = 0;
            overworldCamera = true;
        }
        overworldCamera = !overworldCamera;
    }*/
}
