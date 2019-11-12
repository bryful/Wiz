unit WizSaveSub;

interface
uses
	SysUtils,Classes
  ,Wiz1Const
  ,Wiz2Const
  ,Wiz3Const
  ;
const
	nnnester_state_filesize = $3A18;
  wiz_chara_count	=20;
type
	TWizHex = Byte;

function WizHex2Byte(const inB:TWizHex):Byte;
function Byte2WizHex(const inB:Byte):TWizHex;
implementation
//---------------------------------------------------------------
function WizHex2Byte(const inB:TWizHex):Byte;
Var
	h,l : Byte;
Begin
  h:=inB div $10;
  l:=inB mod $10;
  if h>9 Then h:=9;
  if l>9 Then l:=9;
	Result:= h*10+l;
End;
//---------------------------------------------------------------
function Byte2WizHex(const inB:Byte):TWizHex;
Var
	h,l : Byte;
Begin
  h:=inB div 10;
  l:=inB mod 10;
  if h>9 Then h:=9;
  if l>9 Then l:=9;
	Result:= h*$10+l;
End;
//---------------------------------------------------------------
end.
