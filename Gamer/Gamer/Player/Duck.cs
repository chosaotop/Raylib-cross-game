using Raylib_cs;
using System.Numerics;
namespace Gamer.Player
{
    class Duck
    {
        public Vector2 Pos;
        public Texture2D tex;
        public Vector2 size = new(20, 37);
        public float Rotation;
        private bool isMoving;
        private Vector2 endPos;

        public float Speed = 150f;
        public float step = 45f;
        public Duck()
        {
            tex = Raylib.LoadTexture("assets/galinacio.png");
            Pos = new Vector2(630, 698);
        }
        public Rectangle GetHitbox => new(Pos.X - 10, Pos.Y - 18.5f ,tex.Width, tex.Height);

    
        public void Draw()
        {

            Rectangle src = new(0, 0, tex.Width, tex.Height);
            Rectangle dst = new(Pos.X, Pos.Y, size.X, size.Y);
            Vector2 origin = new(size.X / 2, size.Y/ 2); 

            Raylib.DrawTexturePro(tex, src, dst, origin, Rotation, Color.White);
        }

       
        
        public void Unload()
        {
            Raylib.UnloadTexture(tex);
        }

        public void FPS()
        {
            float dt = Raylib.GetFPS();
            Raylib.DrawText(dt.ToString(), 10, 20, 20, Color.DarkPurple);
        }

        public void Update()
        {
            HandleInput();
            MovePlayer();
        }
        private void HandleInput()
        {
            if (isMoving) return;

            if (Raylib.IsKeyPressed(KeyboardKey.Up))
            {
                StartMove(new Vector2(0, -step));
                Rotation = 0;
            }

            else if (Raylib.IsKeyPressed(KeyboardKey.Down))
            {
                StartMove(new Vector2(0, step));
                Rotation = 180;
            }

            else if (Raylib.IsKeyPressed(KeyboardKey.Left))
            {
                StartMove(new Vector2(-step, 0));
                Rotation = 270;   
            }

            else if (Raylib.IsKeyPressed(KeyboardKey.Right))
            {
                StartMove(new Vector2(step, 0));
                Rotation = 90;
            }
        }

        private void StartMove(Vector2 dir)
        {
            endPos = Pos + dir;
            isMoving = true;
        }

        private void MovePlayer()
        {
            if (!isMoving) return;

            float dt = Raylib.GetFrameTime();
            if (dt <= 0f) return;

            Vector2 delta = endPos - Pos;
            float distance = delta.Length();

            float stepThisFrame = Speed * dt;
            if (stepThisFrame >= distance)
            {
                Pos = endPos;
                isMoving = false;
                return;
            }
            delta /= distance;
            Pos += delta * stepThisFrame;
        }
    }
}