program WizSavChk;

uses
  Forms,
  WizSavchkMain in 'WizSavchkMain.pas' {WizSavChkForm},
  Wiz1Const in '..\Wiz1Const.pas',
  Wiz2Const in '..\Wiz2Const.pas',
  Wiz3Const in '..\Wiz3Const.pas',
  WizSave in '..\WizSave.pas',
  WizSaveSub in '..\WizSaveSub.pas';

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TWizSavChkForm, WizSavChkForm);
  Application.Run;
end.
