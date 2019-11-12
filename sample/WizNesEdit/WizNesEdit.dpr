program WizNesEdit;

{%File 'wiz1.txt'}

uses
  Forms,
  Main in 'Main.pas' {Form1},
  WizSave in 'WizSave.pas',
  Wiz1Const in 'Wiz1Const.pas',
  Wiz2Const in 'Wiz2Const.pas',
  WizSaveSub in 'WizSaveSub.pas',
  Wiz3Const in 'Wiz3Const.pas';

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
