unit WizSave;

interface
uses
	SysUtils,Classes
  ,WizSaveSub
  ,Wiz1Const
  ,Wiz2Const
  ,Wiz3Const
  ;

type
	TWizItem	=Record
  	Num			: Byte;
    Equip		: Boolean;
    Curse 	: Boolean;
    Unknown	: Boolean;
  End;
  TWizJob	= Record
  	Race		: Byte;
    Job			: Byte;
    Attr		: Byte;
  End;
	TWizSaveFile = class(TObject)
		private
      FLoadFlag		: Boolean;
      FNum				: Integer;//シナリオ
      FCharaNum		: Integer;//キャラ訓練所の番号（上から１）
      FStartAdr		: Integer;
      FCharSize		: Integer;
      FOffset			: Integer;
      FFrzData		: array [0..nnnester_state_filesize-1] of Byte;
      FFrzSize		: Integer;
      FFrzFileName: String;
    	function GetCharaNum: Integer;
    	procedure SetCharaNum(const Value: Integer);
    	function GetCharaData(index: Integer): Byte;
    	procedure SetCharaData(index: Integer; const Value: Byte);

    	function GetName(index: Integer): String;
    	function GetStrength: Byte;
	    function GetAC: ShortInt;
  	  function GetAge: Byte;
	    function GetAgility: Byte;
  	  function GetAttr: Integer;
   	 	function GetExp: Integer;
    	function GetJob: Integer;
    	function GetLevel: Integer;
    	function GetLuck: Byte;
	    function GetPiety: Byte;
	    function GetPoison: Boolean;
	    function GetRace: Integer;
	    function GetStatus: Integer;
	    function GetVitarity: Byte;
    	function GetIQ: Byte;
    	procedure SetStrength(const Value: byte);
	    procedure SetAC(const Value: ShortInt);
	    procedure SetAge(const Value: Byte);
	    procedure SetAgility(const Value: Byte);
	    procedure SetAttr(const Value: Integer);
	    procedure SetExp(const Value: Integer);
	    procedure SetJob(const Value: Integer);
	    procedure SetLevel(const Value: Integer);
	    procedure SetLuck(const Value: Byte);
	    procedure SetPiety(const Value: Byte);
	    procedure SetPoison(const Value: Boolean);
	    procedure SetRace(const Value: Integer);
	    procedure SetStatus(const Value: Integer);
	    procedure SetVitarity(const Value: Byte);
    	procedure SetIQ(const Value: Byte);
    	function GetGold: Integer;
    	procedure SetGold(const Value: Integer);
    	function GetItemCount: Byte;
    	procedure SetItemCount(const Value: Byte);
    	function GetItem(index: Integer): TWizItem;
    	procedure SetItem(index: Integer; const Value: TWizItem);
    	function GetHP: Longword;
    	function GetHPMax: Longword;
    	procedure SetHP(const Value: Longword);
    	procedure SetHPMax(const Value: Longword);
    	//procedure SetName(index: Integer; const Value: String);
    public
			constructor	Create;
			destructor	Destroy; override;
      function load(const path:String;Num:Integer):Boolean;
      function saveAs(const path:String):Boolean;
      function save:Boolean;
      function reload:Boolean;
      //
      property LoadFlag:Boolean								read FLoadFLag;
      property FrzFileName:String             read FFrzFileName;
      property CharaData[index:Integer]:Byte	read GetCharaData	write SetCharaData;
      property CharaNum						:Integer 		read GetCharaNum 	write SetCharaNum;
      property Num								:Integer 		read FNum;
      property Name[index:Integer]:String 		read GetName{ write SetName};
      property Level		: Integer							read GetLevel     write SetLevel;
      property Exp			: Integer             read GetExp			 	write SetExp;
      property Gold			: Integer             read GetGold			write SetGold;
      property Race			: Integer							read GetRace      write SetRace;
      property Job			: Integer							read GetJob       write SetJob;
      property Attr			: Integer							read GetAttr      write SetAttr;
      property Status		: Integer							read GetStatus    write SetStatus;
      property Poison		: Boolean							read GetPoison    write SetPoison;
      property Strength : Byte             		read GetStrength 	write SetStrength;
      property IQ				: Byte             		read GetIQ			 	write SetIQ;
      property Piety		: Byte             		read GetPiety 		write SetPiety;
      property Vitarity	: Byte             		read GetVitarity 	write SetVitarity;
      property Agility	: Byte             		read GetAgility 	write SetAgility;
      property Luck			: Byte             		read GetLuck 			write SetLuck;
      property Age			: Byte             		read GetAge 			write SetAge;
      property AC				: ShortInt             		read GetAC	 			write SetAC;
      property ItemCount: Byte             		read GetItemCount write SetItemCount;
      property Item[index:Integer]:TWizItem		read GetItem			write SetItem;
      property HP				: Longword						read GetHP				write SetHP;
      property HPMax		: Longword						read GetHPMax			write SetHPMax;
  end;

