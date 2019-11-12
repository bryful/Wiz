program WizGBCEdit;

uses
  Forms,
  MainForm in 'MainForm.pas' {Form1},
  WizGBC in 'WizGBC.pas';

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
