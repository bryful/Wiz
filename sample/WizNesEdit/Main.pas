unit Main;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ComCtrls
  ,WizSave
  ,WizSaveSub
  ,Wiz1Const
  ,Wiz2Const
  ,Wiz3Const, Menus, ExtCtrls, Buttons, Grids
  ;

type
  TForm1 = class(TForm)
    MainMenu1: TMainMenu;
    File1: TMenuItem;
    FileOpenWiz1: TMenuItem;
    FileOpenWiz2: TMenuItem;
    FileOpenWiz3: TMenuItem;
    FileReload: TMenuItem;
    FileQuit: TMenuItem;
    FileSave: TMenuItem;
    FileSaveAs: TMenuItem;
    N1: TMenuItem;
    N2: TMenuItem;
    N3: TMenuItem;
    OpenDialog1: TOpenDialog;
    SaveDialog1: TSaveDialog;
    Label20: TLabel;
    PageControl2: TPageControl;
    TabSheet4: TTabSheet;
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Label4: TLabel;
    edLevel: TLabeledEdit;
    cmbRace: TComboBox;
    cmbJob: TComboBox;
    cmbAttr: TComboBox;
    cmbStatus: TComboBox;
    edStrength: TLabeledEdit;
    edIQ: TLabeledEdit;
    edPiety: TLabeledEdit;
    edVitarity: TLabeledEdit;
    edAgility: TLabeledEdit;
    edLuck: TLabeledEdit;
    edEXP: TLabeledEdit;
    cbPoison: TCheckBox;
    edAge: TLabeledEdit;
    edAC: TLabeledEdit;
    edGold: TLabeledEdit;
    TabSheet5: TTabSheet;
    Label5: TLabel;
    Label7: TLabel;
    Label8: TLabel;
    Label9: TLabel;
    Label10: TLabel;
    Label11: TLabel;
    Label6: TLabel;
    edMP1: TEdit;
    edMPMax1: TEdit;
    edMPMax3: TEdit;
    edMP3: TEdit;
    edMPMax4: TEdit;
    edMP4: TEdit;
    edMPMax5: TEdit;
    edMP5: TEdit;
    edMPMax6: TEdit;
    edMP6: TEdit;
    edMPMax7: TEdit;
    edMP7: TEdit;
    cbM1_0: TCheckBox;
    cbM1_1: TCheckBox;
    cbM1_2: TCheckBox;
    cbM1_3: TCheckBox;
    cbM1_4: TCheckBox;
    cbM1_5: TCheckBox;
    cbM1_6: TCheckBox;
    cbM1_7: TCheckBox;
    cbM3_0: TCheckBox;
    cbM3_4: TCheckBox;
    cbM3_1: TCheckBox;
    cbM3_5: TCheckBox;
    cbM3_2: TCheckBox;
    cbM3_6: TCheckBox;
    cbM3_3: TCheckBox;
    cbM3_7: TCheckBox;
    cbM4_0: TCheckBox;
    cbM4_4: TCheckBox;
    cbM4_1: TCheckBox;
    cbM4_5: TCheckBox;
    cbM4_2: TCheckBox;
    cbM4_6: TCheckBox;
    cbM4_3: TCheckBox;
    cbM4_7: TCheckBox;
    cbM5_0: TCheckBox;
    cbM5_4: TCheckBox;
    cbM5_1: TCheckBox;
    cbM5_5: TCheckBox;
    cbM5_2: TCheckBox;
    cbM5_6: TCheckBox;
    cbM5_3: TCheckBox;
    cbM5_7: TCheckBox;
    cbM6_0: TCheckBox;
    cbM6_4: TCheckBox;
    cbM6_1: TCheckBox;
    cbM6_5: TCheckBox;
    cbM6_2: TCheckBox;
    cbM6_6: TCheckBox;
    cbM6_3: TCheckBox;
    cbM6_7: TCheckBox;
    cbM7_0: TCheckBox;
    cbM7_4: TCheckBox;
    cbM7_1: TCheckBox;
    cbM7_5: TCheckBox;
    cbM7_2: TCheckBox;
    cbM7_6: TCheckBox;
    cbM7_3: TCheckBox;
    cbM7_7: TCheckBox;
    edMP2: TEdit;
    edMPMax2: TEdit;
    cbM2_0: TCheckBox;
    cbM2_4: TCheckBox;
    cbM2_1: TCheckBox;
    cbM2_5: TCheckBox;
    cbM2_2: TCheckBox;
    cbM2_6: TCheckBox;
    cbM2_3: TCheckBox;
    cbM2_7: TCheckBox;
    TabSheet7: TTabSheet;
    Label12: TLabel;
    Label13: TLabel;
    Label14: TLabel;
    Label15: TLabel;
    Label16: TLabel;
    Label17: TLabel;
    Label18: TLabel;
    edPP7: TEdit;
    edPP6: TEdit;
    edPP5: TEdit;
    edPP4: TEdit;
    edPP3: TEdit;
    edPP2: TEdit;
    edPP1: TEdit;
    edPPMax1: TEdit;
    edPPMax2: TEdit;
    edPPMax3: TEdit;
    edPPMax4: TEdit;
    edPPMax5: TEdit;
    edPPMax6: TEdit;
    edPPMax7: TEdit;
    CheckBox1: TCheckBox;
    CheckBox2: TCheckBox;
    CheckBox3: TCheckBox;
    CheckBox4: TCheckBox;
    CheckBox5: TCheckBox;
    CheckBox6: TCheckBox;
    CheckBox7: TCheckBox;
    CheckBox8: TCheckBox;
    CheckBox9: TCheckBox;
    CheckBox10: TCheckBox;
    CheckBox11: TCheckBox;
    CheckBox12: TCheckBox;
    CheckBox13: TCheckBox;
    CheckBox14: TCheckBox;
    CheckBox15: TCheckBox;
    CheckBox16: TCheckBox;
    CheckBox17: TCheckBox;
    CheckBox18: TCheckBox;
    CheckBox19: TCheckBox;
    CheckBox20: TCheckBox;
    CheckBox21: TCheckBox;
    CheckBox22: TCheckBox;
    CheckBox23: TCheckBox;
    CheckBox24: TCheckBox;
    CheckBox25: TCheckBox;
    CheckBox26: TCheckBox;
    CheckBox27: TCheckBox;
    CheckBox28: TCheckBox;
    CheckBox29: TCheckBox;
    CheckBox30: TCheckBox;
    CheckBox31: TCheckBox;
    CheckBox32: TCheckBox;
    CheckBox33: TCheckBox;
    CheckBox34: TCheckBox;
    CheckBox35: TCheckBox;
    CheckBox36: TCheckBox;
    CheckBox37: TCheckBox;
    CheckBox38: TCheckBox;
    CheckBox39: TCheckBox;
    CheckBox40: TCheckBox;
    CheckBox41: TCheckBox;
    CheckBox42: TCheckBox;
    CheckBox43: TCheckBox;
    CheckBox44: TCheckBox;
    CheckBox45: TCheckBox;
    CheckBox46: TCheckBox;
    CheckBox47: TCheckBox;
    CheckBox48: TCheckBox;
    CheckBox49: TCheckBox;
    CheckBox50: TCheckBox;
    CheckBox51: TCheckBox;
    CheckBox52: TCheckBox;
    CheckBox53: TCheckBox;
    CheckBox54: TCheckBox;
    CheckBox55: TCheckBox;
    CheckBox56: TCheckBox;
    TabSheet6: TTabSheet;
    Label21: TLabel;
    cmbItem0: TComboBox;
    cmbItem1: TComboBox;
    cmbItem2: TComboBox;
    cmbItem3: TComboBox;
    cmbItem4: TComboBox;
    cmbItem5: TComboBox;
    cmbItem6: TComboBox;
    cmbItem7: TComboBox;
    cbEquip0: TCheckBox;
    cbEquip1: TCheckBox;
    cbEquip2: TCheckBox;
    cbEquip3: TCheckBox;
    cbEquip4: TCheckBox;
    cbEquip5: TCheckBox;
    cbEquip6: TCheckBox;
    cbEquip7: TCheckBox;
    cbCurse0: TCheckBox;
    cbCurse1: TCheckBox;
    cbCurse2: TCheckBox;
    cbCurse3: TCheckBox;
    cbCurse4: TCheckBox;
    cbCurse5: TCheckBox;
    cbCurse6: TCheckBox;
    cbCurse7: TCheckBox;
    cbUnknown0: TCheckBox;
    cbUnknown1: TCheckBox;
    cbUnknown2: TCheckBox;
    cbUnknown3: TCheckBox;
    cbUnknown4: TCheckBox;
    cbUnknown5: TCheckBox;
    cbUnknown6: TCheckBox;
    cbUnknown7: TCheckBox;
    cmbItemCount: TComboBox;
    Label19: TLabel;
    CharaList: TListBox;
    btnUp: TBitBtn;
    btnDown: TBitBtn;
    edHP: TLabeledEdit;
    edHPmax: TLabeledEdit;
    TabSheet1: TTabSheet;
    StringGrid1: TStringGrid;
    procedure FileOpenWiz2Click(Sender: TObject);
    procedure FileOpenWiz1Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure FormDestroy(Sender: TObject);
    procedure FileOpenWiz3Click(Sender: TObject);
    procedure CharaListClick(Sender: TObject);
    procedure FileReloadClick(Sender: TObject);
    procedure FileSaveClick(Sender: TObject);
    procedure FileSaveAsClick(Sender: TObject);
    procedure cmbItemCountChange(Sender: TObject);
  private
    { Private 宣言 }
    sv :TWizSaveFile;
  public
    { Public 宣言 }
    procedure Setup(Num:Integer);
    procedure ItemCountChk;
    procedure SvFrom;
    procedure ToSv;
    procedure ListupName;
    procedure ToDump;
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

