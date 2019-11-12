unit WizSavchkMain;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs
  ,IniFiles
  ,WizSaveSub
  ,Wiz1Const
  ,Wiz2Const
  ,Wiz3Const, StdCtrls, Buttons, Grids, ExtCtrls
  ;
type
  TWizSavChkForm = class(TForm)
    sgData: TStringGrid;
    btnLoad: TBitBtn;
    OpenDialog1: TOpenDialog;
    edChecksum: TLabeledEdit;
    edCalc: TLabeledEdit;
    edChecksum2: TLabeledEdit;
    Button2: TButton;
    Edit1: TEdit;
    procedure btnLoadClick(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure FormDestroy(Sender: TObject);
    procedure btnAddClick(Sender: TObject);
    procedure btnXorClick(Sender: TObject);
    procedure btnAdd2byteClick(Sender: TObject);
    procedure btnXor2ByteClick(Sender: TObject);
    procedure btncrc1Click(Sender: TObject);
    procedure btnAdd2Click(Sender: TObject);
    procedure BitBtn1Click(Sender: TObject);
    procedure BitBtn2Click(Sender: TObject);
    procedure BitBtn3Click(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
  private
    { Private 宣言 }
    SavData : array[0..$2000-1] of Byte;
    SavePath : String;
  public
    { Public 宣言 }
    procedure SavDataInit;
    procedure load(const path:String);
    procedure SavDataToSG1;
    function ShowByte(const inB:Byte):String;
    function SwapByte(const inB:Byte):Byte;
    function RevByte(const inB:Byte):Byte;
  end;

var
  WizSavChkForm: TWizSavChkForm;

implementation

{$R *.dfm}

{ TWizSavChkForm }

procedure TWizSavChkForm.SavDataInit;
begin
  FillChar(SavData,Sizeof(SavData),$00);
end;

procedure TWizSavChkForm.load(const path: String);
Var
	FS :TFileStream;
begin
  SavDataInit;
	if FileExists(path)=False Then Exit;
  FS:=TFileStream.Create(path,fmOpenRead);
  FS.ReadBuffer(SavData,Sizeof(SavData));
  FS.Free;
  SavePath:=path;

end;

procedure TWizSavChkForm.SavDataToSG1;
Var
	i,j : Integer;
begin
  //Savデータキャラクタ一人目をDUMP表示
	for j:=0 to $07 do
    	sgData.Cells[0,j+1]:=IntToHex(j*$10,4);
	for j:=0 to $10 do
    	sgData.Cells[j+1,0]:='+'+IntToHex(j,2);

	for j:=0 to $07 do Begin
		for i:=0 to $0F do Begin
    	sgData.Cells[i+1,j+1]:=IntToHex(SavData[j*$10+i],2);
    End;
  End;
  //
  edChecksum.Text:=ShowByte(SavData[$7E])+'/'+ShowByte(SavData[$7F]);
  edChecksum2.Text:=ShowByte(SavData[$7E] xor $FF)+'/'+ShowByte(SavData[$7F] xor $FF);

end;

procedure TWizSavChkForm.btnLoadClick(Sender: TObject);
begin
	if OpenDialog1.Execute then Begin
  	load(OpenDialog1.FileName);
    SavDataToSG1;
  End;
end;

function TWizSavChkForm.ShowByte(const inB: Byte): String;
Var
  b    : String;
  i : Integer;
  theB : Byte;
begin
  b:='';
  theB:=inB;
  for i:=0 to 7 do Begin
  	if (theB and 1)=1 Then
    	b:='1'+b
    Else
    	b:='0'+b;
    theB := theB shr 1;
  End;

  result:='$'+IntToHex(inB,2)+'['+b+']';
end;

procedure TWizSavChkForm.FormCreate(Sender: TObject);
Var
	ini : TIniFile;
  p : String;
begin
	ini:=TIniFile.Create(ChangeFileExt(Application.ExeName,'.ini'));
  p:=ini.ReadString('Wiz','path','');
  ini.Free;
  if FileExists(p)=True Then Begin
  	SavDataInit;
    load(p);
    SavDataToSG1;
  End;
end;

procedure TWizSavChkForm.FormDestroy(Sender: TObject);
Var
	ini : TIniFile;
begin
	ini:=TIniFile.Create(ChangeFileExt(Application.ExeName,'.ini'));
  ini.WriteString('Wiz','path',SavePath);
  ini.Free;

end;

procedure TWizSavChkForm.btnAddClick(Sender: TObject);
Var
	i,v : Integer;
  b0,b1 : Byte;
begin
  v:=0;
	for i:=0 to ($7D div 2) do Begin
  	v:=v + ( (SavData[i+1] shl 1)and(SavData[i]) );
    if v>$10000 Then v:=v-$10000;
  End;
  b0:=(v shr 8)and $FF;
  b1:=v and $FF;

  edCalc.Text:=ShowByte(b0)+'/'+ShowByte(b1);

end;

procedure TWizSavChkForm.btnXorClick(Sender: TObject);
Var
	i,v : Integer;
  b0,b1 : Byte;
begin
  v:=0;
	for i:=0 to $7D do Begin
  	v:=v xor SavData[i];
  End;
  b0:=(v shr 8)and $FF;
  b1:=v and $FF;

  edCalc.Text:=ShowByte(b0)+'/'+ShowByte(b1);

end;

procedure TWizSavChkForm.btnAdd2byteClick(Sender: TObject);
Var
	i,v : Integer;
  b0,b1 : Byte;
begin
  v:=0;
	for i:=0 to ($7D div 2)do Begin
  	v:=v+(SavData[i]*$100+SavData[i+1]);
  End;
  b0:=(v shr 8)and $FF;
  b1:=v and $FF;

  edCalc.Text:=ShowByte(b0)+'/'+ShowByte(b1);

end;

procedure TWizSavChkForm.btnXor2ByteClick(Sender: TObject);
Var
	i,v : Integer;
  b0,b1 : Byte;
begin
  v:=0;
	for i:=0 to ($7D div 2)do Begin
  	v:=v xor (SavData[i]+SavData[i+1]*$100);
  End;
  b0:=(v shr 8)and $FF;
  b1:=v and $FF;

  edCalc.Text:=ShowByte(b0)+'/'+ShowByte(b1);

end;

procedure TWizSavChkForm.btncrc1Click(Sender: TObject);
Var
	i,v : Integer;
  b0,b1 : Byte;
begin
  v:=0;
	for i:=0 to $7D do Begin
  	if (i mod 2)=1 Then
  		v:=v+SavData[i]
    Else
  		v:=v+SavData[i]*$100;
    if v>=65535 Then	v:=v-65536;
  End;
  b0:=v div $100;
  b1:=v mod $100;

  edCalc.Text:=ShowByte(b0)+'/'+ShowByte(b1);

end;

function TWizSavChkForm.SwapByte(const inB: Byte): Byte;
begin
	Result:=(inB shr 4)or(inB shl 4);
end;

procedure TWizSavChkForm.btnAdd2Click(Sender: TObject);
Var
	i,v : Integer;
  b0,b1 : Byte;
begin
  v:=0;
	for i:=0 to $7D do Begin
  	v:=(v+swapbyte(SavData[i]) xor $FF);
    //if v>=65535 Then	v:=v-65536;

  End;
  b0:=v div $100;
  b1:=v mod $100;

  edCalc.Text:=ShowByte(b0)+'/'+ShowByte(b1);

end;

procedure TWizSavChkForm.BitBtn1Click(Sender: TObject);
Var
	i,v : Integer;
  b0,b1 : Byte;
begin
  v:=0;
	for i:=0 to $7D do Begin
  	v:=v-(SavData[i]);
  End;
  b0:=(v shr 8)and $FF;
  b1:=v and $FF;

  edCalc.Text:=ShowByte(b0)+'/'+ShowByte(b1);

end;

procedure TWizSavChkForm.BitBtn2Click(Sender: TObject);
Var
	i,v : Integer;
  b0,b1,v1,v2 : Byte;
begin
	b0:=0;
	for i:=0 to ($6F div 2) do Begin
  	v:=v Xor ( (SavData[i*2])or(SavData[i*2+1]*$100) );
  End;
  b0:=v;
  edCalc.Text:=ShowByte(b0)+','+ShowByte(b0 Xor $FF)

end;

function TWizSavChkForm.RevByte(const inB: Byte): Byte;
Var
	i: Integer;
  b0,b1 : Byte;
begin
  b0:=0;
  b1:=0;
	for i:=0 to 7 do Begin
  	if ((inB shr i) and 1)=1 Then
    	b0:= b0 or( $80 shr i);
  End;
  Result:=b0;
end;

procedure TWizSavChkForm.BitBtn3Click(Sender: TObject);
Var
	i,v : Integer;
  b0,b1 : ShortInt;
begin
  v:=0;
	for i:=0 to $7D do Begin
  	v:=v-Integer(SavData[i] Xor $FF);
  End;
  
  b0:=(v shr 8)and $FF;
  b1:=v and $FF;

  edCalc.Text:=ShowByte(b0)+'/'+ShowByte(b1);

end;

procedure TWizSavChkForm.Button1Click(Sender: TObject);
begin
	ShowMessage(IntToHex(RevByte($01),2));
end;

procedure TWizSavChkForm.Button2Click(Sender: TObject);
Var
	i : Integer;
  v : Integer;
  t : array[0..13] of Byte;
  s : String;
begin
  for i:=0 to 12 do t[i]:=8;
	for i:=0 to 7 do begin
  	t[0]:=t[0]+savData[i];
  	t[1]:=t[1]+savData[i+$08];
  	t[2]:=t[2]+savData[i+$10];
  	t[3]:=t[3]+savData[i+$18];
  	t[4]:=t[4]+savData[i+$20];
  	t[5]:=t[5]+savData[i+$28];
  	t[6]:=t[6]+savData[i+$30];
  	t[7]:=t[7]+savData[i+$38];
  	t[8]:=t[8]+savData[i+$40];
  	t[9]:=t[9]+savData[i+$48];
  	t[9]:=t[9]+savData[i+$50];
  	t[10]:=t[10]+savData[i+$58];
  	t[11]:=t[11]+savData[i+$60];
  	t[12]:=t[12]+savData[i+$68];
  End;
  s:='';
  for i:=0 to 12 do s:=s+IntToHex(t[i],2)+'/';
  Edit1.Text:=s;
  v:=0;
  for i:=0 to $6F do begin
  	v:=v - (savData[i]+8);
  End;
  edCalc.Text:=IntToHex(v,4);
end;

end.
