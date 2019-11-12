unit WizGBC;

interface
uses
	SysUtils, Classes,StdCtrls;
const
  {$INCLUDE WizStrings.pas}
  {$INCLUDE Wiz1Item.pas}
  {$INCLUDE Wiz2Item.pas}
  {$INCLUDE Wiz3Item.pas}

  StateFileSize       = $14515;
  WizCharDataSize     = $6E;
  WizCharDataOffset   = $10E;
  WizCharNameOffset   = $1;
type


  TWizName        = array [0..8] of Byte;
  TWizValue       = array [0..5] of Byte;
	//TWizGold	      = array [0..5] of Byte;
	//TWizExp		      = array [0..5] of Byte;
	//TWizMark	      = array [0..5] of Byte;
  TWizSpell       = array [1..7] of Byte;
  TWizSpellLean   = array [1..7] of Byte;
  TWizItem        = array [1..8] of Byte;
  TWizItemStatus  = array [1..8] of Byte;
  TWizHonor = record
    first   : Boolean;
    Second  : Boolean;
    Third   : Boolean;
    Knight  : Boolean;
    Rakuda  : Boolean;
    Ex      : Boolean;
    Muramasa1 :Boolean;
    Muramasa2 :Boolean;
    Muramasa3 :Boolean;
  End;

	TWizGBCData	=record
		Num       		: Byte;
		Name					: TWizName;
		Kind					: Byte;
		STR						: Byte;
		IQ						: Byte;
		PIE						: Byte;
		VIT						: Byte;
		AGI						: Byte;
		LUK						: Byte;
		GOLD					: TWizValue;
		Exp						: TWizValue;
		HP						: Word;
    HPMAX         : Word;
    LV            : Word;
    Status        : Byte;
    Age           : Shortint;
    Week          : Byte;
    Mag           : TWizSpell;
    Pri           : TWizSpell;
    MagLean       : TWizSpellLean;
    PriLean       : TWizSpellLean;
    ItemStatus    : TWizItemStatus;
    Items         : TWizItem;
    ItemLength    : Byte;
    reserve1      : array [0..2] of Byte;
    Honor         : Word;
    PosFlag       : Byte;
    reserve2      : array [0..2] of Byte;
    AC            : Shortint;
    reserve3      : Byte;
    HealMinus     : Byte;
    HealPlus      : Byte;
    reserve4      : array [0..4] of Byte;
    MARKS         : TWizValue;
    RIP           : Byte;
    checksum      : Word;
  End;


	TWizStateData = class(TComponent)
  private
  { Private éŒ¾ }
    FPath	: String;
    FBuf        : TMemoryStream;
    FTarget     : Integer;
    FData       : array[0..19] of TWizGBCData;
    FIsLoad   : Boolean;
    function GetFPath: String;
    procedure SetFPath(const Value: String);
    procedure BufToData;
    procedure DataToBuf;
    procedure SetFTarget(const Value: Integer);
    function GetKind: Byte;
    procedure SetKind(const Value: Byte);
    function GetStatus: Byte;
    procedure SetStatus(const Value: Byte);
    function GetLevel: Integer;
    procedure SetLevel(const Value: Integer);
    function GetNum: Byte;
    procedure SetNum(const Value: Byte);
    function GetAC: Integer;
    function GetAGE: Integer;
    function GetEP: LongWord;
    function GetGOLD: LongWord;
    function GetHP: Integer;
    function GetHPMAX: Integer;
    function GetMARK: LongWord;
    function GetRIP: Integer;
    function GetWEEK: Integer;
    procedure SetAC(const Value: Integer);
    procedure SetAGE(const Value: Integer);
    procedure SetEP(const Value: LongWord);
    procedure SetGOLD(const Value: LongWord);
    procedure SetHP(const Value: Integer);
    procedure SetHPMAX(const Value: Integer);
    procedure SetMARK(const Value: LongWord);
    procedure SetRIP(const Value: Integer);
    procedure SetWEEK(const Value: Integer);
    function GetAGI: Integer;
    function GetIQ: Integer;
    function GetLUK: Integer;
    function GetSTR: Integer;
    function GetVIT: Integer;
    procedure SetAGI(const Value: Integer);
    procedure SetIQ(const Value: Integer);
    procedure SetLUK(const Value: Integer);
    procedure SetSTR(const Value: Integer);
    procedure SetVIT(const Value: Integer);
    function GetPIE: Integer;
    procedure SetPIE(const Value: Integer);
    function GetHonor: Word;
    procedure SetHonor(const Value: Word);
  protected
  { Protected éŒ¾ }
  public
    constructor	Create(AOwner:TComponent); override;
    destructor	Destroy; override;
    procedure Load;
    //procedure save;

    function GetCharaName(index: Integer):String;
    procedure CharaNameToCompBox(Var cb:TComboBox);
    property IsLoad : Boolean read FIsLoad;
    property Target : Integer read FTarget write SetFTarget;
    property Path : String read GetFPath write SetFPath;
    property CharaName[index:Integer] : String read GetCharaName;

    property Num:Byte read GetNum write SetNum;
    property Kind:Byte read GetKind write SetKind;
    property Status:Byte read GetStatus write SetStatus;
    property Level :Integer read GetLevel write SetLevel;
    property EP : LongWord read GetEP write SetEP;
    property HP : Integer read GetHP write SetHP;
    property HPMAX : Integer read GetHPMAX write SetHPMAX;
    property AGE : Integer read GetAGE write SetAGE;
    property WEEK : Integer read GetWEEK write SetWEEK;
    property GOLD : LongWord read GetGOLD write SetGOLD;
    property AC : Integer read GetAC write SetAC;
    property MARK : LongWord read GetMARK write SetMARK;
    property RIP : Integer read GetRIP write SetRIP;
    property STR : Integer read GetSTR write SetSTR;
    property IQ : Integer read GetIQ write SetIQ;
    property PIE : Integer read GetPIE write SetPIE;
    property VIT : Integer read GetVIT write SetVIT;
    property AGI : Integer read GetAGI write SetAGI;
    property LUK : Integer read GetLUK write SetLUK;
    property Honor : Word read GetHonor write SetHonor;


  published
  { Published éŒ¾ }

	End;

