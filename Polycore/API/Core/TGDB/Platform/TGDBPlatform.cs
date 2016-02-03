using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Polycore.API.Core.TGDB.Game;

namespace Polycore.API.Core.TGDB.Platform
{
    public class TGDBPlatform
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        public string Developer { get; set; }
        public string Manufacturer { get; set; }
        public string Cpu { get; set; }
        public string Memory { get; set; }
        public string Graphics { get; set; }
        public string Sound { get; set; }
        public string Display { get; set; }
        public string Media { get; set; }
        public string MaxControllers { get; set; }
        public string Rating { get; set; }
        public List<TGDBArt> Fanart { get; set; }
        public List<BoxArt> Boxart { get; set; }
        public List<TGDBArt> Banners { get; set; }
        public string ConsoleArt { get; set; }
        public string ControllerArt { get; set; }

        public TGDBPlatform(int id, string name, string overview, string developer, string manufacturer, string cpu, string memory, string graphics, string sound, string display, string media, string maxControllers, string rating, List<TGDBArt> fanart, List<BoxArt> boxart, List<TGDBArt> banners, string consoleArt, string controllerArt)
        {
            Id = id;
            Name = name;
            Overview = overview;
            Developer = developer;
            Manufacturer = manufacturer;
            Cpu = cpu;
            Memory = memory;
            Graphics = graphics;
            Sound = sound;
            Display = display;
            Media = media;
            MaxControllers = maxControllers;
            Rating = rating;
            Fanart = fanart;
            Boxart = boxart;
            Banners = banners;
            ConsoleArt = consoleArt;
            ControllerArt = controllerArt;
        }

        public TGDBPlatform()
        {
            
        }
    }
}