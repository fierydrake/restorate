using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header ("Audio Clips")]
    public AudioClip brokenMovement;
    public AudioClip workingMovement;

    public AudioClip brokenJump;
    public AudioClip workingJump;

    public AudioClip repairSound;
    public AudioClip exitLevel;

    public AudioClip music;

    [Header("Audio Sources")]
    public AudioSource P1_Movement;
    public AudioSource P1_OneShots;
    public AudioSource P2_Movement;
    public AudioSource P2_OneShots;
    public AudioSource ExitLevel;
    public AudioSource RepairStation;
    public AudioSource Music;

    //TEMP
    private int playerNumber;

    void Start()
    {
        playerNumber = 1;
    }


    public void OnBrokenMovement(int playerNumber)
    {
        if (playerNumber == 1)
        {
            P1_OneShots.PlayOneShot(brokenMovement, 1.3f);
        }
        if (playerNumber == 2)
        {
            P2_OneShots.PlayOneShot(brokenMovement, 1.3f);
        }

    }

    public void OnWorkingMovementStart(int playerNumber)
    {
        if (playerNumber == 1)
        {
            P1_Movement.Play();
        }
        if (playerNumber == 2)
        {
            P2_Movement.Play();
        }
    }

    public void OnWorkingMovementStop(int playerNumber)
    {
        if (playerNumber == 1)
        {
            P1_Movement.Stop();
        }
        if (playerNumber == 2)
        {
            P2_Movement.Stop();
        }
    }


    public void OnBrokenJump(int playerNumber)
    {
        if (playerNumber == 1)
        {
            P1_OneShots.PlayOneShot(brokenJump, 1);
        }
        if (playerNumber == 2)
        {
            P2_OneShots.PlayOneShot(brokenJump, 1);
        }
    }

    public void OnWorkingJump(int playerNumber)
    {
        if (playerNumber == 1)
        {
            P1_OneShots.PlayOneShot(workingJump, 1);
        }
        if (playerNumber == 2)
        {
            P2_OneShots.PlayOneShot(workingJump, 1);
        }
    }

    public void OnRepair()
    {
        RepairStation.PlayOneShot(repairSound, 1);
    }

    public void OnExitLevel()
    {
        ExitLevel.PlayOneShot(exitLevel, 1);
    }

}
