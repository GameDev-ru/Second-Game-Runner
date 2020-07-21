using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Работа с интерфейсами
using UnityEngine.SceneManagement; //Работа со сценами
using UnityEngine.Audio; //Работа с аудио

public class Menu1 : MonoBehaviour
{
    public float volume = 0; //Громкость
    public AudioMixer audioMixer; //Регулятор громкости

    public void ChangeVolume(float val) //Изменение звука
    {
        volume = val;
    }
    public void SaveSettings()
    {
        audioMixer.SetFloat("MasterVolume", volume); //Изменение уровня громкости
    }
}