//***************************************************************
//
//***************************************************************
procedure TForm1.FormCreate(Sender: TObject);
Var
	i : Integer;
begin
	//
  sv:=TWizSaveFile.Create;
  ItemCountChk;
  for i:=0 to $F do Begin
  	StringGrid1.Cells[i+1,0]:='+'+IntToHex(i,1);
  End;
  for i:=0 to $F do Begin
  	StringGrid1.Cells[0,i+1]:=IntToHex(i*$10,4);
  End;
end;
//---------------------------------------------------------------
procedure TForm1.FormDestroy(Sender: TObject);
begin
	sv.Free;
end;
//***************************************************************
//
//***************************************************************
procedure TForm1.FileOpenWiz1Click(Sender: TObject);
begin
	OpenDialog1.Title:='Wizardry1のStateFileを開く';
  OpenDialog1.FileName:='wiz1.ss0';
  if OpenDialog1.Execute Then Begin
  	if sv.load(OpenDialog1.FileName,1) Then Begin
      Setup(1);
      ListupName;
    	SvFrom;
    End Else Begin
      Setup(0);
    End;
  End;
end;
//---------------------------------------------------------------
procedure TForm1.FileOpenWiz2Click(Sender: TObject);
begin
	OpenDialog1.Title:='Wizardry2のStateFileを開く';
  OpenDialog1.FileName:='wiz2.ss0';
  if OpenDialog1.Execute Then Begin
  	if sv.load(OpenDialog1.FileName,2) Then Begin
      Setup(2);
      ListupName;
    	SvFrom;
    End Else Begin
      Setup(0);
    End;
  End;
