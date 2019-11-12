unit Wiz3Const;

interface
Uses
	Wiz2Const;

Const
{	//種族
	Wiz3Human	=	$00;	// 人間
	Wiz3Elf		=	$20;	// エルフ
	Wiz3Dwarf	=	$40;	// ドワーフ
	Wiz3Gnome	=	$60;	// ノーム
	Wiz3Hobit	=	$80;	// ホビット
  //職業
	Wiz3Fighter	= $00;	//せんし
	Wiz3Mage		= $04;	//まほうつかい
	Wiz3Priest	= $08;	//そうりょ
	Wiz3Thief		= $0C;	//シーフ
	Wiz3Bishop	= $10;	//ビショップ
	Wiz3Sumrai	= $14;	//サムライ
	Wiz3Lord		= $18;	//ロード
	Wiz3Ninja		= $1C;	//ニンジャ
  //属性
	Wiz3Good		=00;	// Ｇ
	Wiz3Neutral	=01;	// Ｎ
	Wiz3Evil		=02;	// Ｅ
	Wiz3Etc			=03;	// ？ (？はどの属性とも組めるが、全ての装備が呪われるし、転職ができない。魔物？)
}
	//種族
	Wiz3Human	=	Wiz2Human;	// 人間
	Wiz3Elf		=	Wiz2Elf;	// エルフ
	Wiz3Dwarf	=	Wiz2Dwarf;	// ドワーフ
	Wiz3Gnome	=	Wiz2Gnome;	// ノーム
	Wiz3Hobit	=	Wiz2Hobit;	// ホビット
  //職業
	Wiz3Fighter	= Wiz2Fighter;	//せんし
	Wiz3Mage		= Wiz2Mage;	//まほうつかい
	Wiz3Priest	= Wiz2Priest;	//そうりょ
	Wiz3Thief		= Wiz2Thief;	//シーフ
	Wiz3Bishop	= Wiz2Bishop;	//ビショップ
	Wiz3Sumrai	= Wiz2Sumrai;	//サムライ
	Wiz3Lord		= Wiz2Lord;	//ロード
	Wiz3Ninja		= Wiz2Ninja;	//ニンジャ
  //属性
	Wiz3Good		=Wiz2Good;	// Ｇ
	Wiz3Neutral	=Wiz2Neutral;	// Ｎ
	Wiz3Evil		=Wiz2Evil;	// Ｅ
	Wiz3Etc			=Wiz2Etc;	// ？ (？はどの属性とも組めるが、全ての装備が呪われるし、転職ができない。魔物？)

	Wiz3ItemName : array[00..$89] of String =(
	'00:ガラクタ',
	'01:つるぎ',
	'02:たんけん',
	'03:メイス',
	'04:フレイル',
	'05:つえ',
	'06:たんとう',
	'07:バックラー',
	'08:たて',
	'09:ローブ',
	'0A:かわよろい',
	'0B:くさりかたびら',
	'0C:むねあて',
	'0D:よろい',
	'0E:かぶと',
	'0F:きずぐすり',
	'10:どくけし',
	'11:きりさきのけん',
	'12:するどいたんけん',
	'13:ふんさいのメイス',
	'14:てつのつえ',
	'15:ねむりのまきもの',
	'16:かたいかわよろい',
	'17:ひかるくさりかたびら',
	'18:ますらおのよろい',
	'19:てつのたて',
	'1A:どうよろい',
	'1B:いたみのまきもの',
	'1C:ほのおのまきもの',
	'1D:もろはのつるぎ',
	'1E:げんめつのたんけん',
	'1F:わざわいのメイス',
	'20:かたいつえ',
	'21:ドラゴンスレイヤー',
	'22:にんたいのかぶと',
	'23:くさったかわよろい',
	'24:さびたくさりかたびら',
	'25:れきせんのむねあて',
	'26:ゆがんだたて',
	'27:ほうせきのゆびわ',
	'28:くるしみのまきもの',
	'29:けむりだま',
	'2A:まっぷたつのけん',
	'2B:さいきょうのたんけん',
	'2C:ちからのメイス',
	'2D:みちびきのまきもの',
	'2E:めくらましのまきもの',
	'2F:どうのこて',
	'30:ごうかなかわよろい',
	'31:エルフのくさりかたびら',
	'32:ごくじょうのよろい',
	'33:ささえのたて',
	'34:あくのかぶと',
	'35:とっこうやく',
	'36:まもりのゆびわ',
	'37:ワースレイヤー',
	'38:メイジマッシャー',
	'39:ヘビのメイス',
	'3A:ちんもくのつえ',
	'3C:カシナートのつるぎ',
	'3B:いましめのゆびわ',
	'3D:ほのおのつえ',
	'3E:あくのくさりかたびら',
	'3F:ちゅうりつのよろい',
	'40:あくのたて',
	'41:ちっそくのゆびわ',
	'42:てんいのかぶと',
	'43:いちげきのまきもの',
	'44:はめつのたんけん',
	'45:きりさきのたんとう',
	'46:やめるメイス',
	'47:ねじれたつえ',
	'48:はやわざのたんとう',
	'49:のろわれたローブ',
	'4A:はめつのかわよろい',
	'4B:のろいのくさりかたびら',
	'4C:あくまのむねあて',
	'4D:うつろのたて',
	'4E:ふるびたかぶと',
	'4F:きぼうのむねあて',
	'50:ぎんのこて',
	'51:あくのサーベル',
	'52:ソウルスレイヤー',
	'53:とうぞくのたんとう',
	'54:えいゆうのよろい',
	'55:せいなるよろい',
	'56:むらまさ',
	'57:しゅりけん',
	'58:こおりのくさりかたびら',
	'59:あくのよろい',
	'5A:まもりのたて',
	'5B:かいふくのゆびわ',
	'5C:はじゃのゆびわ',
	'5D:しのゆびわ',
	'5E:ふっかつのつえ',
	'5F:いにしえのおまもり',
	'60:みかわしのローブ',
	'61:てぶくろ',
	'62:まふうじのネックレス',
	'63:ひかりのつえ',
	'64:エクスカリバー',
	'65:ひらめきのつるぎ',
	'66:プリーストパンチャー',
	'67:そうりょのメイス',
	'68:ひらめきのたんけん',
	'69:ほのおのゆびわ',
	'6A:のろわれたよろい',
	'6B:ミスリルのよろい',
	'6C:いやしのつえ',
	'6D:いのちのゆびわ',
	'6E:へんげのゆびわ',
	'6F:ふしぎないし',
	'70:きぼうのいし',
	'71:しんぴてきないし',
	'72:いだいなるまほうのつえ',
	'73:ちからのコイン',
	'74:わかがえりのいし',
	'75:こころのいし',
	'76:しんじんのいし',
	'77:ブラーニィのいし',
	'78:じゅくれんのまよけ',
	'79:じゅくれんのまよけ（使用後）',
	'7A:いだいなるまほうのつえ（使用後）',
	'7B:ちからのコイン（使用後）',
	'7C:ニルダのつえ',
	'7D:ハースニール',
	'7E:でんせつのかぶと',
	'7F:でんせつのたて',
	'80:でんせつのこて',
	'81:でんせつのよろい',
	'82:さびたかぎ',
	'83:ちまみれのバッジ',
	'84:きみょうなもんしょう',
	'85:こくたんのかぎ',
	'86:しゅうどういんのかぎ',
	'87:ミスリルのかぎ',
	'88:マスターキー',
	'89:あくまのいし'
	);

  Wiz3OffsetAdress	= $1D52;

  Wiz3CharaDataSize	= Wiz2CharaDataSize;

	Wiz3Alive					= Wiz2Alive;
  Wiz3NameCount			= Wiz2NameCount;
  Wiz3Name					= Wiz2Name;
	  Wiz3NameLength		= Wiz2NameLength;
  Wiz3Job						= Wiz2Job;
  Wiz3Strength			= Wiz2Strength;
  Wiz3IQ						= Wiz2IQ;
  Wiz3Piety					= Wiz2Piety;
  Wiz3Vitarity			= Wiz2Vitarity;
  Wiz3Agility				= Wiz2Agility;
  Wiz3Luck					= Wiz2Luck;
  Wiz3Gold					= Wiz2Gold;
	  Wiz3GoldLength		= Wiz2GoldLength;
  Wiz3Exp						= Wiz2Exp;
	  Wiz3ExpLength				= Wiz2ExpLength;
  Wiz3HP						= Wiz2HP;
  Wiz3HPmax					= Wiz2HPmax;
  	Wiz3HPLength    	=Wiz2HPLength;
  Wiz3Level					= Wiz2Level;
  	Wiz3LevelLength    	=Wiz2LevelLength;
  Wiz3Status				= Wiz2Status;
  Wiz3Age						= Wiz2Age;
  Wiz3AC						= Wiz2AC;
  Wiz3MP						= Wiz2MP;
  Wiz3PP						= Wiz2PP;
  Wiz3MSkill				= Wiz2MSkill;
  Wiz3PSkill				= Wiz2PSkill;
	  Wiz3MPlength			= Wiz2MPlength;
  Wiz3ItemEquip			= Wiz2ItemEquip;
  Wiz3Item					= Wiz2Item;
  Wiz3ItemCount			= Wiz2ItemCount;
	  Wiz3ItemLength		= Wiz2ItemLength;
  Wiz3Poison				= Wiz2Poison;
  Wiz3Appellaction	= Wiz2Appellaction;
  Wiz3checksum			= Wiz2checksum;
	  Wiz3checksumLength	= Wiz2checksumLength;
type
	TWiz3Chara = TWiz2Chara;
implementation

end.