implementation
//---------------------------------------------------------------
{ TWizSaveFile }
//---------------------------------------------------------------
constructor TWizSaveFile.Create;
begin
	FLoadFlag:=False;
  FFrzSize:=nnnester_state_filesize;
  FillChar(FFrzData,FFrzSize,$00);

	FNum:=1;
  FCharaNum	:=1;
  FStartAdr	:=Wiz1OffsetAdress;
  FCharSize	:=Wiz1CharaDataSize;
  FOffSet		:=FStartAdr+FCharSize*(FCharaNum-1);
end;
//---------------------------------------------------------------
destructor TWizSaveFile.Destroy;
begin
	//
  inherited;
end;
//***************************************************************
//
//***************************************************************
function TWizSaveFile.GetCharaNum: Integer;
begin
	Result:=FCharaNum;
end;
//---------------------------------------------------------------
procedure TWizSaveFile.SetCharaNum(const Value: Integer);
begin
	if (Value<1)or(Value>wiz_chara_count) Then Exit
  Else FCharaNum:=Value;

  FOffSet:=FStartAdr+FCharSize*(FCharaNum-1);

end;
//***************************************************************
//
//***************************************************************
procedure TWizSaveFile.SetCharaData(index: Integer; const Value: Byte);
begin
	FFrzData[FOffset+index]:=Value;
end;
//---------------------------------------------------------------
function TWizSaveFile.GetCharaData(index: Integer): Byte;
begin
	Result:=FFrzData[FOffset+index];
end;
//***************************************************************
//
//	各種プロパティ
//
//***************************************************************
function TWizSaveFile.GetName(index: Integer): String;
Var
	i,v,L : Integer;
  theS 	: String;
begin
	Result:='(なし)';
  if FLoadFlag=False Then Exit;

  v:=FStartAdr+FCharSize*(index-1);
  L:=FFrzData[v+Wiz1NameCount];
  if (L=0)or(FFrzData[v]<=0)or(FFrzData[v]>3) Then Begin
    Exit;
  End Else Begin
  	if L>8 Then L:=Wiz1NameLength;
  End;
  theS:='';
	for i:=0 to L-1 do
    if FNum=1 Then
  		theS:=theS+Wiz1Strings[FFrzData[v+Wiz1Name+i]]
    Else
  		theS:=theS+Wiz2Strings[FFrzData[v+Wiz1Name+i]];
	Result:=theS;
end;
{
//名前は読むだけ
procedure TWizSaveFile.SetName(index: Integer; const Value: String);
begin

end;
}
//---------------------------------------------------------------
//種族
function TWizSaveFile.GetRace: Integer;
Var
	v	:Byte;
begin
	Result:=0;
  v:=0;
  if FLoadFlag=False Then Exit;
  if (GetCharaData(0)<1)or(GetCharaData(0)>3) Then Exit;
  case FNum of
  	1:Begin
    	v:=GetCharaData(Wiz1Race);
    End;
  	2:Begin
    	v:=GetCharaData(Wiz2Job) shr 5;

    End;
  	3:Begin
    	v:=GetCharaData(Wiz3Job) shr 5;
    End;
  End;
  Result:=v;
end;
procedure TWizSaveFile.SetRace(const Value: Integer);
Var
	v	:Byte;
begin
  if FLoadFlag=False Then Exit;
  if (GetCharaData(0)<1)or(GetCharaData(0)>3) Then Exit;
  case FNum of
  	1:Begin
    	SetCharaData(Wiz1Race,Value);
    End;
  	2:Begin
    	v:=GetCharaData(Wiz2Job) and $E0;
      v:=V+(Value shl 5);
    	SetCharaData(Wiz2job,v);
    End;
  	3:Begin
    	v:=GetCharaData(Wiz3Job) and $E0;
      v:=V+(Value shl 5);
    	SetCharaData(Wiz3job,v);
    End;
  End;
end;
//---------------------------------------------------------------
function TWizSaveFile.GetJob: Integer;
Var
	v	:Byte;
begin
	Result:=0;
  v:=0;
  if FLoadFlag=False Then Exit;
  if (GetCharaData(0)<1)or(GetCharaData(0)>3) Then Exit;
  case FNum of
  	1:Begin
    	v:=GetCharaData(Wiz1Job);
    End;
  	2:Begin
    	v:=(GetCharaData(Wiz2Job) shr 2)and $7;

    End;
  	3:Begin
    	v:=(GetCharaData(Wiz3Job) shr 2)and $7;
    End;
  End;
  Result:=v;
