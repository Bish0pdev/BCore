using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace BCore
{
    public static class SimpleTextures
    {
        public static Texture2D CreateWireframeCircleTexture(int radius, Color color, int lineThickness, GraphicsDevice graphicsDevice)
        {
            int diameter = radius * 2;
            Texture2D texture = new Texture2D(graphicsDevice, diameter, diameter);

            Color[] data = new Color[diameter * diameter];
            float radiusSquared = radius * radius;
            int innerRadiusSquared = (radius - lineThickness) * (radius - lineThickness);

            for (int x = 0; x < diameter; x++)
            {
                for (int y = 0; y < diameter; y++)
                {
                    int index = x + y * diameter;
                    Vector2 position = new Vector2(x - radius, y - radius);
                    float distanceSquared = position.LengthSquared();

                    if (distanceSquared <= radiusSquared && distanceSquared >= innerRadiusSquared)
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

        public static Texture2D CreateWireframeSquareTexture(GraphicsDevice graphicsDevice, int sideLength, Color color, int lineThickness)
        {
            Texture2D texture = new Texture2D(graphicsDevice, sideLength, sideLength);
            Color[] data = new Color[sideLength * sideLength];

            for (int i = 0; i < data.Length; i++)
            {
                int x = i % sideLength;
                int y = i / sideLength;

                if (x < lineThickness || x >= sideLength - lineThickness || y < lineThickness || y >= sideLength - lineThickness)
                {
                    data[i] = color;
                }
                else
                {
                    data[i] = Color.Transparent;
                }
            }

            texture.SetData(data);
            return texture;
        }
        public static Texture2D CreateWireframeSquareTexture(GraphicsDevice graphicsDevice, Rectangle bounds, Color color, int lineThickness)
        {
            Texture2D texture = new Texture2D(graphicsDevice, bounds.Width, bounds.Height);
            Color[] data = new Color[bounds.Width * bounds.Height];

            for (int i = 0; i < data.Length; i++)
            {
                int x = i % bounds.Width;
                int y = i / bounds.Width;

                if (x < lineThickness || x >= bounds.Width - lineThickness || y < lineThickness || y >= bounds.Height - lineThickness)
                {
                    data[i] = color;
                }
                else
                {
                    data[i] = Color.Transparent;
                }
            }

            texture.SetData(data);
            return texture;
        }

        public static Texture2D CreateWireframeTriangleTexture(GraphicsDevice graphicsDevice, int sideLength, Color color, int lineThickness)
        {
            Texture2D texture = new Texture2D(graphicsDevice, sideLength, sideLength);
            Color[] data = new Color[sideLength * sideLength];

            // Draw the wireframe triangle
            int halfLength = sideLength / 2;
            int topX = halfLength;
            int bottomY = sideLength - 1;

            for (int x = 0; x < sideLength; x++)
            {
                for (int y = 0; y < sideLength; y++)
                {
                    if (
                        y == bottomY ||
                        (y == 0 && x >= halfLength - lineThickness && x <= halfLength + lineThickness) ||
                        (y == topX - x && x < halfLength + lineThickness && x > halfLength - lineThickness && y <= topX)
                    )
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
