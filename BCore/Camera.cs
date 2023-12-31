using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BCore
{
    public class Camera
    {
        public Vector2 Position { get; set; }
        public Matrix TransformMatrix => Matrix.CreateTranslation(new Vector3(-Position, 0f));

        public Camera(Vector2 position)
        {
            Position = position;
        }

        public Vector2 WorldToViewport(Vector2 worldPosition, Viewport viewport)
        {
            // Apply the camera's position to convert world position to viewport position
            Vector2 transformedPosition = Vector2.Transform(worldPosition, TransformMatrix);

            // Convert to viewport coordinates
            Vector2 viewportPosition = new Vector2
            {
                X = transformedPosition.X + viewport.Width / 2,
                Y = transformedPosition.Y + viewport.Height / 2
            };

            return viewportPosition;
        }
    }
}
