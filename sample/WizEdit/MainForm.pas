unit MainForm;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs,WizGBC, StdCtrls, Buttons, ComCtrls, Menus, ExtCtrls, Grids,
  CheckLst, ByteBit;

type
  TForm1 = class(TForm)
    MainMenu1: TMainMenu;
    FileMenu: TMenuItem;
    Filepen: TMenuItem;
    FileSave: TMenuItem;
    FileQuit: TMenuItem;
    gbItem: TGroupBox;
    ComboBox13: TComboBox;
    cmbItem8: TComboBox;
    cmbItem7: TComboBox;
    cmbItem6: TComboBox;
    cmbItem5: TComboBox;
    cmbItem4: TComboBox;
    cmbItem3: TComboBox;
    cmbItem2: TComboBox;
    cmbItem1: TComboBox;
    CheckBox1: TCheckBox;
    CheckBox4: TCheckBox;
    CheckBox7: TCheckBox;
    CheckBox10: TCheckBox;
    CheckBox15: TCheckBox;
    CheckBox16: TCheckBox;
    CheckBox17: TCheckBox;
    CheckBox13: TCheckBox;
    CheckBox14: TCheckBox;
    CheckBox18: TCheckBox;
    CheckBox19: TCheckBox;
    CheckBox20: TCheckBox;
    CheckBox11: TCheckBox;
    CheckBox8: TCheckBox;
    CheckBox5: TCheckBox;
    CheckBox2: TCheckBox;
    CheckBox3: TCheckBox;
    CheckBox6: TCheckBox;
    CheckBox9: TCheckBox;
    CheckBox12: TCheckBox;
    CheckBox21: TCheckBox;
    CheckBox22: TCheckBox;
    CheckBox23: TCheckBox;
    CheckBox24: TCheckBox;
    gbSpell: TGroupBox;
    gbStatus: TGroupBox;
    edSTR: TLabeledEdit;
    edIQ: TLabeledEdit;
    edPIE: TLabeledEdit;
    edVIT: TLabeledEdit;
    edAGI: TLabeledEdit;
    edLUK: TLabeledEdit;
    cmbRace: TComboBox;
    cmbAlign: TComboBox;
    cmbClass: TComboBox;
    cmbStatus: TComboBox;
    edLevel: TLabeledEdit;
    edHP: TLabeledEdit;
    edHPMAX: TLabeledEdit;
    edGOLD: TLabeledEdit;
    edEP: TLabeledEdit;
    edMARK: TLabeledEdit;
    edRIP: TLabeledEdit;
    cmbCharaName: TComboBox;
    gbShop: TGroupBox;
    ListBox1: TListBox;
    Edit1: TEdit;
    CheckListBox1: TCheckListBox;
    gbMageSpell: TGroupBox;
    LabeledEdit14: TLabeledEdit;
    Edit2: TEdit;
    LabeledEdit15: TLabeledEdit;
    Edit3: TEdit;
    LabeledEdit16: TLabeledEdit;
    Edit4: TEdit;
    LabeledEdit17: TLabeledEdit;
    Edit5: TEdit;
    LabeledEdit18: TLabeledEdit;
    Edit6: TEdit;
    LabeledEdit19: TLabeledEdit;
    Edit7: TEdit;
    LabeledEdit20: TLabeledEdit;
    Edit8: TEdit;
    LabeledEdit21: TLabeledEdit;
    Edit9: TEdit;
    Edit10: TEdit;
    LabeledEdit22: TLabeledEdit;
    GroupBox2: TGroupBox;
    LabeledEdit23: TLabeledEdit;
    Edit11: TEdit;
    LabeledEdit24: TLabeledEdit;
    Edit12: TEdit;
    LabeledEdit25: TLabeledEdit;
    Edit13: TEdit;
    LabeledEdit26: TLabeledEdit;
    Edit14: TEdit;
    LabeledEdit27: TLabeledEdit;
    Edit15: TEdit;
    LabeledEdit28: TLabeledEdit;
    Edit16: TEdit;
    LabeledEdit29: TLabeledEdit;
    Edit17: TEdit;
    LabeledEdit30: TLabeledEdit;
    Edit18: TEdit;
    Edit19: TEdit;
    LabeledEdit31: TLabeledEdit;
    Label1: TLabel;
    edAC: TLabeledEdit;
    edAGE: TLabeledEdit;
    edWeek: TLabeledEdit;
    ComboBox1: TComboBox;
    Memo1: TMemo;
    Button1: TButton;
    SaveDialog1: TSaveDialog;
    OpenDialog1: TOpenDialog;
    Button2: TButton;
    cmbNum: TComboBox;
    bbHor1: TByteBit;
    bbHor2: TByteBit;
    procedure Button1Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure FormDestroy(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure cmbCharaNameChange(Sender: TObject);
  private
    { Private êÈåæ }
    FWizData : TWizStateData;
  public
    { Public êÈåæ }
    procedure Load(path:String);
    procedure FromWizData;
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

//******************************************************************************
//******************************************************************************
procedure TForm1.FormCreate(Sender: TObject);
begin
  FWizData:=TWizStateData.Create(Self);

end;

//******************************************************************************
procedure TForm1.FormDestroy(Sender: TObject);
begin
  FWizData.Free;
end;
//******************************************************************************
procedure TForm1.Load(path: String);
begin
  FWizData.Path:=path;
  FWizData.Load;
  FWizData.CharaNameToCompBox(cmbCharaName);

end;

//******************************************************************************
procedure TForm1.Button1Click(Sender: TObject);
begin
  MakeItemCmpBox(1,cmbItem1);
  MakeItemCmpBox(2,cmbItem2);
  MakeItemCmpBox(3,cmbItem3);
end;
//******************************************************************************
procedure TForm1.FromWizData;
Var
  b : Byte;
begin
  cmbNum.ItemIndex :=FWizData.Num;

  b:=FWizData.Kind;
  MakeKindCmpBox(b,cmbAlign,cmbClass,cmbRace);
  cmbStatus.ItemIndex :=FWizData.Status;
  edLevel.Text := IntToStr(FWizData.Level);
  edEP.Text := IntToStr(FWizData.EP);
  edHP.Text := IntToStr(FWizData.HP);
  edHPMAX.Text := IntToStr(FWizData.HPMAX);
  edAGE.Text:=IntToStr(FWizData.AGE);
  edWeek.Text:=IntToStr(FWizData.WEEK);
  edSTR.Text:=IntToStr(FWizData.STR);
  edIQ.Text:=IntToStr(FWizData.IQ);
  edPIE.Text:=IntToStr(FWizData.PIE);
  edVIT.Text:=IntToStr(FWizData.VIT);
  edAGI.Text:=IntToStr(FWizData.AGE);
  edLUK.Text:=IntToStr(FWizData.LUK);
  edGOLD.Text := IntToStr(FWizData.GOLD);
  edAC.Text:=IntToStr(FWizData.AC);
  edMARK.Text:=IntToStr(FWizData.MARK);
  edRIP.Text:=IntToStr(FWizData.RIP);

  bbHor1.Value:=ByteRev(Byte( FWizData.Honor and $FF));
  bbHor2.Value:=ByteRev(Byte( (FWizData.Honor shr 8) and $FF));

end;


//******************************************************************************
procedure TForm1.Button2Click(Sender: TObject);
begin
  if OpenDialog1.Execute Then Load(OpenDialog1.FileName);
end;
//******************************************************************************

procedure TForm1.cmbCharaNameChange(Sender: TObject);
begin
  FWizData.Target:=cmbCharaName.ItemIndex;
  FromWizData;
end;

end.
