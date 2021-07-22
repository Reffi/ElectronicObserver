using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicObserver.Data.Quest
{

	/// <summary>
	/// 演習任務の進捗を管理します。
	/// </summary>
	[DataContract(Name = "ProgressPractice")]
	public class ProgressPractice : ProgressData
	{

		/// <summary>
		/// 勝利のみカウントする
		/// </summary>
		[DataMember]
		private bool WinOnly { get; set; }

		/// <summary>
		/// 条件を満たす最低ランク
		/// </summary>
		[DataMember]
		private int LowestRank { get; set; }


		public ProgressPractice(QuestData quest, int maxCount, string lowestRank)
			: base(quest, maxCount)
		{

			LowestRank = Constants.GetWinRank(lowestRank);
		}

		public virtual void Increment(string rank)
		{
			if (Constants.GetWinRank(rank) < LowestRank)
				return;
		
			Increment();
		}

		public override string GetClearCondition()
		{
			StringBuilder sb = new StringBuilder();

			switch (LowestRank)
			{
				case 2:
				case 3:
					sb.Append(Constants.GetWinRank(LowestRank) + "以上");
					break;
				case 4:
					sb.Append("勝利");
					break;
				case 5:
				case 6:
				case 7:
					sb.Append(Constants.GetWinRank(LowestRank) + "勝利");
					break;
			}
			sb.Append(ProgressMax);

			return sb.ToString();
		}
	}
}
