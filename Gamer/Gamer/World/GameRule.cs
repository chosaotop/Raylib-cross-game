using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Encodings.Web;
using Raylib_cs;

namespace Gamer.World
{
    internal class GameRule
    {
        bool exitWindowRequest = false;
        public GameRule()
        {

        }
        public void Update()
        {
            if (Raylib.WindowShouldClose() || Raylib.IsKeyPressed(KeyboardKey.Escape)) exitWindowRequest = true;
            
            if (exitWindowRequest)
            {
                Raylib.SetExitKey(KeyboardKey.Y);
                if (Raylib.IsKeyPressed(KeyboardKey.N)) 
                {
                    exitWindowRequest = false;
                    Raylib.SetExitKey(KeyboardKey.Null);
                }


            }
        }
        public void Draw()
        {
            if (exitWindowRequest)
            {
                Raylib.DrawRectangle(0, 240, 1280, 240, Color.Black);
                Raylib.DrawText("Tem certeza de que deseja sair? [Y/N]", 360, 340, 30, Color.White);
            }
        }
    }
}
