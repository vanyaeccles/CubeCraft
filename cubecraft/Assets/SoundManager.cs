using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    private AudioClip backgroundMusic;
    private AudioClip RotateClip;
    private AudioClip MoveClip;
    private AudioClip AddClip;
    private AudioClip DeleteClip;
    private AudioClip WinClip;
    private AudioClip LoseClip;
    private AudioSource backgroundSource;
    private AudioSource FXSource;

    void Awake()
    {
        AudioSource[] sources= GameObject.Find("Main Camera").GetComponents<AudioSource>();
        backgroundSource = sources[0];
        FXSource = sources[1];
        RotateClip= Resources.Load("Sounds/RotateSound") as AudioClip;
        MoveClip = Resources.Load("Sounds/MoveSound") as AudioClip;
        AddClip = Resources.Load("Sounds/AddSound") as AudioClip;
        WinClip = Resources.Load("Sounds/WinSound") as AudioClip;
        LoseClip = Resources.Load("Sounds/LoseSound") as AudioClip;
        DeleteClip = Resources.Load("Sounds/RemoveSound") as AudioClip;
    }
    void Start()
    {
        backgroundSource.clip = backgroundMusic;
    }

    public void playBackGroundMusic()
    {
        backgroundSource.Play();
    }

    public void playRotate()
    {
        FXSource.clip = RotateClip;
        FXSource.Play();
    }
    public void playMove()
    {
        FXSource.clip = MoveClip;
        FXSource.Play();
    }

    public void playAdd()
    {
        FXSource.clip = AddClip;
        FXSource.Play();
    }

    public void playDelete()
    {
        FXSource.clip = DeleteClip;
        FXSource.Play();
    }

    public void playWin()
    {
        FXSource.clip = WinClip;
        FXSource.Play();
    }

    public void playLose()
    {
        FXSource.clip = LoseClip;
        FXSource.Play();
    }
}
