// <copyright file="MainClass.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ConsoleApplication1
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using CsvHelper;

    /// <summary>
    /// じゃんけんを行うクラス
    /// </summary>
    internal class MainClass
    {
        private static void Main()
        {
            Console.WriteLine("複数人じゃんけんゲーム");
            while (true)
            {
                var csv = new CsvWriter(new StreamWriter("C:\\dev\\csv\\jyanken.csv", true, System.Text.Encoding.GetEncoding(932)));

                Console.WriteLine("プレイヤーの人数を１人～４人で選択してください>>>");
                int numberOfuser1 = Input.InputPlayerNumber();

                var playerList = new List<Player>();
                for (int i = 1; i <= numberOfuser1; i++)
                {
                    playerList.Add(new Userplayer());
                }

                Console.WriteLine("コンピュータの人数を１人～４人で選択してください>>>");

                int numberOfcpu1 = Input.InputPlayerNumber();

                for (int i = 1; i <= numberOfcpu1; i++)
                {
                    playerList.Add(new Cpuplayer());
                }

                while (true)
                {
                    Input.InputUserHand(playerList, numberOfuser1);
                    Input.InputCpuHand(playerList, numberOfuser1, numberOfcpu1);

                    bool guExist = Exist.HandExist(playerList, Handlist.グー);
                    bool chokiExist = Exist.HandExist(playerList, Handlist.チョキ);
                    bool paExist = Exist.HandExist(playerList, Handlist.パー);

                    bool guWin = guExist && chokiExist && !paExist;
                    bool chokiWin = guExist && !chokiExist && paExist;
                    bool paWin = !guExist && chokiExist && paExist;

                    if (guWin)
                    {
                        HandJudge.Judge(playerList, Handlist.グー, csv, numberOfuser1, numberOfcpu1);
                        break;
                    }
                    else if (chokiWin)
                    {
                        HandJudge.Judge(playerList, Handlist.パー, csv, numberOfuser1, numberOfcpu1);
                        break;
                    }
                    else if (paWin)
                    {
                        HandJudge.Judge(playerList, Handlist.チョキ, csv, numberOfuser1, numberOfcpu1);
                        break;
                    }
                    else
                    {
                        Draw.Aiko(playerList, numberOfuser1, numberOfcpu1);
                        continue;
                    }
                }

                csv.NextRecord();
                csv.Dispose();
                Csv.CsvwRead();

                Console.WriteLine("もう一度じゃんけんを行う場合は 1 を押してください>>>");
                Console.WriteLine("終了する場合は 0 を押してください>>>");

                string temp4;

                while (true)
                {
                    temp4 = Console.ReadLine();
                    bool correct = temp4 == "1" || temp4 == "0";

                    if (correct)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("誤ったキーが選択されました");
                        Console.WriteLine("もう一度、1.続行 0.終了 を再入力してください >>>");
                        continue;
                    }
                }

                bool rematch = temp4 == "1";
                if (rematch)
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
        }
    }
}