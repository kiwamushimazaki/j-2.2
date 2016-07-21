// <copyright file="HandJudge.cs" company="PlaceholderCompany">
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
    /// 勝ち負けの判定を行うクラス
    /// </summary>
    internal class HandJudge
    {
        /// <summary>
        /// 勝ち負けを判定するメソッド
        /// </summary>
        /// <param name="playerList">プレイヤーの手の情報</param>
        /// <param name="targetHand">勝利した手の種類</param>
        /// <param name="csv">勝敗情報を書き込むCSVファイル</param>
        /// <param name="numberOfuser1">プレイヤーの人数</param>
        /// <param name="numberOfcpu1">コンピュータの人数</param>
        public static void Judge(List<Player> playerList, int targetHand, CsvWriter csv, int numberOfuser1, int numberOfcpu1)
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
    }
}