procedure MakeItemCmpBox(num:Integer; Var cb:TComboBox);
function WizNameToStr(name:TWizname):String;
function ToWizKind(r:Integer;a:Integer;c:Integer):Byte;
function WizKindToRace(b:Byte):Integer;
function WizKindToAlign(b:Byte):Integer;
function WizKindToClass(b:Byte):Integer;
procedure MakeKindCmpBox(b:Byte; Var cbA,cbC,cbR:TComboBox);
function WizValueToLongword(const v:TWizValue):LongWord;
function LongwordToWizValue(const l:Longword):TWizValue;
function ByteRev(b:Byte):Byte;
implementation
//*************************************************************
{$INCLUDE WizGBCSub.pas}
function ByteRev(b:Byte):Byte;
Begin
  Result
  := ((b and 1) shl 7) or
      ((b and 2) shl 5) or
      ((b and 4) shl 3) or
      ((b and 8) shl 1) or
      ((b and 10) shr 1) or
      ((b and 20) shr 3) or
      ((b and 40) shr 5) or
      ((b and 80) shr 7);
End;
//*************************************************************
//*************************************************************
// TWizStateData
//*************************************************************
//*************************************************************
constructor TWizStateData.Create(AOwner: TComponent);
begin
  inherited;
  FPath:='';
  FTarget:=-1;
  FBuf:=TMemoryStream.Create;
  FillChar(FData, SizeOf(FData), $0);

end;
//------------------------------------------------------------
destructor TWizStateData.Destroy;
begin
  FBuf.Free;
  inherited;
end;
//*************************************************************
//*************************************************************
function TWizStateData.GetFPath: String;
begin
  if FBuf.Size>=StateFileSize Then
    Result:=FPath
  Else
    Result:='';
end;
//------------------------------------------------------------
procedure TWizStateData.SetFPath(const Value: String);
begin
  FPath:=Value;
  Load;
