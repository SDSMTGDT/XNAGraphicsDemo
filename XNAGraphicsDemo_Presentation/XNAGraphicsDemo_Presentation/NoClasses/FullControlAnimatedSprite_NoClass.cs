///
/// This file creates a texture and then allows for full control of movement
/// and rotation. The sprite is also animated.
///
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace XNAGraphicsDemo_Presentation
{

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class FullControlAnimatedSprite_NoClass : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        KeyboardState lastState;
        Vector2 position;
        float angle;
        const float moveAmount = 0.1f;
        const float rotateAmount = 0.001f;
        Texture2D atlas;
        int Rows;
        int Columns;
        int currentFrame;
        int totalFrames;

        public FullControlAnimatedSprite_NoClass()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            position = new Vector2(200, 200);
            angle = 0;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            atlas = Content.Load<Texture2D>("SmileyWalk");
            //The number of rows and columns in the atlas
            Rows = 4;
            Columns = 4;
            totalFrames = Rows * Columns;
            //starting frame
            currentFrame = 0;


            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            //Default MonoGame exit keys
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //update the keyboard state
            lastState = Keyboard.GetState();

            ///
            /// handle moving the sprite left and right
            /// if right is pressed the sprite will not move left even if left is also pressed
            ///
            if (lastState.IsKeyDown(Keys.Right))
            {
                position += Vector2.UnitX * moveAmount * gameTime.ElapsedGameTime.Milliseconds;
            }
            else if (lastState.IsKeyDown(Keys.Left))
            {
                position += Vector2.UnitX * -moveAmount * gameTime.ElapsedGameTime.Milliseconds;
            }

            ///
            /// handle moving the sprite up and down
            /// if down is pressed the sprite will not move up even if up is also pressed
            ///
            if (lastState.IsKeyDown(Keys.Down))
            {
                position += Vector2.UnitY * moveAmount * gameTime.ElapsedGameTime.Milliseconds;
            }
            else if (lastState.IsKeyDown(Keys.Up))
            {
                position += Vector2.UnitY * -moveAmount * gameTime.ElapsedGameTime.Milliseconds;
            }

            ///
            /// handle rotating the sprite
            /// period will rotate right
            /// comma will rotate left
            /// space will reset the angle
            ///
            if (lastState.IsKeyDown(Keys.OemPeriod))
            {
                angle += rotateAmount * gameTime.ElapsedGameTime.Milliseconds;
            }
            else if (lastState.IsKeyDown(Keys.OemComma))
            {
                angle += -rotateAmount * gameTime.ElapsedGameTime.Milliseconds;
            }
            else if (lastState.IsKeyDown(Keys.Space))
            {
                angle = 0;
            }

            currentFrame++;
            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //clear the screen to remove old draws
            GraphicsDevice.Clear(Color.CornflowerBlue);
            int width = atlas.Width / Columns;
            int height = atlas.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(
                texture: atlas,
                sourceRectangle: sourceRectangle,
                destinationRectangle: destinationRectangle,
                rotation: angle,
                origin: new Vector2(width / 2, height / 2));
            spriteBatch.End();
            base.Draw(gameTime);

        }
    }
}
