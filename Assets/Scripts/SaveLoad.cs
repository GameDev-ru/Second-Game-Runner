using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad 
{

    private static string path = Application.persistentDataPath + "Fucking.save"; 
    private static BinaryFormatter formatter = new BinaryFormatter();

    public static void SaveGame(float vol) 
    {

        FileStream fs = new FileStream(path, FileMode.Create); 

        AudioSave data = new AudioSave(vol); //Получение данных

        formatter.Serialize(fs, data); //Сериализация данных

        fs.Close();

    }

    public static AudioSave LoadGame() //Метод загрузки
    {
        if (File.Exists(path))
        { //Проверка существования файла сохранения
            FileStream fs = new FileStream(path, FileMode.Open); //Открытие потока

            AudioSave data = formatter.Deserialize(fs) as AudioSave; //Получение данных

            fs.Close(); //Закрытие потока

            return data; //Возвращение данных
        }
        else
        {
            return null; //Если файл не существует, будет возвращено null
        }

    }
}
