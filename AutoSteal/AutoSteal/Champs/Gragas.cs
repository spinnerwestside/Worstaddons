﻿namespace AutoSteal.Champs
{
    using System.Linq;
    using EloBuddy;
    using EloBuddy.SDK;
    using EloBuddy.SDK.Menu;
    using EloBuddy.SDK.Menu.Values;

    class Gragas
    {

        public static Spell.Skillshot Q { get; set; }
        public static Spell.Skillshot E { get; set; }
        public static Spell.Skillshot R { get; set; }
        public static Menu GragMenu { get; set; }

        public static void KS()
        {
            foreach (AIHeroClient target in
                ObjectManager.Get<AIHeroClient>()
                    .Where(
                        hero =>
                        hero.IsValidTarget(Q.Range)
                        && !hero.HasBuffOfType(BuffType.Invulnerability)
                        && hero.IsEnemy
                        && !hero.IsDead
                        && !hero.IsZombie))
            {
                if (GragMenu["QC"].Cast<CheckBox>().CurrentValue)
                {
                    if (Player.Instance.Spellbook.GetSpell(SpellSlot.Q).ToggleState != 2 && ObjectManager.Player.BaseAbilityDamage + ObjectManager.Player.GetSpellDamage(target, SpellSlot.Q) > Check.HealthPrediction.GetHealthPrediction(target, (int)(Q.CastDelay * 1000))
                        && Q.IsInRange(target) && Q.IsReady())
                    {
                        var pred = Q.GetPrediction(target);
                        Q.Cast(pred.CastPosition);
                        if (Player.Instance.Spellbook.GetSpell(SpellSlot.Q).ToggleState == 2)
                        {
                            Q.Cast();
                        }
                        return;
                    }
                }

                if (GragMenu["EC"].Cast<CheckBox>().CurrentValue)
                {
                    if (ObjectManager.Player.BaseAbilityDamage + ObjectManager.Player.GetSpellDamage(target, SpellSlot.E) > Check.HealthPrediction.GetHealthPrediction(target, (int)(E.CastDelay * 1000))
                        && E.IsInRange(target) && E.IsReady())
                    {
                        var pred = E.GetPrediction(target);
                        E.Cast(pred.CastPosition);
                        return;
                    }
                }

                if (GragMenu["RC"].Cast<CheckBox>().CurrentValue)
                {
                    if (ObjectManager.Player.BaseAbilityDamage + ObjectManager.Player.GetSpellDamage(target, SpellSlot.R) > Check.HealthPrediction.GetHealthPrediction(target, (int)(R.CastDelay * 1000))
                        && R.IsInRange(target) && R.IsReady())
                    {
                        var pred = R.GetPrediction(target);
                        R.Cast(pred.CastPosition);
                        return;
                    }
                }
            }
        }

        public static void JKS()
        {
            foreach (Obj_AI_Minion mob in
                ObjectManager.Get<Obj_AI_Minion>()
                    .Where(
                        jmob =>
                        jmob.IsValidTarget(Q.Range)
                        && !jmob.HasBuffOfType(BuffType.Invulnerability)
                        && jmob.IsMonster
                        && !jmob.IsDead
                        && !jmob.IsZombie
                        && ((Start.Junglemobs["drake"].Cast<CheckBox>().CurrentValue && jmob.BaseSkinName == "SRU_Dragon")
                        || (Start.Junglemobs["baron"].Cast<CheckBox>().CurrentValue && jmob.BaseSkinName == "SRU_Baron")
                        || (Start.Junglemobs["gromp"].Cast<CheckBox>().CurrentValue && jmob.BaseSkinName == "SRU_Gromp")
                        || (Start.Junglemobs["krug"].Cast<CheckBox>().CurrentValue && jmob.BaseSkinName == "SRU_Krug")
                        || (Start.Junglemobs["razorbeak"].Cast<CheckBox>().CurrentValue && jmob.BaseSkinName == "SRU_Razorbeak")
                        || (Start.Junglemobs["crab"].Cast<CheckBox>().CurrentValue && jmob.BaseSkinName == "Sru_Crab")
                        || (Start.Junglemobs["murkwolf"].Cast<CheckBox>().CurrentValue && jmob.BaseSkinName == "SRU_Murkwolf")
                        || (Start.Junglemobs["blue"].Cast<CheckBox>().CurrentValue && jmob.BaseSkinName == "SRU_Blue")
                        || (Start.Junglemobs["red"].Cast<CheckBox>().CurrentValue && jmob.BaseSkinName == "SRU_Red"))))
            {
                if (GragMenu["QJ"].Cast<CheckBox>().CurrentValue)
                {
                    if (Player.Instance.Spellbook.GetSpell(SpellSlot.Q).ToggleState != 2 && ObjectManager.Player.BaseAbilityDamage + ObjectManager.Player.GetSpellDamage(mob, SpellSlot.Q) > Check.HealthPrediction.GetHealthPrediction(mob, (int)(Q.CastDelay * 1000))
                        && Q.IsInRange(mob))
                    {
                        Q.Cast(mob.Position);
                        if (Player.Instance.Spellbook.GetSpell(SpellSlot.Q).ToggleState == 2)
                        {
                            Q.Cast();
                        }

                        return;
                    }
                }

                if (GragMenu["EJ"].Cast<CheckBox>().CurrentValue)
                {
                    if (ObjectManager.Player.BaseAbilityDamage + ObjectManager.Player.GetSpellDamage(mob, SpellSlot.E) > Check.HealthPrediction.GetHealthPrediction(mob, (int)(E.CastDelay * 1000))
                        && E.IsInRange(mob))
                    {
                        E.Cast(mob.Position);

                        return;
                    }
                }
                if (GragMenu["RJ"].Cast<CheckBox>().CurrentValue)
                {
                    if (ObjectManager.Player.BaseAbilityDamage + ObjectManager.Player.GetSpellDamage(mob, SpellSlot.R) > Check.HealthPrediction.GetHealthPrediction(mob, (int)(R.CastDelay * 1000))
                        && R.IsInRange(mob))
                    {
                        R.Cast(mob.Position);
                        return;
                    }
                }
            }
        }
}
}