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
                int numberOfuser1 = InputPlayerNumber();

                var playerList = new List<Player>();
                for (int i = 1; i <= numberOfuser1; i++)
                {
                    playerList.Add(new Userplayer());
                }

                Console.WriteLine("コンピュータの人数を１人～４人で選択してください>>>");

                int numberOfcpu1 = InputPlayerNumber();

                for (int i = 1; i <= numberOfcpu1; i++)
                {
                    playerList.Add(new Cpuplayer());
                }

                bool aiko = false;
                do
                {
                    InputUserHand(playerList, numberOfuser1);
                    InputCpuHand(playerList, numberOfuser1, numberOfcpu1);

                    bool guExist = HandExist(playerList, グー);

                    bool chokiExist = HandExist(playerList, チョキ);

                    bool paExist = HandExist(playerList, パー);

                    if (guExist && chokiExist && !paExist)
                    {
                        Judge(playerList, グー, csv, numberOfuser1, numberOfcpu1);
                        break;
                    }
                    else if (guExist && !chokiExist && paExist)
                    {
                        Judge(playerList, パー, csv, numberOfuser1, numberOfcpu1);
                        break;
                    }
                    else if (!guExist && chokiExist && paExist)
                    {
                        Judge(playerList, チョキ, csv, numberOfuser1, numberOfcpu1);
                        break;
                    }
                    else
                    {
                        Aiko(playerList, numberOfuser1, numberOfcpu1);
                        aiko = true;
                    }
                }
                while (aiko);

                csv.NextRecord();
                csv.Dispose();
                CsvwRead();

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

        /// <summary>
        /// それぞれの手が存在するかどうかを判断するメソッド
        /// </summary>
        /// <param name="playerList">プレイヤーの手の情報</param>
        /// <param name="targetHand">注目する手の種類</param>
        /// <returns>bool</returns>
        private static bool HandExist(List<Player> playerList, int targetHand)
        {
            foreach (var hand in playerList)
            {
                if (hand.Hand == targetHand)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 勝ち負けを判定するメソッド
        /// </summary>
        /// <param name="playerList">プレイヤーの手の情報</param>
        /// <param name="targetHand">勝利した手の種類</param>
        /// <param name="csv">勝敗情報を書き込むCSVファイル</param>
        /// <param name="numberOfuser1">プレイヤーの人数</param>
        /// <param name="numberOfcpu1">コンピュータの人数</param>
        private static void Judge(List<Player> playerList, int targetHand, CsvWriter csv, int numberOfuser1, int numberOfcpu1)
        {
            for (int i = 1; i <= numberOfcpu1; i++)
            {
                Console.WriteLine("コンピュータ{0}は", i);
                Console.WriteLine("{0}", playerList[numberOfuser1 + i - 1].Hand);
            }

            int win = 0;
            int lose = 0;

            for (int i = 1; i <= numberOfuser1; i++)
            {
                Console.WriteLine("プレイヤー{0}は", i);
                if (playerList[i - 1].Hand == targetHand)
                {
                    Console.WriteLine("勝ちですヽ(〃v〃)ﾉ");
                    Console.WriteLine("おめでとうございます！！");
                    win = 1;
                    lose = 0;
                    csv.WriteField(win);
                    csv.WriteField(lose);
                }
                else
                {
                    Console.WriteLine("負けです (_　_|||)");
                    Console.WriteLine("残念でした (>_<)");
                    win = 0;
                    lose = 1;
                    csv.WriteField(win);
                    csv.WriteField(lose);
                }
            }

            if (numberOfuser1 != 4)
            {
                for (int i = numberOfuser1 + 1; i <= 4; i++)
                {
                    win = 0;
                    lose = 0;
                    csv.WriteField(win);
                    csv.WriteField(lose);
                }
            }
        }

        /// <summary>
        /// プレイヤーの人数を決定するメソッド
        /// </summary>
        /// <returns>int</returns>
        private static int InputPlayerNumber()
        {
            while (true)
            {
                string numberOfplayer;
                numberOfplayer = Console.ReadLine();
                if (numberOfplayer == "1" || numberOfplayer == "2" || numberOfplayer == "3" || numberOfplayer == "4")
                {
                    return int.Parse(numberOfplayer);
                }
                else
                {
                    Console.WriteLine("誤ったキーが選択されました");
                    Console.WriteLine("人数を１人～４人から再入力してください >>>");
                    continue;
                }
            }
        }

        /// <summary>
        /// ユーザーの手を決定するメソッド
        /// </summary>
        /// <param name="playerList">ユーザーの選択した手の情報をまとめるリスト</param>
        /// <param name="numberOfuser1">ユーザーの人数</param>
        private static void InputUserHand(List<Player> playerList, int numberOfuser1)
        {
            for (int i = 1; i <= numberOfuser1; i++)
            {
                Console.WriteLine("プレイヤー{0}", i);
                Console.WriteLine("1.グー, 2.チョキ, 3.パー");
                Console.WriteLine("1～3のいずれかを選択してください>>> ");
                bool user = true;
                do
                {
                    string handInput = Console.ReadLine();
                    if (handInput == "1" || handInput == "2" || handInput == "3")
                    {
                        user = false;
                    }
                    else
                    {
                        Console.WriteLine("誤ったキーが選択されました");
                        Console.WriteLine("もう一度、1.グー, 2.チョキ, 3.パーから再入力してください >>>");
                        continue;
                    }

                    int userHand = int.Parse(handInput);
                    Player player = playerList[i - 1];
                    player.Hand = userHand;
                }
                while (user);
            }
        }

        /// <summary>
        /// コンピュータの手を決定するメソッド
        /// </summary>
        /// <param name="playerList">コンピュータの手の情報をまとめるリスト</param>
        /// <param name="numberOfuser1">ユーザーの人数</param>
        /// <param name="numberOfcpu1">コンピュータの人数</param>
        private static void InputCpuHand(List<Player> playerList, int numberOfuser1, int numberOfcpu1)
        {
            Random temp2 = new Random();
            for (int i = 1; i <= numberOfcpu1; i++)
            {
                int cpuHand = temp2.Next(1, 4);
                Player player = playerList[numberOfuser1 + i - 1];
                player.Hand = cpuHand;
            }
        }

        /// <summary>
        /// あいこの処理をするメソッド
        /// </summary>
        /// <param name="playerList">プレイヤーの手の情報がまとめてあるリスト</param>
        /// <param name="numberOfuser1">ユーザーの人数</param>
        /// <param name="numberOfcpu1">コンピュータの人数</param>
        private static void Aiko(List<Player> playerList, int numberOfuser1, int numberOfcpu1)
        {
            for (int i = 1; i <= numberOfcpu1; i++)
            {
                Console.WriteLine("コンピュータ{0}は", i);
                Console.WriteLine("{0}", playerList[numberOfuser1 + i - 1].Hand);
            }

            Console.WriteLine("あいこです ( 'ω' )");
            Console.WriteLine("もう一度選んでください");
        }

        /// <summary>
        /// CSVファイルを読み込み、各ユーザーの勝敗、勝率を表示するメソッド
        /// </summary>
        private static void CsvwRead()
        {
            string[] jkData = System.IO.File.ReadAllLines(@"C:\\dev\\csv\\jyanken.csv");
            IEnumerable<IEnumerable<int>> multiColQuery =
           from line in jkData
           let elements = line.Split(',')
           let jyanken = elements.Skip(0)
           select from str in jyanken select Convert.ToInt32(str);
            var results = multiColQuery.ToList();
            int columnCount = results[0].Count();
            for (int column = 0; column < columnCount; column = column + 2)
            {
                var results2 = from row in results
                               select row.ElementAt(column);
                decimal sum1 = results2.Sum();
                var results3 = from row in results
                               select row.ElementAt(column + 1);
                decimal sum2 = results3.Sum();
                Console.WriteLine("プレイヤー{0} {1}勝{2}敗　勝率{3:##.##}％", (column + 2) / 2, sum1, sum2, sum1 / (sum1 + sum2) * 100);
            }
        }
    }
}