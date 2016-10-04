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
    class SpriteController
    {
        private const float moveAmount = 0.1f;
        private const float rotateAmount = 0.01f;

        private Sprite sprite { get; set; }

        public SpriteController(Sprite sprite)
        {
            this.sprite = sprite;
        }

        public void Update(GameTime time, KeyboardState last)
        {
            ///
            /// handle moving the sprite left and right
            /// if right is pressed the sprite will not move left even if left is also pressed
            ///
            if (last.IsKeyDown(Keys.Right))
            {
                sprite.position += Vector2.UnitX * moveAmount * time.ElapsedGameTime.Milliseconds;
            }
            else if (last.IsKeyDown(Keys.Left))
            {
                sprite.position += Vector2.UnitX * -moveAmount * time.ElapsedGameTime.Milliseconds;
            }

            ///
            /// handle moving the sprite up and down
            /// if down is pressed the sprite will not move up even if up is also pressed
            ///
            if (last.IsKeyDown(Keys.Down))
            {
                sprite.position += Vector2.UnitY * moveAmount * time.ElapsedGameTime.Milliseconds;
            }
            else if (last.IsKeyDown(Keys.Up))
            {
                sprite.position += Vector2.UnitY * -moveAmount * time.ElapsedGameTime.Milliseconds;
            }

            ///
            /// handle rotating the sprite
            /// period will rotate right
            /// comma will rotate left
            /// space will reset the angle
            ///
            if (last.IsKeyDown(Keys.OemPeriod))
            {
                sprite.angle += rotateAmount * time.ElapsedGameTime.Milliseconds;
            }
            else if (last.IsKeyDown(Keys.OemComma))
            {
                sprite.angle += -rotateAmount * time.ElapsedGameTime.Milliseconds;
            }
            else if (last.IsKeyDown(Keys.Space))
            {
                sprite.angle = 0;
            }
            sprite.Update(time);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }
    }
}
