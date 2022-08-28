using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace statePrac.States
{
    public class GameState : State
    {

        Texture2D background;
        SpriteFont gameFont;

        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager Content)
          : base(game, graphicsDevice, Content)
        {
            background = Content.Load<Texture2D>("background");
            gameFont = Content.Load<SpriteFont>("galleryFont");
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(background, new Vector2(-500, -500), Color.White);
            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}