using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicObserver.Data.Quest
{
	[DataContract(Name = "ProgressSpecialPractice")]
	public class ProgressSpecaiPractice : ProgressPractice
	{
		public ProgressSpecaiPractice(QuestData quest, int maxCount, string lowestRank)
		: base(quest, maxCount, lowestRank)
		{
		}

		public override void Increment(string rank)
		{
			// 邪悪
			var Empty = (ShipTypes)(-1);

			// 邪悪
			var bm = KCDatabase.Instance.Battle;

			var fleet = KCDatabase.Instance.Fleet.Fleets.Values.FirstOrDefault(f => f.IsInSortie);

			var members = fleet.MembersWithoutEscaped;
			var memberstype = members.Select(s => s?.MasterShip?.ShipType ?? Empty).ToArray();

			bool isAccepted = false;


			switch (QuestID)
			{
				case 318:   //|318|月|給糧艦「伊良湖」の支援|演習勝利3, 秘書艦に戦闘糧食x2装備|要軽巡2以上, 戦
					isAccepted =
						memberstype.Count(t => t == ShipTypes.LightCruiser) <= 2;
					break;

			}
			if (isAccepted)
				base.Increment(rank);
		}
	}
}
