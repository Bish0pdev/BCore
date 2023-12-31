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

        public abstract void Update(GameTime gameTime);
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
        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(texture, entity.Position, null, color, entity.Rotation, entity.Origin, entity.Scale, SpriteEffects.None, 0f);
        }
    }

    public class PhysicsComponent : Component
    {
        private Vector2 velocity = Vector2.Zero;
        private float gravity = 9.8f;
        public override void Update(GameTime gameTime)
        {
            velocity.Y += gravity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            entity.Position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }

    public class BoxCollider : Component
    {
        public override void Update(GameTime gameTime)
        {
            
        }
        public override void Draw(SpriteBatch batch)
        {
            //batch.Draw(SimpleTextures.CreateSquareTexture(batch.GraphicsDevice, (int)Math.Round(entity.Scale.Length()), new Color(Color.Red,0.1f)), entity.Position, Color.White);
        }
    }
}