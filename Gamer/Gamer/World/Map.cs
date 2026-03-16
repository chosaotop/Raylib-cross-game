using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gamer.World
{
    class Map
    {
        public Map() 
        {
            background = Raylib.LoadTexture("assets/crossidea.png");
        }
        Texture2D background;
        public void DrawBackGround()
        {
            Raylib.DrawTexture(background, 0, 0, Color.White);
        }
    }
}