end;
//---------------------------------------------------------------
procedure TForm1.FileOpenWiz3Click(Sender: TObject);
begin
	OpenDialog1.Title:='Wizardry3のStateFileを開く';
  OpenDialog1.FileName:='wiz3.ss0';
  if OpenDialog1.Execute Then Begin
  	if sv.load(OpenDialog1.FileName,3) Then Begin
      Setup(3);
      ListupName;
    	SvFrom;
    End Else Begin
      Setup(0);
    End;
  End;
end;
//---------------------------------------------------------------
procedure TForm1.FileReloadClick(Sender: TObject);
begin
	if sv.reload Then Begin
      Setup(1);
      ListupName;
    	SvFrom;
    End Else Begin
      Setup(0);
    End;
end;
//---------------------------------------------------------------
procedure TForm1.FileSaveClick(Sender: TObject);
begin
  ToSv;
	sv.Save;
end;
//---------------------------------------------------------------
procedure TForm1.FileSaveAsClick(Sender: TObject);
begin
  if sv.LoadFlag=False Then Exit;
  case sv.Num of
  	1:SaveDialog1.Title:='Wizardry1のStateFileを保存';
    2:SaveDialog1.Title:='Wizardry2のStateFileを保存';
    3:SaveDialog1.Title:='Wizardry3のStateFileを保存';
  End;

  SaveDialog1.FileName:=sv.FrzFilename;
  if SaveDialog1.Execute Then Begin
	  ToSv;
  	if sv.saveAs(SaveDialog1.FileName) Then Begin
    End;
  End;
