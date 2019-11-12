unit Wiz3Const;

interface
Uses
	Wiz2Const;

Const
{	//�푰
	Wiz3Human	=	$00;	// �l��
	Wiz3Elf		=	$20;	// �G���t
	Wiz3Dwarf	=	$40;	// �h���[�t
	Wiz3Gnome	=	$60;	// �m�[��
	Wiz3Hobit	=	$80;	// �z�r�b�g
  //�E��
	Wiz3Fighter	= $00;	//����
	Wiz3Mage		= $04;	//�܂ق�����
	Wiz3Priest	= $08;	//�������
	Wiz3Thief		= $0C;	//�V�[�t
	Wiz3Bishop	= $10;	//�r�V���b�v
	Wiz3Sumrai	= $14;	//�T�����C
	Wiz3Lord		= $18;	//���[�h
	Wiz3Ninja		= $1C;	//�j���W��
  //����
	Wiz3Good		=00;	// �f
	Wiz3Neutral	=01;	// �m
	Wiz3Evil		=02;	// �d
	Wiz3Etc			=03;	// �H (�H�͂ǂ̑����Ƃ��g�߂邪�A�S�Ă̑���������邵�A�]�E���ł��Ȃ��B�����H)
}
	//�푰
	Wiz3Human	=	Wiz2Human;	// �l��
	Wiz3Elf		=	Wiz2Elf;	// �G���t
	Wiz3Dwarf	=	Wiz2Dwarf;	// �h���[�t
	Wiz3Gnome	=	Wiz2Gnome;	// �m�[��
	Wiz3Hobit	=	Wiz2Hobit;	// �z�r�b�g
  //�E��
	Wiz3Fighter	= Wiz2Fighter;	//����
	Wiz3Mage		= Wiz2Mage;	//�܂ق�����
	Wiz3Priest	= Wiz2Priest;	//�������
	Wiz3Thief		= Wiz2Thief;	//�V�[�t
	Wiz3Bishop	= Wiz2Bishop;	//�r�V���b�v
	Wiz3Sumrai	= Wiz2Sumrai;	//�T�����C
	Wiz3Lord		= Wiz2Lord;	//���[�h
	Wiz3Ninja		= Wiz2Ninja;	//�j���W��
  //����
	Wiz3Good		=Wiz2Good;	// �f
	Wiz3Neutral	=Wiz2Neutral;	// �m
	Wiz3Evil		=Wiz2Evil;	// �d
	Wiz3Etc			=Wiz2Etc;	// �H (�H�͂ǂ̑����Ƃ��g�߂邪�A�S�Ă̑���������邵�A�]�E���ł��Ȃ��B�����H)

	Wiz3ItemName : array[00..$89] of String =(
	'00:�K���N�^',
	'01:�邬',
	'02:���񂯂�',
	'03:���C�X',
	'04:�t���C��',
	'05:��',
	'06:����Ƃ�',
	'07:�o�b�N���[',
	'08:����',
	'09:���[�u',
	'0A:�����낢',
	'0B:�����肩���т�',
	'0C:�ނ˂���',
	'0D:��낢',
	'0E:���Ԃ�',
	'0F:����������',
	'10:�ǂ�����',
	'11:���肳���̂���',
	'12:����ǂ����񂯂�',
	'13:�ӂ񂳂��̃��C�X',
	'14:�Ă̂�',
	'15:�˂ނ�̂܂�����',
	'16:�����������낢',
	'17:�Ђ��邭���肩���т�',
	'18:�܂��炨�̂�낢',
	'19:�Ă̂���',
	'1A:�ǂ���낢',
	'1B:�����݂̂܂�����',
	'1C:�ق̂��̂܂�����',
	'1D:����͂̂邬',
	'1E:����߂̂��񂯂�',
	'1F:�킴�킢�̃��C�X',
	'20:��������',
	'21:�h���S���X���C���[',
	'22:�ɂ񂽂��̂��Ԃ�',
	'23:�������������낢',
	'24:���т������肩���т�',
	'25:�ꂫ����̂ނ˂���',
	'26:�䂪�񂾂���',
	'27:�ق������̂�т�',
	'28:���邵�݂̂܂�����',
	'29:���ނ肾��',
	'2A:�܂��Ղ��̂���',
	'2B:�������傤�̂��񂯂�',
	'2C:������̃��C�X',
	'2D:�݂��т��̂܂�����',
	'2E:�߂���܂��̂܂�����',
	'2F:�ǂ��̂���',
	'30:�������Ȃ����낢',
	'31:�G���t�̂����肩���т�',
	'32:�������傤�̂�낢',
	'33:�������̂���',
	'34:�����̂��Ԃ�',
	'35:�Ƃ������₭',
	'36:�܂���̂�т�',
	'37:���[�X���C���[',
	'38:���C�W�}�b�V���[',
	'39:�w�r�̃��C�X',
	'3A:��������̂�',
	'3C:�J�V�i�[�g�̂邬',
	'3B:���܂��߂̂�т�',
	'3D:�ق̂��̂�',
	'3E:�����̂����肩���т�',
	'3F:���イ��̂�낢',
	'40:�����̂���',
	'41:���������̂�т�',
	'42:�Ă񂢂̂��Ԃ�',
	'43:���������̂܂�����',
	'44:�͂߂̂��񂯂�',
	'45:���肳���̂���Ƃ�',
	'46:��߂郁�C�X',
	'47:�˂��ꂽ��',
	'48:�͂�킴�̂���Ƃ�',
	'49:�̂��ꂽ���[�u',
	'4A:�͂߂̂����낢',
	'4B:�̂낢�̂����肩���т�',
	'4C:�����܂̂ނ˂���',
	'4D:����̂���',
	'4E:�ӂ�т����Ԃ�',
	'4F:���ڂ��̂ނ˂���',
	'50:����̂���',
	'51:�����̃T�[�x��',
	'52:�\�E���X���C���[',
	'53:�Ƃ������̂���Ƃ�',
	'54:�����䂤�̂�낢',
	'55:�����Ȃ��낢',
	'56:�ނ�܂�',
	'57:����肯��',
	'58:������̂����肩���т�',
	'59:�����̂�낢',
	'5A:�܂���̂���',
	'5B:�����ӂ��̂�т�',
	'5C:�͂���̂�т�',
	'5D:���̂�т�',
	'5E:�ӂ����̂�',
	'5F:���ɂ����̂��܂���',
	'60:�݂��킵�̃��[�u',
	'61:�ĂԂ���',
	'62:�܂ӂ����̃l�b�N���X',
	'63:�Ђ���̂�',
	'64:�G�N�X�J���o�[',
	'65:�Ђ�߂��̂邬',
	'66:�v���[�X�g�p���`���[',
	'67:�������̃��C�X',
	'68:�Ђ�߂��̂��񂯂�',
	'69:�ق̂��̂�т�',
	'6A:�̂��ꂽ��낢',
	'6B:�~�X�����̂�낢',
	'6C:���₵�̂�',
	'6D:���̂��̂�т�',
	'6E:�ւ񂰂̂�т�',
	'6F:�ӂ����Ȃ���',
	'70:���ڂ��̂���',
	'71:����҂Ă��Ȃ���',
	'72:�������Ȃ�܂ق��̂�',
	'73:������̃R�C��',
	'74:�킩������̂���',
	'75:������̂���',
	'76:���񂶂�̂���',
	'77:�u���[�j�B�̂���',
	'78:���キ���̂܂悯',
	'79:���キ���̂܂悯�i�g�p��j',
	'7A:�������Ȃ�܂ق��̂��i�g�p��j',
	'7B:������̃R�C���i�g�p��j',
	'7C:�j���_�̂�',
	'7D:�n�[�X�j�[��',
	'7E:�ł񂹂̂��Ԃ�',
	'7F:�ł񂹂̂���',
	'80:�ł񂹂̂���',
	'81:�ł񂹂̂�낢',
	'82:���т�����',
	'83:���܂݂�̃o�b�W',
	'84:���݂傤�Ȃ��񂵂傤',
	'85:��������̂���',
	'86:���イ�ǂ�����̂���',
	'87:�~�X�����̂���',
	'88:�}�X�^�[�L�[',
	'89:�����܂̂���'
	);

  Wiz3OffsetAdress	= $1D52;

  Wiz3CharaDataSize	= Wiz2CharaDataSize;

	Wiz3Alive					= Wiz2Alive;
  Wiz3NameCount			= Wiz2NameCount;
  Wiz3Name					= Wiz2Name;
	  Wiz3NameLength		= Wiz2NameLength;
  Wiz3Job						= Wiz2Job;
  Wiz3Strength			= Wiz2Strength;
  Wiz3IQ						= Wiz2IQ;
  Wiz3Piety					= Wiz2Piety;
  Wiz3Vitarity			= Wiz2Vitarity;
  Wiz3Agility				= Wiz2Agility;
  Wiz3Luck					= Wiz2Luck;
  Wiz3Gold					= Wiz2Gold;
	  Wiz3GoldLength		= Wiz2GoldLength;
  Wiz3Exp						= Wiz2Exp;
	  Wiz3ExpLength				= Wiz2ExpLength;
  Wiz3HP						= Wiz2HP;
  Wiz3HPmax					= Wiz2HPmax;
  	Wiz3HPLength    	=Wiz2HPLength;
  Wiz3Level					= Wiz2Level;
  	Wiz3LevelLength    	=Wiz2LevelLength;
  Wiz3Status				= Wiz2Status;
  Wiz3Age						= Wiz2Age;
  Wiz3AC						= Wiz2AC;
  Wiz3MP						= Wiz2MP;
  Wiz3PP						= Wiz2PP;
  Wiz3MSkill				= Wiz2MSkill;
  Wiz3PSkill				= Wiz2PSkill;
	  Wiz3MPlength			= Wiz2MPlength;
  Wiz3ItemEquip			= Wiz2ItemEquip;
  Wiz3Item					= Wiz2Item;
  Wiz3ItemCount			= Wiz2ItemCount;
	  Wiz3ItemLength		= Wiz2ItemLength;
  Wiz3Poison				= Wiz2Poison;
  Wiz3Appellaction	= Wiz2Appellaction;
  Wiz3checksum			= Wiz2checksum;
	  Wiz3checksumLength	= Wiz2checksumLength;
type
	TWiz3Chara = TWiz2Chara;
implementation

end.

