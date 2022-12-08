using sprint0.Commands;
using System;
using System.Collections.Generic;
using sprint0.Configs;
using sprint0.Interfaces;
using sprint0.FileReaderClasses;

namespace sprint0.ProceduralGeneration
{
    public class TileGenerator
    {
        private const int PresetMax = 18;
        private const string TilePath = "./Content/Data/TilePresets/Tile";
        private const string Xml = ".xml";

        private readonly Random random;

        public TileGenerator(Random rand)
        {
            random = rand;
        }

        public int Generate(LevelConfig cfg)
        {
            LevelFileReader levelReader = new LevelFileReader(cfg);
            int tilePreset;

            // select which preset tile config
            switch (random.Next(PresetMax))
            {
                case 0 or 1 or 2:
                    tilePreset = 1;
                    break;
                case 4 or 5 or 6:
                    tilePreset = 2;
                    break;
                case 7 or 8:
                    tilePreset = 3;
                    break;
                case 9 or 10:
                    tilePreset = 4;
                    break;
                case 11 or 12:
                    tilePreset = 5;
                    break;
                case 13 or 14 or 15:
                    tilePreset = 6;
                    break;
                default:
                    tilePreset = 0;
                    break;
            }

            levelReader.LoadFile(TilePath + tilePreset.ToString() + Xml);

            return tilePreset;
        }
    }
}
