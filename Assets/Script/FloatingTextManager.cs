using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour
{
    public GameObject textContainer;
    public GameObject textPrefabs;
    private List<FloatingText> floatingTexts = new List<FloatingText>();

    private void Update()
    {
        foreach(FloatingText txt in floatingTexts)
        {
            txt.UpdatateFloatingText();
        }
    }
    public void Show(string msg,int fontSize,Color color,Vector3 position,Vector3 motion,float duration)
    {
        FloatingText floatingtext = GetFloatingText();
        floatingtext.text.text = msg;
        floatingtext.text.fontSize = fontSize;
        floatingtext.text.color = color ;
        floatingtext.go.transform.position = Camera.main.WorldToScreenPoint(position);
        floatingtext.motion = motion;
        floatingtext.duration = duration;
        floatingtext.Show();
    }
    private FloatingText GetFloatingText()
    {
        FloatingText txt = floatingTexts.Find(t => !t.active);
        if (txt == null)
        {
            txt = new FloatingText();
            txt.go = Instantiate(textPrefabs);
            txt.go.transform.SetParent(textContainer.transform);
            txt.text = txt.go.GetComponent<Text>();
            floatingTexts.Add(txt);
        }
        return txt;
    }
}
