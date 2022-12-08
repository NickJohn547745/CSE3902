using sprint0.Commands;
using System;
using System.Collections.Generic;
using sprint0.Configs;
using sprint0.Interfaces;
using sprint0.FileReaderClasses;
using Microsoft.Xna.Framework;
using System.Reflection.Metadata.Ecma335;

namespace sprint0.ProceduralGeneration
{
    public class EnemyGenerator
    {
        private const int TrapId = 6;
        private const int AquamentusId = 0;
        private const int MaxId = 6;

        private const int OldManId = 3;
        private const int MaxEnemyPreset = 6;

        private const string EnemyPath = "./Content/Data/EnemyPresets/Enemy";
        private const string Xml = ".xml";
        private readonly Random random;

        public EnemyGenerator(Random rand)
        {
            random = rand;
        }

        private int EnemyPreset(int tilePreset)
        {
            List<int> enemyPresets = new List<int>();

            switch (tilePreset)
            {
                case 0:
                case 4:
                    for (int i = 0; i < MaxEnemyPreset; i++) enemyPresets.Add(i);
                    break;
                case 1:
                    enemyPresets.Add(3);
                    enemyPresets.Add(4);
                    break;
                case 2:
                    enemyPresets.Add(2);
                    enemyPresets.Add(5);
                    break;
                case 3:
                    enemyPresets.Add(3);
                    enemyPresets.Add(4);
                    break;
                case 5:
                    for (int i = 0; i < MaxEnemyPreset - 1; i++) enemyPresets.Add(i);
                    break;
                case 6:
                    enemyPresets.Add(4);
                    enemyPresets.Add(5);
                    break;
            }

            return enemyPresets[random.Next(enemyPresets.Count)];
        }


        private int GenerateId()
        {
            int id = -1;

            while (id < 0 || id == OldManId) id = random.Next(1, MaxId);

            return id;
        }

        private void SetIds(LevelConfig cfg)
        {
            for (int i = 0; i < cfg.Enemies.Count; i++)
            {
                if (cfg.Enemies[i].Item1 != AquamentusId && cfg.Enemies[i].Item1 != TrapId)
                {
                    Tuple<int, Point, int> current = cfg.Enemies[i];
                    cfg.Enemies[i] = new Tuple<int, Point, int>(GenerateId(), current.Item2, current.Item3);
                }
             }
        }

        public void Generate(LevelConfig cfg, int tilePreset)
        {
            int enemyPreset = EnemyPreset(tilePreset);
            LevelFileReader levelReader = new LevelFileReader(cfg);
            

            if (enemyPreset >= 0)
            {
                levelReader.LoadFile(EnemyPath + enemyPreset.ToString() + Xml);
                SetIds(cfg);
            }
        }
    }
}
