using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_Basic_Top_Down
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        KeyboardState state;


        // Textures
        Texture2D pacRightTexture;
        Texture2D pacLeftTexture;
        Texture2D pacUpTexture;
        Texture2D pacDownTexture;
        Texture2D currentPacTexture;
        Rectangle pacRect;

        int pacSpeed;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            pacSpeed = 3;

            base.Initialize();

            pacRect = new Rectangle(0, 0, 50, 50);

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            pacDownTexture = Content.Load<Texture2D>("pac_down");
            pacUpTexture = Content.Load<Texture2D>("pac_up");
            pacRightTexture = Content.Load<Texture2D>("pac_right");
            pacLeftTexture = Content.Load<Texture2D>("pac_left");
            currentPacTexture = pacRightTexture;
        }

        protected override void Update(GameTime gameTime)
        {
            state = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (state.IsKeyDown(Keys.Left))
            {
                pacRect.X -= pacSpeed;
                currentPacTexture = pacLeftTexture;
            }
            if (state.IsKeyDown(Keys.Right))
            {
                pacRect.X += pacSpeed;
                currentPacTexture = pacRightTexture;
            }
            if (state.IsKeyDown(Keys.Up))
            {
                pacRect.Y -= pacSpeed;
                currentPacTexture = pacUpTexture;
            }
            if (state.IsKeyDown(Keys.Down))
            {
                pacRect.Y += pacSpeed;
                currentPacTexture = pacDownTexture;
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(currentPacTexture, pacRect, Color.White);
            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
