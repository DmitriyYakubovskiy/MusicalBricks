using Assets.Scripts;
using System.Globalization;
using System.IO;
using System.Linq;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource audioSource;
    private WWW www;
    private string directoryPath = "Musics";

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>(); 
        if (string.IsNullOrEmpty(CurrentMap.MusicName)) return;
        if (!File.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);

        string[] fileNames = Directory.GetFiles(directoryPath, "*.mp3");
        string fileName = fileNames.Where(x => x == $"{directoryPath}\\{CurrentMap.MusicName}.mp3").FirstOrDefault();
        float musicVolume = 1f;

        if (File.Exists($"{directoryPath}/{CurrentMap.MusicName}Volume.txt")) musicVolume = float.Parse(File.ReadAllText($"{directoryPath}/{CurrentMap.MusicName}Volume.txt"), CultureInfo.InvariantCulture);
        if (fileName != null)
        {
            string fullpath = $"file:///{Application.dataPath}".Replace("/Assets","");
            www = new WWW(@$"file:///{fileName}");
            Debug.Log(www.url);
            audioSource.clip = www.GetAudioClip(false, true, AudioType.MPEG);
            audioSource.volume=musicVolume;
        }
        CurrentMap.MusicName = "";
    }

    private void Update()
    {
        if (!audioSource.isPlaying) audioSource.Play();
    }
}