end;
//------------------------------------------------------------
procedure TWizStateData.SetFTarget(const Value: Integer);
begin
  if (Value<0)or(value>19) Then
    FTarget:=-1
  Else
    FTarget := Value;
end;
//*************************************************************
//*************************************************************
function TWizStateData.GetNum: Byte;
begin
  Result:=0;
  if (FTarget<0)or(FTarget>19) Then Exit;
  Result:=FData[FTarget].Num;
end;
//------------------------------------------------------------
procedure TWizStateData.SetNum(const Value: Byte);
begin
  if (FTarget<0)or(FTarget>19) Then Exit;
  FData[FTarget].Num:=Value;
end;
//------------------------------------------------------------
function TWizStateData.GetKind: Byte;
begin
  Result:=0;
  if (FTarget<0)or(FTarget>19) Then Exit;
  Result:=FData[FTarget].Kind;
end;
//------------------------------------------------------------
procedure TWizStateData.SetKind(const Value: Byte);
begin
  if (FTarget<0)or(FTarget>19) Then Exit;
  FData[FTarget].Kind:=Value;
end;
//------------------------------------------------------------
function TWizStateData.GetStatus: Byte;
begin
  Result:=0;
  if (FTarget<0)or(FTarget>19) Then Exit;
  Result:=FData[FTarget].Status;
end;
//------------------------------------------------------------
procedure TWizStateData.SetStatus(const Value: Byte);
begin
  if (FTarget<0)or(FTarget>19) Then Exit;
  FData[FTarget].Status:=Value;
end;
//------------------------------------------------------------
function TWizStateData.GetLevel: Integer;
begin
  Result:=0;
  if (FTarget<0)or(FTarget>19) Then Exit;
  Result:=Integer(FData[FTarget].LV);
end;
//------------------------------------------------------------
procedure TWizStateData.SetLevel(const Value: Integer);
Var
  w :Word;
begin
  if (FTarget<0)or(FTarget>19) Then Exit;
  if Value<1 Then w:=0
  Else w:=Word(Value);

  FData[FTarget].LV:=w;
end;
//------------------------------------------------------------
function TWizStateData.GetAC: Integer;
begin
  Result:=0;
  if (FTarget<0)or(FTarget>19) Then Exit;
  Result:=Integer(FData[FTarget].AC);
end;
//------------------------------------------------------------
procedure TWizStateData.SetAC(const Value: Integer);
begin
  if (FTarget<0)or(FTarget>19) Then Exit;

  FData[FTarget].LV:=ShortInt(Value);

end;
//------------------------------------------------------------
function TWizStateData.GetAGE: Integer;
begin
  Result:=0;
  if (FTarget<0)or(FTarget>19) Then Exit;
  Result:=Integer(FData[FTarget].Age);
end;
//------------------------------------------------------------
procedure TWizStateData.SetAGE(const Value: Integer);
begin
  if (FTarget<0)or(FTarget>19) Then Exit;

  FData[FTarget].Age:=ShortInt(Value);
end;
//------------------------------------------------------------
function TWizStateData.GetEP: LongWord;
begin
  Result:=0;
  if (FTarget<0)or(FTarget>19) Then Exit;
  Result:=WizValueToLongword(FData[FTarget].Exp);

end;
//------------------------------------------------------------
procedure TWizStateData.SetEP(const Value: LongWord);
begin
  if (FTarget<0)or(FTarget>19) Then Exit;
  FData[FTarget].Exp:=LongwordToWizValue(Value);
end;
//------------------------------------------------------------
function TWizStateData.GetGOLD: LongWord;
begin
  Result:=0;
  if (FTarget<0)or(FTarget>19) Then Exit;
  Result:=WizValueToLongword(FData[FTarget].GOLD);
end;
//------------------------------------------------------------
procedure TWizStateData.SetGOLD(const Value: LongWord);
begin
  if (FTarget<0)or(FTarget>19) Then Exit;
  FData[FTarget].GOLD:=LongwordToWizValue(Value);

end;
//------------------------------------------------------------
function TWizStateData.GetHP: Integer;
begin
  Result:=0;
  if (FTarget<0)or(FTarget>19) Then Exit;
  Result:=Integer(FData[FTarget].HP);
