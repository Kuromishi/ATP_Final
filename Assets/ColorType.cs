using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Color", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class ColorType : ScriptableObject
{
    //不要移动这个脚本的位置
    public int rgb;
    
    public string objname;
    public static ColorType AddColor(ColorType a,ColorType b)
    {
        ColorType c = new ColorType();
        c.rgb = a.rgb + b.rgb;
        return c;
    }
    //需要定义一下rgb值对应的贴图
}