end;
procedure TWizSaveFile.SetJob(const Value: Integer);
Var
	v	:Byte;
begin
  if FLoadFlag=False Then Exit;
  if (GetCharaData(0)<1)or(GetCharaData(0)>3) Then Exit;
  case FNum of
  	1:Begin
    	SetCharaData(Wiz1Job,Value);
    End;
  	2:Begin
    	v:=GetCharaData(Wiz2Job) and $1C;
      v:=V+(Value shl 2);
    	SetCharaData(Wiz2job,v);
    End;
  	3:Begin
    	v:=GetCharaData(Wiz3Job) and $1C;
      v:=V+(Value shl 2);
    	SetCharaData(Wiz3job,v);
    End;
  End;
end;
//---------------------------------------------------------------
function TWizSaveFile.GetAttr: Integer;
Var
	v	:Byte;
begin
	Result:=0;
  v:=0;
  if FLoadFlag=False Then Exit;
  if (GetCharaData(0)<1)or(GetCharaData(0)>3) Then Exit;
  case FNum of
  	1:Begin
    	v:=GetCharaData(Wiz1Attr);
    End;
  	2:Begin
    	v:=GetCharaData(Wiz2Job)and $3;

    End;
  	3:Begin
    	v:=GetCharaData(Wiz3Job)and $3;
    End;
  End;
  Result:=v;
end;
procedure TWizSaveFile.SetAttr(const Value: Integer);
Var
	v	:Byte;
begin
  if FLoadFlag=False Then Exit;
  if (GetCharaData(0)<1)or(GetCharaData(0)>3) Then Exit;
  case FNum of
  	1:Begin
    	SetCharaData(Wiz1Attr,Value);
    End;
  	2:Begin
    	v:=GetCharaData(Wiz2Job) and $FC;
      v:=V+Value;
    	SetCharaData(Wiz2job,v);
    End;
  	3:Begin
    	v:=GetCharaData(Wiz3Job) and $FC;
      v:=V+Value;
    	SetCharaData(Wiz3Job,v);
    End;
  End;
end;
//---------------------------------------------------------------
function TWizSaveFile.GetHP: Longword;
Var
	v	:Byte;
begin
	Result:=0;
  v:=0;
  if FLoadFlag=False Then Exit;
  if (GetCharaData(0)<1)or(GetCharaData(0)>3) Then Exit;
  case FNum of
  	1:Begin
    	v:=GetCharaData(Wiz1HP)*$100+GetCharaData(Wiz1HP+1);
    End;
  	2:Begin
    	v:=GetCharaData(Wiz2HP)+GetCharaData(Wiz2HP+1)*$100;
    End;
  	3:Begin
    	v:=GetCharaData(Wiz3HP)+GetCharaData(Wiz3HP+1)*$100;
    End;
  End;
  Result:=v;
end;

procedure TWizSaveFile.SetHP(const Value: Longword);
begin
  if FLoadFlag=False Then Exit;
  if (GetCharaData(0)<1)or(GetCharaData(0)>3) Then Exit;
  case FNum of
  	1:Begin
    	SetCharaData(Wiz1HP  ,Value div $100);
    	SetCharaData(Wiz1HP+1,Value mod $100);
    End;
  	2:Begin
    	SetCharaData(Wiz2HP  ,Value mod $100);
    	SetCharaData(Wiz2HP+1,Value div $100);
    End;
  	3:Begin
    	SetCharaData(Wiz3HP  ,Value mod $100);
    	SetCharaData(Wiz3HP+1,Value div $100);
    End;
  End;
end;

//---------------------------------------------------------------
function TWizSaveFile.GetHPMax: Longword;
Var
	v	:Byte;
begin
	Result:=0;
  v:=0;
  if FLoadFlag=False Then Exit;
  if (GetCharaData(0)<1)or(GetCharaData(0)>3) Then Exit;
  case FNum of
  	1:Begin
    	v:=GetCharaData(Wiz1HPmax)*$100+GetCharaData(Wiz1HPmax+1);
    End;
  	2:Begin
    	v:=GetCharaData(Wiz2HPmax)+GetCharaData(Wiz2HPmax+1)*$100;
    End;
  	3:Begin
    	v:=GetCharaData(Wiz3HPmax)+GetCharaData(Wiz3HPmax+1)*$100;
    End;
  End;
  Result:=v;
