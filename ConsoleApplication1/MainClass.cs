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
            const int グー = 1;
            const int チョキ = 2;
            const int パー = 3;

            Console.WriteLine("複数人じゃんけんゲーム");
            while (true)
            {
                var append = true;
                var csv = new CsvWriter(new StreamWriter("C:\\dev\\csv\\jyanken.csv", append));
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

                bool aiko = false;
                do
                {
                    Input.InputUserHand(playerList, numberOfuser1);
                    Input.InputCpuHand(playerList, numberOfuser1, numberOfcpu1);

                    bool guExist = Exist.HandExist(playerList, グー);

                    bool chokiExist = Exist.HandExist(playerList, チョキ);

                    bool paExist = Exist.HandExist(playerList, パー);

                    if (guExist && chokiExist && !paExist)
                    {
                        HandJudge.Judge(playerList, グー, csv, numberOfuser1, numberOfcpu1);
                        break;
                    }
                    else if (guExist && !chokiExist && paExist)
                    {
                        HandJudge.Judge(playerList, パー, csv, numberOfuser1, numberOfcpu1);
                        break;
                    }
                    else if (!guExist && chokiExist && paExist)
                    {
                        HandJudge.Judge(playerList, チョキ, csv, numberOfuser1, numberOfcpu1);
                        break;
                    }
                    else
                    {
                        Draw.Aiko(playerList, numberOfuser1, numberOfcpu1);
                        aiko = true;
                    }
                }
                while (aiko);

                csv.NextRecord();
                csv.Dispose();
                Csv.CsvwRead();

                Console.WriteLine("もう一度じゃんけんを行う場合は 1 を押してください>>>");
                Console.WriteLine("終了する場合は 0 を押してください>>>");

                string temp4;

                while (true)
                {
                    temp4 = Console.ReadLine();

                    if (temp4 == "1" || temp4 == "0")
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

                if (temp4 == "1")
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