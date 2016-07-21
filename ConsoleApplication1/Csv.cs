// <copyright file="Csv.cs" company="PlaceholderCompany">
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
    /// CSVの読み込みを行うクラス
    /// </summary>
    internal class Csv
    {
        /// <summary>
        /// CSVファイルを読み込み、各ユーザーの勝敗、勝率を表示するメソッド
        /// </summary>
        public static void CsvwRead()
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