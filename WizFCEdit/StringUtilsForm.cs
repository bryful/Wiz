﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WizEdit
{
    public partial class StringUtilsForm : Form
    {
        string[] Wiz5Strings = new string[]{
"□",
"□",
"□",
"□",
"□",
"□",
"□",
"□",
"□",
"□",
"□",
"□",
"□",
"□",
"□",
"□",
"□",
"□",
"□",
"□",
"□",
"□",
"□",
"□",
"□",
"□",
"□",
"□",
"□",
"□",
"□",
"□",
"　",
"！",
"”",
"＃",
"＄",
"％",
"＆",
"’",
"（",
"）",
"＊",
"＋",
"，",
"－",
"．",
"／",
"０",
"１",
"２",
"３",
"４",
"５",
"６",
"７",
"８",
"９",
"：",
"；",
"＜",
"＝",
"＞",
"？",
"＠",
"Ａ",
"Ｂ",
"Ｃ",
"Ｄ",
"Ｅ",
"Ｆ",
"Ｇ",
"Ｈ",
"Ｉ",
"Ｊ",
"Ｋ",
"Ｌ",
"Ｍ",
"Ｎ",
"Ｏ",
"Ｐ",
"Ｑ",
"Ｒ",
"Ｓ",
"Ｔ",
"Ｕ",
"Ｖ",
"Ｗ",
"Ｘ",
"Ｙ",
"Ｚ",
"［",
"￥",
"］",
"＾",
"＿",
"‘",
"ａ",
"ｂ",
"ｃ",
"ｄ",
"ｅ",
"ｆ",
"ｇ",
"ｈ",
"ｉ",
"ｊ",
"ｋ",
"ｌ",
"ｍ",
"ｎ",
"ｏ",
"ｐ",
"ｑ",
"ｒ",
"ｓ",
"ｔ",
"ｕ",
"ｖ",
"ｗ",
"ｘ",
"ｙ",
"ｚ",
"｛",
"￤",
"｝",
"￣",
"カーソル",
"スペード",
"ハート",
"クラブ",
"ダイヤ",
"○",
"●",
"を",
"ぁ",
"ぃ",
"ぅ",
"ぇ",
"ぉ",
"ゃ",
"ゅ",
"ょ",
"っ",
"*",
"あ",
"い",
"う",
"え",
"お",
"か",
"き",
"く",
"け",
"こ",
"さ",
"し",
"す",
"せ",
"そ",
"of",
"。",
"P",
"S",
"、",
"・",
"ヲ",
"ァ",
"ィ",
"ゥ",
"ェ",
"ォ",
"ャ",
"ュ",
"ョ",
"ッ",
"ー",
"ア",
"イ",
"ウ",
"エ",
"オ",
"カ",
"キ",
"ク",
"ケ",
"コ",
"サ",
"シ",
"ス",
"セ",
"ソ",
"タ",
"チ",
"ツ",
"テ",
"ト",
"ナ",
"ニ",
"ヌ",
"ネ",
"ノ",
"ハ",
"ヒ",
"フ",
"ヘ",
"ホ",
"マ",
"ミ",
"ム",
"メ",
"モ",
"ヤ",
"ユ",
"ヨ",
"ラ",
"リ",
"ル",
"レ",
"ロ",
"ワ",
"ン",
"゛",
"゜",
"た",
"ち",
"つ",
"て",
"と",
"な",
"に",
"ぬ",
"ね",
"の",
"は",
"ひ",
"ふ",
"へ",
"ほ",
"ま",
"み",
"む",
"め",
"も",
"や",
"ゆ",
"よ",
"ら",
"り",
"る",
"れ",
"ろ",
"わ",
"ん",
"゛",
"゜"
};
        string[] Wiz1GBCItem = new string[]{
"ガラクタ",
"剣",
"短剣",
"メイス",
"フレイル",
"杖",
"短刀",
"小型の盾",
"盾",
"ローブ",
"革の鎧",
"鎖帷子",
"胸当て",
"プレートメイル",
"兜",
"治療の薬",
"毒消し",
"切り裂きの剣",
"鋭い短剣",
"粉砕のメイス",
"鉄の杖",
"眠りの巻物",
"硬い革鎧",
"光る鎖帷子",
"丈夫の鎧",
"鉄の盾",
"胴鎧",
"痛みの巻物",
"炎の巻物",
"鈍らな剣",
"幻滅の短剣",
"災いのメイス",
"硬い杖",
"ドラゴンスレイヤー",
"忍耐の兜",
"腐った革鎧",
"錆びた鎖帷子",
"罅割れた胸当て",
"歪んだ盾",
"宝石の指輪",
"稲妻の巻物",
"煙玉",
"真二つの剣",
"レイピア",
"力のメイス",
"導きの巻物",
"目眩ましの巻物",
"銅の篭手",
"豪華な革鎧",
"銀の鎖帷子",
"極上の鎧",
"支えの盾",
"悪の兜",
"特効薬",
"守りの指輪",
"ワースレイヤー",
"メイジマッシャー",
"ヘビのメイス",
"沈黙の杖",
"カシナートの剣",
"戒めの指輪",
"炎の杖",
"悪の鎖帷子",
"中立の鎧",
"悪の盾",
"酸欠の指輪",
"転移の兜",
"一撃の巻物",
"破滅の短剣",
"切り裂きの短刀",
"病めるメイス",
"捻れた杖",
"早業の短刀",
"呪われたローブ",
"破滅の革鎧",
"呪いの鎖帷子",
"悪魔の胸当て",
"虚ろの盾",
"古びた兜",
"希望の胸当て",
"銀の篭手",
"悪のサーベル",
"ソウルスレイヤー",
"盗賊の短刀",
"英雄の胸当て",
"君主の聖衣",
"村正",
"ザ・シュリケン！",
"氷の鎖帷子",
"悪の鎧",
"守りの盾",
"回復の指輪",
"破邪の指輪",
"滅びの指輪",
"ワードナの魔除け",
"クマの置物",
"カエルの置物",
"青銅の鍵",
"銀の鍵",
"金の鍵",
"ブルーリボン",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ダイヤモンドソード",
"ダイヤモンドの篭手",
"大魔道士の魔除け",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"素早さの石",
"ガラクタ",
"ガラクタ",
"カエルの剣",
"クマの鎧",
"ウィンドソード",
"魔法使いのローブ",
"魔法の手袋",
"魔法の頭巾",
"ルビーのスリッパ",
"防御の巻物",
"革の篭手",
"羽根帽子",
"オウガブレード",
"髑髏の盾",
"ルビーの靴",
"全快の薬",
"ドラゴンバスター",
"必殺の針",
"中立の盾",
"闇装束",
"スケイルアーマー",
"賢者のローブ",
"星屑の杖",
"気付け薬",
"致死の巻物",
"冷気の巻物",
"アーメット",
"オベロンの指輪",
"心の石",
"信心の石",
"七星剣",
"ニンジャガーブ",
"プラチナプレート",
"金の篭手",
"酸欠の巻物",
"大爆発の巻物",
"ドラゴンカイト",
"魔封じの盾",
"黒糸威",
"春日の手甲",
"反魂香",
"獅子王",
"エクスカリバー",
"覇王の兜"
};

        string[] WizGBCItem2 = new string[]{
"ガラクタ",
"イアリシンの宝珠",
"中立の水晶",
"悪の水晶",
"善の水晶",
"ビン詰めの船",
"大地の杖",
"空気の魔除け",
"聖水",
"炎の杖",
"金のメダリオン",
"ミューズフェスの宝珠",
"バタフライナイフ",
"短剣",
"ブロードソード",
"メイス",
"杖",
"斧",
"バトルアックス",
"短刀",
"フレイル",
"盾",
"鉄の盾",
"魔法使いのローブ",
"キュイラス",
"ホウバーク",
"胸当て",
"プレートメイル",
"サーリット",
"傷薬",
"毒消し",
"レイピア",
"切り裂きの剣",
"粉砕のメイス",
"ヘビーアックス",
"ヌンチャク",
"切り裂きの短刀",
"眠りの巻物",
"硬い革鎧",
"光る鎖帷子",
"胴鎧",
"丈夫の鎧",
"鉄の盾＋１",
"鉄の兜",
"鉄の篭手",
"苦痛の巻物",
"炎の薬",
"幻滅の短剣",
"鈍らな剣",
"災いのメイス",
"赤錆びた短刀",
"壊れたオノ",
"マルゴーのフレイル",
"宝石の袋",
"魔法使いの杖",
"フレイムタン",
"歪んだ盾",
"腐った革鎧",
"錆びた鎖帷子",
"罅割れた胸当て",
"古代の鎧",
"古びた兜",
"煙玉",
"金の指輪",
"サラマンダーの指輪",
"ヘビの牙",
"真二つの剣",
"レイピア＋１",
"グレートアックス",
"象牙の短刀（善）",
"黒檀の短刀（悪）",
"琥珀の短刀（中立）",
"力のメイス",
"ミスリルの篭手",
"麻痺の魔除け",
"豪華な革鎧",
"支えの盾",
"身躱しのローブ",
"銀の鎖帷子",
"希望の胸当て",
"極上の鎧",
"アーメット",
"ワーガンローブ",
"巨人の棍棒",
"カシナートの剣",
"羊飼いの杖",
"邪悪の斧",
"滅びの杖",
"魔除けの宝石",
"エメラルドの袋",
"ガーネットの袋",
"青真珠",
"ルビーのスリッパ",
"ネクロマンサーの杖",
"命の書",
"滅びの書",
"ドラゴンの牙",
"トロールの指輪",
"ウサギの足",
"盗賊のピック",
"悪魔の書",
"バタフライナイフ",
"金のティアラ",
"カマキリの篭手",
"村正",
"ザ・シュリケン！",
"君主の聖衣",
"赤いクツ",
"金の斧",
"黄色い耳栓",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ダイヤモンドソード",
"ダイヤモンドの篭手",
"大魔道士の魔除け",
"反魂香",
"金剛石の目",
"ルビーの靴",
"宝石の指輪",
"飛竜の腕輪",
"次元の水晶",
"勝者の証",
"調和のベルト",
"剣士のベルト",
"魔王のベルト",
"革ベルト",
"魔刀正光",
"神の槌",
"ジャイアントバスター",
"ドラゴンバスター",
"錆びた棒",
"ブラッドサッカー",
"真紅の鎖帷子",
"ゴールデンハンマー",
"太陽の剣",
"藍色の鎖帷子",
"タケミツ",
"羽根帽子",
"アサシンニードル",
"雪風",
"火炎の巻物",
"神秘の小枝",
"鉛の篭手",
"魔封じの盾",
"魔法の頭巾",
"硬い革の篭手",
"スケイルアーマー",
"大爆発の巻物",
"金剛の杖",
"黒糸威",
"プラチナプレート",
"肩鎧",
"ドラゴンカイト",
"グレートヘルム",
"王者の篭手",
"拉げた魔道器",
"水銀のローブ",
"心の石",
"信心の石",
"命の石",
"若返りの石",
"金の聖杯",
"葉隠れの書",
"魂の箱"
};

        private readonly string[] m_WizGBCItemNames3 = new string[] {
"ガラクタ",
"剣",
"短剣",
"メイス",
"フレイル",
"杖",
"短刀",
"小型の盾",
"盾",
"ローブ",
"革の鎧",
"鎖帷子",
"胸当て",
"プレートメイル",
"兜",
"治療の薬",
"毒消し",
"切り裂きの剣",
"貫きの短剣",
"粉砕のメイス",
"鉄の杖",
"眠りの巻物",
"硬い革鎧",
"光る鎖帷子",
"丈夫の鎧",
"鉄の盾",
"胴鎧",
"痛みの巻物",
"炎の巻物",
"鈍らな剣",
"幻滅の短剣",
"災いのメイス",
"硬い杖",
"ドラゴンスレイヤー",
"忍耐の兜",
"腐った革鎧",
"錆びた鎖帷子",
"罅割れた胸当て",
"歪んだ盾",
"宝石の指輪",
"稲妻の巻物",
"煙玉",
"真二つの剣",
"レイピア",
"力のメイス",
"導きの巻物",
"目眩ましの巻物",
"銅の篭手",
"豪華な革鎧",
"銀の鎖帷子",
"極上の鎧",
"支えの盾",
"悪の兜",
"特効薬",
"守りの指輪",
"ワースレイヤー",
"メイジマッシャー",
"ヘビのメイス",
"沈黙の杖",
"カシナートの剣",
"戒めの指輪",
"炎の杖",
"悪の鎖帷子",
"中立の鎧",
"悪の盾",
"酸欠の指輪",
"転移の兜",
"一撃の巻物",
"破滅の短剣",
"切り裂きの短刀",
"病めるメイス",
"捻れた杖",
"早業の短刀",
"呪われたローブ",
"破滅の革鎧",
"呪いの鎖帷子",
"悪魔の胸当て",
"虚ろの盾",
"古びた兜",
"希望の胸当て",
"銀の篭手",
"悪のサーベル",
"ソウルスレイヤー",
"盗賊の短刀",
"英雄の胸当て",
"君主の聖衣",
"村正",
"ザ・シュリケン！",
"氷の鎖帷子",
"悪の鎧",
"守りの盾",
"回復の指輪",
"破邪の指輪",
"滅びの指輪",
"復活の杖",
"古の御守り",
"身躱しのローブ",
"手袋",
"魔封じのネックレス",
"光の杖",
"光の剣",
"閃きの剣",
"プリーストパンチャー",
"僧侶のメイス",
"閃きの短剣",
"炎の指輪",
"呪われた鎧",
"ミスリルの鎧",
"癒しの杖",
"命の指輪",
"変化の指輪",
"不思議な石",
"希望の石",
"神秘的な石",
"偉大なる魔法使いの杖",
"力のコイン",
"若返りの石",
"心の石",
"信心の石",
"ブラーニィの石",
"熟練の魔除け",
"熟練の魔除け",
"偉大なる魔法使いの杖",
"力のコイン",
"ニルダの杖",
"ハースニール",
"伝説の兜",
"伝説の盾",
"伝説の篭手",
"伝説の鎧",
"錆びた鍵",
"血塗れのバッジ",
"奇妙な紋章",
"黒檀の鍵",
"修道院の鍵",
"ミスリルの鍵",
"マスターキー",
"悪魔の石",
"ガラクタ",
"ガラクタ",
"ダイヤモンドソード",
"ダイヤモンドの篭手",
"大魔道士の魔除け",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"ガラクタ",
"亡者の書",
"亡者のコイン",
"ドリームペインターの羽根",
"フェザースタッフ",
"受け流しの短剣",
"アーメット",
"ファランクスの盾",
"革の兜",
"スケールアーマー",
"羽根帽子",
"革の篭手",
"肩当て",
"滅びの巻物",
"黒糸威",
"ウィンドソード",
"魔法の頭巾",
"気付け薬",
"ガーディアンホーン",
"グラディエイター",
"地獄の斧",
"小烏丸",
"魔封じの盾",
"ブラッディーローブ",
"錆び付いた斧",
"闇のメイス",
"無傷の石",
"苔生した石",
"力の篭手",
"酸欠の巻物",
"冷気の巻物",
"幸運の篭手",
"悪の書",
"善の書",
"悪魔の牙",
"悪魔の鈎爪",
"必殺の針",
"雷撃の巻物",
"全滅の巻物",
"騎士の盾",
"漆黒の篭手",
"硬い革の篭手",
"蛇の篭手",
"五輪書",
"大地の鎧",
"鉛の鎧",
"賢者の法衣",
"エルフの鎖帷子",
"闇装束",
"極悪の盾",
"ニンジャガーブ",
"エルフのレイピア",
"全快の薬",
"金剛石の目",
"ウィングブーツ",
"水銀のローブ",
"漆黒のマント",
"大爆発の巻物",
"ブラッディーマント",
"反魂香",
"ブラックキャンドル",
"悪魔のチャイム",
"ネクロノミコン",
"ルビーの靴",
"黒革の服",
"九尾のムチ",
"漆黒の鎧",
"力のアンク",
"知恵のアンク",
"祈りのアンク",
"生命のアンク",
"素早さのアンク",
"幸運のアンク",
"天女の羽衣",
"不気味なブーツ",
"デストラクションブレード",
"ナックルブレード",
"大盗賊のナイフ"
};
        private readonly string[] m_WizSFCItemNames5 = new string[]{
"ガラクタ",
"松明",
"ランプ",
"ゴムのアヒル",
"短刀",
"杖",
"ショートソード",
"ロングソード",
"メイス",
"ハンドアックス",
"長槍",
"ウォーハンマー",
"ホーリーバッシャー",
"戦士の弓",
"盗賊の弓",
"ローブ",
"革鎧",
"鎖帷子",
"足軽の鎧",
"プレートメイル",
"丸盾",
"ヒーターシールド",
"革の兜",
"革の篭手",
"ロバーズソード",
"ナイトソード",
"ブラックブレード",
"刀",
"バトルアックス",
"モーニングスター",
"病めるフレイル",
"ハルバード",
"クロスボウ",
"硬い革鎧",
"光る鎖帷子",
"武士の鎧",
"ナイトプレート",
"白銀の鎧",
"硬い丸盾",
"ナイトシールド",
"紋章の盾",
"真鍮の兜",
"鉄の篭手",
"ヴァンブレイス",
"マスターソード",
"ロビンソード",
"ファイアーソード",
"達人の刀",
"ソウルスティーラー",
"シルバーアックス",
"デスアックス",
"聖なるフレイル",
"ファウストハルバード",
"シルバーハンマー",
"魔法使いの弓",
"ヘビィクロスボウ",
"豪華な革鎧",
"銀の鎖帷子",
"達人の鎧",
"マスタープレート",
"スカーレットローブ",
"エメラルドローブ",
"タワーシールド",
"鋼の兜",
"炎の尖り帽子",
"銀の篭手",
"ナイトヴァンブレイス",
"カシナートの剣",
"守りの鎧",
"魔封じの盾",
"宝石のアーメット",
"魔法の頭巾",
"ミルダールの篭手",
"山羊座のマント",
"森の精の弓",
"村正",
"オーディンソード",
"金色の鎧",
"魔法使いの指輪",
"髑髏の指輪",
"全快の指輪",
"翡翠の指輪",
"孤独の指輪",
"奇跡のアンク",
"力のアンク",
"命のアンク",
"知恵のアンク",
"祈りのアンク",
"若さのアンク",
"召喚の杖",
"死神の杖",
"眠りの巻物",
"石の巻物",
"炎の巻物",
"召喚の巻物",
"傷薬",
"惚れ薬",
"毒消し",
"気付け薬",
"劇薬",
"特効薬",
"ダイヤのキング",
"ハートのクイーン",
"スペードのジャック",
"クラブのエース",
"猿のワンド",
"稲妻の杖",
"絡繰ヒバリ",
"水の杖",
"炎の杖",
"空気の杖",
"大地の杖",
"聖水",
"金のメダリオン",
"氷の鍵",
"半券",
"チケット",
"骸骨の鍵",
"懐中時計",
"バッテリー",
"石化した悪魔",
"金の鍵",
"青いロウソク",
"宝石の笏",
"除霊の秘薬",
"金鋸",
"ラム酒",
"銀の鍵",
"トークンの入った袋",
"真鍮の鍵",
"リルガミンの宝珠",
"アブリエルの",
"聖なるタリスマン",
"虹の魔除け",
"霧の魔除け",
"炎の魔除け"
};


        public StringUtilsForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = "string[] Wiz5Strings = new string[]{\r\n";

            for (int i=0; i<0x100;i++)
            {
                string ss = String.Format("/*{0:X2}*/\"{1}\",", i, Wiz5Strings[i]);
                if ((i % 0x10) == 0) s += "\r\n";
                s += ss;
            }
            textBox1.Text = s;
        }

        private void StringUtilsForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = "string[] Wiz1GBCStrings = new string[]{\r\n";

            for (int i = 0; i < Wiz1GBCItem.Length; i++)
            {
                string ss = String.Format("/*{0:X2}*/\"{0:X2}:{1}\",\r\n", i, Wiz1GBCItem[i]);
           
                s += ss;
            }
            textBox1.Text = s;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s = "string[] WizGBCItem2 = new string[]{\r\n";

            for (int i = 0; i < WizGBCItem2.Length; i++)
            {
                string ss = String.Format("/*{0:X2}*/\"{0:X2}:{1}\",\r\n", i, WizGBCItem2[i]);

                s += ss;
            }
            textBox1.Text = s;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string s = "string[] m_WizGBCItemNames3 = new string[]{\r\n";

            for (int i = 0; i < m_WizGBCItemNames3.Length; i++)
            {
                string ss = String.Format("/*{0:X2}*/\"{0:X2}:{1}\",\r\n", i, m_WizGBCItemNames3[i]);

                s += ss;
            }
            s += "};";

            textBox1.Text = s;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string s = "string[] m_WizSFCItemNames5 = new string[]{\r\n";

            for (int i = 0; i < m_WizSFCItemNames5.Length; i++)
            {
                string ss = String.Format("/*{0:X2}*/\"{0:X2}:{1}\",\r\n", i, m_WizSFCItemNames5[i]);

                s += ss;
            }
            s += "};";

            textBox1.Text = s;
        }

        private void button6_Click(object sender, EventArgs e)
        {

            byte[] Wiz5SFCNoneName = WizString.StringToCode(WIZSCN.SFC5, WizString.NoneName);
            string s = "";

            for ( int i=0; i< Wiz5SFCNoneName.Length; i++)
            {
                if (s != "") s += ",";
                s += String.Format("0x{0:X2}", Wiz5SFCNoneName[i]);
            }

            s = "static public readonly byte[] Wiz5SFCNoneName = new byte[] {" + s + "};//-- NONE --";
            textBox1.Text = s;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            byte[] a = WizString.StringToCode(WIZSCN.GBC1, WizString.NoneName);
            string s = "";

            for (int i = 0; i < a.Length; i++)
            {
                if (s != "") s += ",";
                s += String.Format("0x{0:X2}", a[i]);
            }

            s = "static public readonly byte[] WizGBCNoneName = new byte[] {" + s + "};//-- NONE --";
            textBox1.Text = s;
        }
    }
}