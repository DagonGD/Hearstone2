using Hearthtone2.MonoFront.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Hearthtone2.MonoFront
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Hearthtone2 : Game
    {
	    private GraphicsDeviceManager _graphics;

        public Hearthtone2()
        {
            _graphics = new GraphicsDeviceManager(this);
			_graphics.IsFullScreen = false;
			_graphics.PreferredBackBufferWidth = 1024;
			_graphics.PreferredBackBufferHeight = 768;
			Content.RootDirectory = "../../Content";
	        this.IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
	        Components.Add(new Table(this));

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
			KeyboardState newState = Keyboard.GetState();

			if (newState.IsKeyDown(Keys.Escape))
			{
				Exit();
			}
	        
			base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }
    }
}
