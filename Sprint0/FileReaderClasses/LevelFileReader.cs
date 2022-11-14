using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml;
using Microsoft.Xna.Framework;
using sprint0.Classes;
using sprint0.FileReaderClasses;

namespace sprint0.FileReaderClasses
{
    public class LevelFileReader : FileReader
    {
        public LevelConfig LevelConfig { get; set; }
        public LevelFileReader(LevelConfig levelConfig)
        {
            LevelConfig = levelConfig;
        }

        public override void ParseXml()
        {
            XmlDocument xmlDocument = this.GetXmlDocument();

            XmlNodeList settings = xmlDocument["Settings"].GetElementsByTagName("Setting");

            foreach (XmlNode settingNode in settings)
            {
                string settingText = settingNode.InnerText;

                switch (settingNode.Attributes["name"].Value)
                {
                    case "Id":
                        {
                            LevelConfig.Id = Int32.Parse(settingText);
                            break;
                        }
                    case "TileIds":
                        {
                            string[] tileIdRows = settingText.Trim().Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

                            List<List<int>> tileIdArray = new List<List<int>>();

                            foreach (string currentRow in tileIdRows)
                            {
                                string[] trimmedRowArray = currentRow.Trim().Split(' ');

                                tileIdArray.Add(trimmedRowArray.Select(int.Parse).ToList());
                            }


                            LevelConfig.TileIds = tileIdArray;
                            break;
                        }
                    case "DoorIds":
                        {
                            string[] doorIdArray = settingText.Trim().Split(' ');
                            List<int> doorIdList = doorIdArray.Select(int.Parse).ToList();

                            doorIdList.ForEach(id => LevelConfig.DoorIds.Add(id));

                            break;
                        }
                    case "Destinations":
                        {
                            string[] destinationArray = settingText.Trim().Split(' ');
                            List<int> destionationList = destinationArray.Select(int.Parse).ToList();

                            destionationList.ForEach(id => LevelConfig.Destinations.Add(id));

                            break;
                        }
                    case "Enemies":
                        {
                            XmlNodeList enemies = settingNode.ChildNodes;

                            foreach (XmlNode enemy in enemies)
                            {
                                string enemyText = enemy.InnerText;

                                string[] enemyData = enemyText.Trim().Split(' ');
                                List<int> enemyList = enemyData.Select(int.Parse).ToList();

                                LevelConfig.Enemies.Add(enemyList[0], 
                                    new Tuple<Point, int>(new Point(enemyList[2], enemyList[3]), enemyList[1]));
                            }

                            break;
                        }
                }
            }
        }
    }
}