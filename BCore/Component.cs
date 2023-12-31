using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace BCore
{
    public abstract class Component
    {
        protected Entity entity = new();

        public void Initialize(Entity entity)
        {
            this.entity = entity;
            OnInitialize();
        }

        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw(SpriteBatch batch) {  }

        protected virtual void OnInitialize(){}
    }

    public class SpriteRenderer : Component
    {
        public Texture2D texture;
        public Color color = Color.White;

        public SpriteRenderer(Texture2D texture, Color color)
        {
            this.texture = texture;
            this.color = color;
        }
        public SpriteRenderer(Texture2D _texture)
        {
            texture = _texture;
            color = Color.White;
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(texture, entity.Position, null, color, entity.Rotation, entity.Origin, entity.Scale, SpriteEffects.None, 0f);
        }
        protected override void OnInitialize()
        {
            entity.Origin = texture.Bounds.Center.ToVector2();
        }
    }

    public class TextRenderer : Component
    {
        public SpriteFont font;
        public Color color = Color.White;
        public string Text = "";

        public TextRenderer(SpriteFont font,string text, Color color)
        {
            this.font = font;
            this.color = color;
            this.Text = text;
        }
        public TextRenderer(SpriteFont font, Color color)
        {
            this.font = font;
            this.color = color;
        }
        public TextRenderer(SpriteFont font) { this.font = font; }
        public void SetText(string text)
        {
            Text = text;
        }
        public override void Draw(SpriteBatch batch)
        {
            batch.DrawString(font,Text,entity.Position,color);
        }
    }
}