end;
procedure TWizSaveFile.SetHPMax(const Value: Longword);
begin
  if FLoadFlag=False Then Exit;
  if (GetCharaData(0)<1)or(GetCharaData(0)>3) Then Exit;
  case FNum of
  	1:Begin
    	SetCharaData(Wiz1HPmax  ,Value div $100);
    	SetCharaData(Wiz1HPmax+1,Value mod $100);
    End;
  	2:Begin
    	SetCharaData(Wiz2HPmax  ,Value mod $100);
    	SetCharaData(Wiz2HPmax+1,Value div $100);
    End;
  	3:Begin
    	SetCharaData(Wiz3HPmax  ,Value mod $100);
    	SetCharaData(Wiz3HPmax+1,Value div $100);
    End;
  End;
end;
//---------------------------------------------------------------
function TWizSaveFile.GetStrength: Byte;
begin
	Result:=0;
  if FLoadFlag=False Then Exit;
  if (GetCharaData(0)<1)or(GetCharaData(0)>3) Then Exit;
  Case FNum of
  	1:Result:=GetCharaData(Wiz1Strength);
  	2:Result:=GetCharaData(Wiz2Strength);
  	3:Result:=GetCharaData(Wiz3Strength);
  End;
end;
procedure TWizSaveFile.SetStrength(const Value: Byte);
begin
  if FLoadFlag=False Then Exit;
  if (GetCharaData(0)<1)or(GetCharaData(0)>3) Then Exit;
  Case FNum of
  	1:SetCharaData(Wiz1Strength,Value);
  	2:SetCharaData(Wiz2Strength,Value);
  	3:SetCharaData(Wiz3Strength,Value);
  End;
end;
//---------------------------------------------------------------
function TWizSaveFile.GetIQ: Byte;
begin
	Result:=0;
  if FLoadFlag=False Then Exit;
  if (GetCharaData(0)<1)or(GetCharaData(0)>3) Then Exit;
  Case FNum of
  	1:Result:=GetCharaData(Wiz1IQ);
  	2:Result:=GetCharaData(Wiz2IQ);
  	3:Result:=GetCharaData(Wiz3IQ);
  End;
end;

procedure TWizSaveFile.SetIQ(const Value: Byte);
begin
  if FLoadFlag=False Then Exit;
  if (GetCharaData(0)<1)or(GetCharaData(0)>3) Then Exit;
  Case FNum of
  	1:SetCharaData(Wiz1IQ,Value);
  	2:SetCharaData(Wiz2IQ,Value);
  	3:SetCharaData(Wiz3IQ,Value);
  End;
end;
//---------------------------------------------------------------
function TWizSaveFile.GetPiety: Byte;
begin
	Result:=0;
  if FLoadFlag=False Then Exit;
  if (GetCharaData(0)<1)or(GetCharaData(0)>3) Then Exit;
  Case FNum of
  	1:Result:=GetCharaData(Wiz1Piety);
  	2:Result:=GetCharaData(Wiz2Piety);
  	3:Result:=GetCharaData(Wiz3Piety);
  End;
end;
procedure TWizSaveFile.SetPiety(const Value: Byte);
begin
  if FLoadFlag=False Then Exit;
  if (GetCharaData(0)<1)or(GetCharaData(0)>3) Then Exit;
  Case FNum of
  	1:SetCharaData(Wiz1Piety,Value);
  	2:SetCharaData(Wiz2Piety,Value);
  	3:SetCharaData(Wiz3Piety,Value);
  End;
end;
//---------------------------------------------------------------
function TWizSaveFile.GetVitarity: Byte;
begin
	Result:=0;
  if FLoadFlag=False Then Exit;
  if (GetCharaData(0)<1)or(GetCharaData(0)>3) Then Exit;
  Case FNum of
  	1:Result:=GetCharaData(Wiz1Vitarity);
  	2:Result:=GetCharaData(Wiz2Vitarity);
  	3:Result:=GetCharaData(Wiz3Vitarity);
  End;
end;
procedure TWizSaveFile.SetVitarity(const Value: Byte);
begin
  if FLoadFlag=False Then Exit;
  if (GetCharaData(0)<1)or(GetCharaData(0)>3) Then Exit;
  Case FNum of
  	1:SetCharaData(Wiz1Vitarity,Value);
  	2:SetCharaData(Wiz2Vitarity,Value);
  	3:SetCharaData(Wiz3Vitarity,Value);
  End;
end;
//---------------------------------------------------------------
function TWizSaveFile.GetAgility: Byte;
begin
	Result:=0;
  if FLoadFlag=False Then Exit;
  if (GetCharaData(0)<1)or(GetCharaData(0)>3) Then Exit;
  Case FNum of
  	1:Result:=GetCharaData(Wiz1Agility);
  	2:Result:=GetCharaData(Wiz2Agility);
  	3:Result:=GetCharaData(Wiz3Agility);
  End;
