using System.Collections.Generic;
using Hearstone2.Core;
using Hearstone2.Core.Cards;
using Hearstone2.Core.Cards.Druid;
using Hearstone2.Core.Cards.Mage;
using Hearstone2.Core.Cards.Neutral;
using Hearstone2.Core.Classes;
using Hearthtone2.MonoFront.Components;
using Hearthtone2.MonoFront.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Hearthtone2.MonoFront
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Hearthtone2Game : Game
    {
	    private GraphicsDeviceManager _graphics;
	    public Table Table;
		public GameMode CurrentGameMode;
		public PlacedCard CurrentlyPlayingCard;
	    public CardFaceStorage CardFaceStorage;
	    public PlacedCardsStorage PlacedCardsStorage;

        public Hearthtone2Game()
        {
            _graphics = new GraphicsDeviceManager(this);
			_graphics.IsFullScreen = false;
			_graphics.PreferredBackBufferWidth = 1024;
			_graphics.PreferredBackBufferHeight = 768;
			Content.RootDirectory = "../../Content";
	        this.IsMouseVisible = true;

			Table = new Table(
				new Druid
				{
					Deck = new List<Card> { new BluegillWarrior(), new IronbarkProtector(), new BluegillWarrior(), new IronbarkProtector() }
				},
				new Mage
				{
					Deck = new List<Card> { new Fireball(), new BluegillWarrior(), new Fireball(), new Fireball(), new Fireball(), new Fireball() }
				});
			CurrentGameMode = GameMode.SelectCard;
			CardFaceStorage = new CardFaceStorage(this);
			PlacedCardsStorage = new PlacedCardsStorage();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
	        Components.Add(new TableComponent(this));
			Components.Add(new TargetArrowComponent(this));

			Components.Add(new DeckComponent(this, Table.Player1, new Point(850, 550)));
			Components.Add(new DeckComponent(this, Table.Player2, new Point(850, -20)));

			Components.Add(new HandComponent(this, Table.Player1, new Point(0, 550)));
			Components.Add(new HandComponent(this, Table.Player2, new Point(0, -20)));

			Components.Add(new PlacedMinionsComponent(this, Table.Player1, new Point(0, 360)));
			Components.Add(new PlacedMinionsComponent(this, Table.Player2, new Point(0, 170)));

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
	        CardFaceStorage.LoadContent();
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