end;
//***************************************************************
//
//***************************************************************
procedure TForm1.CharaListClick(Sender: TObject);
begin
	if (sv.CharaNum-1)<>CharaList.ItemIndex Then Begin
    ToSv;
  	sv.CharaNum:=CharaList.ItemIndex+1;
    SvFrom;
  End;
end;
//***************************************************************
//
//***************************************************************
procedure TForm1.cmbItemCountChange(Sender: TObject);
begin
	ItemCountChk;
end;
//***************************************************************
//アイテムリストとかの準備
//***************************************************************
procedure TForm1.Setup(Num:Integer);
Var
	i : Integer;
begin
  //アイテムの準備
	cmbItem0.Clear;
	cmbItem1.Clear;
	cmbItem2.Clear;
	cmbItem3.Clear;
	cmbItem4.Clear;
	cmbItem5.Clear;
	cmbItem6.Clear;
	cmbItem7.Clear;

  case Num of
    0:Begin
    	//何もしない
    End;
  	1:
    Begin
    	for i:=Low(Wiz1ItemName) to High(Wiz1ItemName) do Begin
				cmbItem0.Items.Append(Wiz1ItemName[i]);
				cmbItem1.Items.Append(Wiz1ItemName[i]);
				cmbItem2.Items.Append(Wiz1ItemName[i]);
				cmbItem3.Items.Append(Wiz1ItemName[i]);
				cmbItem4.Items.Append(Wiz1ItemName[i]);
				cmbItem5.Items.Append(Wiz1ItemName[i]);
				cmbItem6.Items.Append(Wiz1ItemName[i]);
				cmbItem7.Items.Append(Wiz1ItemName[i]);
      End;
    End;
    2:Begin
    	for i:=Low(Wiz2ItemName) to High(Wiz2ItemName) do Begin
				cmbItem0.Items.Append(Wiz2ItemName[i]);
				cmbItem1.Items.Append(Wiz2ItemName[i]);
				cmbItem2.Items.Append(Wiz2ItemName[i]);
				cmbItem3.Items.Append(Wiz2ItemName[i]);
				cmbItem4.Items.Append(Wiz2ItemName[i]);
				cmbItem5.Items.Append(Wiz2ItemName[i]);
				cmbItem6.Items.Append(Wiz2ItemName[i]);
				cmbItem7.Items.Append(Wiz2ItemName[i]);
      End;
    End;
    3:
    Begin
    	for i:=Low(Wiz3ItemName) to High(Wiz3ItemName) do Begin
				cmbItem0.Items.Append(Wiz3ItemName[i]);
				cmbItem1.Items.Append(Wiz3ItemName[i]);
				cmbItem2.Items.Append(Wiz3ItemName[i]);
				cmbItem3.Items.Append(Wiz3ItemName[i]);
				cmbItem4.Items.Append(Wiz3ItemName[i]);
				cmbItem5.Items.Append(Wiz3ItemName[i]);
				cmbItem6.Items.Append(Wiz3ItemName[i]);
				cmbItem7.Items.Append(Wiz3ItemName[i]);
      End;
    End;
  End;

  ItemCountChk;
end;
//***************************************************************
//
//***************************************************************
procedure TForm1.SvFrom;
Var
	i : Integer;
  cp : TComponent;
  wi : TWizItem;
