using UnityEngine;

[CreateAssetMenu(fileName = "Color Library", menuName = "Scriptable Objects/Color Library")]
public class ColorLibrary : ScriptableObject
{
    [System.Serializable]
    public class Colors
    {
        public Color primaryColor;
        public Color secondaryColor;
        public Gradient gradient;
        public Color cylinderColor;
        public Color ballColor;
    }

    [NonReorderable]
    public Colors[] colors;
}
