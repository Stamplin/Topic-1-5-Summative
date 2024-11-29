using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;

namespace Topic_1_5_Summative
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D mainMenu, backgroundTexture, sniperScopeTexture, win, lose;
        SoundEffect shotSound, tWin, ctWin, trahtalk;
        Song bgMusic;
        SpriteFont spriteFont;

        float x, y, seconds;

        enum Screen
        {
            Intro,
            Game,
            Endwin,
            Endlose
        }

        Screen screen;
        MouseState mouseState;


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
            _graphics.PreferredBackBufferHeight = 590;
            _graphics.ApplyChanges();
            seconds = 0;

            

            screen = Screen.Intro;


            base.Initialize();
            MediaPlayer.Play(bgMusic);

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //load content
            mainMenu = Content.Load<Texture2D>("mainmenu");
            shotSound = Content.Load<SoundEffect>("Pewpew");
            tWin = Content.Load<SoundEffect>("Twin");
            ctWin = Content.Load<SoundEffect>("CTwin");
            bgMusic = Content.Load<Song>("musicBg");
            spriteFont = Content.Load<SpriteFont>("File");
            backgroundTexture = Content.Load<Texture2D>("bg");
            sniperScopeTexture = Content.Load<Texture2D>("scope");  
            win = Content.Load<Texture2D>("win");
            lose = Content.Load<Texture2D>("lose");
            trahtalk = Content.Load<SoundEffect>("trashtalk");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            seconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
            mouseState = Mouse.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
           
            if (screen == Screen.Intro)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Enter)) //if keyboard pressed enter not hold down enter
                {
                    screen = Screen.Game;
                    MediaPlayer.Stop();
                    seconds = 0;
                    seconds = 0f;
                }
            }
            else if (screen == Screen.Game)
            {
                y = (float)Math.Sin(gameTime.TotalGameTime.TotalSeconds) * 20;
                x = (float)Math.Cos(gameTime.TotalGameTime.TotalSeconds) * 20;
                
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    shotSound.Play();
                    ctWin.Play();
                    screen = Screen.Endwin;
                }
                else if (seconds >= 5) //not working 
                {
                    screen = Screen.Endlose;
                    tWin.Play();
                    trahtalk.Play();
                }
            }
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            
            //mainmenu
            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(mainMenu, Vector2.Zero, Color.White);
                _spriteBatch.DrawString(spriteFont, "Press enter to start", new Vector2(450, 500), Color.Black);
            
            }
      
            //start
            if (screen == Screen.Game)
            {
                //draw the retangle background and scope
                _spriteBatch.Draw(backgroundTexture, new Vector2(x, y), Color.White);
                _spriteBatch.Draw(sniperScopeTexture, new Vector2(0, 0), Color.White);
                _spriteBatch.DrawString(spriteFont, "Press left click to shoot", new Vector2(200, 500), Color.White);

            }

            //end
            if (screen == Screen.Endwin)
            {
                _spriteBatch.Draw(win, new Vector2(0, 0), Color.White); 
            }

            if (screen == Screen.Endlose)
            {
                _spriteBatch.Draw(lose, new Vector2(0, 0), Color.White);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}