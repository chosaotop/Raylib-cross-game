using Gamer.Player;
using Raylib_cs;
namespace Gamer.World
{
    internal class Spawner
    {
        Texture2D tex = Raylib.LoadTexture("assets/galinacioGO.png");
        Texture2D tex2 = Raylib.LoadTexture("assets/galinacio.png");
        bool gameOver = false;
        public List<Enemy> cars = new List<Enemy>();
        public float[] spawnPositionsY = { 653f, 608f, 518f, 473f, 383f, 293f, 203f, 158f, 68f };
        float spawnTimer = 0f;
        float spawnInterval = 0.3f;
        float y;
        Sound sound;
        int index;
        Texture2D texture;
        Random random = new();
        public Spawner(Texture2D texture, Sound sound)
        {
            this.sound = sound;
            this.texture = texture;
        }
        public void Update(float deltaTime, Duck duck)
        {
            spawnTimer += deltaTime;
            if (spawnTimer >= spawnInterval)
            {
                SpawnEnemy();
                spawnTimer = 0f;
            }
            foreach (var car in cars)
            {
                if (Raylib.CheckCollisionRecs(duck.GetHitbox, car.GetHitbox))
                {
                    Raylib.PlaySound(sound);
                }
                car.Update(deltaTime);
                if (Raylib.CheckCollisionRecs(duck.GetHitbox, car.GetHitbox))
                {
                    duck.Rotation = 0f;
                    duck.tex = tex;
                    duck.step = 0f;
                    gameOver = true;
                }
            }
            if (gameOver)
            {
                foreach (var car in cars)
                {
                    car.Speed = 0f;
                }
                if (Raylib.IsKeyPressed(KeyboardKey.R))
                {

                    foreach (var car in cars) 
                    {
                        car.Pos.X = 1330; 
                    }
                    duck.tex = tex2;
                    duck.Pos = new(630, 698);
                    duck.step = 45f;
                    gameOver = false;
                }
            }
            cars.RemoveAll(e => e.Pos.X > 1311 ||e.Pos.X < -31);
        }
        public void SpawnEnemy()
        {
            index = random.Next(spawnPositionsY.Length);
            y = spawnPositionsY[index];
            cars.Add(new Enemy(texture, y, index));
        }
        public void Draw()
        {
            foreach (var car in cars)
            {
                    car.Draw();
            }
            if (gameOver)
            {
                Raylib.DrawRectangle(0, 240, 1280, 240, Color.DarkBrown);
                Raylib.DrawText("GAME OVER!", 490, 300, 50, Color.White);
                Raylib.DrawText("Pressione 'R' para recarregar", 400, 340, 30, Color.White);
            }
        }
        public void Unload()
        {
            Raylib.UnloadSound(sound);
        }
    }
}
