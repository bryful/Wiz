
�� Wizardry I(FC)�p�̃p�b�`�ł�

�� �����̕ύX

[����]
0x01: ��(��/��)
0x02: ��
0x04: ��
0x08: ��
0x10: �z
0x20: ��
0x40: ����(���g�p?)
0x80: ??(���g�p?)

[�ύX]
010F8B : 10 -> 08 (�w�r�̃��C�X)
01108B : 04 -> 02 (�ق̂��̂�)
01170B : 30 -> 18 (����肯��)
01174B : 04 -> 02 (������̂����肩���т�)
0118CB : FE -> 7F (���[�h�i�̂܂悯)

01FAFC : 10 -> 08 (�őϐ�)
01FB25 : 02 -> 01 (��ბϐ�)
01FB5A : 40 -> 20 (�Ή��ϐ�)
01FB86 : 20 -> 10 (�z���ϐ�)
01FC4A : 02 -> 01 (��ϐ�)

�� �{�ŏC��

BD91 : AE 7C 02		ldx	$027C		;
BD94 : AC 7D 02		ldy	$027D		;
BD97 : B9 B4 7B		lda	$7BB4,y		; ��Ԉُ�
BD9A : D0 13		bne	$BDAF		;
;
BD9C : AC 43 7E		ldy	$7E43		; �����X�^�[�^�C�v
BD9F : BD B8 7D		lda	$7DB8,x		; �{�ŉ���
BDA2 : 39 18 DE		and	$DE18,y		;
BDA5 : D0 08		bne	$BDAF		;
;
BDA7 : BD B2 7D		lda	$7DB2,x		; �{�ŏ��
BDAA : 39 28 DE		and	$DE28,y		;
BDAD : F0 04		beq	$BDB3		;
;
BDAF : 06 6D		asl	$6D		;
BDB1 : 26 6E		rol	$6E		;
;
BDB3 : 86 06		stx	$06		; $06 = $027C

�� �Ō��h��C��

DDF5 : B9 DC 7A		lda	$7ADC,y		; ������
DDF8 : 85 00		sta	$00		;
DDFA : B9 D6 7A		lda	$7AD6,y		; �t�]
DDFD : AC 43 7E		ldy	$7E43		;
DE00 : 39 28 DE		and	$DE28,y		;
DE03 : D0 07		bne	$DE0C		;
;
DE05 : A5 00		lda	$00		;
DE07 : 39 18 DE		and	$DE18,y		;
DE0A : F0 06		beq	$DE12		;
DE0C : 20 A1 C2		jsr	$C2A1		;
DE0F : 4A		lsr	a		;
DE10 : 90 D5		bcc	$DDE7		
;
DE12 : A9 6A		lda	#$6A		; �Ō�
DE14 : 9D B0 7C		sta	$7CB0,x		;
DE17 : 60		rts			;

�� ��㩉���

EB90 : A0 23		ldy	#$23		;
EB92 : B1 2E		lda	($2E),y		;
EB94 : D0 45		bne	$EBDB		; LV256�ȏ�Ő���
;
EB96 : C8		iny			;
EB97 : B1 2E		lda	($2E),y		;
EB99 : C9 53		cmp	#$53		;
EB9B : B0 3E		bcs	$EBDB		; LV83�ȏ�Ő��� (SFC�łƓ���)
;
EB9D : E9 06		sbc	#$06		; -= 7
EB9F : 38		sec			;
EBA0 : E5 3D		sbc	$3D		; -= (�K�w)
EBA2 : 48		pha			;
EBA3 : A0 11		ldy	#$11		;
EBA5 : B1 2E		lda	($2E),y		;
EBA7 : 85 0E		sta	$0E		; $0E: AGL
EBA9 : A0 0B		ldy	#$0B		;
EBAB : B1 2E		lda	($2E),y		;
EBAD : 29 03		and	#$03		;
EBAF : A8		tay			;
EBB0 : 68		pla			;
EBB1 : 18		clc			;
EBB2 : 79 BF FF		adc	$FFBF,y		;
EBB5 : 85 0F		sta	$0F		;
EBB7 : 30 0B		bmi	$EBC4		; ���Ŏ��s
;
EBB9 : A9 46		lda	#$46		;
EBBB : 20 DA CD		jsr	$CDDA		;
EBBE : C5 0F		cmp	$0F		;
EBC0 : 90 19		bcc	$EBDB		;
EBC2 : EA		nop			;
EBC3 : EA		nop			;

(�ǉ���4�o�C�g�g�p) 

FFBF : 00 00 00 32      db $00,$00,$00,$32

�� �G����p�[�e�B�ւ̑Ō��̖�����

F9D5 : AC 7D 02		ldy	$027D		;
F9D8 : 20 BD CF		jsr	$CFBD		;
F9DB : A0 13		ldy	#$13		;
F9DD : AE 7C 02		ldx	$027C		;
F9E0 : BD B0 7C		lda	$7CB0,x		;
F9E3 : D0 02		bne	$F9E7		;
F9E5 : A0 15		ldy	#$15		; "�݂��܂���" �ŉ��+10%
;
F9E7 : 98		tya			;
F9E8 : 38		sec			;
F9E9 : FD D0 7D		sbc	$7DD0,x		; (�L�����N�^�[��AC)
F9EC : 38		sec			;
F9ED : ED 81 02		sbc	$0281		; (�}�|�[�t�B�b�N�L��)
F9F0 : 38		sec			;
F9F1 : ED 48 7E		sbc	$7E48		; (�G��LV)
F9F4 : 85 0F		sta	$0F		;
F9F6 : 38		sec			;
F9F7 : FD 2E 7D		sbc	$7D2E,x		; (�⏕���@)
F9FA : 10 0A		bpl	$FA06		;
F9FC : C9 DC		cmp	#$DC		; (�ȉ��I���W�i���ʂ�)
F9FE : B0 0E		bcs	$FA0E		;
FA00 : A5 0F		lda	$0F		;
FA02 : 30 0A		bmi	$FA0E		;
FA04 : 10 04		bpl	$FA0A		;
;
FA06 : C9 13		cmp	#$13		;
FA08 : 90 06		bcc	$FA10		;
;
FA0A : A9 13		lda	#$13		;
FA0C : 10 02		bpl	$FA10		; (bra)
;
FA0E : A9 00		lda	#$00		;
;
FA10 : 85 6B		sta	$6B		;
FA12 : E6 6B		inc	$6B		;
