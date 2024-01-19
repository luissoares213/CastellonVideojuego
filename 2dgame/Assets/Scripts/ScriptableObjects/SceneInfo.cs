
using UnityEngine;

[CreateAssetMenu(fileName = "SceneInfo", menuName ="Persistance",order =0)]
public class SceneInfo : ScriptableObject
{
    public int acto = 1;
    public Vector3 cameraPos = new Vector3 (0,0,-10);
    public Vector3 periDest = new Vector3 (22, -15, 0);
    public Vector3 periMov = new Vector3(22, -15, 0);
    public string volver= "MenuInicial";
}
