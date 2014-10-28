using Microsoft.Xna.Framework;

namespace Hearthtone2.MonoFront.Extensions
{
    public static class RectangleExtension
    {
        public static Vector2 ToVector(this Rectangle rectangle)
        {
            return new Vector2(rectangle.X, rectangle.Y);
        }
    }
}
