using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using statePrac.States;

namespace statePrac
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        /*
        public static int WIDTH = 1280;
        public static int HEIGHT = 720;
        public static int BUTTON_RAD = 56;
        Texture2D background;
        Texture2D button1;
        Texture2D button2;
        Texture2D button3;

        SpriteFont gameFont;
        */

        private State _currentState;

        private State _nextState;

        public void ChangeState(State state)
        {
            _nextState = state;
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            
            /*
            _graphics.PreferredBackBufferWidth = WIDTH;
            _graphics.PreferredBackBufferHeight = HEIGHT;
            _graphics.ApplyChanges();
            */

            IsMouseVisible = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            /*
            button1 = Content.Load<Texture2D>("button");
            button2 = Content.Load<Texture2D>("button");
            button3 = Content.Load<Texture2D>("button");
            background = Content.Load<Texture2D>("space");
            gameFont = Content.Load<SpriteFont>("spaceFont");
            */

            _currentState = new MenuState(this, graphics.GraphicsDevice, Content);
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (_nextState != null)
            {
                _currentState = _nextState;

                _nextState = null;
            }
            _currentState.Update(gameTime);
            _currentState.PostUpdate(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _currentState.Draw(gameTime, spriteBatch);

            /*
            _spriteBatch.Begin();
            _spriteBatch.Draw(background, new Vector2(-500, -500), Color.White);
            _spriteBatch.Draw(button1, new Vector2((WIDTH / 2) - BUTTON_RAD, (HEIGHT / 2) - 200), Color.White);
            _spriteBatch.Draw(button2, new Vector2((WIDTH / 2) - BUTTON_RAD, (HEIGHT / 2) - BUTTON_RAD), Color.White);
            _spriteBatch.Draw(button3, new Vector2((WIDTH / 2) - BUTTON_RAD, (HEIGHT / 2) + 90), Color.White);
            _spriteBatch.DrawString(gameFont, "Start", new Vector2(WIDTH / 2 - 47, HEIGHT / 2 - 165), Color.White);
            _spriteBatch.DrawString(gameFont, "HS", new Vector2(WIDTH / 2 - 25, HEIGHT / 2 - 25), Color.White);
            _spriteBatch.DrawString(gameFont, "Exit", new Vector2(WIDTH / 2 - 35, HEIGHT / 2 + 125), Color.White);
            _spriteBatch.End();
            */

            base.Draw(gameTime);
        }
    }
}