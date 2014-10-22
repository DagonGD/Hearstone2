using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Hearthtone2.MonoFront
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Hearthtone2 : Game
    {
        private GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;
	    private Texture2D _cardTexture;
	    private GameObjects _gameObjects;
		private KeyboardState _oldState;
	    private SpriteFont _font;

        public Hearthtone2()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "../../Content";
			_gameObjects=new GameObjects();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            _gameObjects.Init();
	        _oldState = Keyboard.GetState();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);
	        _cardTexture = Content.Load<Texture2D>("card");
			//_font = Content.Load<SpriteFont>("Arial");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
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

			if (newState.IsKeyDown(Keys.Space) && _oldState.IsKeyDown(Keys.Space))
			{
				_gameObjects.Turn();
			}

	        _oldState = newState;
			base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

			//_spriteBatch.DrawString();

	        for (int index = 0; index < _gameObjects.Table.Player1.Hand.Count; index++)
	        {
		        var card = _gameObjects.Table.Player1.Hand[index];
		        _spriteBatch.Draw(_cardTexture, new Rectangle(286*index, 0, 286, 401), Color.White);
	        }

	        _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
