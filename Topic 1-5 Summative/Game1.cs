using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Topic_1_5_Summative
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D backgroundTexture, sniperScope, mainMenu;
        SoundEffect shotSound, tWin, ctWin, bgMusic;
        SpriteFont spriteFont;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 1079;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            backgroundTexture = Content.Load<Texture2D>("bg");
            sniperScope = Content.Load<Texture2D>("scope");
            mainMenu = Content.Load<Texture2D>("mainmenu");
            shotSound = Content.Load<SoundEffect>("Pewpew");
            tWin = Content.Load<SoundEffect>("Twin");
            ctWin = Content.Load<SoundEffect>("CTwin");
            bgMusic = Content.Load<SoundEffect>("musicBg");
            spriteFont = Content.Load<SpriteFont>("File");

            // TODO: use this.Content to load your game content here
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

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            //mainmenu
            _spriteBatch.Draw(mainMenu, Vector2.Zero, Color.White);
            _spriteBatch.DrawString(spriteFont, "Press enter to start", new Vector2(450, 500), Color.Black);
            //start
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                _spriteBatch.Draw(backgroundTexture, new Vector2(600,300), Color.White);
                _spriteBatch.Draw(sniperScope, new Vector2(400, 300), Color.White);
                
            } 
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}