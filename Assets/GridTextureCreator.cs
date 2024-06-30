using UnityEngine;

public class GridTextureCreator : MonoBehaviour
{
    public int textureSize = 256; // Size of the texture (must be a power of two)
    public Color backgroundColor = Color.white; // Color of the background
    public Color xAxisColor = Color.red; // Color of the X-axis lines
    public Color zAxisColor = Color.blue; // Color of the Z-axis lines
    public int gridSpacing = 16; // Spacing between grid lines in pixels
    public int lineWidth = 2; // Width of the grid lines in pixels
    public Material targetMaterial; // Material to apply the texture to

    void Start()
    {
        CreateAndApplyGridTexture();
    }

    void CreateAndApplyGridTexture()
    {
        // Create the texture
        Texture2D texture = new Texture2D(textureSize, textureSize);
        texture.filterMode = FilterMode.Point;

        // Fill the texture with the background color
        Color[] pixels = new Color[textureSize * textureSize];
        for (int i = 0; i < pixels.Length; i++)
        {
            pixels[i] = backgroundColor;
        }
        texture.SetPixels(pixels);

        // Draw lines on the X-axis
        for (int y = 0; y < textureSize; y += gridSpacing)
        {
            for (int x = 0; x < textureSize; x++)
            {
                for (int w = 0; w < lineWidth; w++)
                {
                    if (y + w < textureSize)
                    {
                        texture.SetPixel(x, y + w, xAxisColor); // Horizontal lines (X-axis)
                    }
                }
            }
        }

        // Draw lines on the Z-axis
        for (int x = 0; x < textureSize; x += gridSpacing)
        {
            for (int y = 0; y < textureSize; y++)
            {
                for (int w = 0; w < lineWidth; w++)
                {
                    if (x + w < textureSize)
                    {
                        texture.SetPixel(x + w, y, zAxisColor); // Vertical lines (Z-axis)
                    }
                }
            }
        }

        texture.Apply();

        // Assign the texture to the material
        if (targetMaterial != null)
        {
            targetMaterial.mainTexture = texture;
        }
    }
}
