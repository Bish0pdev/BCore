using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace BCore
{
    public class Entity
    {
        public Vector2 Position { get; set; }
        public float Rotation { get; set; }
        public Vector2 Scale { get; set; }
        public Vector2 Origin { get; set; } = Vector2.Zero;

        private List<Component> components = new List<Component>();

        public Entity() 
        { Position = Vector2.Zero; Rotation = 0; Scale = Vector2.One; }

        public Entity(Vector2 position, float rotation, Vector2 scale, List<Component> components)
        {
            Position = position;
            Rotation = rotation;
            Scale = scale;
            this.components = components;
        }
        

        public void MoveTo(Vector2 position)
        {
            Position = position;
        }

        public void Rotate(float angle)
        {
            Rotation += angle;
        }

        public void SetScale(Vector2 scale)
        {
            Scale = scale;
        }

        public Component AddComponent(Component component)
        {
            components.Add(component);
            component.Initialize(this);
            return component;
        }

        public T GetComponent<T>() where T : Component
        {
            foreach (var component in components)
            {
                if (component is T typedComponent)
                {
                    return typedComponent;
                }
            }

            return null;
        }

        // Update all components attached to the entity
        public virtual void Update(GameTime gameTime)
        {
            foreach (var component in components)
            {
                component.Update(gameTime);
            }
        }

        // Draw all components attached to the entity
        public virtual void Draw(SpriteBatch batch)
        {
            foreach (var component in components)
            {
                component.Draw(batch);
            }
        }
    }
}
