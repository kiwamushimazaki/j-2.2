// <copyright file="Input.cs" company="PlaceholderCompany">
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
    /// プレイヤーの人数や手の入力を行うクラス
    /// </summary>
    internal class Input
    {
        /// <summary>
        /// プレイヤーの人数を決定するメソッド
        /// </summary>
        /// <returns>int</returns>
        public static int InputPlayerNumber()
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
        public static void InputUserHand(List<Player> playerList, int numberOfuser1)
        {
            for (int i = 1; i <= numberOfuser1; i++)
            {
                Console.WriteLine("プレイヤー{0}", i);
                Console.WriteLine("1.グー, 2.チョキ, 3.パー");
                Console.WriteLine("1～3のいずれかを選択してください>>> ");
                while (true)
                {
                    string handInput = Console.ReadLine();
                    if (handInput == "1" || handInput == "2" || handInput == "3")
                    {
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
                    break;
                }
            }
        }

        /// <summary>
        /// コンピュータの手を決定するメソッド
        /// </summary>
        /// <param name="playerList">コンピュータの手の情報をまとめるリスト</param>
        /// <param name="numberOfuser1">ユーザーの人数</param>
        /// <param name="numberOfcpu1">コンピュータの人数</param>
        public static void InputCpuHand(List<Player> playerList, int numberOfuser1, int numberOfcpu1)
        {
            Random temp2 = new Random();
            for (int i = 1; i <= numberOfcpu1; i++)
            {
                int cpuHand = temp2.Next(1, 4);
                Player player = playerList[numberOfuser1 + i - 1];
                player.Hand = cpuHand;
            }
        }
    }
}