end;
//------------------------------------------------------------
procedure TWizStateData.SetHP(const Value: Integer);
begin
  if (FTarget<0)or(FTarget>19) Then Exit;
  FData[FTarget].HP:=Word(Value);
end;
//------------------------------------------------------------
function TWizStateData.GetHPMAX: Integer;
begin
  Result:=0;
  if (FTarget<0)or(FTarget>19) Then Exit;
  Result:=Integer(FData[FTarget].HPMAX);
end;
//------------------------------------------------------------
procedure TWizStateData.SetHPMAX(const Value: Integer);
begin
  if (FTarget<0)or(FTarget>19) Then Exit;
  FData[FTarget].HPMAX:=Word(Value);
end;
//------------------------------------------------------------
function TWizStateData.GetMARK: LongWord;
begin
  Result:=0;
  if (FTarget<0)or(FTarget>19) Then Exit;
  Result:=WizValueToLongword(FData[FTarget].MARKS);
end;
//------------------------------------------------------------
procedure TWizStateData.SetMARK(const Value: LongWord);
begin
  if (FTarget<0)or(FTarget>19) Then Exit;
  FData[FTarget].MARKS:=LongwordToWizValue(Value);
end;
//------------------------------------------------------------
function TWizStateData.GetRIP: Integer;
begin
  Result:=0;
  if (FTarget<0)or(FTarget>19) Then Exit;
  Result:=Integer(FData[FTarget].RIP);
end;
//------------------------------------------------------------
procedure TWizStateData.SetRIP(const Value: Integer);
begin
  if (FTarget<0)or(FTarget>19) Then Exit;
  FData[FTarget].RIP:=Byte(Value);
end;
//------------------------------------------------------------
function TWizStateData.GetWEEK: Integer;
begin
  Result:=0;
  if (FTarget<0)or(FTarget>19) Then Exit;
  Result:=Integer(FData[FTarget].Week);
end;
//------------------------------------------------------------
procedure TWizStateData.SetWEEK(const Value: Integer);
Var
  i : Integer;
begin
  if (FTarget<0)or(FTarget>19) Then Exit;
  i:=Value;
  if i<0 Then i:=0
  Else if i>51 Then i:=51;
  FData[FTarget].Week:=Byte(i);

end;
//------------------------------------------------------------
function TWizStateData.GetAGI: Integer;
begin
  Result:=0;
  if (FTarget<0)or(FTarget>19) Then Exit;
  Result:=Integer(FData[FTarget].AGI);
end;
//------------------------------------------------------------
procedure TWizStateData.SetAGI(const Value: Integer);
begin
  if (FTarget<0)or(FTarget>19) Then Exit;
  FData[FTarget].AGI:=Byte(Value);
end;
//------------------------------------------------------------
function TWizStateData.GetIQ: Integer;
begin
  Result:=0;
  if (FTarget<0)or(FTarget>19) Then Exit;
  Result:=Integer(FData[FTarget].IQ);
end;
//------------------------------------------------------------
procedure TWizStateData.SetIQ(const Value: Integer);
begin
  if (FTarget<0)or(FTarget>19) Then Exit;
  FData[FTarget].IQ:=Byte(Value);
end;
//------------------------------------------------------------
function TWizStateData.GetLUK: Integer;
begin
  Result:=0;
  if (FTarget<0)or(FTarget>19) Then Exit;
  Result:=Integer(FData[FTarget].LUK);
end;
//------------------------------------------------------------
procedure TWizStateData.SetLUK(const Value: Integer);
begin
  if (FTarget<0)or(FTarget>19) Then Exit;
  FData[FTarget].LUK:=Byte(Value);
end;
//------------------------------------------------------------
function TWizStateData.GetVIT: Integer;
begin
  Result:=0;
  if (FTarget<0)or(FTarget>19) Then Exit;
  Result:=Integer(FData[FTarget].VIT);
