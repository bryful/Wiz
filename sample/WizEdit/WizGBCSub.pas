procedure MakeItemCmpBox(num:Integer; Var cb:TComboBox);
var
  i : Integer;
Begin
  if Assigned(cb)=False Then Exit;
  cb.Clear;
  case num of

      1: for i:=Low(Wiz1ItemName) to High(Wiz1ItemName) do
          cb.Items.Append(IntToHex(i,2)+' '+Wiz1ItemName[i]);
      2: for i:=Low(Wiz2ItemName) to High(Wiz2ItemName) do
          cb.Items.Append(IntToHex(i,2)+' '+Wiz2ItemName[i]);
      3: for i:=Low(Wiz3ItemName) to High(Wiz3ItemName) do
          cb.Items.Append(IntToHex(i,2)+' '+Wiz3ItemName[i]);
  End;
  cb.ItemIndex:=0;
End;
//------------------------------------------------------------
function WizNameToStr(name:TWizname):String;
Var
  i : Integer;
  s : String;
Begin
  Result:='';
  if Integer(name[0])<=0 Then Exit;
  s:='';
  for i:=1 to Integer(name[0]) do Begin
    s:=s+MojiTbl[name[i]];
  End;
  result:=s;
End;
//------------------------------------------------------------
function ToWizKind(r:Integer;a:Integer;c:Integer):Byte;
Begin
  Result:= (r and $3) or ((a and $3) shl 2) or ((c and $3) shl 5);
End;
//------------------------------------------------------------
function WizKindToRace(b:Byte):Integer;
Begin
  Result:= Integer((b shr 5) and $7);
End;
//------------------------------------------------------------
function WizKindToAlign(b:Byte):Integer;
Begin
  Result:= Integer(b and $3);
End;
//------------------------------------------------------------
function WizKindToClass(b:Byte):Integer;
Begin
  Result:= Integer((b shr 2) and $7);
End;
//------------------------------------------------------------
procedure MakeKindCmpBox(b:Byte; Var cbA,cbC,cbR:TComboBox);
Begin
  if Assigned(cbA)=True Then cbA.ItemIndex:=WizKindToAlign(b);
  if Assigned(cbC)=True Then cbC.ItemIndex:=WizKindToClass(b);
  if Assigned(cbR)=True Then cbR.ItemIndex:=WizKindToRace(b);
End;
//------------------------------------------------------------
function WizValueToLongword(const v:TWizValue):LongWord;
Var
  theV : TWizValue;
  theL : LongWord;
  i,p: Integer;
begin
  theV:=v;
  theL:=0;
  p:=1;
  for i:=5 downto 0 do Begin
    theL:=theL+LongWord(theV[i]*p);
    p:=p*100;
  End;
  Result:=theL;
End;
//------------------------------------------------------------
function LongwordToWizValue(const l:Longword):TWizValue;
Var
  theV : TWizValue;
  theL : LongWord;
  i : Integer;
begin
  theL:=l;
  for i:=5 downto 0 do Begin
    theV[i]:= theL mod 100;
    theL:=theL div 100;
  end;
  Result:=theV;
end;
//------------------------------------------------------------

