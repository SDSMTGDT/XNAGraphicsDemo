///
/// The sprite class contains a texture and information about how to draw it
/// to the screen, the information can be modified to accomplish rotation
/// and other actions.
///
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace XNAGraphicsDemo_Presentation.Classes
{
    public class Sprite
    {
        //C# properties allow the information to be automatically modified and
        //retrieved.
        internal Texture2D texture { get; set; }
        internal Vector2 position { get; set; }
        internal float angle { get; set; }
        internal int rows { get; set; }
        internal int columns { get; set; }
        internal int totalFrames { get; set; }
        internal int currentFrame { get; set; }

        //this constructor only needs the texture that will be drawn
        public Sprite(Texture2D texture, int rows = 1, int columns = 1, float angle = 0)
        {
            this.texture = texture;
            this.angle = angle;
            this.rows = rows;
            this.columns = columns;
            totalFrames = rows * columns;
            position = new Vector2(0, 0);
        }

        //this constructor allows the Sprite to be drawn at a given position.
        public Sprite(Texture2D texture, Vector2 position, int rows = 1, int columns = 1, float angle = 0)
        {
            this.texture = texture;
            this.position = position;
            this.angle = angle;
            this.rows = rows;
            this.columns = columns;
            totalFrames = rows * columns;
        }

        public void Update(GameTime time)
        {
            if (totalFrames > 1)
            {
                currentFrame++;
                if (currentFrame == totalFrames)
                {
                    currentFrame = 0;
                }
            }
        }

        /// <summary>
        /// The draw method takes the game's spriteBatch and handles drawing
        /// the sprite using the spriteBatch.
        /// </summary>
        /// <param name="spriteBatch">The spriteBatch for this sprite</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            int width = texture.Width / columns;
            int height = texture.Height / rows;
            int row = (int)((float)currentFrame / (float)columns);
            int column = currentFrame % columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(position.ToPoint(),new Point(width,height));

            spriteBatch.Begin();
            spriteBatch.Draw(
                texture: texture,
                sourceRectangle: sourceRectangle,
                destinationRectangle: destinationRectangle,
                origin: new Vector2(width/2,height/2),
                rotation: angle);
            spriteBatch.End();
        }

    }
}