end;
procedure TWizSaveFile.SetAgility(const Value: Byte);
begin
  if FLoadFlag=False Then Exit;
  if (GetCharaData(0)<1)or(GetCharaData(0)>3) Then Exit;
  Case FNum of
  	1:SetCharaData(Wiz1Agility,Value);
  	2:SetCharaData(Wiz2Agility,Value);
  	3:SetCharaData(Wiz3Agility,Value);
  End;
end;
//---------------------------------------------------------------
function TWizSaveFile.GetLuck: Byte;
begin
	Result:=0;
  if FLoadFlag=False Then Exit;
  if (GetCharaData(0)<1)or(GetCharaData(0)>3) Then Exit;
  Case FNum of
  	1:Result:=GetCharaData(Wiz1Luck);
  	2:Result:=GetCharaData(Wiz2Luck);
  	3:Result:=GetCharaData(Wiz3Luck);
  End;
end;
procedure TWizSaveFile.SetLuck(const Value: Byte);
begin
  if FLoadFlag=False Then Exit;
  if (GetCharaData(0)<1)or(GetCharaData(0)>3) Then Exit;
  Case FNum of
  	1:SetCharaData(Wiz1Luck,Value);
  	2:SetCharaData(Wiz2Luck,Value);
  	3:SetCharaData(Wiz3Luck,Value);
  End;
end;
//---------------------------------------------------------------
function TWizSaveFile.GetLevel: Integer;
begin
	Result:=0;
  if FLoadFlag=False Then Exit;
  if (GetCharaData(0)<1)or(GetCharaData(0)>3) Then Exit;
	case FNum of
  	1:Begin
    	Result:=(GetCharaData(Wiz1Level) shl 8)+GetCharaData(Wiz1Level+1);
    End;
    2:Begin
    	Result:=(GetCharaData(Wiz2Level) shl 8)+GetCharaData(Wiz2Level+1);
    End;
    3:Begin
    	Result:=(GetCharaData(Wiz3Level) shl 8)+GetCharaData(Wiz3Level+1);
    End;
  End;
end;
procedure TWizSaveFile.SetLevel(const Value: Integer);
begin
  if FLoadFlag=False Then Exit;
  if (GetCharaData(0)<1)or(GetCharaData(0)>3) Then Exit;
	case FNum of
  	1:Begin
    	SetCharaData(Wiz1Level  ,Value shr 8);
    	SetCharaData(Wiz1Level+1,Value and $FF);
    End;
    2:Begin
    	SetCharaData(Wiz2Level  ,Value shr 8);
    	SetCharaData(Wiz2Level+1,Value and $FF);
    End;
    3:Begin
    	SetCharaData(Wiz2Level  ,Value shr 8);
    	SetCharaData(Wiz2Level+1,Value and $FF);
    End;
  End;
end;
//---------------------------------------------------------------
function TWizSaveFile.GetExp: Integer;
Var
	i,Exp : Integer;
begin
	Result:=0;
  Exp:=0;
  if FLoadFlag=False Then Exit;
  if (GetCharaData(0)<1)or(GetCharaData(0)>3) Then Exit;
	case FNum of
  	1:Begin
      for i:=0 to Wiz1ExpLength-1 do
    		Exp:=(Exp * 100)+WizHex2Byte(GetCharaData(Wiz1Exp+i));
    End;
    2:Begin
      for i:=0 to Wiz2ExpLength-1 do
    		Exp:=(Exp * 100)+WizHex2Byte(GetCharaData(Wiz2Exp+i));
    End;
    3:Begin
      for i:=0 to Wiz2ExpLength-1 do
    		Exp:=(Exp * 100)+WizHex2Byte(GetCharaData(Wiz2Exp+i));
    End;
  End;
  Result:=Exp;
end;
procedure TWizSaveFile.SetExp(const Value: Integer);
Var
	i,v : Integer;
begin
  if FLoadFlag=False Then Exit;
  if (GetCharaData(0)<1)or(GetCharaData(0)>3) Then Exit;
	case FNum of
  	1:Begin
      v:=Value;
    	for i:=Wiz1ExpLength-1 downto 0 do Begin
	    	SetCharaData(Wiz1Exp+i  ,Byte2WizHex(v mod 100));
        v:=v div 100;
      End;
    End;
    2:Begin
      v:=Value;
    	for i:=Wiz2ExpLength-1 downto 0 do Begin
	    	SetCharaData(Wiz2Exp+i  ,Byte2WizHex(v mod 100));
        v:=v div 100;
      End;
    End;
    3:Begin
      v:=Value;
    	for i:=Wiz2ExpLength-1 downto 0 do Begin
	    	SetCharaData(Wiz2Exp+i  ,Byte2WizHex(v mod 100));
        v:=v div 100;
      End;
    End;
  End;

