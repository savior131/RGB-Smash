using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : SingltonPattern
{
    [Header("Dash")]
    [SerializeField] AudioClip DashClip;
    [SerializeField][Range(0, 1)] float volume;
    [Header("destroy enemy")]
    [SerializeField] AudioClip destroyEnemyClip;
    [SerializeField][Range(0, 1)] float destroyEnemyVolume;
    [Header("player heart")]
    [SerializeField] AudioClip playerHeartClip;
    [SerializeField][Range(0, 1)] float playerHeartVolume;
    [Header("destroy player")]
    [SerializeField] AudioClip destroyPlayerClip;
    [SerializeField][Range(0, 1)] float destroyPlayerVolume;
    [Header("Music BackGround")]
    [SerializeField] AudioSource MusicBackGround;

    private void Awake()
    {
        mangeSelgalton();
    }

    public void playDashSoundEffect()
    {
        AudioSource.PlayClipAtPoint(DashClip, Camera.main.transform.position, volume);
    }
    public void playDestoryEnemyEffect()
    {
        AudioSource.PlayClipAtPoint(destroyEnemyClip, Camera.main.transform.position, destroyEnemyVolume);
    }
    public void playPlayerHeartEffect()
    {
        AudioSource.PlayClipAtPoint(playerHeartClip, Camera.main.transform.position, playerHeartVolume);
    }
    public void playDestoryPlayerEffect()
    {
        AudioSource.PlayClipAtPoint(destroyPlayerClip, Camera.main.transform.position, destroyPlayerVolume);
    }
    public void decreaseVolumeMusicBackGround()
    {
        StartCoroutine(DecreasVolumeMusicBackGround());
    }
    public void increaseVolumeBGMusic()
    {
        StartCoroutine(increaseVolumeMusicBackGround());
    }

    IEnumerator increaseVolumeMusicBackGround()
    {
        while (true) 
        {
            MusicBackGround.volume += 0.01f;
            yield return new WaitForSeconds(0.03f);
            if(MusicBackGround.volume >= 0.3)
                StopAllCoroutines();
        }
    }

    IEnumerator DecreasVolumeMusicBackGround()
    {
        while (true)
        {
            MusicBackGround.volume -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            if (MusicBackGround.volume <= 0.2f)
                StopAllCoroutines();
        }
    }
}
