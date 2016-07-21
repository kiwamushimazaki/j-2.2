// <copyright file="Draw.cs" company="PlaceholderCompany">
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
    /// あいこが起こったときの処理をするクラス
    /// </summary>
    internal class Draw
    {
        /// <summary>
        /// あいこの処理をするメソッド
        /// </summary>
        /// <param name="playerList">プレイヤーの手の情報がまとめてあるリスト</param>
        /// <param name="numberOfuser1">ユーザーの人数</param>
        /// <param name="numberOfcpu1">コンピュータの人数</param>
        public static void Aiko(List<Player> playerList, int numberOfuser1, int numberOfcpu1)
        {
            for (int i = 1; i <= numberOfcpu1; i++)
            {
                Console.WriteLine("コンピュータ{0}は", i);
                Console.WriteLine("{0}", playerList[numberOfuser1 + i - 1].Hand);
            }

            Console.WriteLine("あいこです ( 'ω' )");
            Console.WriteLine("もう一度選んでください");
        }
    }
}