end;
//---------------------------------------------------------------
function TWizSaveFile.GetGold: Integer;
Var
	i,Exp : Integer;
begin
	Result:=0;
  Exp:=0;
  if FLoadFlag=False Then Exit;
  if (GetCharaData(0)<1)or(GetCharaData(0)>3) Then Exit;
	case FNum of
  	1:Begin
      for i:=0 to Wiz1GoldLength-1 do
    		Exp:=(Exp * 100)+WizHex2Byte(GetCharaData(Wiz1Gold+i));
    End;
    2:Begin
      for i:=0 to Wiz2GoldLength-1 do
    		Exp:=(Exp * 100)+WizHex2Byte(GetCharaData(Wiz2Gold+i));
    End;
    3:Begin
      for i:=0 to Wiz3GoldLength-1 do
    		Exp:=(Exp * 100)+WizHex2Byte(GetCharaData(Wiz3Gold+i));
    End;
  End;
  Result:=Exp;
end;

procedure TWizSaveFile.SetGold(const Value: Integer);
Var
	i,v : Integer;
begin
  if FLoadFlag=False Then Exit;
  if (GetCharaData(0)<1)or(GetCharaData(0)>3) Then Exit;
	case FNum of
  	1:Begin
      v:=Value;
    	for i:=Wiz1GoldLength-1 downto 0 do Begin
	    	SetCharaData(Wiz1Gold+i  ,Byte2WizHex(v mod 100));
        v:=v div 100;
      End;
    End;
    2:Begin
      v:=Value;
    	for i:=Wiz2GoldLength-1 downto 0 do Begin
	    	SetCharaData(Wiz2Gold+i  ,Byte2WizHex(v mod 100));
        v:=v div 100;
      End;
    End;
    3:Begin
      v:=Value;
    	for i:=Wiz3GoldLength-1 downto 0 do Begin
	    	SetCharaData(Wiz3Gold+i  ,Byte2WizHex(v mod 100));
        v:=v div 100;
      End;
    End;
  End;

end;
//---------------------------------------------------------------
function TWizSaveFile.GetStatus: Integer;
Var
	v	:Byte;
begin
	Result:=0;
  v:=0;
  if FLoadFlag=False Then Exit;
  if (GetCharaData(0)<1)or(GetCharaData(0)>3) Then Exit;
  case FNum of
  	1:Begin
    	v:=GetCharaData(Wiz1Status);
    End;
  	2:Begin
    	v:=GetCharaData(Wiz2Status);
    End;
  	3:Begin
    	v:=GetCharaData(Wiz3Status);
    End;
  End;
  Result:=v;
end;
procedure TWizSaveFile.SetStatus(const Value: Integer);
begin
  if FLoadFlag=False Then Exit;
  if (GetCharaData(0)<1)or(GetCharaData(0)>3) Then Exit;
  case FNum of
  	1:Begin
    	SetCharaData(Wiz1Status,Value);
    End;
  	2:Begin
    	SetCharaData(Wiz2Status,Value);
    End;
  	3:Begin
    	SetCharaData(Wiz3Status,Value);
    End;
  End;
end;
//---------------------------------------------------------------
function TWizSaveFile.GetAge: Byte;
Var
	v	:Byte;
begin
	Result:=0;
  v:=0;
  if FLoadFlag=False Then Exit;
  if (GetCharaData(0)<1)or(GetCharaData(0)>3) Then Exit;
  case FNum of
  	1:Begin
    	v:=GetCharaData(Wiz1Age);
    End;
  	2:Begin
    	v:=GetCharaData(Wiz2Age);
    End;
  	3:Begin
    	v:=GetCharaData(Wiz3Age);
    End;
  End;
  Result:=v;
end;
procedure TWizSaveFile.SetAge(const Value: Byte);
begin
  if FLoadFlag=False Then Exit;
  if (GetCharaData(0)<1)or(GetCharaData(0)>3) Then Exit;
  case FNum of
  	1:Begin
    	SetCharaData(Wiz1Age,Value);
    End;
  	2:Begin
    	SetCharaData(Wiz2Age,Value);
    End;
  	3:Begin
    	SetCharaData(Wiz3Age,Value);
    End;
  End;
