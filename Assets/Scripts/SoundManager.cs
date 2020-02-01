using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Audio Clips")]
    public AudioClip workingMovement;
    public AudioClip movementStartOneshot;
    public AudioClip movementStopOneshot;

    public AudioClip brokenJump;
    public AudioClip workingJump;

    public AudioClip impact1;
    public AudioClip impact2;
    public AudioClip impact3;
    public AudioClip impact4;

    public AudioClip repairSound;
    public AudioClip exitLevel;

    [Header("Audio Sources")]
    public AudioSource P1_Movement;
    public AudioSource P1_OneShots;
    public AudioSource P2_Movement;
    public AudioSource P2_OneShots;
    public AudioSource ExitLevel;
    public AudioSource RepairStation;
    public AudioSource Music;

    void Start()
    {
        MusicStart();
    }

    public void OnWorkingMovementStart(int playerNumber)
    {
        if (playerNumber == 1)
        {
            P1_Movement.Play();
            P1_OneShots.PlayOneShot(movementStartOneshot, 0.3f);
        }
        if (playerNumber == 2)
        {
            P2_Movement.Play();
            P2_OneShots.PlayOneShot(movementStartOneshot, 0.3f);
        }
    }

    public void OnWorkingMovementStop(int playerNumber)
    {
        if (playerNumber == 1)
        {
            P1_Movement.Stop();
            P1_OneShots.PlayOneShot(movementStopOneshot, 0.3f);
        }
        if (playerNumber == 2)
        {
            P2_Movement.Stop();
            P2_OneShots.PlayOneShot(movementStopOneshot, 0.3f);
        }
    }


    public void OnBrokenJump(int playerNumber)
    {
        if (playerNumber == 1)
        {
            P1_OneShots.PlayOneShot(brokenJump, 0.5f);
        }
        if (playerNumber == 2)
        {
            P2_OneShots.PlayOneShot(brokenJump, 0.5f);
        }
    }

    public void OnWorkingJump(int playerNumber)
    {
        if (playerNumber == 1)
        {
            P1_OneShots.PlayOneShot(workingJump, 0.5f);
        }
        if (playerNumber == 2)
        {
            P2_OneShots.PlayOneShot(workingJump, 0.5f);
        }
    }

    public void OnRepair()
    {
        RepairStation.PlayOneShot(repairSound, 0.7f);
    }

    public void OnExitLevel()
    {
        ExitLevel.PlayOneShot(exitLevel, 0.5f);
        MusicStop();
    }

    public void MusicStart()
    {
        Music.Play();
    }

    public void MusicStop()
    {
        Music.Stop();
    }

    public void OnImpact(int playerNumber)
    {
        AudioClip[] impacts = {impact1, impact2, impact3, impact4};

        if (playerNumber == 1)
        {
            P1_OneShots.PlayOneShot(impacts[Random.Range(0, impacts.Length)], 0.8f);
        }
        if (playerNumber == 2)
        {
            P2_OneShots.PlayOneShot(impacts[Random.Range(0, impacts.Length)], 0.8f);
        }
    }
}
