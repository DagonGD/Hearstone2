using System.Collections.Generic;
using Hearstone2.Core;
using Hearstone2.Core.Cards;
using Hearstone2.Core.Cards.Druid;
using Hearstone2.Core.Cards.Mage;
using Hearstone2.Core.Cards.Neutral;
using Hearstone2.Core.Heroes.Druid;
using Hearstone2.Core.Heroes.Mage;
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
	    private readonly GraphicsDeviceManager _graphics;
	    public Table Table;
		public GameMode CurrentGameMode { get; private set; }
		public PlacedCard CurrentlyPlayingCard { get;private set; }
	    public CardFaceStorage CardFaceStorage;
        public AvatarStorage AvatarStorage;
        public AbilityStorage AbilityStorage;
	    public FontsStorage FontsStorage;

        public Hearthtone2Game()
        {
            _graphics = new GraphicsDeviceManager(this)
                {
                    IsFullScreen = false,
                    PreferredBackBufferWidth = 1600,
                    PreferredBackBufferHeight = 900
                };
            Content.RootDirectory = "../../Content";
	        IsMouseVisible = true;

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
            AvatarStorage = new AvatarStorage(this);
            AbilityStorage = new AbilityStorage(this);
			FontsStorage = new FontsStorage(this);
        }

		public void ResetGameMode()
		{
			CurrentlyPlayingCard = null;
			CurrentGameMode = GameMode.SelectCard;
		}

		public void SelectTargetFor(PlacedCard currentlyPlayingCard)
		{
			CurrentlyPlayingCard = currentlyPlayingCard;
			CurrentGameMode = GameMode.SelectTarget;
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

            Components.Add(new DeckComponent(this, Table.Player1, new Point(GraphicsDevice.Viewport.Width - PlacedCard.Width, GraphicsDevice.Viewport.Height - PlacedCard.Height)));
            Components.Add(new HandComponent(this, Table.Player1, new Point(0, GraphicsDevice.Viewport.Height - PlacedCard.Height)));
            Components.Add(new PlacedMinionsComponent(this, Table.Player1, new Point(0, GraphicsDevice.Viewport.Height - 2 * PlacedCard.Height)));
            Components.Add(new HeroAvatarComponent(this, Table.Player1, new Point(GraphicsDevice.Viewport.Width - PlacedCard.Width - HeroAvatarComponent.Width, GraphicsDevice.Viewport.Height - HeroAvatarComponent.Height - HeroAbilityComponent.Height)));
            Components.Add(new HeroAbilityComponent(this, Table.Player1, new Point(GraphicsDevice.Viewport.Width - PlacedCard.Width - HeroAvatarComponent.Width, GraphicsDevice.Viewport.Height - HeroAvatarComponent.Height)));

            Components.Add(new DeckComponent(this, Table.Player2, new Point(GraphicsDevice.Viewport.Width - PlacedCard.Width, -20)));
            Components.Add(new HandComponent(this, Table.Player2, new Point(0, -20)));
            Components.Add(new PlacedMinionsComponent(this, Table.Player2, new Point(0, PlacedCard.Height)));
            Components.Add(new HeroAvatarComponent(this, Table.Player2, new Point(GraphicsDevice.Viewport.Width - PlacedCard.Width - HeroAvatarComponent.Width, 0)));
            Components.Add(new HeroAbilityComponent(this, Table.Player2, new Point(GraphicsDevice.Viewport.Width - PlacedCard.Width - HeroAvatarComponent.Width, HeroAvatarComponent.Height)));

            Components.Add(new TargetArrowComponent(this));

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
	        CardFaceStorage.LoadContent();
            AvatarStorage.LoadContent();
            AbilityStorage.LoadContent();
			FontsStorage.LoadContent();
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