end;
//---------------------------------------------------------------
function TWizSaveFile.GetAC: ShortInt;
Var
	v	:Byte;
begin
	Result:=0;
  v:=0;
  if FLoadFlag=False Then Exit;
  if (GetCharaData(0)<1)or(GetCharaData(0)>3) Then Exit;
  case FNum of
  	1:Begin
    	v:=GetCharaData(Wiz1AC);
    End;
  	2:Begin
    	v:=GetCharaData(Wiz2AC);
    End;
  	3:Begin
    	v:=GetCharaData(Wiz3AC);
    End;
  End;
  Result:=v;
end;
//---------------------------------------------------------------
procedure TWizSaveFile.SetAC(const Value: ShortInt);
begin
  if FLoadFlag=False Then Exit;
  if (GetCharaData(0)<1)or(GetCharaData(0)>3) Then Exit;
  case FNum of
  	1:Begin
    	SetCharaData(Wiz1AC,Value);
    End;
  	2:Begin
    	SetCharaData(Wiz2AC,Value);
    End;
  	3:Begin
    	SetCharaData(Wiz3AC,Value);
    End;
  End;
end;
//---------------------------------------------------------------
function TWizSaveFile.GetPoison: Boolean;
begin
	Result:=False;
  if FLoadFlag=False Then Exit;
  if (GetCharaData(0)<1)or(GetCharaData(0)>3) Then Exit;
  case FNum of
  	1:Begin
    	if GetCharaData(Wiz1Poison)=0 Then
      	Result:=False
      Else
      	Result:=True;
    End;
  	2:Begin
    	if GetCharaData(Wiz2Poison)=0 Then
      	Result:=False
      Else
      	Result:=True;
    End;
  	3:Begin
    	if GetCharaData(Wiz3Poison)=0 Then
      	Result:=False
      Else
      	Result:=True;
    End;
  End;
end;
procedure TWizSaveFile.SetPoison(const Value: Boolean);
Var
	v : Byte;
begin
  if FLoadFlag=False Then Exit;
  if (GetCharaData(0)<1)or(GetCharaData(0)>3) Then Exit;
  if Value Then v:=1
  Else v:=0;
  case FNum of
  	1:Begin
    	SetCharaData(Wiz1Poison,v);
    End;
  	2:Begin
    	SetCharaData(Wiz2Poison,v);
    End;
  	3:Begin
    	SetCharaData(Wiz3Poison,v);
    End;
  End;
end;
//---------------------------------------------------------------
function TWizSaveFile.GetItemCount: Byte;
Var
	v : Byte;
begin
	Result:=0;
  v:=0;
  if FLoadFlag=False Then Exit;
  if (GetCharaData(0)<1)or(GetCharaData(0)>3) Then Exit;
  case FNum of
  	1:Begin
    	v:=GetCharaData(Wiz1ItemCount);
    End;
  	2:Begin
    	v:=GetCharaData(Wiz2ItemCount);
    End;
  	3:Begin
    	v:=GetCharaData(Wiz3ItemCount);
    End;
  End;
  Result:=v;
end;
procedure TWizSaveFile.SetItemCount(const Value: Byte);
begin
  if FLoadFlag=False Then Exit;
  if (GetCharaData(0)<1)or(GetCharaData(0)>3) Then Exit;
  case FNum of
  	1:Begin
    	SetCharaData(Wiz1ItemCount,Value);
    End;
  	2:Begin
    	SetCharaData(Wiz2ItemCount,Value);
    End;
  	3:Begin
    	SetCharaData(Wiz3ItemCount,Value);
    End;
  End;
end;
//---------------------------------------------------------------
function TWizSaveFile.GetItem(index: Integer): TWizItem;
Var
	e : Byte;
  wi : TWizItem;
begin
  wi.Num:=0;
  wi.Equip:=False;
  wi.Curse:=False;
  wi.Unknown:=False;
	Result:=wi;
  if FLoadFlag=False Then Exit;
  if (GetCharaData(0)<1)or(GetCharaData(0)>3) Then Exit;
  case FNum of
  	1:Begin
      wi.Num:=GetCharaData(Wiz1Item+index);
      e:=GetCharaData(Wiz1ItemEquip+index);
      if (e and $80)<>0 Then wi.Equip:=True;
      if (e and $40)<>0 Then wi.Curse:=True;
      if (e and $20)<>0 Then wi.Unknown:=True;
    End;
  	2:Begin
      wi.Num:=GetCharaData(Wiz2Item+index);
      e:=GetCharaData(Wiz2ItemEquip+index);
      if (e and $80)<>0 Then wi.Equip:=True;
      if (e and $40)<>0 Then wi.Curse:=True;
      if (e and $20)<>0 Then wi.Unknown:=True;
    End;
  	3:Begin
      wi.Num:=GetCharaData(Wiz3Item+index);
      e:=GetCharaData(Wiz3ItemEquip+index);
      if (e and $80)<>0 Then wi.Equip:=True;
      if (e and $40)<>0 Then wi.Curse:=True;
      if (e and $20)<>0 Then wi.Unknown:=True;
    End;
  End;
  Result:=wi;
