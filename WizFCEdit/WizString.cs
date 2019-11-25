﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizEdit
{
    public class WizString
    {
        public const int Wiz1FCStringSize = 0xA0;
        public const int Wiz2FCStringSize = 0x100;
        public const int WizSFCStringSize = 0x100;
        public const int WizGBCStringSize = 0x100;

        public const int Wiz1FCStringStart = 0x00;
        public const int Wiz2FCStringStart = 0x20;
        public const int WizSFCStringStart = 0x20;
        public const int WizGBCStringStart = 0x00;

        static public readonly string NoneName = "-- NONE --";
        static public readonly byte[] Wiz1FCNoneName = new byte[]{0x35, 0x35,0x24, 0x17,0x18,0x17,0x0E, 0x24, 0x35, 0x35 };//-- NONE --

        static public readonly string[] Wiz1FCStrings = new string[]{
      /*00*/"０",/*01*/"１",/*02*/"２",/*03*/"３",/*04*/"４",/*05*/"５",/*06*/"６",/*07*/"７",/*08*/"８",/*09*/"９",/*0A*/"Ａ",/*0B*/"Ｂ",/*0C*/"Ｃ",/*0D*/"Ｄ",/*0E*/"Ｅ",/*0F*/"Ｆ",
      /*10*/"Ｇ",/*11*/"Ｈ",/*12*/"Ｉ",/*13*/"Ｊ",/*14*/"Ｋ",/*15*/"Ｌ",/*16*/"Ｍ",/*17*/"Ｎ",/*18*/"Ｏ",/*19*/"Ｐ",/*1A*/"Ｑ",/*1B*/"Ｒ",/*1C*/"Ｓ",/*1D*/"Ｔ",/*1E*/"Ｕ",/*1F*/"Ｖ",
      /*20*/"Ｗ",/*21*/"Ｘ",/*22*/"Ｙ",/*23*/"Ｚ",/*24*/"　",/*25*/"■",/*26*/"＜",/*27*/"＞",/*28*/"（",/*29*/"）",/*2A*/"／",/*2B*/"＊",/*2C*/"＃",/*2D*/"！",/*2E*/"？",/*2F*/"”",
      /*30*/"’",/*31*/"．",/*32*/"，",/*33*/"　",/*34*/"＋",/*35*/"－",/*36*/"゜",/*37*/"゛",/*38*/"ア",/*39*/"イ",/*3A*/"ウ",/*3B*/"エ",/*3C*/"オ",/*3D*/"カ",/*3E*/"キ",/*3F*/"ク",
      /*40*/"ケ",/*41*/"コ",/*42*/"サ",/*43*/"シ",/*44*/"ス",/*45*/"セ",/*46*/"ソ",/*47*/"タ",/*48*/"チ",/*49*/"ツ",/*4A*/"テ",/*4B*/"ト",/*4C*/"ナ",/*4D*/"ニ",/*4E*/"ヌ",/*4F*/"ネ",
      /*50*/"ノ",/*51*/"ハ",/*52*/"ヒ",/*53*/"フ",/*54*/"ヘ",/*55*/"ホ",/*56*/"マ",/*57*/"ミ",/*58*/"ム",/*59*/"メ",/*5A*/"モ",/*5B*/"ヤ",/*5C*/"ユ",/*5D*/"ヨ",/*5E*/"ラ",/*5F*/"リ",
      /*60*/"ル",/*61*/"レ",/*62*/"ロ",/*63*/"ワ",/*64*/"of",/*65*/"ン",/*66*/"ァ",/*67*/"ィ",/*68*/"ェ",/*69*/"ォ",/*6A*/"ッ",/*6B*/"ャ",/*6C*/"ュ",/*6D*/"ョ",/*6E*/"あ",/*6F*/"い",
      /*70*/"う",/*71*/"え",/*72*/"お",/*73*/"か",/*74*/"き",/*75*/"く",/*76*/"け",/*77*/"こ",/*78*/"さ",/*79*/"し",/*7A*/"す",/*7B*/"せ",/*7C*/"そ",/*7D*/"た",/*7E*/"ち",/*7F*/"つ",
      /*80*/"て",/*81*/"と",/*82*/"な",/*83*/"に",/*84*/"ぬ",/*85*/"ね",/*86*/"の",/*87*/"は",/*88*/"ひ",/*89*/"ふ",/*8A*/"へ",/*8B*/"ほ",/*8C*/"ま",/*8D*/"み",/*8E*/"む",/*8F*/"め",
      /*90*/"も",/*91*/"や",/*92*/"ゆ",/*93*/"よ",/*94*/"ら",/*95*/"り",/*96*/"る",/*97*/"れ",/*98*/"ろ",/*99*/"わ",/*9A*/"を",/*9B*/"ん",/*9C*/"っ",/*9D*/"ゃ",/*9E*/"ゅ",/*9F*/"ょ",
      /*A0*/"□",/*A1*/"□",/*A2*/"□",/*A3*/"□",/*A4*/"□",/*A5*/"□",/*A6*/"□",/*A7*/"□",/*A8*/"□",/*A9*/"□",/*AA*/"□",/*AB*/"□",/*AC*/"□",/*AD*/"□",/*AE*/"□",/*AF*/"□",
      /*B0*/"□",/*B1*/"□",/*B2*/"□",/*B3*/"□",/*B4*/"□",/*B5*/"□",/*B6*/"□",/*B7*/"□",/*B8*/"□",/*B9*/"□",/*BA*/"□",/*BB*/"□",/*BC*/"□",/*BD*/"□",/*BE*/"□",/*BF*/"□",
      /*C0*/"□",/*C1*/"□",/*C2*/"□",/*C3*/"□",/*C4*/"□",/*C5*/"□",/*C6*/"□",/*C7*/"□",/*C8*/"□",/*C9*/"□",/*CA*/"□",/*CB*/"□",/*CC*/"□",/*CD*/"□",/*CE*/"□",/*CF*/"□",
      /*D0*/"□",/*D1*/"□",/*D2*/"□",/*D3*/"□",/*D4*/"□",/*D5*/"□",/*D6*/"□",/*D7*/"□",/*D8*/"□",/*D9*/"□",/*DA*/"□",/*DB*/"□",/*DC*/"□",/*DD*/"□",/*DE*/"□",/*DF*/"□",
      /*E0*/"□",/*E1*/"□",/*E2*/"□",/*E3*/"□",/*E4*/"□",/*E5*/"□",/*E6*/"□",/*E7*/"□",/*E8*/"□",/*E9*/"□",/*EA*/"□",/*EB*/"□",/*EC*/"□",/*ED*/"□",/*EE*/"□",/*EF*/"□",
      /*F0*/"□",/*F1*/"□",/*F2*/"□",/*F3*/"□",/*F4*/"□",/*F5*/"□",/*F6*/"□",/*F7*/"□",/*F8*/"□",/*F9*/"□",/*FA*/"□",/*FB*/"□",/*FC*/"□",/*FD*/"□",/*FE*/"□",/*FF*/"□"
        };
        static public readonly byte[] Wiz2FCNoneName = new byte[] { 0x2D, 0x2D, 0x20, 0x4E, 0x4F, 0x4E, 0x45, 0x20, 0x2D, 0x2D };//-- NONE --
        static public readonly string[] Wiz2FCStrings = new[]{
      /*00*/"□",/*01*/"□",/*02*/"□",/*03*/"□",/*04*/"□",/*05*/"□",/*06*/"□",/*07*/"□",/*08*/"□",/*09*/"□",/*0A*/"□",/*0B*/"□",/*0C*/"□",/*0D*/"□",/*0E*/"□",/*0F*/"□",
      /*10*/"□",/*11*/"□",/*12*/"□",/*13*/"□",/*14*/"□",/*15*/"□",/*16*/"□",/*17*/"□",/*18*/"□",/*19*/"□",/*1A*/"□",/*1B*/"□",/*1C*/"□",/*1D*/"□",/*1E*/"□",/*1F*/"□",
      /*20*/"　",/*21*/"！",/*22*/"”",/*23*/"＃",/*24*/"＄",/*25*/"％",/*26*/"＆",/*27*/"’",/*28*/"（",/*29*/"）",/*2A*/"＊",/*2B*/"＋",/*2C*/"，",/*2D*/"－",/*2E*/"．",/*2F*/"／",
      /*30*/"０",/*31*/"１",/*32*/"２",/*33*/"３",/*34*/"４",/*35*/"５",/*36*/"６",/*37*/"７",/*38*/"８",/*39*/"９",/*3A*/"：",/*3B*/"；",/*3C*/"＜",/*3D*/"＝",/*3E*/"＞",/*3F*/"？",
      /*40*/"＠",/*41*/"Ａ",/*42*/"Ｂ",/*43*/"Ｃ",/*44*/"Ｄ",/*45*/"Ｅ",/*46*/"Ｆ",/*47*/"Ｇ",/*48*/"Ｈ",/*49*/"Ｉ",/*4A*/"Ｊ",/*4B*/"Ｋ",/*4C*/"Ｌ",/*4D*/"Ｍ",/*4E*/"Ｎ",/*4F*/"Ｏ",
      /*50*/"Ｐ",/*51*/"Ｑ",/*52*/"Ｒ",/*53*/"Ｓ",/*54*/"Ｔ",/*55*/"Ｕ",/*56*/"Ｖ",/*57*/"Ｗ",/*58*/"Ｘ",/*59*/"Ｙ",/*5A*/"Ｚ",/*5B*/"［",/*5C*/"￥",/*5D*/"］",/*5E*/"＾",/*5F*/"＿",
      /*60*/"‘",/*61*/"ａ",/*62*/"ｂ",/*63*/"ｃ",/*64*/"ｄ",/*65*/"ｅ",/*66*/"ｆ",/*67*/"ｇ",/*68*/"ｈ",/*69*/"ｉ",/*6A*/"ｊ",/*6B*/"ｋ",/*6C*/"ｌ",/*6D*/"ｍ",/*6E*/"ｎ",/*6F*/"ｏ",
      /*70*/"ｐ",/*71*/"ｑ",/*72*/"ｒ",/*73*/"ｓ",/*74*/"ｔ",/*75*/"ｕ",/*76*/"ｖ",/*77*/"ｗ",/*78*/"ｘ",/*79*/"ｙ",/*7A*/"ｚ",/*7B*/"｛",/*7C*/"｜",/*7D*/"｝",/*7E*/"～",/*7F*/"　",
      /*80*/"〒",/*81*/"▼",/*82*/"★",/*83*/"◆",/*84*/"○",/*85*/"●",/*86*/"を",/*87*/"ぁ",/*88*/"ぃ",/*89*/"ぅ",/*8A*/"ぇ",/*8B*/"ぉ",/*8C*/"ゃ",/*8D*/"ゅ",/*8E*/"ょ",/*8F*/"っ",
      /*90*/"ー",/*91*/"あ",/*92*/"い",/*93*/"う",/*94*/"え",/*95*/"お",/*96*/"か",/*97*/"き",/*98*/"く",/*99*/"け",/*9A*/"こ",/*9B*/"さ",/*9C*/"し",/*9D*/"す",/*9E*/"せ",/*9F*/"そ",
      /*A0*/"の",/*A1*/"。",/*A2*/"薬",/*A3*/"巻",/*A4*/"、",/*A5*/"。",/*A6*/"ヲ",/*A7*/"ァ",/*A8*/"ィ",/*A9*/"ゥ",/*AA*/"ェ",/*AB*/"ォ",/*AC*/"ャ",/*AD*/"ュ",/*AE*/"ョ",/*AF*/"ッ",
      /*B0*/"ー",/*B1*/"ア",/*B2*/"イ",/*B3*/"ウ",/*B4*/"エ",/*B5*/"オ",/*B6*/"カ",/*B7*/"キ",/*B8*/"ク",/*B9*/"ケ",/*BA*/"コ",/*BB*/"サ",/*BC*/"シ",/*BD*/"ス",/*BE*/"セ",/*BF*/"ソ",
      /*C0*/"タ",/*C1*/"チ",/*C2*/"ツ",/*C3*/"テ",/*C4*/"ト",/*C5*/"ナ",/*C6*/"ニ",/*C7*/"ヌ",/*C8*/"ネ",/*C9*/"ノ",/*CA*/"ハ",/*CB*/"ヒ",/*CC*/"フ",/*CD*/"ヘ",/*CE*/"ホ",/*CF*/"マ",
      /*D0*/"ミ",/*D1*/"ム",/*D2*/"メ",/*D3*/"モ",/*D4*/"ヤ",/*D5*/"ユ",/*D6*/"ヨ",/*D7*/"ラ",/*D8*/"リ",/*D9*/"ル",/*DA*/"レ",/*DB*/"ロ",/*DC*/"ワ",/*DD*/"ン",/*DE*/"゛",/*DF*/"゜",
      /*E0*/"た",/*E1*/"ち",/*E2*/"つ",/*E3*/"て",/*E4*/"と",/*E5*/"な",/*E6*/"に",/*E7*/"ぬ",/*E8*/"ね",/*E9*/"の",/*EA*/"は",/*EB*/"ひ",/*EC*/"ふ",/*ED*/"へ",/*EE*/"ほ",/*EF*/"ま",
      /*F0*/"み",/*F1*/"む",/*F2*/"め",/*F3*/"も",/*F4*/"や",/*F5*/"ゆ",/*F6*/"よ",/*F7*/"ら",/*F8*/"り",/*F9*/"る",/*FA*/"れ",/*FB*/"ろ",/*FC*/"わ",/*FD*/"ん",/*FE*/"゛",/*FF*/"゜"
      };

        static public readonly string[] WizGBCStrings = new string[]{
        /*00*/"　",/*01*/"ぇ",/*02*/"え",/*03*/"ぉ",/*04*/"お",/*05*/"か",/*06*/"が",/*07*/"き",/*08*/"ぎ",/*09*/"く",/*0A*/"ぐ",/*0B*/"け",/*0C*/"げ",/*0D*/"こ",/*0E*/"ご",/*0F*/"さ",
        /*10*/"ざ",/*11*/"し",/*12*/"じ",/*13*/"す",/*14*/"ず",/*15*/"せ",/*16*/"ぜ",/*17*/"そ",/*18*/"ぞ",/*19*/"た",/*1A*/"だ",/*1B*/"ち",/*1C*/"ぢ",/*1D*/"っ",/*1E*/"つ",/*1F*/"づ",
        /*20*/"　",/*21*/"！",/*22*/"”",/*23*/"＃",/*24*/"＄",/*25*/"％",/*26*/"＆",/*27*/"’",/*28*/"（",/*29*/"）",/*2A*/"＊",/*2B*/"＋",/*2C*/"，",/*2D*/"－",/*2E*/"．",/*2F*/"／",
        /*30*/"０",/*31*/"１",/*32*/"２",/*33*/"３",/*34*/"４",/*35*/"５",/*36*/"６",/*37*/"７",/*38*/"８",/*39*/"９",/*3A*/"：",/*3B*/"；",/*3C*/"＜",/*3D*/"＝",/*3E*/"＞",/*3F*/"？",
        /*40*/"＠",/*41*/"Ａ",/*42*/"Ｂ",/*43*/"Ｃ",/*44*/"Ｄ",/*45*/"Ｅ",/*46*/"Ｆ",/*47*/"Ｇ",/*48*/"Ｈ",/*49*/"Ｉ",/*4A*/"Ｊ",/*4B*/"Ｋ",/*4C*/"Ｌ",/*4D*/"Ｍ",/*4E*/"Ｎ",/*4F*/"Ｏ",
        /*50*/"Ｐ",/*51*/"Ｑ",/*52*/"Ｒ",/*53*/"Ｓ",/*54*/"Ｔ",/*55*/"Ｕ",/*56*/"Ｖ",/*57*/"Ｗ",/*58*/"Ｘ",/*59*/"Ｙ",/*5A*/"Ｚ",/*5B*/"「",/*5C*/"￥",/*5D*/"」",/*5E*/"・",/*5F*/"＿",
        /*60*/"う",/*61*/"ａ",/*62*/"ｂ",/*63*/"ｃ",/*64*/"ｄ",/*65*/"ｅ",/*66*/"ｆ",/*67*/"ｇ",/*68*/"ｈ",/*69*/"ｉ",/*6A*/"ｊ",/*6B*/"ｋ",/*6C*/"ｌ",/*6D*/"ｍ",/*6E*/"ｎ",/*6F*/"ｏ",
        /*70*/"ｐ",/*71*/"ｑ",/*72*/"ｒ",/*73*/"ｓ",/*74*/"ｔ",/*75*/"ｕ",/*76*/"ｖ",/*77*/"ｗ",/*78*/"ｘ",/*79*/"ｙ",/*7A*/"ｚ",/*7B*/"ぁ",/*7C*/"あ",/*7D*/"ぃ",/*7E*/"い",/*7F*/"ぅ",
        /*80*/"て",/*81*/"で",/*82*/"と",/*83*/"ど",/*84*/"な",/*85*/"に",/*86*/"ぬ",/*87*/"ね",/*88*/"の",/*89*/"は",/*8A*/"ば",/*8B*/"ぱ",/*8C*/"ひ",/*8D*/"び",/*8E*/"ぴ",/*8F*/"ふ",
        /*90*/"ぶ",/*91*/"ぷ",/*92*/"へ",/*93*/"べ",/*94*/"ぺ",/*95*/"ほ",/*96*/"ぼ",/*97*/"ぽ",/*98*/"ま",/*99*/"み",/*9A*/"む",/*9B*/"め",/*9C*/"も",/*9D*/"ゃ",/*9E*/"や",/*9F*/"ゅ",
        /*A0*/"ゆ",/*A1*/"ょ",/*A2*/"よ",/*A3*/"ら",/*A4*/"り",/*A5*/"る",/*A6*/"れ",/*A7*/"ろ",/*A8*/"わ",/*A9*/"を",/*AA*/"ん",/*AB*/"、",/*AC*/"。",/*AD*/"ァ",/*AE*/"ア",/*AF*/"ィ",
        /*B0*/"イ",/*B1*/"ゥ",/*B2*/"ウ",/*B3*/"ェ",/*B4*/"エ",/*B5*/"ォ",/*B6*/"オ",/*B7*/"カ",/*B8*/"ガ",/*B9*/"キ",/*BA*/"ギ",/*BB*/"ク",/*BC*/"グ",/*BD*/"ケ",/*BE*/"ゲ",/*BF*/"コ",
        /*C0*/"ゴ",/*C1*/"サ",/*C2*/"ザ",/*C3*/"シ",/*C4*/"ジ",/*C5*/"ス",/*C6*/"ズ",/*C7*/"セ",/*C8*/"ゼ",/*C9*/"ソ",/*CA*/"ゾ",/*CB*/"タ",/*CC*/"ダ",/*CD*/"チ",/*CE*/"ヂ",/*CF*/"ッ",
        /*D0*/"ツ",/*D1*/"ヅ",/*D2*/"テ",/*D3*/"デ",/*D4*/"ト",/*D5*/"ド",/*D6*/"ナ",/*D7*/"ニ",/*D8*/"ヌ",/*D9*/"ネ",/*DA*/"ノ",/*DB*/"ハ",/*DC*/"バ",/*DD*/"パ",/*DE*/"ヒ",/*DF*/"ビ",
        /*E0*/"ピ",/*E1*/"フ",/*E2*/"ブ",/*E3*/"プ",/*E4*/"ヘ",/*E5*/"ベ",/*E6*/"ペ",/*E7*/"ホ",/*E8*/"ボ",/*E9*/"ポ",/*EA*/"マ",/*EB*/"ミ",/*EC*/"ム",/*ED*/"メ",/*EE*/"モ",/*EF*/"ャ",
        /*F0*/"ヤ",/*F1*/"ュ",/*F2*/"ユ",/*F3*/"ョ",/*F4*/"ヨ",/*F5*/"ラ",/*F6*/"リ",/*F7*/"ル",/*F8*/"レ",/*F9*/"ロ",/*FA*/"ワ",/*FB*/"ヲ",/*FC*/"ン",/*FD*/"ヴ",/*FE*/"゛",/*FF*/"゜"
        };

        static public readonly string[] WizSFCStrings = new string[]{
        /*00*/ "□",/*01*/ "□",/*02*/ "□",/*03*/ "□",/*04*/ "□",/*05*/ "□",/*06*/ "□",/*07*/ "□",/*08*/ "□",/*09*/ "□",/*0A*/ "□",/*0B*/ "□",/*0C*/ "□",/*0D*/ "□",/*0E*/ "□",/*0F*/ "□",
        /*10*/ "□",/*11*/ "□",/*12*/ "□",/*13*/ "□",/*14*/ "□",/*15*/ "□",/*16*/ "□",/*17*/ "□",/*18*/ "□",/*19*/ "□",/*1A*/ "□",/*1B*/ "□",/*1C*/ "□",/*1D*/ "□",/*1E*/ "□",/*1F*/ "□",
        /*20*/ "　",/*21*/ "！",/*22*/ "”",/*23*/ "＃",/*24*/ "＄",/*25*/ "％",/*26*/ "＆",/*27*/ "’",/*28*/ "（",/*29*/ "）",/*2A*/ "＊",/*2B*/ "＋",/*2C*/ "，",/*2D*/ "－",/*2E*/ "．",/*2F*/ "／",
        /*30*/ "０",/*31*/ "１",/*32*/ "２",/*33*/ "３",/*34*/ "４",/*35*/ "５",/*36*/ "６",/*37*/ "７",/*38*/ "８",/*39*/ "９",/*3A*/ "：",/*3B*/ "；",/*3C*/ "＜",/*3D*/ "＝",/*3E*/ "＞",/*3F*/ "？",
        /*40*/ "＠",/*41*/ "Ａ",/*42*/ "Ｂ",/*43*/ "Ｃ",/*44*/ "Ｄ",/*45*/ "Ｅ",/*46*/ "Ｆ",/*47*/ "Ｇ",/*48*/ "Ｈ",/*49*/ "Ｉ",/*4A*/ "Ｊ",/*4B*/ "Ｋ",/*4C*/ "Ｌ",/*4D*/ "Ｍ",/*4E*/ "Ｎ",/*4F*/ "Ｏ",
        /*50*/ "Ｐ",/*51*/ "Ｑ",/*52*/ "Ｒ",/*53*/ "Ｓ",/*54*/ "Ｔ",/*55*/ "Ｕ",/*56*/ "Ｖ",/*57*/ "Ｗ",/*58*/ "Ｘ",/*59*/ "Ｙ",/*5A*/ "Ｚ",/*5B*/ "［",/*5C*/ "￥",/*5D*/ "］",/*5E*/ "＾",/*5F*/ "＿",
        /*60*/ "‘",/*61*/ "ａ",/*62*/ "ｂ",/*63*/ "ｃ",/*64*/ "ｄ",/*65*/ "ｅ",/*66*/ "ｆ",/*67*/ "ｇ",/*68*/ "ｈ",/*69*/ "ｉ",/*6A*/ "ｊ",/*6B*/ "ｋ",/*6C*/ "ｌ",/*6D*/ "ｍ",/*6E*/ "ｎ",/*6F*/ "ｏ",
        /*70*/ "ｐ",/*71*/ "ｑ",/*72*/ "ｒ",/*73*/ "ｓ",/*74*/ "ｔ",/*75*/ "ｕ",/*76*/ "ｖ",/*77*/ "ｗ",/*78*/ "ｘ",/*79*/ "ｙ",/*7A*/ "ｚ",/*7B*/ "｛",/*7C*/ "￤",/*7D*/ "｝",/*7E*/ "￣",/*7F*/ "「",
        /*80*/ "♠", /*81*/ "♥", /*82*/ "♣", /*83*/ "♦", /*84*/ "○",/*85*/ "●",/*86*/ "を",/*87*/ "ぁ",/*88*/ "ぃ",/*89*/ "ぅ",/*8A*/ "ぇ",/*8B*/ "ぉ",/*8C*/ "ゃ",/*8D*/ "ゅ",/*8E*/ "ょ",/*8F*/ "っ",
        /*90*/ "。",/*91*/ "あ",/*92*/ "い",/*93*/ "う",/*94*/ "え",/*95*/ "お",/*96*/ "か",/*97*/ "き",/*98*/ "く",/*99*/ "け",/*9A*/ "こ",/*9B*/ "さ",/*9C*/ "し",/*9D*/ "す",/*9E*/ "せ",/*9F*/ "そ",
        /*A0*/ "o", /*A1*/ "f", /*A2*/ "’",/*A3*/ "s", /*A4*/ "、",/*A5*/ "・",/*A6*/ "ヲ",/*A7*/ "ァ",/*A8*/ "ィ",/*A9*/ "ゥ",/*AA*/ "ェ",/*AB*/ "ォ",/*AC*/ "ャ",/*AD*/ "ュ",/*AE*/ "ョ",/*AF*/ "ッ",
        /*B0*/ "」",/*B1*/ "ア",/*B2*/ "イ",/*B3*/ "ウ",/*B4*/ "エ",/*B5*/ "オ",/*B6*/ "カ",/*B7*/ "キ",/*B8*/ "ク",/*B9*/ "ケ",/*BA*/ "コ",/*BB*/ "サ",/*BC*/ "シ",/*BD*/ "ス",/*BE*/ "セ",/*BF*/ "ソ",
        /*C0*/ "タ",/*C1*/ "チ",/*C2*/ "ツ",/*C3*/ "テ",/*C4*/ "ト",/*C5*/ "ナ",/*C6*/ "ニ",/*C7*/ "ヌ",/*C8*/ "ネ",/*C9*/ "ノ",/*CA*/ "ハ",/*CB*/ "ヒ",/*CC*/ "フ",/*CD*/ "ヘ",/*CE*/ "ホ",/*CF*/ "マ",
        /*D0*/ "ミ",/*D1*/ "ム",/*D2*/ "メ",/*D3*/ "モ",/*D4*/ "ヤ",/*D5*/ "ユ",/*D6*/ "ヨ",/*D7*/ "ラ",/*D8*/ "リ",/*D9*/ "ル",/*DA*/ "レ",/*DB*/ "ロ",/*DC*/ "ワ",/*DD*/ "ン",/*DE*/ "゛",/*DF*/ "゜",
        /*E0*/ "た",/*E1*/ "ち",/*E2*/ "つ",/*E3*/ "て",/*E4*/ "と",/*E5*/ "な",/*E6*/ "に",/*E7*/ "ぬ",/*E8*/ "ね",/*E9*/ "の",/*EA*/ "は",/*EB*/ "ひ",/*EC*/ "ふ",/*ED*/ "へ",/*EE*/ "ほ",/*EF*/ "ま",
        /*F0*/ "み",/*F1*/ "む",/*F2*/ "め",/*F3*/ "も",/*F4*/ "や",/*F5*/ "ゆ",/*F6*/ "よ",/*F7*/ "ら",/*F8*/ "り",/*F9*/ "る",/*FA*/ "れ",/*FB*/ "ろ",/*FC*/ "わ",/*FD*/ "ん",/*FE*/ "゛",/*FF*/ "゜"
        };


        static public string CodeToString(WIZSCN scn,byte value)
        {
            string ret = "";
            if (scn == WIZSCN.NO) return ret;
            if ((value>=0)&&(value<=0xFF))
            {

                switch (scn)
                {
                    case WIZSCN.FC1:
                        ret = Wiz1FCStrings[(int)value];
                        break;
                    case WIZSCN.FC2:
                    case WIZSCN.FC3:
                        ret = Wiz1FCStrings[(int)value];
                        break;
                    case WIZSCN.SFC1:
                    case WIZSCN.SFC2:
                    case WIZSCN.SFC3:
                        ret = WizSFCStrings[(int)value];
                        break;
                    case WIZSCN.GBC1:
                    case WIZSCN.GBC2:
                    case WIZSCN.GBC3:
                        ret = WizSFCStrings[(int)value];
                        break;
                }
            }
            return ret;
        }
        static public string CodeToString(WIZSCN scn, byte [] values)
        {
            string ret = "";
            if (scn == WIZSCN.NO) return ret;
            if (values.Length <= 0) return ret;
            for ( int i=0; i<values.Length;i++)
            {
                ret += CodeToString(scn, values[i]);
            }
            return ret;

        }
        static public byte StringToCode(WIZSCN scn, char c)
        {
            int idx = -1;
            string s = c.ToString();
            
            switch (scn)
            {
                case WIZSCN.FC1:
                    if (s != "")
                    {
                        for (int i = Wiz1FCStringStart; i < Wiz1FCStringSize; i++)
                        {
                            if (Wiz1FCStrings[i] == s)
                            {
                                idx = i;
                                break;
                            }
                        }
                    }
                    if (idx <= -1) idx = 0x2E;
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                    if (s != "")
                    {
                        for (int i = Wiz2FCStringStart; i < Wiz2FCStringSize; i++)
                        {
                            if (Wiz2FCStrings[i] == s)
                            {
                                idx = i;
                                break;
                            }
                        }
                    }
                    if (idx <= -1) idx = 0x2F;
                    break;
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                    if (s != "")
                    {
                        for (int i = WizSFCStringStart; i < WizSFCStringSize; i++)
                        {
                            if (WizSFCStrings[i] == s)
                            {
                                idx = i;
                                break;
                            }
                        }
                    }
                    if (idx <= -1) idx = 0x3F;
                    break;
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                    if (s != "")
                    {
                        for (int i = WizGBCStringStart; i < WizGBCStringSize; i++)
                        {
                            if (WizGBCStrings[i] == s)
                            {
                                idx = i;
                                break;
                            }
                        }
                    }
                    if (idx <= -1) idx = 0x3F;
                    break;

            }
            return (byte)idx;
        }
        static public byte [] StringToCode(WIZSCN scn, string str)
        {
            if (str == "") return new byte[0];
            byte[] ret = new byte[str.Length];

            for (int i=0; i<str.Length;i++)
            {
                ret[i] = StringToCode(scn, str[i]);
            }
            return ret;
            
        }

    }
}
