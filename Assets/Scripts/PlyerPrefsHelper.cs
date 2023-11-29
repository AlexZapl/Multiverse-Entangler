using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PlayerPrefsHelper : MonoBehaviour
{
    public static void SetDictionaryInvslotsGameObject(string key, Dictionary<Inventory.invslots, GameObject> dict)
    {
        BinaryFormatter bf = new BinaryFormatter();
        MemoryStream ms = new MemoryStream();
        bf.Serialize(ms, dict);
        PlayerPrefs.SetString(key, System.Convert.ToBase64String(ms.ToArray()));
        PlayerPrefs.Save();
    }

    public static Dictionary<Inventory.invslots, GameObject> GetDictionaryInvslotsGameObject(string key)
    {
        Dictionary<Inventory.invslots, GameObject> dict = new Dictionary<Inventory.invslots, GameObject>();
        if (PlayerPrefs.HasKey(key))
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(System.Convert.FromBase64String(PlayerPrefs.GetString(key)));
            dict = (Dictionary<Inventory.invslots, GameObject>)bf.Deserialize(ms);
        }
        return dict;
    }



    public static void SetDictionaryInvslotsItems(string key, Dictionary<Inventory.invslots, Inventory.items> dict)
    {
        BinaryFormatter bf = new BinaryFormatter();
        MemoryStream ms = new MemoryStream();
        bf.Serialize(ms, dict);
        PlayerPrefs.SetString(key, System.Convert.ToBase64String(ms.ToArray()));
        PlayerPrefs.Save();
    }

    public static Dictionary<Inventory.invslots, Inventory.items> GetDictionaryInvslotsItems(string key)
    {
        Dictionary<Inventory.invslots, Inventory.items> dict = new Dictionary<Inventory.invslots, Inventory.items>();
        if (PlayerPrefs.HasKey(key))
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(System.Convert.FromBase64String(PlayerPrefs.GetString(key)));
            dict = (Dictionary<Inventory.invslots, Inventory.items>)bf.Deserialize(ms);
        }
        return dict;
    }
}