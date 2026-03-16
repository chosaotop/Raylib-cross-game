using Gamer.World;
using Gamer.Player;
using Raylib_cs;
using System.Threading.Channels;

namespace Gamermax
{
    class Program()
    {
        public static void Main()
        {
            Raylib.InitWindow(1280, 720, "pato?");
            Raylib.InitAudioDevice();
            Sound sound = Raylib.LoadSound("assets/metalpipe.mp3");
            Raylib.SetExitKey(KeyboardKey.Null);
            Texture2D eTex = Raylib.LoadTexture("assets/car.png");
            GameRule rule = new();
            Spawner spawn = new(eTex, sound);
            Map map = new();
            Duck player = new();
            Raylib.SetTargetFPS(60);
            while (!Raylib.WindowShouldClose())
            {
                rule.Update();
                float dt = Raylib.GetFrameTime();
                player.Update();
                spawn.Update(dt, player);
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Gray);
                map.DrawBackGround();
                spawn.Draw();
                player.Draw();
                rule.Draw();
                player.FPS();
                Raylib.EndDrawing();
            }
            spawn.Unload();
            Raylib.CloseAudioDevice();
            player.Unload();
            Raylib.CloseWindow();
        }
    }
}