end;
//------------------------------------------------------------
procedure TWizStateData.SetVIT(const Value: Integer);
begin
  if (FTarget<0)or(FTarget>19) Then Exit;
  FData[FTarget].VIT:=Byte(Value);
end;
//------------------------------------------------------------
function TWizStateData.GetSTR: Integer;
begin
  Result:=0;
  if (FTarget<0)or(FTarget>19) Then Exit;
  Result:=Integer(FData[FTarget].STR);
end;
//------------------------------------------------------------
procedure TWizStateData.SetSTR(const Value: Integer);
begin
  if (FTarget<0)or(FTarget>19) Then Exit;
  FData[FTarget].STR:=Byte(Value);
end;
//------------------------------------------------------------
function TWizStateData.GetPIE: Integer;
begin
  Result:=0;
  if (FTarget<0)or(FTarget>19) Then Exit;
  Result:=Integer(FData[FTarget].PIE);
end;
//------------------------------------------------------------
procedure TWizStateData.SetPIE(const Value: Integer);
begin
  if (FTarget<0)or(FTarget>19) Then Exit;
  FData[FTarget].PIE:=Byte(Value);
end;
//------------------------------------------------------------
function TWizStateData.GetHonor: Word;
begin
  Result:=0;
  if (FTarget<0)or(FTarget>19) Then Exit;
  Result:=FData[FTarget].Honor;
end;
//------------------------------------------------------------
procedure TWizStateData.SetHonor(const Value: Word);
begin
  if (FTarget<0)or(FTarget>19) Then Exit;
  FData[FTarget].Honor:=Value;
end;

//*************************************************************
//*************************************************************
procedure TWizStateData.CharaNameToCompBox(var cb: TComboBox);
Var
  i : Integer;
  s : String;
begin
  if Assigned(cb)=False Then Exit;
  cb.Clear;
  for i:=Low(FData) to High(FData) do Begin
    s:=GetCharaName(i);
    if s='' Then s:='(none)';
    s:=IntToHex(i,2)+' '+s;
    cb.Items.Append(s);
  End;


end;
//*************************************************************
//*************************************************************
procedure TWizStateData.BufToData;
Var
  bp : Int64;
begin
  FIsLoad:=False;
  if FPath='' Then Exit;
  if FBuf.Size<StateFileSize Then Exit;
  bp:=FBuf.Position;
  FBuf.Position:=WizCharDataOffset;

  FBuf.Read(FData,SizeOf(FData));

  FBuf.Position:=bp;
  FIsLoad:=True;
end;

//------------------------------------------------------------
procedure TWizStateData.DataToBuf;
Var
  bp : Int64;
begin
  if FIsLoad=False Then Exit;
  bp:=FBuf.Position;
  FBuf.Position:=WizCharDataOffset;

  FBuf.Write(FData,SizeOf(FData));

  FBuf.Position:=bp;

end;
//------------------------------------------------------------
//------------------------------------------------------------
function TWizStateData.GetCharaName(index: Integer): String;
begin
  Result:='';
  if FIsLoad=False Then Exit;
  Result:=WizNameToStr(FData[index].Name);

end;
//------------------------------------------------------------
//------------------------------------------------------------
procedure TWizStateData.Load;
  function ChkBuf:Boolean;
  Var
    pc: PChar;
  Begin
    Result:=False;
    if FBuf.Size<StateFileSize Then Begin Exit;
    End;
    pc:=FBuf.Memory;
    if Integer(pc^)<>3 Then Exit;
    inc(pc,WizCharDataOffset);
    if (Integer(pc^)<>1)and(Integer(pc^)<>2)and(Integer(pc^)<>3) Then Exit;
     Result:=True;
  End;
begin
  if FileExists(FPath)=False Then Begin
    FPath:='';
    Exit;
  End;

  FillChar(FData, SizeOf(FData), $0);
  FBuf.Clear;
  FBuf.LoadFromFile(FPath);
  if ChkBuf=true Then Begin
    BufToData;
    FTarget:=0;
  End Else Begin
    FillChar(FData, SizeOf(FData), $0);
    FBuf.Clear;
  End;
end;
//------------------------------------------------------------
//------------------------------------------------------------

















end.
