using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats 
{
	public List<BaseStat> stats = new List<BaseStat> ();
	/*
	 * Eliminado en tutorial #14
	void Start()
	{
		stats.Add (new BaseStat (4, "Power", "Your power level."));
		stats.Add (new BaseStat (2, "Vitality", "Your vitality level"));
		stats[0].AddStatBonus(new StatBonus(5));
		stats[0].AddStatBonus(new StatBonus(-7));
		stats[0].AddStatBonus(new StatBonus(21));
		Debug.Log(stats[0].GetCalculatedStatValue());

	}*/

	public  CharacterStats(int power, int toughness, int attackSpeed)
	{
		stats = new List<BaseStat> () {
			new BaseStat (BaseStat.BaseStatType.Power , power, "Power"),
			new BaseStat (BaseStat.BaseStatType.Toughness , toughness, "Tougness"),
			new BaseStat (BaseStat.BaseStatType.AttackSpeed , attackSpeed, "Atk Spd")
		};
	}

	public BaseStat GetStat(BaseStat.BaseStatType stat)
	{
		return this.stats.Find (x => x.StatType == stat);
	}


	public void AddStatBonus(List<BaseStat> statBonuses)
	{
		foreach(BaseStat statBonus in statBonuses)
		{
			GetStat (statBonus.StatType).AddStatBonus (new StatBonus (statBonus.BaseValue));
			/*stats.Find (x=> x.StatName == statBonus.StatName).AddStatBonus(new StatBonus(statBonus.BaseValue));*/
		}
	}

	public void RemoveStatBonus(List<BaseStat> statBonuses)
	{
		foreach(BaseStat statBonus in statBonuses)
		{
			GetStat (statBonus.StatType).RemoveStatBonus(new StatBonus(statBonus.BaseValue));
		}
	}


}
