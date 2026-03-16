using Raylib_cs;
using System.Numerics;
namespace Gamer.Player
{
    internal class Enemy
    {
        Vector2 size = new(60, 30);
        float rotation;
        public Vector2 Pos;
        public float Speed;
        public Texture2D texture;
        public Enemy(Texture2D texture, float y, int laneindex)
        {
            this.texture = texture;
            Speed = 300f;
            Pos = new(-30, y);
            if (laneindex == 0 ||laneindex == 2 ||laneindex == 6)
            {
                rotation = -180f;
                Speed = -300f;
                Pos.X = 1300;
            }
        }
        public Rectangle GetHitbox => new(Pos.X - 30, Pos.Y - 15, texture.Width, texture.Height);
        
        public void Update(float deltaTime)
        {
            Pos.X += Speed * deltaTime;
        }
        public void Draw()
        {
            Rectangle src = new(0, 0, texture.Width, texture.Height);
            Rectangle dst = new(Pos.X, Pos.Y, size.X, size.Y);
            Vector2 origin = new(size.X / 2, size.Y / 2);
            Raylib.DrawTexturePro(texture, src, dst, origin, rotation, Color.White);
        }
    }
} 