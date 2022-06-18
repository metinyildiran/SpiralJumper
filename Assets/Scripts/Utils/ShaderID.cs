using UnityEngine;

public static class ShaderID
{
    public static int Color = Shader.PropertyToID("_Color");
    public static int BaseColor = Shader.PropertyToID("_BaseColor");
    public static int TopColor = Shader.PropertyToID("_TopColor");
    public static int BottomColor = Shader.PropertyToID("_BottomColor");
    public static int FaceColor = Shader.PropertyToID("_FaceColor");
    public static int OutlineColor = Shader.PropertyToID("_OutlineColor");
    public static int UnderlayColor = Shader.PropertyToID("_UnderlayColor");
}
