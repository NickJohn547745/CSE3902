using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Microsoft.Xna.Framework;
using sprint0.Classes;
using sprint0.Commands;
using sprint0.FileReaderClasses;

namespace sprint0.FileReaderClasses
{
    public class GameFileReader : FileReader
    {
        public GameConfig GameConfig { get; set; }
        public GameFileReader(GameConfig gameConfig)
        {
            GameConfig = gameConfig;
        }

        public override void ParseXml()
        {
            XmlDocument xmlDocument = this.GetXmlDocument();

            XmlElement settingsNode = xmlDocument["Settings"];
            XmlNodeList settings = settingsNode.GetElementsByTagName("Setting");

            foreach (XmlElement settingNode in settings)
            {
                string settingText = settingNode.InnerText;

                switch (settingNode.Attributes["name"].Value)
                {
                    case "ResolutionWidth":
                        {
                            GameConfig.ResolutionWidth = Int32.Parse(settingText);
                            break;
                        }
                    case "ResolutionHeight":
                        {
                            GameConfig.ResolutionHeight = Int32.Parse(settingText);
                            break;
                        }
                    case "StartLevelId":
                        {
                            GameConfig.StartLevelId = Int32.Parse(settingText);
                            break;
                        }
                    case "LevelConfigs":
                        {
                            foreach (XmlElement levelNode in settingNode.GetElementsByTagName("Field"))
                            {
                                int id = Int32.Parse(levelNode.Attributes["id"].InnerText);
                                GameConfig.LevelData.Add(id, levelNode.Value);

                                LevelConfig levelConfig = new LevelConfig();
                                LevelFileReader levelReader = new LevelFileReader(levelConfig);

                                levelReader.LoadFile("./Content/Data/" + levelNode.InnerText);
                                GameConfig.LevelConfigs.Add(id, levelConfig);
                            }
                            break;
                        }
                }
            }
        }
    }
}