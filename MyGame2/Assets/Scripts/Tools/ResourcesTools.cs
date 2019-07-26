using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ResourcesTools  {

    /// <summary>
    /// 加载文件夹中的图片资源，以<名称,图片>方式存储
    /// </summary>
	public static Dictionary<string , Sprite> LoadFolderSprites( string floderName , Dictionary<string, Sprite> dic )
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>(floderName);
        for( int i = 0; i < sprites.Length; i++)
        {
            dic.Add(sprites[i].name, sprites[i]);
        }
        return dic;
    }

    /// <summary>
    /// 通过名称从字典中获取图片
    /// </summary>
    /// <returns></returns>
    public static Sprite GetSpriteByName( string imageName , Dictionary<string, Sprite> dic)
    {
        Sprite sprite = null;
        dic.TryGetValue(imageName,  out sprite);
        return sprite;
    }

}
