using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace BCore
{
    public static class SimpleTextures
    {
        public static Texture2D CreateCircleTextureData(int radius, Color color,GraphicsDevice graphicsDevice)
        {
            int diameter = radius * 2;
            Texture2D texture = new Texture2D(graphicsDevice, diameter, diameter);

            Color[] data = new Color[diameter * diameter];
            float radiusSquared = radius * radius;

            for (int x = 0; x < diameter; x++)
            {
                for (int y = 0; y < diameter; y++)
                {
                    int index = x + y * diameter;
                    Vector2 position = new Vector2(x - radius, y - radius);

                    if (position.LengthSquared() <= radiusSquared)
                    {
                        data[index] = color;
                    }
                    else
                    {
                        data[index] = Color.Transparent;
                    }
                }
            }

            texture.SetData(data);
            return texture;
        }

        public static Texture2D CreateSquareTexture(GraphicsDevice graphicsDevice, int sideLength, Color color)
        {
            Texture2D texture = new Texture2D(graphicsDevice, sideLength, sideLength);
            Color[] data = new Color[sideLength * sideLength];

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = color;
            }

            texture.SetData(data);
            return texture;
        }

        public static Texture2D CreateTriangleTexture(GraphicsDevice graphicsDevice, int sideLength, Color color)
        {
            Texture2D texture = new Texture2D(graphicsDevice, sideLength, sideLength);
            Color[] data = new Color[sideLength * sideLength];

            // Assuming an equilateral triangle for simplicity
            int halfLength = sideLength / 2;

            for (int x = 0; x < sideLength; x++)
            {
                for (int y = 0; y < sideLength; y++)
                {
                    if (y <= x && y <= (sideLength - x) && y <= halfLength)
                    {
                        data[x + y * sideLength] = color;
                    }
                    else
                    {
                        data[x + y * sideLength] = Color.Transparent;
                    }
                }
            }

            texture.SetData(data);
            return texture;
        }
    }
}
