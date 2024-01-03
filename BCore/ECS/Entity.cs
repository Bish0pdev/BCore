using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace BCore
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Represents an entity in a game world with position, rotation, scale, and components.
    /// </summary>
    public class Entity
    {
        /// <summary>
        /// Gets or sets the position of the entity.
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// Gets or sets the rotation angle of the entity.
        /// </summary>
        public float Rotation { get; set; }

        /// <summary>
        /// Gets or sets the scale of the entity.
        /// </summary>
        public Vector2 Scale { get; set; }

        /// <summary>
        /// Gets or sets the origin point of the entity.
        /// </summary>
        public Vector2 Origin { get; set; } = Vector2.Zero;

        private List<Component> components = new List<Component>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Entity"/> class with default values.
        /// </summary>
        public Entity()
        {
            Position = Vector2.Zero;
            Rotation = 0;
            Scale = new Vector2(100);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Entity"/> class with specified parameters.
        /// </summary>
        /// <param name="position">The initial position of the entity.</param>
        /// <param name="rotation">The initial rotation angle of the entity.</param>
        /// <param name="scale">The initial scale of the entity.</param>
        /// <param name="components">The list of components to be attached to the entity.</param>
        public Entity(Vector2 position, float rotation, Vector2 scale, List<Component> components)
        {
            Position = position;
            Rotation = rotation;
            Scale = scale;
            this.components = components;
        }

        /// <summary>
        /// Moves the entity to the specified position.
        /// </summary>
        /// <param name="position">The new position of the entity.</param>
        public void MoveTo(Vector2 position)
        {
            Position = position;
        }

        /// <summary>
        /// Rotates the entity by the specified angle.
        /// </summary>
        /// <param name="angle">The angle to rotate the entity by.</param>
        public void Rotate(float angle)
        {
            Rotation += angle;
        }

        /// <summary>
        /// Sets the scale of the entity.
        /// </summary>
        /// <param name="scale">The new scale of the entity.</param>
        public void SetScale(Vector2 scale)
        {
            Scale = scale;
        }

        /// <summary>
        /// Adds a component to the entity and initializes it.
        /// </summary>
        /// <param name="component">The component to be added.</param>
        /// <returns>The added component.</returns>
        public Component AddComponent(Component component)
        {
            components.Add(component);
            component.Initialize(this);
            return component;
        }

        /// <summary>
        /// Gets the first component of type T attached to the entity.
        /// </summary>
        /// <typeparam name="T">The type of the component to retrieve.</typeparam>
        /// <returns>The component of type T if found; otherwise, null.</returns>
        public T GetComponent<T>() where T : Component
        {
            return (T)components.Find(x => x is T);
        }

        /// <summary>
        /// Updates all components attached to the entity.
        /// </summary>
        /// <param name="gameTime">Snapshot of the game's timing state.</param>
        public virtual void Update(GameTime gameTime)
        {
            foreach (var component in components)
            {
                component.Update(gameTime);
            }
        }

        /// <summary>
        /// Draws all components attached to the entity.
        /// </summary>
        /// <param name="batch">The SpriteBatch used for rendering.</param>
        public virtual void Draw(SpriteBatch batch)
        {
            foreach (var component in components)
            {
                component.Draw(batch);
            }
        }
    }

}
