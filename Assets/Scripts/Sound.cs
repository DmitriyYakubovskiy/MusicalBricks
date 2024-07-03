using UnityEngine;
using UnityEngine.Audio;
public class Sound : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup mixerGroup;
    [SerializeField] private float volume = 0.2f;
    private AudioSource audioSrc => GetComponent<AudioSource>();

    public float Volume => volume;
    public SoundArray[] sounds;

    private void Awake()
    {
        audioSrc.outputAudioMixerGroup = mixerGroup;
    }

    public void PlaySound()
    {
        PlaySound(0, isDestroyed: true);
    }

    public void PlaySound(int i, float volume = 1f, bool isDestroyed = false)
    {
        AudioClip clip = sounds[0].soundArray[i];
        if (isDestroyed) CreateAudioInPoint(clip, mixerGroup, volume);
        else audioSrc.PlayOneShot(clip, volume);
    }

    private void CreateAudioInPoint(AudioClip clip, AudioMixerGroup mixerGroup, float volume, float p1 = 0.85f, float p2 = 1.2f, float spatialBlend = 1)
    {
        GameObject soundObj = new GameObject("Sound");
        AudioSource source = soundObj.AddComponent<AudioSource>();
        soundObj.transform.position = transform.position;

        Instantiate(soundObj);
        SetAudioParams(ref source, clip, mixerGroup, volume, p1, p2);
        source.Play();
        Destroy(soundObj, clip.length);
    }

    private void SetAudioParams(ref AudioSource source, AudioClip clip, AudioMixerGroup mixerGroup, float volume, float p1 = 0.85f, float p2 = 1.2f, float spatialBlend = 1)
    {
        source.clip = clip;
        source.outputAudioMixerGroup = mixerGroup;
        source.spatialBlend = spatialBlend;
        source.volume = volume;
        source.pitch = Random.Range(p1, p2);
    }

    [System.Serializable]
    public class SoundArray
    {
        public AudioClip[] soundArray;
    }
}

