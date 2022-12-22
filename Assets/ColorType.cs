using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Color", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class ColorType : ScriptableObject
{
    //��Ҫ�ƶ�����ű���λ��
    public int rgb;
    
    public string objname;
    public static ColorType AddColor(ColorType a,ColorType b)
    {
        ColorType c = new ColorType();
        c.rgb = a.rgb + b.rgb;
        return c;
    }
    //��Ҫ����һ��rgbֵ��Ӧ����ͼ
}
