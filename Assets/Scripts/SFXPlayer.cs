using System.Collections.Generic;
using UnityEngine;

public enum SFX
{
    PlayerBallHitBall,
    OtherBallHitBall,
    BallHitWall,
    GoodBallInHole,
    BadBallInHole,
    EightBallInHole,
    TimeUp,
    Bomb,
    HighScore,
    TimeAlmostUp,
    Go
}

public class SFXPlayer : MonoBehaviour
{

    [SerializeField] 
    private AudioClip playerBallHitBall = null;

    [SerializeField] 
    private AudioClip otherBallHitBall = null;

    [SerializeField] 
    private AudioClip ballHitWall = null;

    [SerializeField] 
    private AudioClip goodBallInHole = null;

    [SerializeField] 
    private AudioClip badBallInHole = null;

    [SerializeField] 
    private AudioClip eightBallInHole = null;

    [SerializeField] 
    private AudioClip timeUp = null;

    [SerializeField] 
    private AudioClip bomb = null;

    [SerializeField] 
    private AudioClip highScore = null;

    [SerializeField] 
    private AudioClip timeAlmostUp = null;

    [SerializeField] 
    private AudioClip go = null;

    private static AudioSource audioPlayer;

    private static Dictionary<SFX, AudioClip> clips = new Dictionary<SFX, AudioClip>();

    private void Awake()
    {
        audioPlayer = GetComponent<AudioSource>();
        clips.Add(SFX.PlayerBallHitBall, playerBallHitBall);
        clips.Add(SFX.OtherBallHitBall, otherBallHitBall);
        clips.Add(SFX.BallHitWall, ballHitWall);
        clips.Add(SFX.GoodBallInHole, goodBallInHole);
        clips.Add(SFX.BadBallInHole, badBallInHole);
        clips.Add(SFX.EightBallInHole, eightBallInHole);
        clips.Add(SFX.TimeUp, timeUp);
        clips.Add(SFX.Bomb, bomb);
        clips.Add(SFX.HighScore, highScore);
        clips.Add(SFX.TimeAlmostUp, timeAlmostUp);
        clips.Add(SFX.Go, go);
    }

    internal static void PlayClip(SFX sfx)
    {
        audioPlayer.PlayOneShot(clips[sfx]);
    }

}