begin
  cmbRace.ItemIndex		:=sv.Race;
  cmbJob.ItemIndex		:=sv.Job;
  cmbAttr.ItemIndex		:=sv.Attr;
	cmbStatus.ItemIndex	:=sv.Status;


	edStrength.Text			:=IntToStr(sv.Strength);
	edIQ.Text						:=IntToStr(sv.IQ);
	edPiety.Text				:=IntToStr(sv.Piety);
  edVitarity.Text     :=IntToStr(sv.Vitarity);
  edAgility.Text     	:=IntToStr(sv.Agility);
  edLuck.Text					:=IntToStr(sv.Luck);
  edAge.Text		     	:=IntToStr(sv.Age);
  edAC.Text           :=IntToStr(sv.AC);
  edLevel.Text				:=IntToStr(sv.Level);
  edEXP.Text					:=IntToStr(sv.Exp);
  edGold.Text					:=IntToStr(sv.Gold);
  cbPoison.Checked		:=sv.Poison;
  edHP.Text						:=IntToStr(sv.HP);
  edHPmax.Text				:=IntToStr(sv.HPMax);

  cmbItemCount.ItemIndex:=sv.ItemCount;


  ItemCountChk;

  for i:=0 to 7 do Begin
    wi:=sv.Item[i];
  	cp:=FindComponent('cmbItem'+IntToStr(i));
    if cp is TComboBox then TComboBox(cp).ItemIndex:=wi.Num;
  	cp:=FindComponent('cbEquip'+IntToStr(i));
    if cp is TCheckBox then TCheckBox(cp).Checked:=wi.Equip;
  	cp:=FindComponent('cbCurse'+IntToStr(i));
    if cp is TCheckBox then TCheckBox(cp).Checked:=wi.Curse;
  	cp:=FindComponent('cbUnknown'+IntToStr(i));
    if cp is TCheckBox then TCheckBox(cp).Checked:=wi.Unknown;
  End;

  ToDump;
end;
//***************************************************************
//
//***************************************************************
procedure TForm1.ToSv;
Var
	i : Integer;
  cp : TComponent;
  wi : TWizItem;
begin
  sv.Race					:=cmbRace.ItemIndex;
  sv.Job					:=cmbJob.ItemIndex;
  sv.Attr					:=cmbAttr.ItemIndex;
	sv.Status				:=cmbStatus.ItemIndex;

	sv.Strength			:=StrToIntDef(edStrength.Text,0);
	sv.IQ						:=StrToIntDef(edIQ.Text,0);
	sv.Piety				:=StrToIntDef(edPiety.Text,0);
  sv.Vitarity			:=StrToIntDef(edVitarity.Text,0);
  sv.Agility			:=StrToIntDef(edAgility.Text,0);
  sv.Luck					:=StrToIntDef(edLuck.Text,0);
  sv.Age					:=StrToIntDef(edAge.Text,0);
  sv.AC						:=StrToIntDef(edAC.Text,0);
  sv.Level				:=StrToIntDef(edLevel.Text,0);
  sv.Exp					:=StrToIntDef(edEXP.Text,0);
  sv.Gold					:=StrToIntDef(edGold.Text,0);
  sv.Poison				:=cbPoison.Checked;
  sv.HP						:=StrToIntDef(edHP.Text,0);
  sv.HPMax				:=StrToIntDef(edHPmax.Text,0);
  sv.ItemCount		:=cmbItemCount.ItemIndex;
  for i:=0 to 7 do Begin
  	cp:=FindComponent('cmbItem'+IntToStr(i));
    if cp is TComboBox then wi.Num:=TComboBox(cp).ItemIndex;;
  	cp:=FindComponent('cbEquip'+IntToStr(i));
    if cp is TCheckBox then wi.Equip:=TCheckBox(cp).Checked;
  	cp:=FindComponent('cbCurse'+IntToStr(i));
    if cp is TCheckBox then wi.Curse:=TCheckBox(cp).Checked;
  	cp:=FindComponent('cbUnknown'+IntToStr(i));
    if cp is TCheckBox then wi.Unknown:=TCheckBox(cp).Checked;
    sv.Item[i]:=wi;
  End;

