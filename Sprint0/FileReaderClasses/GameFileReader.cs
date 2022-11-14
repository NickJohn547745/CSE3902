using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using sprint0.Classes;
using sprint0.Commands;
using sprint0.FileReaderClasses;
using sprint0.Interfaces;

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
                    case "KeyboardBinds":
                        {
                            foreach (XmlElement levelNode in settingNode.GetElementsByTagName("Tuple"))
                            {
                                string[] tupleText = levelNode.InnerText.Split(' ');

                                int keyId = Int32.Parse(tupleText[0]);
                                Keys castedKey = (Keys)keyId;

                                Type keyCommandType = Type.GetType("sprint0.Commands." + tupleText[1]);
                                object keyCommandObject = Activator.CreateInstance(keyCommandType);
                                ICommand castedKeyCommand = (ICommand)keyCommandObject;

                                int keyStateId = Int32.Parse(tupleText[2]);
                                IController.KeyState castedKeyState = (IController.KeyState)keyStateId;

                                Debug.WriteLine(castedKey.ToString() + " " + castedKeyCommand.ToString() + " " + castedKeyState.ToString());

                                GameConfig.KeyboardBinds.Add(
                                    new Tuple<Keys, ICommand, IController.KeyState>(castedKey, castedKeyCommand, castedKeyState));
                            }
                            break;
                        }
                    case "GamePadBinds":
                        {
                            foreach (XmlElement levelNode in settingNode.GetElementsByTagName("Pair"))
                            {
                                string[] tupleText = levelNode.InnerText.Split(' ');

                                int buttonId = Int32.Parse(tupleText[0]);
                                Buttons castedButton = (Buttons)buttonId;

                                Type buttonCommandType = Type.GetType("sprint0.Commands." + tupleText[1]);
                                object buttonCommandObject = Activator.CreateInstance(buttonCommandType);
                                ICommand castedButtonCommand = (ICommand)buttonCommandObject;

                                int buttonStateId = Int32.Parse(tupleText[2]);
                                IController.KeyState castedButtonState = (IController.KeyState)buttonStateId;

                                GameConfig.GamePadBinds.Add(
                                    new Tuple<Buttons, ICommand, IController.KeyState>(castedButton, castedButtonCommand, castedButtonState));
                            }
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