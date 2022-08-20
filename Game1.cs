using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace statePrac
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public static int WIDTH = 1280;
        public static int HEIGHT = 720;
        public static int BUTTON_RAD = 56;
        Texture2D background;
        Texture2D button1;
        Texture2D button2;
        Texture2D button3;

        SpriteFont gameFont;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = WIDTH;
            _graphics.PreferredBackBufferHeight = HEIGHT;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            button1 = Content.Load<Texture2D>("button");
            button2 = Content.Load<Texture2D>("button");
            button3 = Content.Load<Texture2D>("button");
            background = Content.Load<Texture2D>("space");
            gameFont = Content.Load<SpriteFont>("spaceFont");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(background, new Vector2(-500, -500), Color.White);
            _spriteBatch.Draw(button1, new Vector2((WIDTH / 2) - BUTTON_RAD, (HEIGHT / 2) - 200), Color.White);
            _spriteBatch.Draw(button2, new Vector2((WIDTH / 2) - BUTTON_RAD, (HEIGHT / 2) - BUTTON_RAD), Color.White);
            _spriteBatch.Draw(button3, new Vector2((WIDTH / 2) - BUTTON_RAD, (HEIGHT / 2) + 90), Color.White);
            _spriteBatch.DrawString(gameFont, "Start", new Vector2(WIDTH / 2 - 47, HEIGHT / 2 - 165), Color.White);
            _spriteBatch.DrawString(gameFont, "HS", new Vector2(WIDTH / 2 - 25, HEIGHT / 2 - 25), Color.White);
            _spriteBatch.DrawString(gameFont, "Exit", new Vector2(WIDTH / 2 - 35, HEIGHT / 2 + 125), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}