end;

procedure TWizSaveFile.SetItem(index: Integer; const Value: TWizItem);
Var
	v : Byte;
begin
  if FLoadFlag=False Then Exit;
  if (GetCharaData(0)<1)or(GetCharaData(0)>3) Then Exit;
  case FNum of
  	1:Begin
    	SetCharaData(Wiz1Item+index,Value.Num);
      v:=0;
      if Value.Equip Then v:=$80;
      if Value.Curse Then v:=v+$40;
      if Value.Unknown Then v:=v+$20;
    	SetCharaData(Wiz1ItemEquip+index,v);
    End;
  	2:Begin
    	SetCharaData(Wiz2Item+index,Value.Num);
      v:=0;
      if Value.Equip Then v:=$80;
      if Value.Curse Then v:=v+$40;
      if Value.Unknown Then v:=v+$20;
    	SetCharaData(Wiz2ItemEquip+index,v);
    End;
  	3:Begin
    	SetCharaData(Wiz3Item+index,Value.Num);
      v:=0;
      if Value.Equip Then v:=$80;
      if Value.Curse Then v:=v+$40;
      if Value.Unknown Then v:=v+$20;
    	SetCharaData(Wiz3ItemEquip+index,v);
    End;
  End;

end;
//***************************************************************
//
//***************************************************************
function TWizSaveFile.load(const path: String;Num:Integer): Boolean;
Var
	FS : TFileStream;
  r  : Boolean;
Begin
	Result:=False;
  FLoadFlag:=False;
  FFrzFileName:='';
  if FileExists(path)=False Then Exit;

  FS:=TFileStream.Create(path,fmOpenRead);

  r:=True;
  try
  	if FS.Size=nnnester_state_filesize Then Begin
    	//初期化
	  	FillChar(FFrzData,nnnester_state_filesize,$00);

    	FS.Position:=0;
    	FS.ReadBuffer(FFrzData,nnnester_state_filesize);
      FFrzFileName:=path;
    End;
  except
  	r:=False;
  end;
  FS.Free;

	//その他
  FCharaNum:=1;
  if Num<=1 Then Begin
  	FNum:=1;
    FStartAdr:=Wiz1OffsetAdress;
    FCharSize:=Wiz1CharaDataSize;
  End ELse If Num=2 Then Begin
  	FNum:=2;
    FStartAdr:=Wiz2OffsetAdress;
    FCharSize:=Wiz2CharaDataSize;
  End Else Begin
  	FNum:=3;
    FStartAdr:=Wiz3OffsetAdress;
    FCharSize:=Wiz3CharaDataSize;
  End;
  FOffSet		:=FStartAdr+FCharSize*(FCharaNum-1);
  FLoadFlag:=r;
  Result:=r;
End;
//---------------------------------------------------------------
function TWizSaveFile.reload: Boolean;
Var
	r :Boolean;
begin
	Result:=False;
  r:=True;
  if FLoadFlag=False Then r:=False
  Else if FFrzFileName='' Then r:=False
  Else if FileExists(FFrzFileName)=False Then r:=False;

  if r=False Then Begin
  	FLoadFlag:=False;
    FFrzFileName:='';
    Exit;
  End;
  Result:=load(FFrzFileName,FNum);

end;
//---------------------------------------------------------------
function TWizSaveFile.saveAs(const path: String): Boolean;
Var
	FS : TFileStream;
  r  : Boolean;
Begin
	Result:=False;
  if FLoadFlag=False Then Exit;
  FS:=TFileStream.Create(path,fmCreate);

  r:=True;
  try
  	FS.Position:=0;
    FS.WriteBuffer(FFrzData,nnnester_state_filesize);
  except
  	r:=False;
  end;
  FS.Free;
  if r=True Then
  	FFrzFileName:=path
  Else
  	FFrzFileName:='';
  FLoadFlag:=r;
  Result:=r;
End;
//---------------------------------------------------------------
function TWizSaveFile.save: Boolean;
begin
	Result:=False;
  if FLoadFlag=False Then Exit
  Else if FFrzFileName='' Then Exit;
  Result:=saveAs(FFrzFileName);
end;
//---------------------------------------------------------------




end.
