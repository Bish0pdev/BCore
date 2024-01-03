using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace BCore {

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System.Drawing;
    using Color = Color;

    /// <summary>
    /// Represents a base class for components that can be attached to entities.
    /// </summary>
    public abstract class Component
    {
        /// <summary>
        /// The entity to which this component is attached.
        /// </summary>
        protected Entity entity = new();

        /// <summary>
        /// Initializes the component with the specified entity and calls the OnInitialize method.
        /// </summary>
        /// <param name="entity">The entity to which this component is attached.</param>
        public void Initialize(Entity entity)
        {
            this.entity = entity;
            OnInitialize();
        }

        /// <summary>
        /// Performs initialization logic for the component.
        /// </summary>
        protected virtual void OnInitialize() { }

        /// <summary>
        /// Updates the component's logic based on the game time.
        /// </summary>
        /// <param name="gameTime">Snapshot of the game's timing state.</param>
        public virtual void Update(GameTime gameTime) { }

        /// <summary>
        /// Draws the component using the provided SpriteBatch.
        /// </summary>
        /// <param name="batch">The SpriteBatch used for rendering.</param>
        public virtual void Draw(SpriteBatch batch) { }
    }

    /// <summary>
    /// Represents a component that renders a sprite.
    /// </summary>
    public class SpriteRenderer : Component
    {
        /// <summary>
        /// The texture of the sprite.
        /// </summary>
        public Texture2D texture;

        /// <summary>
        /// The color tint of the sprite.
        /// </summary>
        public Color color = Color.White;

        /// <summary>
        /// Initializes a new instance of the SpriteRenderer class with a texture and color.
        /// </summary>
        /// <param name="texture">The texture of the sprite.</param>
        /// <param name="color">The color tint of the sprite.</param>
        public SpriteRenderer(Texture2D texture, Color color)
        {
            this.texture = texture;
            this.color = color;
        }

        /// <summary>
        /// Initializes a new instance of the SpriteRenderer class with a texture and default color (White).
        /// </summary>
        /// <param name="_texture">The texture of the sprite.</param>
        public SpriteRenderer(Texture2D _texture)
        {
            texture = _texture;
            color = Color.White;
        }

        /// <summary>
        /// Draws the sprite using the provided SpriteBatch.
        /// </summary>
        /// <param name="batch">The SpriteBatch used for rendering.</param>
        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(texture, entity.Position, null, color, entity.Rotation, entity.Origin, entity.Scale / texture.Bounds.Size.ToVector2(), SpriteEffects.None, 0f);
        }

        /// <summary>
        /// Performs additional initialization logic by setting the origin based on the texture's center.
        /// </summary>
        protected override void OnInitialize()
        {
            entity.Origin = texture.Bounds.Center.ToVector2();
        }
    }

    /// <summary>
    /// Represents a component that renders text using a SpriteFont.
    /// </summary>
    public class TextRenderer : Component
    {
        /// <summary>
        /// The font used for rendering text.
        /// </summary>
        public SpriteFont font;

        /// <summary>
        /// The color of the rendered text.
        /// </summary>
        public Color color = Color.White;

        /// <summary>
        /// The text to be rendered.
        /// </summary>
        public string Text = "";

        /// <summary>
        /// Initializes a new instance of the TextRenderer class with a font, text, and color.
        /// </summary>
        /// <param name="font">The font used for rendering text.</param>
        /// <param name="text">The text to be rendered.</param>
        /// <param name="color">The color of the rendered text.</param>
        public TextRenderer(SpriteFont font, string text, Color color)
        {
            this.font = font;
            this.color = color;
            Text = text;
        }

        /// <summary>
        /// Initializes a new instance of the TextRenderer class with a font and color.
        /// </summary>
        /// <param name="font">The font used for rendering text.</param>
        /// <param name="color">The color of the rendered text.</param>
        public TextRenderer(SpriteFont font, Color color)
        {
            this.font = font;
            this.color = color;
        }

        /// <summary>
        /// Initializes a new instance of the TextRenderer class with a font.
        /// </summary>
        /// <param name="font">The font used for rendering text.</param>
        public TextRenderer(SpriteFont font) { this.font = font; }

        /// <summary>
        /// Sets the text to be rendered.
        /// </summary>
        /// <param name="text">The text to be rendered.</param>
        public void SetText(string text)
        {
            Text = text;
        }

        /// <summary>
        /// Draws the text using the provided SpriteBatch.
        /// </summary>
        /// <param name="batch">The SpriteBatch used for rendering.</param>
        public override void Draw(SpriteBatch batch)
        {
            batch.DrawString(font, Text, entity.Position, color);
        }
    }
}