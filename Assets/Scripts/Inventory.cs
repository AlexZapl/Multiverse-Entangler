using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public enum items
    {
        Rock,
        StonePickAxe,
        Heart
    }

    public enum invslots
    {
        HB0, HB1, HB2, HB3, HB4, HB5, HB6, HB7, HB8,

        Inv0, Inv1, Inv2, Inv3, Inv4, Inv5, Inv6, Inv7, Inv8, Inv9,
        Inv10, Inv11, Inv12, Inv13, Inv14, Inv15, Inv16, Inv17, Inv18, Inv19,
        Inv20, Inv21, Inv22, Inv23, Inv24, Inv25, Inv26, Inv27, Inv28, Inv29,
        Inv30, Inv31, Inv32, Inv33, Inv34, Inv35, Inv36, Inv37, Inv38, Inv39,
        Inv40, Inv41, Inv42, Inv43, Inv44
    }

    [SerializeField] List<GameObject> HotbarBtns = new List<GameObject>();
    [SerializeField] List<GameObject> InvBtns = new List<GameObject>();
    Dictionary<invslots, GameObject> slots = new Dictionary<invslots, GameObject>();
    Dictionary<invslots, items> inv = new Dictionary<invslots, items>();
    void Start()
    {
        for (int i = 0; i < HotbarBtns.Count; i++)
        {
            slots[(invslots)i] = HotbarBtns[i];
        }

        for (int i = 0; i < InvBtns.Count; i++)
        {
            slots[(invslots)(i + 9)] = InvBtns[i];
        }
        SaveScore();
        LoadScore();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SaveScore()
    {
        PlayerPrefsHelper.SetDictionaryInvslotsGameObject("slots", slots);
        PlayerPrefsHelper.SetDictionaryInvslotsItems("inv", inv);
    }

    private void LoadScore()
    {
        slots = PlayerPrefsHelper.GetDictionaryInvslotsGameObject("slots");
        inv = PlayerPrefsHelper.GetDictionaryInvslotsItems("inv");
    }
}