end;
//***************************************************************
//
//***************************************************************
procedure TForm1.ListupName;
Var
	i,ii : Integer;
begin
	CharaList.Clear;
  if sv.LoadFlag=False Then Exit;
  ii:=CharaList.ItemIndex;
  if ii<0 Then ii:=0;
  for i:=1 to wiz_chara_count do
  	CharaList.Items.Append(sv.Name[i]);
  for i:=CharaList.Count-1 downto 0 do Begin

  	if CharaList.Items[i]='(なし)' Then
    	CharaList.Items.Delete(i)
    Else
    	Break;
  End;
  if CharaList.Count>0 Then Begin
  	if ii>(CharaList.Count-1) Then ii:=CharaList.Count-1;
    CharaList.ItemIndex:=ii;
    sv.CharaNum:=ii+1;
  End;
end;
//***************************************************************
//
//***************************************************************
procedure TForm1.ItemCountChk;
Var
	i : Integer;
  cp : TComponent;
begin
  for i:=0 to 7 do Begin
    cp:=FindComponent('cmbItem'+IntToStr(i));
    if cp is TComboBox Then Begin
    	TComboBox(cp).Enabled:=False;
    ENd;
    cp:=FindComponent('cbEquip'+IntToStr(i));
    if cp is TCheckBox Then Begin
    	TCheckBox(cp).Enabled:=False;
    End;
    cp:=FindComponent('cbCurse'+IntToStr(i));
    if cp is TCheckBox Then Begin
    	TCheckBox(cp).Enabled:=False;
    End;
    cp:=FindComponent('cbUnknown'+IntToStr(i));
    if cp is TCheckBox Then Begin
    	TCheckBox(cp).Enabled:=False;
    End;
	End;

  if sv.LoadFlag=False Then Begin
    cmbItemCount.ItemIndex:=0;
    cmbItemCount.Enabled:=False;
  	Exit;
  End Else if cmbItemCount.ItemIndex<=0 Then begin
  	Exit;
  End;
  for i:=0 to cmbItemCount.ItemIndex-1 do Begin
    cp:=FindComponent('cmbItem'+IntToStr(i));
    if cp is TComboBox Then TComboBox(cp).Enabled:=True;
    cp:=FindComponent('cbEquip'+IntToStr(i));
    if cp is TCheckBox Then TCheckBox(cp).Enabled:=True;
    cp:=FindComponent('cbCurse'+IntToStr(i));
    if cp is TCheckBox Then TCheckBox(cp).Enabled:=True;
    cp:=FindComponent('cbUnknown'+IntToStr(i));
    if cp is TCheckBox Then TCheckBox(cp).Enabled:=True;
	End;
  cmbItemCount.Enabled:=True;


end;
//***************************************************************
//
//***************************************************************




procedure TForm1.ToDump;
Var
	i,j,x,y : Integer;
begin
  //取りあえず
  StringGrid1.Visible:=False;
  for j:=1 to $10 do
	  for i:=1 to $10 do StringGrid1.Cells[i,j]:='';
	if sv.LoadFlag=False Then Begin
	  StringGrid1.Visible:=True;
  	Exit;
  End;
  case sv.Num of
  	1: Begin
    	y:=(Wiz1CharaDataSize div $10) div 2;
      StringGrid1.RowCount:=y+1;
    End;
    2: Begin
    	y:=Wiz2CharaDataSize div $10;
      StringGrid1.RowCount:=y+1;
    End;
    3: Begin
    	y:=Wiz3CharaDataSize div $10;
      StringGrid1.RowCount:=y+1;
    End;
  End;

  for j:=0 to y-1 do Begin
    StringGrid1.Cells[0,j+1]:=IntToHex(j*$10,4);
	  for i:=0 to $F do Begin
    	StringGrid1.Cells[i+1,j+1]:=IntToHex(sv.CharaData[i+j*$10],2);
    End;
  End;

	  StringGrid1.Visible:=True;


end;

end.
